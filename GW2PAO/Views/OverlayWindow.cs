﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using GW2PAO.Infrastructure;
using GW2PAO.Properties;
using GW2PAO.Utility;
using Microsoft.Practices.Prism.PubSubEvents;
using NLog;

namespace GW2PAO.Views
{
    public class OverlayWindow : Window
    {
        /// <summary>
        /// Static owner window that all overlay windows live under. This reduces the amount of entries in the taskbar and in the alt-tab menu of windows
        /// </summary>
        public static Window OwnerWindow { get; set; }

        /// <summary>
        /// The event aggregator for all overlay windows
        /// </summary>
        public static EventAggregator EventAggregator { get; set; }

        /// <summary>
        /// Set to true to never allow click-through, else false
        /// </summary>
        protected virtual bool NeverClickThrough { get { return false; } }

        /// <summary>
        /// Set to false to not set the "NoFocus" property, else true
        /// </summary>
        protected virtual bool SetNoFocus { get { return true; } }

        /// <summary>
        /// Dependency property for IsClickthrough
        /// True if this window has click-through enabled, else false
        /// </summary>
        public static readonly DependencyProperty IsClickthroughProperty =
            DependencyProperty.Register("IsClickthrough",
            typeof(bool),
            typeof(OverlayWindow),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(IsClickthroughPropertyChanged)));

        /// <summary>
        /// Dependency property for IsSticky
        /// True if this window has click-through enabled, else false
        /// </summary>
        public static readonly DependencyProperty IsStickyProperty =
            DependencyProperty.Register("IsSticky",
            typeof(bool),
            typeof(OverlayWindow),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(IsStickyPropertyChanged)));

        /// <summary>
        /// True if this window has click-through enabled, else false
        /// </summary>
        public bool IsClickthrough
        {
            get { return (bool)GetValue(IsClickthroughProperty); }
            set { SetValue(IsClickthroughProperty, value); }
        }

        /// <summary>
        /// True if the window should be sticky (stick to edges, other windows, etc), else false
        /// </summary>
        public bool IsSticky
        {
            get { return (bool)GetValue(IsStickyProperty); }
            set { SetValue(IsStickyProperty, value); }
        }

        /// <summary>
        /// True if the window has been closed, else false
        /// </summary>
        public bool IsClosed
        {
            get;
            private set;
        }

        /// <summary>
        /// Set to true to allow auto-hiding this window, else false
        /// Defaults to True
        /// </summary>
        public virtual bool SupportsAutoHide { get { return true; } }

        /// <summary>
        /// Helper for snapping any resizing
        /// </summary>
        protected ResizeSnapHelper ResizeHelper;

        private Point DragStartPosition { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public OverlayWindow()
        {
            this.Loaded += OverlayWindowBase_Loaded;
            this.ResizeHelper = new ResizeSnapHelper(this);

            this.MouseLeftButtonDown += OverlayWindow_MouseLeftButtonDown;
            this.MouseLeftButtonUp += OverlayWindow_MouseLeftButtonUp;

            this.IsClosed = false;
            this.Closed += (o, e) => this.IsClosed = true;

            OverlayWindow.EventAggregator.GetEvent<GW2ProcessFocused>().Subscribe(o => Threading.BeginInvokeOnUI(() => User32.SetTopMost(this, this.Topmost)));

            Settings.Default.PropertyChanged += Settings_PropertyChanged;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Background = this.GetBackgroundBrush();
        }

        private void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Settings.Default.OverlayColor):
                    this.Background = this.GetBackgroundBrush();
                    break;
                default: break;
            }
        }

        private void OverlayWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragStartPosition = new Point(this.Left, this.Top);
        }

        private void OverlayWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Math.Abs(this.DragStartPosition.X - this.Left) > 1 || Math.Abs(this.DragStartPosition.Y - this.Top) > 1)
            {
                this.CommitPositionSettings();
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Event handler for the window Loaded event
        /// </summary>
        private void OverlayWindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (OwnerWindow != null && OwnerWindow != this && OwnerWindow.IsLoaded)
                this.Owner = OwnerWindow;

            // Set up the click through binding
            if (!this.NeverClickThrough)
            {
                this.IsClickthrough = GW2PAO.Properties.Settings.Default.IsClickthroughEnabled;
                Binding clickthroughBinding = new Binding("IsClickthroughEnabled")
                    {
                        Source = GW2PAO.Properties.Settings.Default,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };
                BindingOperations.SetBinding(this, OverlayWindow.IsClickthroughProperty, clickthroughBinding);
            }

            // Disable window activation, which prevents the taskbar from showing
            if (this.SetNoFocus)
                Utility.User32.SetNoActivate(this, true);
        }

        /// <summary>
        /// Event handler for the Location Changed event
        /// </summary>
        protected void OverlayWindowBase_LocationChanged(object sender, EventArgs e)
        {
            //if (this.IsMouseOver)
            //{
            //    System.Windows.Point MousePoint = Mouse.GetPosition(this);
            //    System.Windows.Point ScreenPoint = this.PointToScreen(MousePoint);
            //}
        }

        /// <summary>
        /// Property Changed event handler for the IsClickthrough property
        /// </summary>
        private static void IsClickthroughPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            bool isClickThrough = (bool)e.NewValue;
            OverlayWindow window = (OverlayWindow)source;

            if (isClickThrough && !window.NeverClickThrough)
            {
                User32.SetWindowExTransparent(window, true);
            }
            else
            {
                User32.SetWindowExTransparent(window, false);
            }
        }

        /// <summary>
        /// Property Changed event handler for the IsSticky property
        /// </summary>
        private static void IsStickyPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            bool isSticky = (bool)e.NewValue;
            OverlayWindow window = (OverlayWindow)source;
        }

        protected virtual void CommitPositionSettings() {}

        protected virtual Brush GetBackgroundBrush()
        {
            return new SolidColorBrush(Settings.Default.OverlayColor);
        }
    }
}
