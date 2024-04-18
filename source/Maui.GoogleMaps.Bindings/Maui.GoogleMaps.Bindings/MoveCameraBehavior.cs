﻿using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public class MoveCameraBehavior : BehaviorBase<MauiMap>
    {
        public static readonly BindableProperty RequestProperty = BindableProperty.Create("Request", typeof(MoveCameraRequest), typeof(MoveCameraBehavior), null, propertyChanged: OnRequestChanged);

        private static void OnRequestChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((MoveCameraBehavior)bindable).OnRequestChanged(oldValue as MoveCameraRequest, newValue as MoveCameraRequest);
        }

        public MoveCameraRequest Request
        {
            get => (MoveCameraRequest)GetValue(RequestProperty);
            set => SetValue(RequestProperty, value);
        }

        private void OnRequestChanged(MoveCameraRequest oldValue, MoveCameraRequest newValue)
        {
            if (oldValue != null)
            {
                oldValue.MoveCameraBehavior = null;
            }
            if (newValue != null)
            {
                newValue.MoveCameraBehavior = this;
            }
        }

        public Task<AnimationStatus> MoveCamera(CameraUpdate cameraUpdate)
        {
            return AssociatedObject.MoveCamera(cameraUpdate);
        }
    }
}
