using Maui.GoogleMaps;
using MauiMap =  Maui.GoogleMaps.Map;
using System.Collections.ObjectModel;

namespace Maui.GoogleMaps.Bindings
{
    //[Foundation.Preserve(AllMembers = true)]
    public sealed class BindingCirclesBehavior : BehaviorBase<MauiMap>
    {
        private static readonly BindablePropertyKey ValuePropertyKey = BindableProperty.CreateReadOnly("Value", typeof(ObservableCollection<Circle>), typeof(BindingCirclesBehavior), default(ObservableCollection<Circle>));

        public static readonly BindableProperty ValueProperty = ValuePropertyKey.BindableProperty;
        public ObservableCollection<Circle> Value
        {
            get => (ObservableCollection<Circle>)GetValue(ValueProperty);
            private set => SetValue(ValuePropertyKey, value);
        }

        protected override void OnAttachedTo(MauiMap bindable)
        {
            base.OnAttachedTo(bindable);
            Value = bindable.Circles as ObservableCollection<Circle>;
        }

        protected override void OnDetachingFrom(MauiMap bindable)
        {
            base.OnDetachingFrom(bindable);
            Value = null;
        }
    }
}
