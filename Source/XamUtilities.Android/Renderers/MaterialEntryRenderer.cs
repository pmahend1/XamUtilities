using Android.Content;
using Google.Android.Material.TextField;
using System.ComponentModel;
using Xamarin.Forms;

using Xamarin.Forms.Platform.Android;

using XamUtilities.Views.Material.TextFields;

[assembly: ExportRenderer(typeof(XamUtilities.Views.Material.TextFields.MaterialEntry), typeof(XamUtilities.Droid.Renderers.MaterialEntryRenderer))]

namespace XamUtilities.Droid.Renderers
{
    public class MaterialEntryRenderer : ViewRenderer<MaterialEntry, TextInputLayout>
    {
        private MaterialEntry FormsView;

        public MaterialEntryRenderer(Context context) : base(context)
        {
            System.Diagnostics.Debug.WriteLine("here");
        }


        protected override void OnElementChanged(ElementChangedEventArgs<MaterialEntry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement is null)
                return;
            FormsView = e.NewElement as MaterialEntry;

            var view = CreateNativeControl();
            SetNativeControl(view);

        }


        protected override TextInputLayout CreateNativeControl()
        {
            var _TextInputLayout = new TextInputLayout(Context) { Hint = "Hint" };
            _TextInputLayout.AddView(new TextInputEditText(Context));
            var lp = _TextInputLayout.LayoutParameters;
            lp.Width = 300;
            lp.Height = 100;
            return _TextInputLayout;
            // return base.CreateNativeControl();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);
        }

        
    }
}