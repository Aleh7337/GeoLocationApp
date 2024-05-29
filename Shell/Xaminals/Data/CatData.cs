using Xaminals.Models;

namespace Xaminals.Data
{
    public static class CatData
    {
        public static IList<VoceMenuPersonalizzato> Cats { get; private set; }

        static CatData()
        {
            Cats = new List<VoceMenuPersonalizzato>();
            Entry miaConnettiEntry = new Entry();
            miaConnettiEntry.Text = "127.0.0.1";
            Button OKBtn = new Button();
            Cats.Add(new VoceMenuPersonalizzato
            {
                Name = "Connetti",
                Location = "Server Centrale",
                Details = "",
                ImageUrl = "server.png",
                IndirizzoServer = miaConnettiEntry,
                OkButton=OKBtn
            });
            
        }
    }
}
