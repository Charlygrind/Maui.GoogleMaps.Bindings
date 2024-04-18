using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.GoogleMaps;
using Maui.GoogleMaps.Bindings;
using MauiGoogleMapBehaviorsSample.ViewModels.Base;
using System.Collections.ObjectModel;

namespace MauiGoogleMapBehaviorsSample.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        
        public HomeViewModel()
        {
            
        }

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private MoveCameraRequest moveCameraRequest;

        [ObservableProperty]
        public MapSpan visibleRegion;

        [ObservableProperty]
        private MoveToRegionRequest moveToRegionRequest;

        public ObservableCollection<Pin> Pins { get; set; }

        [RelayCommand]
        private async Task MapClicked(MapClickedEventArgs e)
        {
            try
            {
                double Latitude = Convert.ToDouble(e.Point.Latitude);
                double Longitude = Convert.ToDouble(e.Point.Longitude);


                var placemarks = await Geocoding.GetPlacemarksAsync(Latitude, Longitude);
                var placemark = placemarks?.FirstOrDefault();

                string dCountry = placemark.CountryName;
                string dState = placemark.AdminArea;
                string dLocation = placemark.Locality;
                string dColony = placemark.SubLocality == null ? "N/A" : placemark.SubLocality;
                string dNumExt = placemark.FeatureName != null || placemark.FeatureName != "" ? placemark.FeatureName : "S/N";
                string dStreet = placemark.Thoroughfare;
                string dPostalCode = placemark.PostalCode;
                if (placemark != null)
                {
                    dCountry = placemark.CountryName;
                    dState = placemark.AdminArea;
                    dLocation = placemark.Locality;
                    dColony = placemark.SubLocality == null ? "N/A" : placemark.SubLocality;
                    dNumExt = placemark.FeatureName != null || placemark.FeatureName != "" ? placemark.FeatureName : "S/N";
                    dStreet = placemark.Thoroughfare;
                    dPostalCode = placemark.PostalCode;
                }

                Address = $"{dStreet} # {dNumExt}, {dLocation}, {dState}, {dCountry}, CP: {dPostalCode}";

                Position pos = new Position(Latitude, Longitude);
                Pin Point = new Pin
                {
                    IsVisible = true,
                    Position = pos,
                    Type = PinType.Place,
                    Label = Address,
                    InfoWindowAnchor = new Point(100, 100)

                };

                Pins.Add(Point);

                for (int index = 0; index < Pins.Count(); index++)
                {
                    var item = Pins[index];
                    Pins.Remove(item);
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            catch (Exception E)
            {
                string ErrorMsg = E.Message.ToString();
                string line = E.StackTrace.ToString();
                line = line.Substring(line.LastIndexOf(':') + 6);

#if DEBUG
                string ClassName = (new System.Diagnostics.StackTrace()).GetFrame(0).GetMethod().ReflectedType.DeclaringType.Name;
                string MethodName = (new System.Diagnostics.StackTrace()).GetFrame(0).GetMethod().ReflectedType.Name;

                await App.Current.MainPage.DisplayAlert("Error de no identificado", $"Ocurrio un error!  => {ClassName} => {MethodName} ({line})", "OK");
#else
                await App.Current.MainPage.DisplayAlert("Error de no identificado", $"Ocurrio un error!  => ({line})", "OK");
#endif
            }
        }

        public override async void OnDisappearing()
        {

        }
        public override async void OnAppearing(object navigationContext)
        {
            try
            {
                Position southwestBound = new Position(30.62229, -110.97107);
                Position northeastBound = new Position(26.9083913884255, -109.397419095039);

                var placemarks = await Geocoding.GetPlacemarksAsync(southwestBound.Latitude, southwestBound.Longitude);
                var placemark = placemarks?.FirstOrDefault();

                string dCountry = placemark.CountryName;
                string dState = placemark.AdminArea;
                string dLocation = placemark.Locality;
                string dColony = placemark.SubLocality == null ? "N/A" : placemark.SubLocality;
                string dNumExt = placemark.FeatureName != null || placemark.FeatureName != "" ? placemark.FeatureName : "S/N";
                string dStreet = placemark.Thoroughfare;
                string dPostalCode = placemark.PostalCode;
                if (placemark != null)
                {
                    dCountry = placemark.CountryName;
                    dState = placemark.AdminArea;
                    dLocation = placemark.Locality;
                    dColony = placemark.SubLocality == null ? "N/A" : placemark.SubLocality;
                    dNumExt = placemark.FeatureName != null || placemark.FeatureName != "" ? placemark.FeatureName : "S/N";
                    dStreet = placemark.Thoroughfare;
                    dPostalCode = placemark.PostalCode;
                }

                Address = $"{dStreet} # {dNumExt}, {dLocation}, {dState}, {dCountry}, CP: {dPostalCode}";

                Position pos = new Position(southwestBound.Latitude, southwestBound.Longitude);
                Pin Point = new Pin
                {
                    IsVisible = true,
                    Position = pos,
                    Type = PinType.Place,
                    Label = Address,
                    InfoWindowAnchor = new Point(100, 100)

                };
                Pins.Add(Point);

                var bounds = new Bounds(southwestBound, northeastBound);
                VisibleRegion = MapSpan.FromBounds(bounds);

                MoveToRegionRequest = new MoveToRegionRequest();
                MoveToRegionRequest.MoveToRegion(VisibleRegion, true);

            }
            catch (Exception E)
            {
                string ErrorMsg = E.Message.ToString();
                string line = E.StackTrace.ToString();
                line = line.Substring(line.LastIndexOf(':') + 6);

#if DEBUG
                string ClassName = (new System.Diagnostics.StackTrace()).GetFrame(0).GetMethod().ReflectedType.DeclaringType.Name;
                string MethodName = (new System.Diagnostics.StackTrace()).GetFrame(0).GetMethod().ReflectedType.Name;

                await App.Current.MainPage.DisplayAlert("Error de no identificado", $"Ocurrio un error!  => {ClassName} => {MethodName} ({line})", "OK");
#else
                await App.Current.MainPage.DisplayAlert("Error de no identificado", $"Ocurrio un error!  => ({line})", "OK");
#endif
            }
        }
    }
}