﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GW2PAO.API.Data;
using GW2PAO.Data.UserData;
using GW2PAO.PresentationCore;
using NLog;

namespace GW2PAO.Modules.Events
{
    /// <summary>
    /// User settings for the Events Tracker and Event Notifications
    /// </summary>
    [Serializable]
    public class EventsUserData : UserData<EventsUserData>
    {
        /// <summary>
        /// Default logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The default settings filename
        /// </summary>
        public const string Filename = "EventsUserData.xml";

        private bool areCompletedEventsVisible;
        private bool areInactiveEventsVisible;
        private bool areHiddenEventsVisible;
        private bool areHiddenMetaEventsVisible;
        private bool showWaypointCopyButtons;
        private bool areEventNotificationsEnabled;
        private bool useAdjustedTimeTable;
        private bool autoDetectCompletion;
        private uint notificationDuration;
        private bool showEndOfEvents;
        private DateTime lastResetDateTime;
        private ObservableCollection<Guid> hiddenEvents = new ObservableCollection<Guid>();
        private ObservableCollection<Guid> hiddenMetaEvents = new ObservableCollection<Guid>();
        private ObservableCollection<Guid> eventsWithTreasureObtained = new ObservableCollection<Guid>();
        private ObservableCollection<EventNotificationSettings> notificationSettings = new ObservableCollection<EventNotificationSettings>();

        /// <summary>
        /// True if completed events are visible, else false
        /// </summary>
        public bool AreCompletedEventsVisible
        {
            get { return this.areCompletedEventsVisible; }
            set { SetProperty(ref this.areCompletedEventsVisible, value); }
        }

        /// <summary>
        /// True if inactive events are visible, else false
        /// </summary>
        public bool AreInactiveEventsVisible
        {
            get { return this.areInactiveEventsVisible; }
            set { SetProperty(ref this.areInactiveEventsVisible, value); }
        }

        public bool AreHiddenEventsVisible
        {
            get { return this.areHiddenEventsVisible; }
            set { SetProperty(ref this.areHiddenEventsVisible, value); }
        }

        public bool AreHiddenMetaEventsVisible
        {
            get { return this.areHiddenMetaEventsVisible; }
            set { SetProperty(ref this.areHiddenMetaEventsVisible, value); }
        }

        /// <summary>
        /// True if the waypoint-code copy buttons are visible in the events tracker, else false
        /// </summary>
        public bool ShowWaypointCopyButtons
        {
            get { return this.showWaypointCopyButtons; }
            set { SetProperty(ref this.showWaypointCopyButtons, value); }
        }

        /// <summary>
        /// True if event notifications are enabled, else false
        /// </summary>
        public bool AreEventNotificationsEnabled
        {
            get { return this.areEventNotificationsEnabled; }
            set { SetProperty(ref this.areEventNotificationsEnabled, value); }
        }

        /// <summary>
        /// True if the adjusted time table should be used, else false
        /// </summary>
        public bool UseAdjustedTimeTable
        {
            get { return this.useAdjustedTimeTable; }
            set { SetProperty(ref this.useAdjustedTimeTable, value); }
        }

        /// <summary>
        /// True of event daily completion should be automatically detected, else false
        /// </summary>
        public bool AutoDetectCompletion
        {
            get { return this.autoDetectCompletion; }
            set { SetProperty(ref this.autoDetectCompletion, value); }
        }

        /// <summary>
        /// The amount of time to display notifications, in seconds
        /// </summary>
        public uint NotificationDuration
        {
            get { return this.notificationDuration; }
            set { SetProperty(ref this.notificationDuration, value); }
        }

        /// <summary>
        /// True if user selects show "end of event" notifications, else false
        /// </summary>
        public bool ShowEndOfEvents
        {
            get { return this.showEndOfEvents; }
            set { SetProperty(ref this.showEndOfEvents, value); }
        }

        /// <summary>
        /// True if the standard time table should be used, else false
        /// </summary>
        [XmlIgnore]
        public bool UseStandardTimeTable
        {
            get { return !this.UseAdjustedTimeTable; }
            set
            {
                if (this.UseAdjustedTimeTable != !value)
                {
                    this.UseAdjustedTimeTable = !value;
                    this.OnPropertyChanged(() => this.UseStandardTimeTable);
                }
            }
        }

        /// <summary>
        /// The last recorded server-reset date/time
        /// </summary>
        public DateTime LastResetDateTime
        {
            get { return this.lastResetDateTime; }
            set { SetProperty(ref this.lastResetDateTime, value); }
        }

        /// <summary>
        /// Collection of user-configured Hidden World Boss Events
        /// </summary>
        public ObservableCollection<Guid> HiddenEvents { get { return this.hiddenEvents; } }

        /// <summary>
        /// Collection of user-configured Hidden Meta Events
        /// </summary>
        public ObservableCollection<Guid> HiddenMetaEvents { get { return this.hiddenMetaEvents; } }

        /// <summary>
        /// Collection of user-configured events with treasures already obtained
        /// </summary>
        public ObservableCollection<Guid> EventsWithTreasureObtained { get { return this.eventsWithTreasureObtained; } }

        /// <summary>
        /// Collection of notification settings
        /// </summary>
        public ObservableCollection<EventNotificationSettings> NotificationSettings { get { return this.notificationSettings; } }

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventsUserData()
        {
            this.AreCompletedEventsVisible = true;
            this.AreInactiveEventsVisible = true;
            this.AreHiddenEventsVisible = false;
            this.AreHiddenMetaEventsVisible = false;
            this.ShowWaypointCopyButtons = true;
            this.AreEventNotificationsEnabled = true;
            this.UseAdjustedTimeTable = true;
            this.AutoDetectCompletion = true;
            this.NotificationDuration = 10;
            this.LastResetDateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Enables auto-save of settings. If called, whenever a setting is changed, this settings object will be saved to disk
        /// </summary>
        public override void EnableAutoSave()
        {
            logger.Info("Enabling auto save");
            this.PropertyChanged += (o, e) => EventsUserData.SaveData(this, EventsUserData.Filename);
            this.HiddenEvents.CollectionChanged += (o, e) => EventsUserData.SaveData(this, EventsUserData.Filename);
            this.HiddenMetaEvents.CollectionChanged += (o, e) => EventsUserData.SaveData(this, EventsUserData.Filename);
            this.EventsWithTreasureObtained.CollectionChanged += (o, e) => EventsUserData.SaveData(this, EventsUserData.Filename);
            this.NotificationSettings.CollectionChanged += (o, e) =>
                {
                    EventsUserData.SaveData(this, EventsUserData.Filename);
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (EventNotificationSettings ens in e.NewItems)
                        {
                            ens.PropertyChanged += (obj, arg) => EventsUserData.SaveData(this, EventsUserData.Filename);
                        }
                    }
                };
            foreach (EventNotificationSettings ens in this.NotificationSettings)
            {
                ens.PropertyChanged += (obj, arg) => EventsUserData.SaveData(this, EventsUserData.Filename);
            }
        }
    }
}
