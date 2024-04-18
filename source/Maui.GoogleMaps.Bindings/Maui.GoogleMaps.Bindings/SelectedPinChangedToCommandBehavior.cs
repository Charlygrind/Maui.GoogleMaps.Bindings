using Maui.GoogleMaps;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class SelectedPinChangedToCommandBehavior : EventToCommandBehaviorBase
    {
        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.SelectedPinChanged += OnSelectedPinChanged;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.SelectedPinChanged -= OnSelectedPinChanged;
        }

        private void OnSelectedPinChanged(object sender, SelectedPinChangedEventArgs args)
        {
            Command?.Execute(args);
        }
    }
}
