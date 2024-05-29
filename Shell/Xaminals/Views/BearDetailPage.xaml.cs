using Xaminals.Models;

namespace Xaminals.Views
{
    [QueryProperty(nameof(Bear), "Bear")]
    public partial class BearDetailPage : ContentPage
    {
        VoceMenuPersonalizzato bear;
        public VoceMenuPersonalizzato Bear
        {
            get => bear;
            set
            {
                bear = value;
                OnPropertyChanged();
            }
        }

        public BearDetailPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
