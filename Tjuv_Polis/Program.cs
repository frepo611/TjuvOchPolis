﻿using Tjuv_Polis;

namespace Tjuv_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random random = new Random();
            List<Person> persons = new List<Person>();
            int numberOfEachType = 5;
            int horizontalCitySize = 100;
            int verticalCitySize = 25;


            for (int civilians = 0; civilians < numberOfEachType; civilians++)
            {
                persons.Add(new Civilian(horizontalCitySize, verticalCitySize, civilians + 1));
            }

            for (int thiefs = 0; thiefs < numberOfEachType; thiefs++)
            {
                persons.Add(new Thief(horizontalCitySize, verticalCitySize, thiefs + 1));
            }

            for (int police = 0; police < numberOfEachType; police++)
            {
                persons.Add(new Police(horizontalCitySize, verticalCitySize, police + 1));
            }

            City city = new City(horizontalCitySize, verticalCitySize);
            city.DrawCity();


            while (true)
            {
                foreach (Person person in persons)
                {
                    person.Move();

                    Console.SetCursorPosition(0, verticalCitySize + 2); // För Mac
                }
                foreach (Person person in persons)
                {
                    Console.WriteLine(person.Status());
                }

                bool somethingHappens = Helper.CheckCollision(persons);
                
                if (somethingHappens)
                {
                    Console.WriteLine("Something happened");
                    Console.ReadKey();
                }

                Thread.Sleep(500);
            }
        }
    }
}

//person.Collision(Civilan);
//person.Collision(Thief);
//person.Collision(Police);