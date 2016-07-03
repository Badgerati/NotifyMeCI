/*
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

namespace NotifyMeCI.Engine.Managers
{
    public class SettingManager
    {

        #region Repositories

        private ISettingRepository SettingRepository
        {
            get { return DIContainer.Instance.Get<ISettingRepository>(); }
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
                }
            }
        }

        private Setting Get(string name)
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

        #endregion

        #region Public Methods

        private void Save()
        {
            if (_settings == default(IList<Setting>) || !_settings.Any())
            {
                return;
            }

            SettingRepository.UpdateMany(_settings);
        }

        #endregion

    }
}
