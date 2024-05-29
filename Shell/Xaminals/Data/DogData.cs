using Xaminals.Models;

namespace Xaminals.Data
{
    public static class DogData
    {
        public static IList<VoceMenuPersonalizzato> Dogs { get; private set; }

        static DogData()
        {
            Dogs = new List<VoceMenuPersonalizzato>();
            Entry EntryTx = new Entry();
            EntryTx.Text = "Invia";
            Button InviaBtn = new Button();
            Dogs.Add(new VoceMenuPersonalizzato
            {
                Name = "Invia",
                Location = "Server Centrale",
                Details = "",
                ImageUrl = "invia.png",
                IndirizzoServer = EntryTx,
                OkButton = InviaBtn
            }) ;

        }
    }
}


