﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GW2PAO.API.Data;
using GW2PAO.API.Data.Enums;
using GW2PAO.API.Services;
using GW2PAO.Models;
using GW2PAO.PresentationCore;
using NLog;

namespace GW2PAO.ViewModels.EventTracker
{
    /// <summary>
    /// View model for an event shown by the event tracker
    /// </summary>
    public class EventViewModel : NotifyPropertyChangedBase
    {
        /// <summary>
        /// Default logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private EventState state;
        private TimeSpan timerValue;
        private bool isVisible;
        private EventTrackerSettings userOptions;

        /// <summary>
        /// The primary model object containing the event information
        /// </summary>
        public WorldEvent EventModel { get; private set; }

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
        public string ZoneName { get { return "Located in " + this.EventModel.Location; } }

        /// <summary>
        /// Current state of the event
        /// </summary>
        public EventState State
        {
            get { return this.state; }
            set { if (SetField(ref this.state, value)) this.RefreshVisibility(); }
        }

        /// <summary>
        /// Depending on the state of the event, contains the
        /// 'Time Until Active' or the 'Time Since Active'
        /// </summary>
        public TimeSpan TimerValue
        {
            get { return this.timerValue; }
            set { SetField(ref this.timerValue, value); }
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
            set { SetField(ref this.isVisible, value); }
        }

        /// <summary>
        /// Daily treasure obtained state
        /// Resets at UTC midnight
        /// </summary>
        public bool IsTreasureObtained
        {
            get { return this.userOptions.EventsWithTreasureObtained.Contains(this.EventModel.ID); }
            set
            {
                if (value && !this.userOptions.EventsWithTreasureObtained.Contains(this.EventModel.ID))
                {
                    logger.Debug("Adding \"{0}\" to EventsWithTreasureObtained", this.EventName);
                    this.userOptions.EventsWithTreasureObtained.Add(this.EventModel.ID);
                    this.RaisePropertyChanged();
                }
                else
                {
                    logger.Debug("Removing \"{0}\" from EventsWithTreasureObtained", this.EventName);
                    if (this.userOptions.EventsWithTreasureObtained.Remove(this.EventModel.ID))
                        this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Command to hide the event
        /// </summary>
        public DelegateCommand HideCommand { get { return new DelegateCommand(this.AddToHiddenEvents); } }

        /// <summary>
        /// Command to copy the nearest waypoint's chat code to the clipboard
        /// </summary>
        public DelegateCommand CopyWaypointCommand { get { return new DelegateCommand(this.CopyWaypointCode); } }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="eventData">The event's details/data</param>
        /// <param name="userSettings">Event tracker user settings</param>
        public EventViewModel(WorldEvent eventData, EventTrackerSettings userSettings)
        {
            this.EventModel = eventData;
            this.userOptions = userSettings;
            this.IsVisible = true;

            this.State = EventState.Unknown;
            this.TimerValue = TimeSpan.Zero;
            this.userOptions.PropertyChanged += (o, e) => this.RefreshVisibility();
            this.userOptions.HiddenEvents.CollectionChanged += (o, e) => this.RefreshVisibility();
        }

        /// <summary>
        /// Adds the event to the list of hidden events
        /// </summary>
        private void AddToHiddenEvents()
        {
            logger.Debug("Adding \"{0}\" to hidden events", this.EventName);
            this.userOptions.HiddenEvents.Add(this.EventModel.ID);
        }

        /// <summary>
        /// Refreshes the visibility of the event
        /// </summary>
        private void RefreshVisibility()
        {
            logger.Trace("Refreshing visibility of \"{0}\"", this.EventName);
            if (this.userOptions.HiddenEvents.Any(id => id == this.EventId))
            {
                this.IsVisible = false;
            }
            else if (!this.userOptions.AreInactiveEventsVisible
                    && this.State == EventState.Inactive)
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
            System.Windows.Clipboard.SetText(this.EventModel.WaypointCode);
        }

    }
}
