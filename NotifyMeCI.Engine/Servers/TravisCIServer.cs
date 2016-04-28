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
    public class TravisCIServer : BaseCIServer
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
            catch (Exception)
            {
                return default(IList<CIJob>);
            }
        }

        public override bool ValidateUrl(string url, string token, out string error)
        {
            error = string.Empty;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                
                request.Accept = "application/vnd.travis-ci.2+json";
                request.ContentType = "application/json";

                using (var response = request.GetResponse()) { }
                return true;
            }
            catch (Exception ex)
            {
                error = string.Format("Error connecting to Server URL provided:{0}{0}{1}", Environment.NewLine, ex.Message);
                return false;
            }
        }

        #endregion

        #region Private Helpers

        private IList<CIJob> GetJobsList(CIServer server)
        {
            var _jobsJson = GetJson(server.Url);

            // if no jobs then return
            if (_jobsJson == default(JObject))
            {
                return default(IList<CIJob>);
            }

            // get repos
            var _reposJson = (JArray)_jobsJson["repos"];
            if (_reposJson == default(JArray) || !_reposJson.Any())
            {
                return default(IList<CIJob>);
            }

            // setup basic jobs with name, url and status
            return _reposJson
                .Select(x => InitialiseJob(x, server))
                .Where(x => x != default(CIJob))
                .ToList();
        }

        private CIJob InitialiseJob(JToken projectJson, CIServer server)
        {
            if (!GetBool(projectJson["active"]))
            {
                return default(CIJob);
            }

            var _job = new CIJob();

            _job.ServerType = CIServerType.TravisCI;
            _job.ServerName = server.Name;
            _job.Name = GetString(projectJson["slug"]);

            // is the server open source, pro or enterprise?
            if (server.Url.Contains("api.travis-ci.org"))
            {
                _job.Url = string.Format("https://travis-ci.org/{0}", _job.Name);
            }
            else if (server.Url.Contains("api.travis-ci.com"))
            {
                _job.Url = string.Format("https://travis-ci.com/{0}", _job.Name);
            }
            else
            {
                _job.Url = string.Format("{0}/{1}", server.Url.Split(new[] { "/api/" }, StringSplitOptions.RemoveEmptyEntries)[0], _job.Name);
            }
            
            _job.BuildId = GetString(projectJson["last_build_number"]);
            _job.TimeStamp = GetDateTime(projectJson["last_build_started_at"]);
            _job.Duration = GetInt(projectJson["last_build_duration"]);
            _job.BuildStatus = MapBuildStatus(projectJson["last_build_state"].ToString());

            return _job;
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

        private HttpWebRequest GetRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Accept = "application/vnd.travis-ci.2+json";
            request.ContentType = "application/json";

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
                case "started":
                case "running":
                    return BuildStatusType.Building;
            }

            return BuildStatusType.Unknown;
        }

        #endregion

    }
}
