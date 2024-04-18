using System.Windows.Input;
using MauiMap =  Maui.GoogleMaps.Map;
namespace Maui.GoogleMaps.Bindings
{
    public abstract class EventToCommandBehaviorBase : BehaviorBase<MauiMap>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(MapClickedToCommandBehavior), default(ICommand));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        internal EventToCommandBehaviorBase()
        {
        }
    }
}
