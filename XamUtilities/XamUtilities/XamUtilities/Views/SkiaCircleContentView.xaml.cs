using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamUtilities.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkiaCircleContentView : AbsoluteLayout
    {

        public SkiaCircleContentView()
        {
            InitializeComponent();

            SizeChanged += SkiaCircleContentView_SizeChanged;

            contentView.SizeChanged += ContentView_SizeChanged;

        }

        private void SkiaCircleContentView_SizeChanged(object sender, EventArgs e)
        {
            var thisview = sender as AbsoluteLayout;
            var parent = Parent as View;
            double diameter = Math.Min(thisview.Height, thisview.Width);
            if (diameter > parent.Width)
                diameter = thisview.Width;
            skCanvasView.WidthRequest = diameter;
            skCanvasView.HeightRequest = diameter;
        }

        private void ContentView_SizeChanged(object sender, EventArgs e)
        {
            var baseContentView = sender as ContentView;
            var parent = Parent as View;
            double diameter = Math.Min(baseContentView.Height, baseContentView.Width);
            if (diameter > parent.Width)
                diameter = baseContentView.Width;
            skCanvasView.WidthRequest = diameter;
            skCanvasView.HeightRequest = diameter;


        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(propertyName: nameof(BorderColor),
                                                                                           returnType: typeof(Color),
                                                                                           declaringType: typeof(SkiaCircleContentView),
                                                                                           defaultValue: Color.Transparent);


        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(propertyName: nameof(BorderWidth),
                                                                                   returnType: typeof(float),
                                                                                   declaringType: typeof(SkiaCircleContentView),
                                                                                   defaultValue: ((float)0.0));


        public float BorderWidth
        {

            get { return (float)GetValue(BorderWidthProperty); }
            set
            {
                var value_ = (float)value;
                SetValue(BorderWidthProperty, value_);
            }
        }

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {

            var info = e.Info;
            var canvas = e.Surface.Canvas;
            canvas.Clear();

            if (BackgroundColor != Color.Transparent)
            {
                var fillpaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,

                    Color = BackgroundColor.ToSKColor(),

                };
                var fillradius = Math.Min(info.Width, info.Height) / 2;
                canvas.DrawCircle(info.Width / 2, info.Height / 2, fillradius, fillpaint);
            }
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = BorderColor.ToSKColor(),
                StrokeWidth = (float)BorderWidth,
            };
            var radius = (Math.Min(info.Width, info.Height) / 2) - paint.StrokeWidth;
            canvas.DrawCircle(info.Width / 2, info.Height / 2, radius, paint);




        }

        public static readonly BindableProperty BaseContentViewProperty = BindableProperty.Create(propertyName: nameof(BaseContentView),
                                                                                   returnType: typeof(View),
                                                                                   declaringType: typeof(SkiaCircleContentView),
                                                                                   defaultValue: default(View),
                                                                                   propertyChanged: OnBaseContentViewChanged);

        private static void OnBaseContentViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view_ = (View)newValue;

            var skia = bindable as AbsoluteLayout;

            var contentview = skia.Children[1] as ContentView;

          
            contentview.Content = view_;
        }

        public View BaseContentView
        {
            get { return (View)GetValue(BaseContentViewProperty); }
            set
            {

                SetValue(BaseContentViewProperty, value);
                contentView.Content = value;
            }
        }

        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(propertyName: nameof(BackgroundColor),
                                                                                         returnType: typeof(Color),
                                                                                         declaringType: typeof(SkiaCircleContentView),
                                                                                         defaultValue: Color.Transparent);


        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

    }
}