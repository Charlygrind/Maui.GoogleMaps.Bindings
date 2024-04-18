using Maui.GoogleMaps;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class PinDraggingToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.PinDragging += OnPinDragging;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.PinDragging -= OnPinDragging;
        }

        private void OnPinDragging(object sender, PinDragEventArgs args)
        {
            Command?.Execute(args);
        }
    }
}
