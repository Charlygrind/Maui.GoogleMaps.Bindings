using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;
using System.Collections.ObjectModel;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class BindingTileLayersBehavior : BehaviorBase<MauiMap>
    {
        private static readonly BindablePropertyKey ValuePropertyKey = BindableProperty.CreateReadOnly("Value", typeof(ObservableCollection<TileLayer>), typeof(BindingTileLayersBehavior), default(ObservableCollection<TileLayer>));

        public static readonly BindableProperty ValueProperty = ValuePropertyKey.BindableProperty;
        public ObservableCollection<TileLayer> Value
        {
            get => (ObservableCollection<TileLayer>)GetValue(ValueProperty);
            private set => SetValue(ValuePropertyKey, value);
        }

        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            Value = bindable.TileLayers as ObservableCollection<TileLayer>;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            Value = null;
        }
    }
}
