using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;
using System.ComponentModel;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    [Obsolete("Plese use BindingRegionBehavior.")]
    public class BindingVisibleRegionBehavior : BehaviorBase<MauiMap>
    {
        private static readonly BindablePropertyKey ValuePropertyKey = BindableProperty.CreateReadOnly("Value", typeof(MapSpan), typeof(BindingVisibleRegionBehavior), default(MapSpan));

        public static readonly BindableProperty ValueProperty = ValuePropertyKey.BindableProperty;
        public MapSpan Value
        {
            get => (MapSpan)GetValue(ValueProperty);
            private set => SetValue(ValuePropertyKey, value);
        }

        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.PropertyChanged += MapOnPropertyChanged;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            bindable.PropertyChanged -= MapOnPropertyChanged;
            base.OnDetachingFrom(bindable);
        }

        private void MapOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "VisibleRegion")
            {
                Value = AssociatedObject.VisibleRegion;
            }
        }
    }
}
