using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;
using System.Collections.ObjectModel;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class BindingPolygonsBehavior : BehaviorBase<MauiMap>
    {
        private static readonly BindablePropertyKey ValuePropertyKey = BindableProperty.CreateReadOnly("Value", typeof(ObservableCollection<Polygon>), typeof(BindingPolygonsBehavior), default(ObservableCollection<Polygon>));

        public static readonly BindableProperty ValueProperty = ValuePropertyKey.BindableProperty;
        public ObservableCollection<Polygon> Value
        {
            get => (ObservableCollection<Polygon>)GetValue(ValueProperty);
            private set => SetValue(ValuePropertyKey, value);
        }

        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            Value = bindable.Polygons as ObservableCollection<Polygon>;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            Value = null;
        }
    }
}
