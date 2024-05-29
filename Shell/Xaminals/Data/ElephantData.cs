using Xaminals.Models;

namespace Xaminals.Data
{
    public static class ElephantData
    {
        public static IList<VoceMenuPersonalizzato> Elephants { get; private set; }

        static ElephantData()
        {
            Elephants = new List<VoceMenuPersonalizzato>();

            Elephants.Add(new VoceMenuPersonalizzato
            {
                Name = "African Bush Elephant",
                Location = "Africa",
                Details = "The African bush elephant, also known as the African savanna elephant, is the larger of the two species of African elephants, and the largest living terrestrial animal. These elephants were previously regarded as the same species, but the African forest elephant has been reclassified as L. cyclotis.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/African_Elephant_%28Loxodonta_africana%29_bull_%2831100819046%29.jpg/320px-African_Elephant_%28Loxodonta_africana%29_bull_%2831100819046%29.jpg"
            });

            Elephants.Add(new VoceMenuPersonalizzato
            {
                Name = "African Forest Elephant",
                Location = "Africa",
                Details = "The African forest elephant is a forest-dwelling species of elephant found in the Congo Basin. It is the smallest of the three extant species of elephant, but still one of the largest living terrestrial animals. The African forest elephant and the African bush elephan  were considered to be one species until genetic studies indicated that they separated an estimated 2–7 million years ago. From an estimated population size of over 2 million prior to the colonization of Africa, the population in 2015 is estimated to be about 100,000 forest elephants, mostly living in the forests of Gabon. Due to a slower birth rate, the forest elephant takes longer to recover from poaching, which caused its population to fall by 65% from 2002 to 2014.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/6a/African_Forest_Elephant.jpg"
            });

            
        }
    }
}


