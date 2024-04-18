using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;
using System.Collections.ObjectModel;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class BindingPolylinesBehavior : BehaviorBase<MauiMap>
    {
        private static readonly BindablePropertyKey ValuePropertyKey = BindableProperty.CreateReadOnly("Value", typeof(ObservableCollection<Polyline>), typeof(BindingPolylinesBehavior), default(ObservableCollection<Polyline>));

        public static readonly BindableProperty ValueProperty = ValuePropertyKey.BindableProperty;
        public ObservableCollection<Polyline> Value
        {
            get => (ObservableCollection<Polyline>)GetValue(ValueProperty);
            set => SetValue(ValuePropertyKey, value);
        }

        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            Value = bindable.Polylines as ObservableCollection<Polyline>;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            Value = null;
        }
    }
}