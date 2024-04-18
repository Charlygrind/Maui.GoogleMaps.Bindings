## ![Logo](https://github.com/Charlygrind/Maui.GoogleMaps.Bindings/blob/main/source/Maui.GoogleMaps.Bindings/Maui.GoogleMaps.Bindings/logo.png?raw=true) Maui.GoogleMaps.Bindings

Maps bindings library for MAUI. This library allows to interact with the map behaviors and MVVM bindings.

Ported library from https://github.com/nuitsjp/Xamarin.Forms.GoogleMaps.Bindings to net maui 

This library has dependency on https://github.com/themronion/Maui.GoogleMaps, and have to be installed or referenced and configured before

Could need following packages on android

```csharp
<ItemGroup Condition="'$(TargetFramework)' == 'net8.0-android'">
  <PackageReference Include="Xamarin.AndroidX.Collection">
    <Version>1.4.0.2</Version>
  </PackageReference>
  <PackageReference Include="Xamarin.AndroidX.Collection.Jvm">
    <Version>1.4.0.1</Version>
  </PackageReference>
  <PackageReference Include="Xamarin.AndroidX.Collection.Ktx">
    <Version>1.4.0.1</Version>
  </PackageReference>
</ItemGroup>
```

# Usage
```csharp
  <!--Reference for custom map control-->
  xmlns:Maps="clr-namespace:Maui.GoogleMaps;assembly=Maui.GoogleMaps"

  <!--Reference for map bindings-->
  xmlns:MapsBehavior="clr-namespace:Maui.GoogleMaps.Bindings;assembly=CHGX6.Maui.GoogleMaps.Bindings"

<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    x:Class="MauiGoogleMapBehaviorsSample.Pages.HomePage"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:Maps="clr-namespace:Maui.GoogleMaps;assembly=Maui.GoogleMaps"
    xmlns:MapsBehavior="clr-namespace:Maui.GoogleMaps.Bindings;assembly=CHGX6.Maui.GoogleMaps.Bindings"
    Title="MauiGoogleMapBehaviorsSample"
    BackgroundColor="#fafafa">
    <StackLayout>
        <Label
            FontSize="Small"
            HorizontalOptions="StartAndExpand"
            TextColor="Gray">
            <Label.FormattedText>
                <FormattedString>
                    <Span Text="{Binding Address}" />
                </FormattedString>
            </Label.FormattedText>
        </Label>
        <Maps:Map
            x:Name="Map"
            ItemsSource="{Binding Pins}"
            VerticalOptions="FillAndExpand">
            <Maps:Map.Behaviors>
                <MapsBehavior:BindingPinsBehavior Value="{Binding Pins}" />
                <MapsBehavior:MapClickedToCommandBehavior Command="{Binding MapClickedCommand}" />
                <MapsBehavior:MoveToRegionBehavior Request="{Binding MoveToRegionRequest}" />
                <MapsBehavior:BindingRegionBehavior Value="{Binding VisibleRegion}" />
            </Maps:Map.Behaviors>
        </Maps:Map>
    </StackLayout>
</ContentPage>
```
(TESTED ON ANDROID)
