using Maui.GoogleMaps;
namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public class CameraMovingToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.CameraMoving += OnCameraMoving;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.CameraMoving -= OnCameraMoving;
        }

        private void OnCameraMoving(object sender, CameraMovingEventArgs cameraMovingEventArgs)
        {
            Command?.Execute(cameraMovingEventArgs);
        }
    }
}
