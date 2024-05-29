using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;
using Xaminals.Models;

namespace Xaminals.ViewModels
{
    public class MonkeyDetailViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public VoceMenuPersonalizzato Monkey { get; private set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Monkey = query["Monkey"] as VoceMenuPersonalizzato;
            OnPropertyChanged("Monkey");
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
