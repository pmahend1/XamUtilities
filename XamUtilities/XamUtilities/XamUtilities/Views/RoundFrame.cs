using System;
using Xamarin.Forms;

namespace XamUtilities.Views
{

    public class RoundFrame : Frame
    {
        public RoundFrame()
        {
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            IsClippedToBounds = true;

            SizeChanged += RoundFrame_SizeChanged;
        }

        protected override void OnSizeAllocated(double width, double height)
        {

            base.OnSizeAllocated(width, height);

        }

        private void RoundFrame_SizeChanged(object sender, EventArgs e)
        {
            var roundframe = sender as Frame;

            if (roundframe.HeightRequest - roundframe.WidthRequest < 0)
            {

                roundframe.HeightRequest = roundframe.WidthRequest;

            }
            else if (roundframe.HeightRequest - roundframe.WidthRequest > 0)
            {
                roundframe.WidthRequest = roundframe.HeightRequest;
            }

            else
            {
                roundframe.CornerRadius = (float)roundframe.Width / 2;
            }


        }

        public static readonly BindableProperty DiameterProperty = BindableProperty.Create(propertyName: nameof(Diameter),
                                                                                            returnType: typeof(float),
                                                                                            declaringType: typeof(Frame),
                                                                                            defaultValue: (float)0.0,
                                                                                            propertyChanged: OnDiameterChanged);

        private static void OnDiameterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var diameter = (float)newValue;
            var frame = bindable as Frame;
            frame.HeightRequest = diameter;
            frame.WidthRequest = diameter;
            frame.CornerRadius = diameter / 2;
        }

        public float Diameter
        {
            get { return (float)GetValue(DiameterProperty); }
            set { SetValue(DiameterProperty, value); }
        }
    }

}
