﻿using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class AnimateCameraBehavior : BehaviorBase<MauiMap>
    {
        public static readonly BindableProperty RequestProperty = BindableProperty.Create("Request", typeof(AnimateCameraRequest), typeof(AnimateCameraBehavior), null, propertyChanged: OnRequestChanged);

        private static void OnRequestChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AnimateCameraBehavior)bindable).OnRequestChanged(oldValue as AnimateCameraRequest, newValue as AnimateCameraRequest);
        }

        public AnimateCameraRequest Request
        {
            get => (AnimateCameraRequest) GetValue(RequestProperty);
            set => SetValue(RequestProperty, value);
        }

        private void OnRequestChanged(AnimateCameraRequest oldValue, AnimateCameraRequest newValue)
        {
            if (oldValue != null)
            {
                oldValue.AnimateCameraBehavior = null;
            }
            if (newValue != null)
            {
                newValue.AnimateCameraBehavior = this;
            }
        }

        public Task<AnimationStatus> AnimateCamera(CameraUpdate cameraUpdate, TimeSpan? duration = null)
        {
            return AssociatedObject.AnimateCamera(cameraUpdate, duration);
        }
    }
}
