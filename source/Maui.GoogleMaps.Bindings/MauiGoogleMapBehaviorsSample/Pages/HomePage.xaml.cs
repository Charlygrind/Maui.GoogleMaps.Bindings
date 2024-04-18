using MauiGoogleMapBehaviorsSample.ViewModels;

namespace MauiGoogleMapBehaviorsSample.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage(HomeViewModel viewModel) : base()
        {
            this.BindingContext = viewModel;
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
        protected override void OnAppearing()
        {
            if (BindingContext is HomeViewModel viewModel) viewModel.OnAppearing(this.BindingContext);
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            if (BindingContext is HomeViewModel viewModel) viewModel.OnDisappearing();
            base.OnDisappearing();
        }
    }
}