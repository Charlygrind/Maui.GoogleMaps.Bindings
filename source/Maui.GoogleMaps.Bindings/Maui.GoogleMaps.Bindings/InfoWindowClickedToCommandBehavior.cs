using Maui.GoogleMaps;
namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class InfoWindowClickedToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.InfoWindowClicked += OnInfoWindowClicked;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.InfoWindowClicked -= OnInfoWindowClicked;
        }

        private void OnInfoWindowClicked(object sender, InfoWindowClickedEventArgs infoWindowClickedEventArgs)
        {
            Command?.Execute(infoWindowClickedEventArgs);
        }
    }
}
