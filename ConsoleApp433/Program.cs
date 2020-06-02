using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace ConsoleApp433
{
    public class House_data
    {
        private string surname;
        private string housenumber;
        private string flatnumber;
        private string sex;
        private string suma;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Housenumber
        {
            get { return housenumber; }
            set { housenumber = value; }
        }
        public string Flatnumber
        {
            get { return flatnumber; }
            set { flatnumber = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Suma
        {
            get { return suma; }
            set { suma = value; }
        }
    }

    class Program
    {

        private static string P = "house.json";
        private static string N = "house.json";
        static void House()
        {
            while (true)
            {

                Console.WriteLine("To delete or change the data in the search box, select exactly what you want to modify");
                Console.WriteLine("\n\"add data by clicking 'A'\nsearch data click 'S'" + "\nshow all click data 'T'\nreturn to the main menu 'Enter'\nClear console  by clicking 'F'\nExit click 'Esc'");
                // enter -- назад , щоб редагувати або удаляти просто шукаєте по прізвищу кого там є можливість
                var data = JsonConvert.DeserializeObject<List<House_data>>(File.ReadAllText(P));

                var y = Console.ReadKey();
                var x = y.Key;
                switch (x)
                {
                    case ConsoleKey.A: // ДОДАТИ

                        {
                            Console.Clear();
                            Console.WriteLine("Enter the tenant's details\n Surname : ");
                            string surname = Console.ReadLine();
                            Console.Write("House number: ");
                            string housenumber = Console.ReadLine();
                            Console.WriteLine("Apartment number: ");
                            string flatnumber = Console.ReadLine();
                            Console.WriteLine("Woman or man: ");
                            string sex = Console.ReadLine();
                            Console.WriteLine("Suma: ");
                            string suma = Console.ReadLine();

                            if (surname != null && housenumber != null && flatnumber != null && sex != null && suma != null)
                            {
                                data.Add(new House_data { Surname = surname, Housenumber = housenumber, Flatnumber = flatnumber, Sex = sex, Suma = suma });
                            }
                            else
                            {
                                Console.WriteLine("Please fill in all fields");
                            }
                            Console.Clear();
                            break;
                        }
                    case ConsoleKey.F://CLEAR
                        {
                            Console.Clear();
                            break;
                        }
                    case ConsoleKey.S://ПОШУК
                        {
                            Console.Clear();
                            string surname;
                            Console.WriteLine("Enter a last name to search: ");
                            surname = Console.ReadLine();
                            if (Console.ReadLine() != null)
                            {

                                Console.Clear();
                                House_data FoundData = data.Find(found => found.Surname == surname);
                                if (FoundData == null)
                                {
                                    Console.WriteLine("There is no such thing");
                                }
                                else
                                {
                                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                    Console.WriteLine("\tSurname\t│  House number\t│  Apartment number\t│\t\tWoman or man:\t\t│\tSuma\t");
                                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");



                                    Console.Write("\t" + FoundData.Surname + "\t");
                                    Console.Write("\t\t " + FoundData.Housenumber + "\t");
                                    Console.Write("\t\t " + FoundData.Flatnumber + "\t");
                                    Console.Write("\t\t\t" + FoundData.Sex + "\t");
                                    Console.Write("\t" + FoundData.Suma + "\t\n");
                                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                                    Console.WriteLine("\nClick to edit 'E'");
                                    Console.WriteLine("\n\nTo edit delete 'D'");
                                    if (Console.ReadKey().Key == ConsoleKey.E)
                                    {
                                        Console.WriteLine("Enter data \n Surname : ");

                                        string surrname = Console.ReadLine();
                                        Console.Write("House number: ");
                                        string housenumber = Console.ReadLine();
                                        Console.WriteLine("Apartment number: ");
                                        string flatnumber = Console.ReadLine();
                                        Console.WriteLine("Woman or man:ь: ");
                                        string sex = Console.ReadLine();
                                        Console.WriteLine("Suma: ");
                                        string suma = Console.ReadLine();


                                        if (surrname != null && housenumber != null && flatnumber != null && sex != null && suma != null)
                                        {
                                            FoundData.Surname = surname;
                                            FoundData.Housenumber = housenumber;
                                            FoundData.Flatnumber = flatnumber;
                                            FoundData.Sex = sex;
                                            FoundData.Suma = suma;
                                            Console.Clear();
                                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                            Console.WriteLine("\tSurname\t│  House number\t│  Apartment number\t│\t\tWoman or man:\t\t│\tSuma\t");
                                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");



                                            Console.Write("\t" + FoundData.Surname + "\t");
                                            Console.Write("\t\t " + FoundData.Housenumber + "\t");
                                            Console.Write("\t\t " + FoundData.Flatnumber + "\t");
                                            Console.Write("\t\t\t" + FoundData.Sex + "\t");
                                            Console.Write("\t" + FoundData.Suma + "\t\n");
                                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                        }

                                    }
                                    if (Console.ReadKey().Key == ConsoleKey.D)//DELETED
                                    {
                                        data.RemoveAll(x => x.Surname == surname);
                                    }
                                }


                            }
                            else

                            {
                                Console.WriteLine("Enter surname");

                            }
                            break;
                        }
                    case ConsoleKey.T://ВСІ ДАНІ
                        {
                            Console.Clear();

                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("\tSurname\t│  House number\t│  Apartment number\t│\t\tWoman or man:\t\t│\tSuma\t");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.Write("\t" + data[i].Surname + "\t");
                                Console.Write("\t\t " + data[i].Housenumber + "\t");
                                Console.Write("\t\t " + data[i].Flatnumber + "\t");
                                Console.Write("\t\t\t" + data[i].Sex + "\t");
                                Console.Write("\t\t" + data[i].Suma + "\t\n");
                                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                            }

                            Console.WriteLine("\nSort data by click amount 'S'");

                            Console.WriteLine("\nSort data by last name click 'M'");
                            if (Console.ReadKey().Key == ConsoleKey.S)//Сортувати дані за прізвищем нажми
                            {

                                Console.Clear();
                                List<House_data> SortData = data.OrderByDescending(o => o.Suma).ToList();
                                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("\tSurname\t│  House number\t│  Apartment number\t│\t\tWoman or man:\t\t│\tSuma\t");
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");

                                for (int i = 0; i < data.Count; i++)
                                {

                                    Console.Write("\t" + SortData[i].Surname + "\t");
                                    Console.Write("\t\t " + SortData[i].Housenumber + "\t");
                                    Console.Write("\t\t " + SortData[i].Flatnumber + "\t");
                                    Console.Write("\t\t\t" + SortData[i].Sex + "\t");
                                    Console.Write("\t" + SortData[i].Suma + "\t\n");
                                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");




                            }
                            if (Console.ReadKey().Key == ConsoleKey.M)//Сортувати дані за прізвищем нажми
                            {

                                Console.Clear();
                                List<House_data> SortData = data.OrderBy(o => o.Surname).ToList();
                                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("\tSurname\t│  House number\t│ Apartment number\t│\t\tWoman or man:\t\t│\tSuma\t");
                                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                                for (int i = 0; i < data.Count; i++)
                                {

                                    Console.Write("\t" + SortData[i].Surname + "\t");
                                    Console.Write("\t\t " + SortData[i].Housenumber + "\t");
                                    Console.Write("\t\t " + SortData[i].Flatnumber + "\t");
                                    Console.Write("\t\t\t" + SortData[i].Sex + "\t");
                                    Console.Write("\t" + SortData[i].Suma + "\t\n");
                                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                                }
                                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                                {
                                    Console.Clear();
                                }
                            }
                            string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                            if (serialize.Count() > 1)
                            {
                                if (!File.Exists(N))
                                {
                                    File.Create(N).Close();
                                }
                                File.WriteAllText(P, serialize, Encoding.UTF8);
                            }
                            break;
                        }
                }

            }
        }


        static void Main(string[] args)
        {
            House();
        }


    }


}

