using Xaminals.Models;

namespace Xaminals.Data
{
    public static class MonkeyData
    {
        public static IList<VoceMenuPersonalizzato> Monkeys { get; private set; }

        static MonkeyData()
        {
            Monkeys = new List<VoceMenuPersonalizzato>();

            Monkeys.Add(new VoceMenuPersonalizzato
            {
                Name = "Baboon",
                Location = "Africa & Asia",
                Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            });

            Monkeys.Add(new VoceMenuPersonalizzato
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
            });
        }
    }
}
