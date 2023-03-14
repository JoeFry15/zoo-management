using System.Collections.Generic;
using System.Linq;
using zoo_mgmt.Models.Database;
using System;
using zoo_mgmt.Repositories;

namespace zoo_mgmt.Data
{
    public static class SampleAnimals
    {
        public const int NumberOfAnimals = 55;

        private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> { "Leo", "Lion", "Mammal ", "Male", "1 Feb 2000", "4 June 2020" },
            new List<string> { "Gary", "Giraffe", "Mammal", "Female", "2 March 2005", "4 April 2021"},
            new List<string> {"Simba", "Lion", "Mammal", "Male", "3 Sep 2014", "8 Dec 2021"},
            new List<string> {"Elsa", "Lioness", "Mammal", "Female", "15 Nov 2016", "2 Jan 2022"},
            new List<string> {"Baloo", "Sloth Bear", "Mammal", "Male", "10 May 2013", "20 Sep 2021"},
            new List<string> {"Rani", "Sloth Bear", "Mammal", "Female", "25 Mar 2015", "12 Oct 2021"},
            new List<string> {"Koda", "Grizzly Bear", "Mammal", "Male", "19 Jul 2017", "3 Mar 2022"},
            new List<string> {"Nova", "Grizzly Bear", "Mammal", "Female", "7 Sep 2018", "12 Apr 2022"},
            new List<string> {"Max", "Chimpanzee", "Mammal", "Male", "2 Jan 2005", "29 Nov 2021"},
            new List<string> {"Maya", "Chimpanzee", "Mammal", "Female", "14 Feb 2006", "15 Jan 2022"},
            new List<string> {"Blue", "Gorilla", "Mammal", "Male", "12 Aug 2010", "4 Feb 2022"},
            new List<string> {"Kiki", "Gorilla", "Mammal", "Female", "21 Apr 2012", "21 Mar 2022"},
            new List<string> {"Marley", "Orangutan", "Mammal", "Male", "30 Oct 2011", "1 Apr 2022"},
            new List<string> {"Mira", "Orangutan", "Mammal", "Female", "17 Jul 2013", "11 May 2022"},
            new List<string> {"Flash", "Cheetah", "Mammal", "Male", "20 Dec 2016", "20 Jun 2022"},
            new List<string> {"Cleo", "Cheetah", "Mammal", "Female", "5 Jun 2018", "7 Jul 2022"},
            new List<string> {"Zeus", "Tiger", "Mammal", "Male", "23 Jan 2015", "1 Sep 2022"},
            new List<string> {"Nala", "Tiger", "Mammal", "Female", "11 Jul 2017", "11 Oct 2022"},
            new List<string> {"Bongo", "Giraffe", "Mammal", "Male", "18 Aug 2013", "17 Nov 2022"},
            new List<string> {"Kiki", "Giraffe", "Mammal", "Female", "26 Oct 2015", "26 Dec 2022"},
            new List<string> {"Ellie", "Elephant", "Mammal", "Female", "3 Jun 2010", "31 Jan 2023"},
            new List<string> {"Raju", "Elephant", "Mammal", "Male", "12 Nov 2006", "21 Feb 2023"},
            new List<string> {"Spike", "Bearded Dragon", "Reptile", "Male", "14 Jan 2017", "20 Nov 2021"},
            new List<string> {"Lizzy", "Bearded Dragon", "Reptile", "Female", "3 Mar 2018", "7 Jan 2022"},
            new List<string> {"Ralph", "Green Iguana", "Reptile", "Male", "5 Jun 2015", "11 Apr 2022"},
            new List<string> {"Jade", "Green Iguana", "Reptile", "Female", "12 Dec 2016", "23 May 2022"},
            new List<string> {"Rex", "Komodo Dragon", "Reptile", "Male", "29 Aug 2013", "14 Jul 2022"},
            new List<string> {"Kara", "Komodo Dragon", "Reptile", "Female", "4 Nov 2014", "28 Aug 2022"},
            new List<string> {"Sandy", "Leopard Gecko", "Reptile", "Female", "10 Feb 2019", "8 Sep 2022"},
            new List<string> {"Leo", "Leopard Gecko", "Reptile", "Male", "18 Jul 2020", "11 Oct 2022"},
            new List<string> {"Ziggy", "Chameleon", "Reptile", "Male", "21 Jan 2016", "12 Nov 2022"},
            new List<string> {"Lila", "Chameleon", "Reptile", "Female", "7 Apr 2017", "21 Dec 2022"},
            new List<string> {"Rocky", "Red Eared Slider Turtle", "Reptile", "Male", "29 Jun 2008", "15 Jan 2023"},
            new List<string> {"Tina", "Red Eared Slider Turtle", "Reptile", "Female", "2 Sep 2010", "28 Feb 2023"},
            new List<string> {"Sasha", "Ball Python", "Reptile", "Female", "8 Dec 2016", "20 Mar 2023"},
            new List<string> {"Charlie", "Bald Eagle", "Bird", "Male", "1 Jan 2017", "6 Nov 2021"},
            new List<string> {"Luna", "Bald Eagle", "Bird", "Female", "15 Feb 2018", "22 Jan 2022"},
            new List<string> {"Max", "Peregrine Falcon", "Bird", "Male", "10 Apr 2015", "12 Feb 2022"},
            new List<string> {"Mia", "Peregrine Falcon", "Bird", "Female", "7 Jul 2016", "21 Mar 2022"},
            new List<string> {"Buddy", "African Grey Parrot", "Bird", "Male", "15 Nov 2014", "4 Apr 2022"},
            new List<string> {"Sandy", "African Grey Parrot", "Bird", "Female", "21 Mar 2016", "16 May 2022"},
            new List<string> {"Rocky", "Budgerigar", "Bird", "Male", "9 Jun 2019", "28 Jun 2022"},
            new List<string> {"Tina", "Budgerigar", "Bird", "Female", "2 Sep 2020", "8 Aug 2022"},
            new List<string> {"Oscar", "Harris's Hawk", "Bird", "Male", "6 Jan 2017", "17 Sep 2022"},
            new List<string> {"Penny", "Harris's Hawk", "Bird", "Female", "12 Apr 2018", "29 Oct 2022"},
            new List<string> {"Lucy", "Barn Owl", "Bird", "Female", "5 Aug 2015", "12 Nov 2022"},
            new List<string> {"Sam", "Barn Owl", "Bird", "Male", "20 Nov 2016", "23 Dec 2022"},
            new List<string> {"Simba", "Great Horned Owl", "Bird", "Male", "4 Feb 2014", "4 Jan 2023"},
            new List<string> {"Lily", "Great Horned Owl", "Bird", "Female", "11 Mar 2015", "15 Feb 2023"},
            new List<string> {"Kiwi", "Emu", "Bird", "Male", "29 Jul 2017", "28 Mar 2023"},
            new List<string> {"Sally", "Emu", "Bird", "Female", "14 Oct 2018", "10 Apr 2023"},
            new List<string> {"Zeus", "Bald Eagle", "Bird", "Male", "2 Dec 2012", "19 May 2023"},
            new List<string> {"Athena", "Bald Eagle", "Bird", "Female", "19 Jan 2014", "27 Jun 2023"},
            new List<string> {"Apollo", "Red-tailed Hawk", "Bird", "Male", "3 Mar 2019", "15 Jul 2023"},
            new List<string> {"Artemis", "Red-tailed Hawk", "Bird", "Female", "8 Jun 2020", "23 Aug 2023"},
        };

        public static IEnumerable<Animal> GetAnimals()
        {
            return Enumerable.Range(0, NumberOfAnimals).Select(CreateRandomAnimal);
        }

        private static Animal CreateRandomAnimal(int index)
        {

            List<string> Enclosures = new List<string>()
                {"Lion Enclosure","Aviary","Reptile House", "Giraffe Enclosure", "Hippo Enclosure"};
            
            Random rnd = new Random();
            
            int rndIndex = rnd.Next(0, 5);

            return new Animal
            {
                Name = Data[index][0],
                Species = Data[index][1],
                Classification = Data[index][2],
                Sex = Data[index][3],
                BirthDate = DateTime.Parse(Data[index][4]),
                AcquiredDate = DateTime.Parse(Data[index][5]),
                Enclosure = Enclosures[rndIndex],
            };
        }
    }
}