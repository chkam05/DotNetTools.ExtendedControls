﻿using chkam05.Tools.ControlsEx.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx
{
    public class TabItemEx : TabItem
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(TabItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(TabItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected),
            typeof(Brush),
            typeof(TabItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(TabItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(TabItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected),
            typeof(Brush),
            typeof(TabItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(TabItemEx),
            new PropertyMetadata(new CornerRadius(4,4,0,0)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(TabItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(TabItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected),
            typeof(Brush),
            typeof(TabItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(TabItemEx),
            new PropertyMetadata(0.56d));


        //  GETTERS & SETTERS

        public Brush BackgroundInactive
        {
            get => (Brush)GetValue(BackgroundInactiveProperty);
            set => SetValue(BackgroundInactiveProperty, value);
        }

        public Brush BackgroundMouseOver
        {
            get => (Brush)GetValue(BackgroundMouseOverProperty);
            set => SetValue(BackgroundMouseOverProperty, value);
        }

        public Brush BackgroundSelected
        {
            get => (Brush)GetValue(BackgroundSelectedProperty);
            set => SetValue(BackgroundSelectedProperty, value);
        }

        public Brush BorderBrushInactive
        {
            get => (Brush)GetValue(BorderBrushInactiveProperty);
            set => SetValue(BorderBrushInactiveProperty, value);
        }

        public Brush BorderBrushMouseOver
        {
            get => (Brush)GetValue(BorderBrushMouseOverProperty);
            set => SetValue(BorderBrushMouseOverProperty, value);
        }

        public Brush BorderBrushSelected
        {
            get => (Brush)GetValue(BorderBrushSelectedProperty);
            set => SetValue(BorderBrushSelectedProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Brush ForegroundInactive
        {
            get => (Brush)GetValue(ForegroundInactiveProperty);
            set => SetValue(ForegroundInactiveProperty, value);
        }

        public Brush ForegroundMouseOver
        {
            get => (Brush)GetValue(ForegroundMouseOverProperty);
            set => SetValue(ForegroundMouseOverProperty, value);
        }

        public Brush ForegroundSelected
        {
            get => (Brush)GetValue(ForegroundSelectedProperty);
            set => SetValue(ForegroundSelectedProperty, value);
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> TabItemEx class constructor. </summary>
        static TabItemEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabItemEx),
                new FrameworkPropertyMetadata(typeof(TabItemEx)));
        }

        #endregion CONSTRUCTORS

    }
}
