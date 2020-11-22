using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using XamUtilities.Droid;
using XamUtilities.Views;
[assembly:ExportRenderer(typeof(EntryDatePickerRenderer),typeof(EntryDatePicker))]
namespace XamUtilities.Droid
{
    public class EntryDatePickerRenderer: ViewRenderer<EntryDatePicker, Android.Widget.DatePicker>
    {
        private readonly Context _Context;
        public EntryDatePickerRenderer(Context context): base(context)
        {
            _Context = context;
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<EntryDatePicker> e)
        {
            if(e.NewElement is null)
            {
                return;
            }
            SetNativeControl(new Android.Widget.DatePicker(this._Context));
            base.OnElementChanged(e);
        }
    }
}