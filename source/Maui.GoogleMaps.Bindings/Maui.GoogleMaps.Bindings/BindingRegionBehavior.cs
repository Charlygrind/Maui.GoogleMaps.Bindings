using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;
using System.ComponentModel;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class BindingRegionBehavior : BehaviorBase<MauiMap>
    {
        private static readonly BindablePropertyKey ValuePropertyKey = 
            BindableProperty.CreateReadOnly(
                "Value", 
                typeof(MapRegion), 
                typeof(BindingRegionBehavior), 
                default(MapRegion));

        public static readonly BindableProperty ValueProperty = ValuePropertyKey.BindableProperty;

        public MapRegion Value
        {
            get => (MapRegion)GetValue(ValueProperty);
            set => SetValue(ValuePropertyKey, value);
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
            if (args.PropertyName == "Region")
            {
                Value = AssociatedObject.Region;
            }
        }
    }
}
