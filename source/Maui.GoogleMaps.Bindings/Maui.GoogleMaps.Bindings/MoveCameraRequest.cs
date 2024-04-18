﻿using Maui.GoogleMaps;

namespace Maui.GoogleMaps.Bindings
{
    public sealed class MoveCameraRequest
    {
        internal MoveCameraBehavior MoveCameraBehavior { get; set; }
        public Task<AnimationStatus> MoveCamera(CameraUpdate cameraUpdate)
        {
            if(MoveCameraBehavior == null) throw new InvalidOperationException("Not binding to MoveCameraBehavior.");

            return MoveCameraBehavior.MoveCamera(cameraUpdate);
        }
    }
}
