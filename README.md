# XamUtilities

<img src="https://raw.githubusercontent.com/pmahend1/XamUtilities/master/Images/icon.png" width="200">

Utilities for Xamarin Forms

**[Nuget XamUtilities.1.1.0](https://www.nuget.org/packages/XamUtilities/)**

## Release notes

### Version 1.1.0

- SkiaCircleContentView added

### Version 1.0.0

- RoundFrame added

## Guide

Add nuget to your Xamarin forms project

### RoundFrame

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

<img src="https://raw.githubusercontent.com/pmahend1/XamUtilities/master/Images/Screenshot_roundframe.png" width="300">

### SkiaCircleContentView

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:ref="clr-namespace:XamUtilities.Views;assembly=XamUtilities"
             mc:Ignorable="d"
             x:Class="XamUtilities.Sample.SkiaCircleContentViewsPage"
             Title="SkiaCircleContentView">
    <ContentPage.Content>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="1*" />
                <RowDefinition Height="1*" />
            </Grid.RowDefinitions>
            <ref:SkiaCircleContentView BorderColor="Red"
                                       BorderWidth="10"
                                       Grid.Row="0">
                <ref:SkiaCircleContentView.BaseContentView>
                    <Label Text="I am inside SkiaCanvas"
                           TextColor="Blue"
                           FontSize="Medium"
                           LineBreakMode="WordWrap"
                           HorizontalOptions="Center"
                           VerticalOptions="Center"
                           HorizontalTextAlignment="Center"
                           VerticalTextAlignment="Center" />
                </ref:SkiaCircleContentView.BaseContentView>
            </ref:SkiaCircleContentView>
            <ref:SkiaCircleContentView BorderColor="Blue"
                                       BackgroundColor="Yellow"
                                       BorderWidth="5"
                                       Grid.Row="1">
                <ref:SkiaCircleContentView.BaseContentView>
                    <Image Source="xamutilities.png"
                           HeightRequest="125"
                           WidthRequest="125" />
                </ref:SkiaCircleContentView.BaseContentView>
            </ref:SkiaCircleContentView>
        </Grid>
    </ContentPage.Content>
</ContentPage>
```

<img src="https://raw.githubusercontent.com/pmahend1/XamUtilities/master/Images/Screenshot_SkiaCircleContentView.png" width="300">
