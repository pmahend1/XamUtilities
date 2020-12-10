using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;
using XamUtilities.Internal;

namespace XamUtilities.Views
{
    public class DateEntry: Entry
    {
        public static readonly BindableProperty FormatProperty  = BindableProperty.Create(propertyName: nameof(Format),
                                                                                          returnType: typeof(string),
                                                                                          declaringType: typeof(DateEntry),
                                                                                          defaultValue: CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);

        public string Format
        {
            get { return (string)GetValue(FormatProperty); }
            set { SetValue(FormatProperty, value); }
        }

        private static string DefaultCreator(BindableObject bindable)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        }

        public DateEntry()
        {
            Debug.WriteLine(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            Placeholder = Format;
            this.Behaviors.Add(new DateEntryBehavior());
        }
    }
}
