using System;
using System.Collections.Generic;
using System.IO;
using PhonebookApp.Data;
using PhonebookApp.Domain;

namespace PhonebookApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbName = "PhonebookAppDb.db";
            if (File.Exists(dbName))
            {
                File.Delete(dbName);
            }

            using(var context = new PhonebookAppContext())
            {
                context.Database.EnsureCreated();
                var phonebook = new PhoneBook
                {
                    Name = "Default",
                    Entries = new List<Entry>
                {
                    new Entry
                    {
                        Name = "Dewald",
                        PhoneNumber = "076 201 4779"
                    },
                    //new Entry
                    //{
                    //    Name = "Dewald",
                    //    PhoneNumber = "076 201 4779"
                    //}
                }
                };

                context.PhoneBooks.Add(phonebook);
                context.SaveChanges();

                foreach(var phoneBook in context.PhoneBooks)
                {
                    foreach(var phoneBookEntry in phoneBook.Entries)
                    {
                        System.Console.WriteLine($"{phoneBookEntry.Name}, {phoneBookEntry.PhoneNumber}");
                    }
                }
            }
        }
    }
}
