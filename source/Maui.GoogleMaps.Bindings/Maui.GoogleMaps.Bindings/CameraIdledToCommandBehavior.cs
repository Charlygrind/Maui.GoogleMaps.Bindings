using Maui.GoogleMaps;
namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public class CameraIdledToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.CameraIdled += OnCameraIdled;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.CameraIdled -= OnCameraIdled;
        }

        private void OnCameraIdled(object sender, CameraIdledEventArgs cameraIdledEventArgs)
        {
            Command?.Execute(cameraIdledEventArgs);
        }
    }
}
