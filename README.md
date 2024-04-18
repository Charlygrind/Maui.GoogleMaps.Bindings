## Maui.GoogleMaps.Bindings

Maps bindings library for MAUI.
Ported library from https://github.com/nuitsjp/Xamarin.Forms.GoogleMaps.Bindings/tree/master to net maui 

This library has dependency on https://github.com/themronion/Maui.GoogleMaps, and have to be installed or referenced and configures before

This library allows to interact with the map behaviors.


Could need following packages 

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
