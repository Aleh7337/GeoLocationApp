using Xaminals.Models;

namespace Xaminals.Views
{
    public partial class MonkeysPage : ContentPage
    {
        public MonkeysPage()
        {
            InitializeComponent();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VoceMenuPersonalizzato animal = e.CurrentSelection.FirstOrDefault() as VoceMenuPersonalizzato;
            var navigationParameters = new Dictionary<string, object>
            {
                { "Monkey", animal }
            };
            await Shell.Current.GoToAsync($"monkeydetails", navigationParameters);
        }
    }
}
