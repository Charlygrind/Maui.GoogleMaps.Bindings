using Maui.GoogleMaps;
namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public class CameraMoveStartedToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.CameraMoveStarted += OnCameraMoveStarted;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.CameraMoveStarted -= OnCameraMoveStarted;
        }

        private void OnCameraMoveStarted(object sender, CameraMoveStartedEventArgs cameraMoveStartedEventArgs)
        {
            Command?.Execute(cameraMoveStartedEventArgs);
        }
    }
}
