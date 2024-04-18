﻿using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;

namespace Maui.GoogleMaps.Bindings
{
    public class UpdateCameraPositionBehavior : BehaviorBase<MauiMap>
    {
        public static readonly BindableProperty CameraUpdateProperty =
            BindableProperty.Create("CameraUpdate", typeof(CameraUpdate), typeof(UpdateCameraPositionBehavior), default(CameraUpdate), propertyChanged: OnCameraUpdateChanged);

        public static readonly BindableProperty DurationProperty =
            BindableProperty.Create("Duration", typeof(TimeSpan?), typeof(UpdateRegionBehavior), null);

        public TimeSpan? Duration => (TimeSpan?)GetValue(DurationProperty);

        public CameraUpdate CameraUpdate
        {
            get => (CameraUpdate)GetValue(CameraUpdateProperty);
            set => SetValue(CameraUpdateProperty, value);
        }

        private static void OnCameraUpdateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null) return;

            var behavior = (UpdateCameraPositionBehavior)bindable;
            if(behavior.Duration == null)
            {
                behavior.AssociatedObject.MoveCamera((CameraUpdate)newValue);
            }
            else
            {
                behavior.AssociatedObject.AnimateCamera((CameraUpdate)newValue, behavior.Duration);
            }
        }
    }
}
