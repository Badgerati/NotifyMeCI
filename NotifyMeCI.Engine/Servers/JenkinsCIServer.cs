/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotifyMeCI.Engine.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using NotifyMeCI.Engine.Enums;

namespace NotifyMeCI.Engine.Servers
{

    public class JenkinsCIServer : BaseCIServer
    {

        #region Fields

        private readonly DateTime EpochDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        #endregion

        #region Public Helpers

        public override IList<CIJob> GetJobs(CIServer server)
        {
            var _jobs = default(IList<CIJob>);

            // if not server return null
            if (server == default(CIServer))
            {
                return _jobs;
            }

            try
            {
                // get job list
                _jobs = GetInitialJobsList(server);
                if (_jobs == default(IList<CIJob>) || !_jobs.Any())
                {
                    return default(IList<CIJob>);
                }

                // update each job with full descriptions
                for (var i = 0; i < _jobs.Count; i++)
                {
                    _jobs[i] = UpdateJob(_jobs[i]);
                }

                return _jobs;
            }
            catch (Exception)
            {
                return default(IList<CIJob>);
            }
        }

        #endregion

        #region Private Helpers

        private CIJob UpdateJob(CIJob job)
        {
            if (job == default(CIJob))
            {
                return job;
            }

            // retrieve job page json
            var _jobJson = GetJson(job.Url);

            // if no job then return
            if (_jobJson == default(JObject))
            {
                return job;
            }

            // grab latest build ID
            job.BuildId = _jobJson["lastBuild"] == default(JArray) || !_jobJson["lastBuild"].Any()
                ? "0"
                : GetString(_jobJson["lastBuild"]["number"]);

            //retrieve build page json
            if (string.IsNullOrWhiteSpace(job.BuildId) || job.BuildId == "0")
            {
                job.Duration = 0;
                job.TimeStamp = DateTime.MinValue;
            }
            else
            {
                var _url = string.Format("{0}{1}", job.Url, job.BuildId);
                var _buildJson = GetJson(_url);

                // if no build then return current job setup
                if (_buildJson == default(JObject))
                {
                    return job;
                }

                // get the duration, or the estimated duration
                job.Duration = _buildJson["duration"] == default(JToken) || GetInt(_buildJson["duration"]) <= 0
                    ? GetInt(_buildJson["estimatedDuration"])
                    : GetInt(_buildJson["duration"]);

                if (job.Duration > 0)
                {
                    job.Duration = (int)(job.Duration / 1000.0);
                }

                // get the timestamp
                job.TimeStamp = EpochDate.AddMilliseconds(GetLong(_buildJson["timestamp"]));

                // update url
                job.Url = _url;
            }

            return job;
        }

        private JObject GetJson(string url)
        {
            var _request = GetRequest(url);
            var _jobsJson = default(JObject);

            using (var _response = _request.GetResponse())
            {
                using (var _stream = new StreamReader(_response.GetResponseStream()))
                {
                    using (var _reader = new JsonTextReader(_stream))
                    {
                        _jobsJson = (JObject)JToken.ReadFrom(_reader);
                    }
                }
            }

            return _jobsJson;
        }

        private IList<CIJob> GetInitialJobsList(CIServer server)
        {
            var _jobsJson = GetJson(server.Url);

            // if no jobs then return
            if (_jobsJson == default(JObject) || !((JArray)_jobsJson["jobs"]).Any())
            {
                return default(IList<CIJob>); ;
            }

            // setup basic jobs with name, url and status
            return ((JArray)_jobsJson["jobs"])
                .Select(x => new CIJob()
                {
                    ServerType = CIServerType.Jenkins,
                    ServerName = server.Name,
                    Name = x["name"].ToString(),
                    Url = x["url"].ToString(),
                    BuildStatus = MapBuildStatus(x["color"].ToString())
                })
                .ToList();
        }

        private BuildStatusType MapBuildStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return BuildStatusType.Unknown;
            }

            switch (status.ToLowerInvariant())
            {
                case "blue":
                    return BuildStatusType.Success;

                case "red":
                    return BuildStatusType.Failed;

                case "yellow":
                    return BuildStatusType.Unstable;

                case "grey":
                    return BuildStatusType.Pending;

                case "disabled":
                    return BuildStatusType.Disabled;

                case "aborted":
                    return BuildStatusType.Aborted;

                case "notbuilt":
                    return BuildStatusType.NotBuilt;
            }

            return status.ToLowerInvariant().EndsWith("anime")
                ? BuildStatusType.Building
                : BuildStatusType.Unknown;
        }

        private WebRequest GetRequest(string url)
        {
            return WebRequest.Create(string.Format("{0}/api/json", url.TrimEnd('/', '\\')));
        }
        
        #endregion

    }

}
