using Xaminals.Models;

namespace Xaminals.Views
{
    public partial class ElephantsPage : ContentPage
    {
        public ElephantsPage()
        {
            InitializeComponent();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VoceMenuPersonalizzato animal = e.CurrentSelection.FirstOrDefault() as VoceMenuPersonalizzato;
            string elephantName = animal.Name;

            var navigationParameter = new Dictionary<string, object>
            {
                { "Elephant", animal }
            };

            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"elephantdetails?name={elephantName}", navigationParameter);
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/elephants/elephantdetails?name={elephantName}");
        }
    }
}
