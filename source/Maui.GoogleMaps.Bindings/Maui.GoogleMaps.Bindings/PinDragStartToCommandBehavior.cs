using Maui.GoogleMaps;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class PinDragStartToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.PinDragStart += OnPinDragStart;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.PinDragStart -= OnPinDragStart;
        }

        private void OnPinDragStart(object sender, PinDragEventArgs args)
        {
            Command?.Execute(args);
        }
    }
}
