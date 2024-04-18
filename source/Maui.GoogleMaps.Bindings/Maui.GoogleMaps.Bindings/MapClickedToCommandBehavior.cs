using Maui.GoogleMaps;
namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class MapClickedToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.MapClicked += OnMapClicked;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.MapClicked -= OnMapClicked;
        }

        private void OnMapClicked(object sender, MapClickedEventArgs mapClickedEventArgs)
        {
            Command?.Execute(mapClickedEventArgs);
        }
    }
}
