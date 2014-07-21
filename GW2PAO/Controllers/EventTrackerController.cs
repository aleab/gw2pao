﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using GW2PAO.API.Data;
using GW2PAO.API.Services;
using GW2PAO.API.Services.Interfaces;
using GW2PAO.Controllers.Interfaces;
using GW2PAO.Models;
using GW2PAO.Utility;
using GW2PAO.ViewModels.EventTracker;
using GW2PAO.ViewModels.Interfaces;
using GW2PAO.ViewModels.ZoneCompletion;
using NLog;

namespace GW2PAO.Controllers
{
    /// <summary>
    /// The Event Tracker controller. Handles refresh of events, including state and timer values.
    /// </summary>
    public class EventTrackerController : IEventTrackerController
    {
        /// <summary>
        /// Default logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Service responsible for Event information
        /// </summary>
        private IEventsService eventsService;

        /// <summary>
        /// The primary event refresh timer object
        /// </summary>
        private Timer eventRefreshTimer;

        /// <summary>
        /// Locking object for operations performed with the refresh timer
        /// </summary>
        private readonly object refreshTimerLock = new object();

        /// <summary>
        /// The user settings
        /// </summary>
        private EventTrackerSettings userSettings;

        /// <summary>
        /// Keeps track of how many times Start() has been called in order
        /// to support reuse of a single object
        /// </summary>
        private int startCallCount;

        /// <summary>
        /// Backing store of the World Events collection
        /// </summary>
        private ObservableCollection<EventViewModel> worldEvents = new ObservableCollection<EventViewModel>();

        /// <summary>
        /// The collection of World Events
        /// </summary>
        public ObservableCollection<EventViewModel> WorldEvents { get { return this.worldEvents; } }

        /// <summary>
        /// The interval by which to refresh events (in ms)
        /// </summary>
        public int EventRefreshInterval { get; set; }

        /// <summary>
        /// The event tracker user settings
        /// </summary>
        public EventTrackerSettings UserSettings { get { return this.userSettings; } }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="eventsService">The events service</param>
        /// <param name="userSettings">The user settings</param>
        public EventTrackerController(IEventsService eventsService, EventTrackerSettings userSettings)
        {
            logger.Debug("Initializing Event Tracker Controller");
            this.eventsService = eventsService;

            this.userSettings = userSettings;

            // Initialize the refresh timer
            this.eventRefreshTimer = new Timer(this.RefreshEvents);
            this.EventRefreshInterval = 1000;

            // Initialize the start call count to 0
            this.startCallCount = 0;

            // Initialize the WorldEvents collection
            this.InitializeWorldEvents();

            logger.Info("Event Tracker Controller initialized");
        }

        /// <summary>
        /// Starts the automatic refresh
        /// </summary>
        public void Start()
        {
            logger.Debug("Start called");
            Task.Factory.StartNew(() =>
                {
                    // Start the timer if this is the first time that Start() has been called
                    if (this.startCallCount == 0)
                    {
                        logger.Debug("Starting refresh timers");
                        this.RefreshEvents();
                    }

                    this.startCallCount++;
                    logger.Debug("startCallCount = {0}", this.startCallCount);

                }, TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// Stops the automatic refresh
        /// </summary>
        public void Stop()
        {
            this.startCallCount--;
            logger.Debug("Stop called - startCallCount = {0}", this.startCallCount);

            // Stop the refresh timer if all calls to Start() have had a matching call to Stop()
            if (this.startCallCount == 0)
            {
                logger.Debug("Stopping refresh timers");
                lock (refreshTimerLock)
                {
                    this.eventRefreshTimer.Change(Timeout.Infinite, Timeout.Infinite);
                }
            }
        }

        /// <summary>
        /// Initializes the collection of world events
        /// </summary>
        private void InitializeWorldEvents()
        {
            logger.Debug("Initializing world events");
            this.eventsService.LoadTable();

            Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    foreach (var worldEvent in this.eventsService.EventTimeTable.WorldEvents)
                    {
                        logger.Debug("Initializing view model for {0}", worldEvent.ID);
                        this.WorldEvents.Add(new EventViewModel(worldEvent, this.userSettings));
                    }
                }));
        }

        /// <summary>
        /// Refreshes all events within the events collection
        /// This is the primary function of the EventTrackerController
        /// </summary>
        private void RefreshEvents(object state = null)
        {
            lock (refreshTimerLock)
            {
                // Refresh the state of all world events
                foreach (var worldEvent in WorldEvents)
                {
                    var newState = this.eventsService.GetState(worldEvent.EventModel);
                    Threading.BeginInvokeOnUI(() => worldEvent.State = newState);

                    if (newState == API.Data.Enums.EventState.Active)
                    {
                        var timeSinceActive = this.eventsService.GetTimeSinceActive(worldEvent.EventModel);
                        Threading.BeginInvokeOnUI(() => worldEvent.TimerValue = timeSinceActive.Negate());
                    }
                    else
                    {
                        var timeUntilActive = this.eventsService.GetTimeUntilActive(worldEvent.EventModel);
                        Threading.BeginInvokeOnUI(() => worldEvent.TimerValue = timeUntilActive);
                    }
                }

                // Refresh state of daily treasures
                if (DateTime.UtcNow.Date.CompareTo(this.userSettings.LastResetDateTime.Date) != 0)
                {
                    logger.Info("Resetting daily treasures state");
                    this.userSettings.LastResetDateTime = DateTime.UtcNow;
                    Threading.BeginInvokeOnUI(() =>
                    {
                        foreach (var worldEvent in WorldEvents)
                        {
                            worldEvent.IsTreasureObtained = false;
                        }
                    });
                }

                this.eventRefreshTimer.Change(this.EventRefreshInterval, Timeout.Infinite);
            }
        }
    }
}
