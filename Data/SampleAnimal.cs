using System.Collections.Generic;
using System.Linq;
using zoo_mgmt.Models.Database;
using System;
using zoo_mgmt.Repositories;

namespace zoo_mgmt.Data
{
    public static class SampleAnimals
    {
        public const int NumberOfAnimals = 22;

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
        };

        public static IEnumerable<Animal> GetAnimals()
        {
            return Enumerable.Range(0, NumberOfAnimals).Select(CreateRandomAnimal);
        }

        private static Animal CreateRandomAnimal(int index)
        {
            return new Animal
            {
                Name = Data[index][0],
                Species = Data[index][1],
                Classification = Data[index][2],
                Sex = Data[index][3],
                BirthDate = DateTime.Parse(Data[index][4]),
                AcquiredDate = DateTime.Parse(Data[index][5]),
            };
        }
    }
}