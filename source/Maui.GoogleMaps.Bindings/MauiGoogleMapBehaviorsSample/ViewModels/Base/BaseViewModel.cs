using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiGoogleMapBehaviorsSample.ViewModels.Base
{
    public class BaseViewModel : ObservableObject
    {
        public virtual void OnAppearing(object navigationContext)
        {
        }

        public virtual void OnDisappearing()
        {
        }
    }

}
