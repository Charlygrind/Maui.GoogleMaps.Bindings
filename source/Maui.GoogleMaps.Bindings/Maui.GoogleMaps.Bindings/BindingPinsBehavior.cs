using MauiMap =  Maui.GoogleMaps.Map;
using System.Collections.ObjectModel;
using Maui.GoogleMaps;

namespace Maui.GoogleMaps.Bindings
{
    ////[Foundation.Preserve(AllMembers = true)]
    public class BindingPinsBehavior : BehaviorBase<MauiMap>
    {
        private static readonly BindablePropertyKey ValuePropertyKey = BindableProperty.CreateReadOnly(
            "Value",
            typeof(ObservableCollection<Pin>),
            typeof(BindingPinsBehavior),
            default(ObservableCollection<Pin>));

        public static readonly BindableProperty ValueProperty = ValuePropertyKey.BindableProperty;
        public ObservableCollection<Pin> Value
        {
            get => (ObservableCollection<Pin>)GetValue(ValueProperty);
            set => SetValue(ValuePropertyKey, value);
        }

        protected override void OnAttachedTo(Maui.GoogleMaps.Map bindable)
        {
            base.OnAttachedTo(bindable);
            Value = bindable.Pins as ObservableCollection<Pin>;
        }

        protected override void OnDetachingFrom(Maui.GoogleMaps.Map bindable)
        {
            base.OnDetachingFrom(bindable);
            Value = null;
        }
    }
}