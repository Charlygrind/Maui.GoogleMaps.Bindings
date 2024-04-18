using MauiMap =  Maui.GoogleMaps.Map;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class TakeSnapshotBehavior : BehaviorBase<MauiMap>
    {
        public static readonly BindableProperty RequestProperty = BindableProperty.Create("Request", typeof(TakeSnapshotRequest), typeof(TakeSnapshotBehavior), null, propertyChanged: OnRequestChanged);

        public TakeSnapshotRequest Request
        {
            get => (TakeSnapshotRequest)GetValue(RequestProperty);
            set => SetValue(RequestProperty, value);
        }

        private static void OnRequestChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((TakeSnapshotBehavior)bindable).OnRequestChanged(oldValue as TakeSnapshotRequest, newValue as TakeSnapshotRequest);
        }

        private void OnRequestChanged(TakeSnapshotRequest oldValue, TakeSnapshotRequest newValue)
        {
            if (oldValue != null)
            {
                oldValue.TakeSnapshotBehavior = null;
            }
            if (newValue != null)
            {
                newValue.TakeSnapshotBehavior = this;
            }
        }

        public Task<Stream> TakeSnapshot()
        {
            return AssociatedObject.TakeSnapshot();
        }
    }
}
