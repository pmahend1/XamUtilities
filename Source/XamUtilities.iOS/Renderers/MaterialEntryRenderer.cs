using MaterialComponents;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(XamUtilities.Views.Material.TextFields.MaterialEntry), typeof(XamUtilities.iOS.Renderers.MaterialEntryRenderer))]

namespace XamUtilities.iOS.Renderers
{
    public class MaterialEntryRenderer:ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            SetNativeControl(new TextField());
        }
    }
}