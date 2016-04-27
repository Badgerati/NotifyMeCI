/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotifyMeCI.Engine.Exceptions;
using NotifyMeCI.Engine.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using NotifyMeCI.Engine.Enums;

namespace NotifyMeCI.Engine.Servers
{
    public class AppVeyorCIServer : BaseCIServer
    {

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
                _jobs = GetJobsList(server);
                if (_jobs == default(IList<CIJob>) || !_jobs.Any())
                {
                    return default(IList<CIJob>);
                }

                return _jobs;
            }
            catch (Exception ex)
            {
                throw new NMCIException("Exception thrown while trying to retrieve jobs from AppVeyor", ex);
            }
        }

        #endregion

        #region Private Helpers

        private IList<CIJob> GetJobsList(CIServer server)
        {
            var _jobsJson = GetJson(server.Url, server.ApiToken);

            // if no jobs then return
            if (_jobsJson == default(JArray) || !_jobsJson.Any())
            {
                return default(IList<CIJob>); ;
            }
            
            // setup basic jobs with name, url and status
            return _jobsJson
                .Select(x => InitialiseJob(x, server))
                .ToList();
        }

        private CIJob InitialiseJob(JToken projectJson, CIServer server)
        {
            var job = new CIJob();

            job.ServerType = CIServerType.AppVeyor;
            job.ServerName = server.Name;
            job.Name = string.Format("{0} ({1})", projectJson["name"], projectJson["repositoryBranch"]);

            job.Url = string.Format("{0}/{1}/{2}", server.Url.TrimEnd('/', '\\'), projectJson["accountName"], projectJson["slug"]);
            job.Url = job.Url.Replace("api/", string.Empty);
            job.Url = job.Url.Replace("/projects/", "/project/");

            var buildsJson = (JArray)projectJson["builds"];
            if (buildsJson == default(JArray) || !buildsJson.Any())
            {
                job.BuildStatus = BuildStatusType.Unknown;
                return job;
            }

            var buildJson = buildsJson.First;
            job.BuildId = GetString(buildJson["version"]);
            job.TimeStamp = GetDateTime(buildJson["started"]);

            var finished = GetDateTime(buildJson["finished"]);
            job.Duration = finished != DateTime.MinValue
                ? (int)(finished - job.TimeStamp).TotalMilliseconds
                : 0;

            job.BuildStatus = MapBuildStatus(buildJson["status"].ToString());

            return job;
        }

        private JArray GetJson(string url, string token)
        {
            var _request = GetRequest(url, token);
            var _jobsJson = default(JArray);

            using (var _response = _request.GetResponse())
            {
                using (var _stream = new StreamReader(_response.GetResponseStream()))
                {
                    using (var _reader = new JsonTextReader(_stream))
                    {
                        _jobsJson = (JArray)JToken.ReadFrom(_reader);
                    }
                }
            }

            return _jobsJson;
        }

        private WebRequest GetRequest(string url, string token)
        {
            var request = WebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.Authorization, string.Format("Bearer {0}", token));
            return request;
        }

        private BuildStatusType MapBuildStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return BuildStatusType.Unknown;
            }

            switch (status.ToLowerInvariant())
            {
                case "success":
                case "passed":
                    return BuildStatusType.Success;

                case "failure":
                case "failed":
                    return BuildStatusType.Failed;

                case "queued":
                    return BuildStatusType.Pending;

                case "building":
                case "pending":
                case "running":
                    return BuildStatusType.Building;
            }

            return BuildStatusType.Unknown;
        }

        #endregion

    }
}
