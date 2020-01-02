using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamUtilities.Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDHomePage : MasterDetailPage
    {
        public MDHomePage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is string item))
                return;
            ContentPage detail;
            switch (item)
            {
                case "RoundFrame":
                    detail = new MainPage();
                    break;
                case "SkiaCircleContentView":
                    detail = new SkiaCircleContentViewsPage();
                    break;
                default:
                    detail = new MainPage();
                    break;
            }
            Title = detail.Title;

            Detail = new NavigationPage(detail);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}