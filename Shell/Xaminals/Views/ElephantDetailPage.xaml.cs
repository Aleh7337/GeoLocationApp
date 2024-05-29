using Xaminals.Models;

namespace Xaminals.Views
{
    [QueryProperty(nameof(Name), "name")]
    [QueryProperty(nameof(Elephant), "Elephant")]
    public partial class ElephantDetailPage : ContentPage
    {
        public string Name { get; set; }

        VoceMenuPersonalizzato elephant;
        public VoceMenuPersonalizzato Elephant
        {
            get => elephant;
            set
            {
                elephant = value;
                OnPropertyChanged();
            }
        }

        public ElephantDetailPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
