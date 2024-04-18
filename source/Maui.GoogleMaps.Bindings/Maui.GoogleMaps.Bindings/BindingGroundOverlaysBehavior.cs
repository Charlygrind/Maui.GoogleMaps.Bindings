using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;
using System.Collections.ObjectModel;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class BindingGroundOverlaysBehavior : BehaviorBase<MauiMap>
    {
        private static readonly BindablePropertyKey ValuePropertyKey = BindableProperty.CreateReadOnly("Value", typeof(ObservableCollection<GroundOverlay>), typeof(BindingGroundOverlaysBehavior), default(ObservableCollection<GroundOverlay>));

        public static readonly BindableProperty ValueProperty = ValuePropertyKey.BindableProperty;
        public ObservableCollection<GroundOverlay> Value
        {
            get => (ObservableCollection<GroundOverlay>)GetValue(ValueProperty);
            private set => SetValue(ValuePropertyKey, value);
        }

        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            Value = bindable.GroundOverlays as ObservableCollection<GroundOverlay>;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            Value = null;
        }
    }
}
