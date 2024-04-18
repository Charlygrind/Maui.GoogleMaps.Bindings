﻿using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;

namespace Maui.GoogleMaps.Bindings
{
    public class UpdateRegionBehavior : BehaviorBase<MauiMap>
    {
        public static readonly BindableProperty RegionProperty = 
            BindableProperty.Create("Region", typeof(MapSpan), typeof(UpdateRegionBehavior), default(MapSpan), propertyChanged: OnRegionChanged);

        public static readonly BindableProperty AnimatedProperty =
            BindableProperty.Create("Animated", typeof(bool), typeof(UpdateRegionBehavior), true);

        public bool Animated => (bool)GetValue(AnimatedProperty);

        public MapSpan Region
        {
            get => (MapSpan) GetValue(RegionProperty);
            set => SetValue(RegionProperty, value);
        }

        private static void OnRegionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null) return;

            var behavior = (UpdateRegionBehavior)bindable;
            behavior.AssociatedObject.MoveToRegion((MapSpan)newValue, behavior.Animated);
        }
    }
}
