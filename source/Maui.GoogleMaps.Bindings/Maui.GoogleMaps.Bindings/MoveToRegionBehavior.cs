using MauiMap =  Maui.GoogleMaps.Map;
namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class MoveToRegionBehavior : BehaviorBase<MauiMap>
    {
        public static readonly BindableProperty RequestProperty = BindableProperty.Create("Request", typeof(MoveToRegionRequest), typeof(MoveToRegionBehavior), default(MoveToRegionRequest), propertyChanged:OnRequestChanged);

        public MoveToRegionRequest Request
        {
            get => (MoveToRegionRequest)GetValue(RequestProperty);
            set => SetValue(RequestProperty, value);
        }

        private static void OnRequestChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((MoveToRegionBehavior)bindable).OnRequestChanged(oldValue as MoveToRegionRequest, newValue as MoveToRegionRequest);
        }

        private void OnRequestChanged(MoveToRegionRequest oldValue, MoveToRegionRequest newValue)
        {
            if (oldValue != null)
            {
                oldValue.MoveToRegionRequested -= OnMoveToRegionRequested;
            }
            if (newValue != null)
            {
                newValue.MoveToRegionRequested += OnMoveToRegionRequested;
            }
        }

        private void OnMoveToRegionRequested(object sender, MoveToRegionRequestedEventArgs moveToRegionRequestedEventArgs)
        {
            if (moveToRegionRequestedEventArgs.MapSpan != null)
            {
                AssociatedObject.MoveToRegion(
                    moveToRegionRequestedEventArgs.MapSpan, 
                    moveToRegionRequestedEventArgs.Animated);
            }
        }
    }
}
