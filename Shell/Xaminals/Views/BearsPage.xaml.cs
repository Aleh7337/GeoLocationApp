using Xaminals.Models;

namespace Xaminals.Views
{
    public partial class BearsPage : ContentPage
    {
        public BearsPage()
        {
            InitializeComponent();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VoceMenuPersonalizzato animal = e.CurrentSelection.FirstOrDefault() as VoceMenuPersonalizzato;

            var navigationParameter = new Dictionary<string, object>
            {
                { "Bear", animal }
            };
            await Shell.Current.GoToAsync($"beardetails", navigationParameter);
        }
    }
}
