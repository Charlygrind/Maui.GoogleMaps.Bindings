using Maui.GoogleMaps;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class PinClickedToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.PinClicked += OnPinClicked;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.PinClicked -= OnPinClicked;
        }

        private void OnPinClicked(object sender, PinClickedEventArgs pinClickedEventArgs)
        {
            Command?.Execute(pinClickedEventArgs);
        }
    }
}
