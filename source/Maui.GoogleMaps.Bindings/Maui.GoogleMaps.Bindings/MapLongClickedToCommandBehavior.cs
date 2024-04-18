using Maui.GoogleMaps;
namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class MapLongClickedToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.MapLongClicked += OnMapLongClicked;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.MapLongClicked -= OnMapLongClicked;
        }

        private void OnMapLongClicked(object sender, MapLongClickedEventArgs args)
        {
            Command?.Execute(args);
        }
    }
}
