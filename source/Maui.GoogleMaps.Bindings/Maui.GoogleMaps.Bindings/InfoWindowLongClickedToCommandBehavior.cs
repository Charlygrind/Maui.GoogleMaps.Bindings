using Maui.GoogleMaps;
namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class InfoWindowLongClickedToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.InfoWindowLongClicked += OnInfoWindowLongClicked;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.InfoWindowLongClicked -= OnInfoWindowLongClicked;
        }

        private void OnInfoWindowLongClicked(object sender, InfoWindowLongClickedEventArgs infoWindowLongClickedEventArgs)
        {
            Command?.Execute(infoWindowLongClickedEventArgs);
        }
    }
}
