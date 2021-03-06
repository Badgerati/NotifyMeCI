﻿/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Objects;
using NotifyMeCI.Engine.Repositories.Interfaces;
using NotifyMeCI.Injector;
using System;
using System.Linq;
using System.Collections.Generic;
using NotifyMeCI.Engine.Enums;

namespace NotifyMeCI.Engine.Managers
{
    public class SettingManager
    {

        #region Repositories

        private ISettingRepository SettingRepository
        {
            get { return DIContainer.Instance.Get<ISettingRepository>(); }
        }

        private IBuildStatusRepository BuildStatusRepository
        {
            get { return DIContainer.Instance.Get<IBuildStatusRepository>(); }
        }

        #endregion

        #region Lazy

        private static Lazy<SettingManager> _lazy = new Lazy<SettingManager>(() => new SettingManager());
        public static SettingManager Instance
        {
            get { return _lazy.Value; }
        }

        #endregion

        #region Fields

        private IList<Setting> _settings = default(IList<Setting>);

        #endregion

        #region Properties

        private bool _minimize = false;
        public bool Minimize
        {
            get { return _minimize; }
            set
            {
                if (_minimize != value)
                {
                    _minimize = value;
                    Get(nameof(Minimize)).BooleanValue = value;
                    Save();
                }
            }
        }

        private bool _abortedEqualsFailed = true;
        public bool AbortedEqualsFailed
        {
            get { return _abortedEqualsFailed; }
            set
            {
                if (_abortedEqualsFailed != value)
                {
                    _abortedEqualsFailed = value;
                    Get(nameof(AbortedEqualsFailed)).BooleanValue = value;
                    Save();
                }
            }
        }

        private IDictionary<BuildStatusType, BuildStatus> _buildStatuses = new Dictionary<BuildStatusType, BuildStatus>();
        public IDictionary<BuildStatusType, BuildStatus> BuildStatuses
        {
            get { return _buildStatuses; }
            set
            {
                _buildStatuses = value;
                Save();
            }
        }

        #endregion

        #region Constructor

        private SettingManager()
        {
            Initialise();
        }

        #endregion

        #region Private Methods

        private void Initialise()
        {
            InitialiseSettings();
            InitialiseBuildStatuses();
        }

        private void InitialiseSettings()
        {
            // retrieve the settings from the repository
            _settings = SettingRepository.All();
            if (_settings == default(IList<Setting>) || !_settings.Any())
            {
                return;
            }

            // loop through all the settings, and switch on the name to determine the values to set
            foreach (var setting in _settings)
            {
                switch (setting.Name)
                {
                    case nameof(Minimize):
                        _minimize = setting.BooleanValue;
                        break;

                    case nameof(AbortedEqualsFailed):
                        _abortedEqualsFailed = setting.BooleanValue;
                        break;
                }
            }
        }

        private void InitialiseBuildStatuses()
        {
            // retrieve the build status configurations from the repository
            var buildStatuses = BuildStatusRepository.All();
            if (buildStatuses == default(IList<BuildStatus>) || !buildStatuses.Any())
            {
                return;
            }

            _buildStatuses = new Dictionary<BuildStatusType, BuildStatus>(buildStatuses.Count);
            buildStatuses.ToList().ForEach(x => _buildStatuses.Add(x.BuildStatusType, x));
        }

        #endregion

        #region Public Methods

        public Setting Get(string name)
        {
            var newSetting = new Setting() { Name = name };

            // if there are no settings, set them up with a new one
            if (_settings == default(IList<Setting>))
            {
                _settings = new List<Setting>(1) { newSetting };
                return newSetting;
            }

            // attempt to select the setting
            var setting = _settings.SingleOrDefault(x => x.Name.Equals(name));

            // if it doesn't exist, create it
            if (setting == default(Setting))
            {
                _settings.Add(newSetting);
                return newSetting;
            }

            // else it does exit, so just return it
            return setting;
        }

        public void Save()
        {
            if (_settings != default(IList<Setting>) && _settings.Any())
            {
                SettingRepository.UpdateMany(_settings);
            }

            if (_buildStatuses != default(IDictionary<BuildStatusType, BuildStatus>) && _buildStatuses.Any())
            {
                BuildStatusRepository.UpdateMany(_buildStatuses.Values.ToList());
            }
        }

        #endregion

    }
}
