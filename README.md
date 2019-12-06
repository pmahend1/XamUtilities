# XamUtilities
Utilities for Xamarin Forms

## Release notes

### Version 1.0.0

- RoundFrame added

## Guide

Add nuget to your Xamarin forms project

```xml

<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:ref="clr-namespace:XamUtilities.Views;assembly=XamUtilities"
             x:Class="XamUtilities.Sample.MainPage">
    <StackLayout HorizontalOptions="CenterAndExpand"
                 Padding="25">
        <ref:RoundFrame Diameter="150"
                        BackgroundColor="Blue">
            <Label Text="Round Frame"
                   TextColor="White"
                   HorizontalTextAlignment="Center"
                   VerticalTextAlignment="Center"
                   HorizontalOptions="Center"
                   VerticalOptions="Center" />
        </ref:RoundFrame>
        <ref:RoundFrame HeightRequest="175"
                        d:CornerRadius="87.5"
                        BackgroundColor="Red">
            <Label Text="Round Frame"
                   TextColor="White"
                   HorizontalTextAlignment="Center"
                   VerticalTextAlignment="Center"
                   HorizontalOptions="Center"
                   VerticalOptions="Center" />
        </ref:RoundFrame>
        <ref:RoundFrame WidthRequest="125"
                        HeightRequest="125"
                        HorizontalOptions="Center"
                        d:CornerRadius="62.5"
                        BackgroundColor="Green">
            <Label Text="Round Frame"
                   TextColor="White"
                   HorizontalTextAlignment="Center"
                   VerticalTextAlignment="Center"
                   HorizontalOptions="Center"
                   VerticalOptions="Center" />
        </ref:RoundFrame>
    </StackLayout>
</ContentPage>
```

## Screenshots

![RoundFrame](./ScreenShots/RoundFrame.png)