using Maui.GoogleMaps;
namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class PinDragEndToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.PinDragEnd += OnPinDragEnd;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.PinDragEnd -= OnPinDragEnd;
        }

        private void OnPinDragEnd(object sender, PinDragEventArgs args)
        {
            Command?.Execute(args);
        }
    }
}
