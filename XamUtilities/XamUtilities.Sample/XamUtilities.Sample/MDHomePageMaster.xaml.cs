
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamUtilities.Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDHomePageMaster : ContentPage
    {
        public ListView ListView;

        public MDHomePageMaster()
        {
            InitializeComponent();

            ListView = MenuItemsListView;
        }
    }
}