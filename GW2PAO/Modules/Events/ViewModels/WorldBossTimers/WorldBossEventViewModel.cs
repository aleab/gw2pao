﻿using System;
using System.Collections.Generic;
using System.Linq;
using GW2PAO.API.Data.Entities;
using GW2PAO.API.Data.Enums;
using GW2PAO.PresentationCore;
using Microsoft.Practices.Prism.Mvvm;
using NLog;

namespace GW2PAO.Modules.Events.ViewModels.WorldBossTimers
{
    /// <summary>
    /// View model for an event shown by the event tracker
    /// </summary>
    public class WorldBossEventViewModel : BindableBase
    {
        /// <summary>
        /// Default logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private EventState state;
        private TimeSpan timeSinceActive;
        private TimeSpan timerValue;
        private bool isVisible;
        private bool isHidden;

        /// <summary>
        /// The general events-related user settings/data
        /// </summary>
        public EventsUserData UserData { get; private set; }

        /// <summary>
        /// The primary model object containing the event information
        /// </summary>
        public WorldBossEvent EventModel { get; private set; }

        /// <summary>
        /// The event's ID
        /// </summary>
        public Guid EventId { get { return this.EventModel.ID; } }

        /// <summary>
        /// The event's name
        /// </summary>
        public string EventName { get { return this.EventModel.Name; } }

        /// <summary>
        /// Name of the zone in which the event occurs
        /// </summary>
        public string ZoneName { get { return this.EventModel.MapName; } }

        /// <summary>
        /// Current state of the event
        /// </summary>
        public EventState State
        {
            get { return this.state; }
            set { if (SetProperty(ref this.state, value)) this.RefreshVisibility(); }
        }

        /// <summary>
        /// Depending on the state of the event, contains the
        /// 'Time Until Active' or the 'Time Since Active'
        /// </summary>
        public TimeSpan TimerValue
        {
            get { return this.timerValue; }
            set { SetProperty(ref this.timerValue, value); }
        }

        /// <summary>
        /// Time since the event was last active
        /// </summary>
        public TimeSpan TimeSinceActive
        {
            get { return this.timeSinceActive; }
            set { SetProperty(ref this.timeSinceActive, value); }
        }

        /// <summary>
        /// Visibility of the event
        /// Visibility is based on multiple properties, including:
        ///     - EventState and the user configuration for what states are shown
        ///     - IsTreasureObtained and whether or not treasure-obtained events are shown
        ///     - Whether or not the event is user-configured as hidden
        /// </summary>
        public bool IsVisible
        {
            get { return this.isVisible; }
            set { SetProperty(ref this.isVisible, value); }
        }

        public bool IsHidden
        {
            get { return this.isHidden; }
            set { SetProperty(ref this.isHidden, value); }
        }

        /// <summary>
        /// Daily treasure obtained state
        /// Resets at UTC midnight
        /// </summary>
        public bool IsTreasureObtained
        {
            get { return this.UserData.EventsWithTreasureObtained.Contains(this.EventModel.ID); }
            set
            {
                if (value && !this.UserData.EventsWithTreasureObtained.Contains(this.EventModel.ID))
                {
                    logger.Debug("Adding \"{0}\" to EventsWithTreasureObtained", this.EventName);
                    this.UserData.EventsWithTreasureObtained.Add(this.EventModel.ID);
                    this.OnPropertyChanged(() => this.IsTreasureObtained);
                    this.RefreshVisibility();
                }
                else
                {
                    logger.Debug("Removing \"{0}\" from EventsWithTreasureObtained", this.EventName);
                    if (this.UserData.EventsWithTreasureObtained.Remove(this.EventModel.ID))
                        this.OnPropertyChanged(() => this.IsTreasureObtained);
                    this.RefreshVisibility();
                }
            }
        }

        /// <summary>
        /// Command to hide the event
        /// </summary>
        public DelegateCommand HideCommand { get; }

        /// <summary>
        /// Command to copy the nearest waypoint's chat code to the clipboard
        /// </summary>
        public DelegateCommand CopyWaypointCommand { get { return new DelegateCommand(this.CopyWaypointCode); } }

        /// <summary>
        /// Command to copy the information about the event to the clipboard
        /// </summary>
        public DelegateCommand CopyDataCommand { get { return new DelegateCommand(this.CopyEventData); } }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="eventData">The event's details/data</param>
        /// <param name="userData">Event tracker user data</param>
        public WorldBossEventViewModel(WorldBossEvent eventData, EventsUserData userData)
        {
            this.EventModel = eventData;
            this.UserData = userData;
            this.IsVisible = true;
            this.isHidden = this.UserData.HiddenEvents.Any(id => id == this.EventModel.ID);

            this.HideCommand = new DelegateCommand(this.AddOrRemoveToHiddenEvents);

            this.State = EventState.Unknown;
            this.TimerValue = TimeSpan.Zero;
            this.UserData.PropertyChanged += (o, e) => this.RefreshVisibility();
            this.UserData.HiddenEvents.CollectionChanged += (o, e) => this.RefreshVisibility();
        }

        /// <summary>
        /// Adds the event to the list of hidden events
        /// </summary>
        private void AddOrRemoveToHiddenEvents()
        {
            if (this.UserData.HiddenEvents.Any(id => id == this.EventModel.ID))
            {
                logger.Debug("Removing \"{0}\" from hidden events", this.EventName);
                this.UserData.HiddenEvents.Remove(this.EventModel.ID);
            }
            else
            {
                logger.Debug("Adding \"{0}\" to hidden events", this.EventName);
                this.UserData.HiddenEvents.Add(this.EventModel.ID);
            }
        }

        /// <summary>
        /// Refreshes the visibility of the event
        /// </summary>
        private void RefreshVisibility()
        {
            logger.Trace("Refreshing visibility of \"{0}\"", this.EventName);
            this.IsHidden = this.UserData.HiddenEvents.Any(id => id == this.EventModel.ID);
            if (!this.UserData.AreHiddenEventsVisible && this.IsHidden)
            {
                this.IsVisible = false;
            }
            else if (!this.UserData.AreInactiveEventsVisible && this.State == EventState.Inactive)
            {
                this.IsVisible = false;
            }
            else if (!this.UserData.AreCompletedEventsVisible && this.IsTreasureObtained)
            {
                this.IsVisible = false;
            }
            else
            {
                this.IsVisible = true;
            }
            logger.Trace("IsVisible = {0}", this.IsVisible);
        }

        /// <summary>
        /// Copies the nearest waypoint's chat code to the clipboard
        /// </summary>
        private void CopyWaypointCode()
        {
            logger.Debug("Copying waypoint code of \"{0}\" as \"{1}\"", this.EventName, this.EventModel.WaypointCode);
            System.Windows.Clipboard.SetDataObject(this.EventModel.WaypointCode);
        }

        /// <summary>
        /// Places a string of data on the clipboard for pasting into the game
        /// Contains the event name, status, time until active, waypoint code, etc
        /// </summary>
        private void CopyEventData()
        {
            string fullText;
            if (this.State == EventState.Active)
            {
                fullText = string.Format("{0} - {1}",
                    this.EventName,
                    this.EventModel.WaypointCode);
            }
            else
            {
                fullText = string.Format("{0} - {1} {2} - {3}",
                    this.EventName,
                    GW2PAO.Properties.Resources.ActiveIn, this.TimerValue.ToString("hh\\:mm\\:ss"),
                    this.EventModel.WaypointCode);
            }

            logger.Debug("Copying \"{0}\" to clipboard", fullText);
            System.Windows.Clipboard.SetDataObject(fullText);
        }
    }
}
