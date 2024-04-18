using Maui.GoogleMaps;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]

    public sealed class MyLocationButtonClickedToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.MyLocationButtonClicked +=OnMyLocationButtonClicked;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.MyLocationButtonClicked -= OnMyLocationButtonClicked;
        }

        private void OnMyLocationButtonClicked(object sender, MyLocationButtonClickedEventArgs myLocationButtonClickedEventArgs)
        {
            Command?.Execute(myLocationButtonClickedEventArgs);
        }
    }
}
