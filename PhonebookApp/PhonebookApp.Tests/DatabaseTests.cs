using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhonebookApp.Data;
using PhonebookApp.Domain;

namespace PhonebookApp.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertPhonebookIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertPhonebook");

            using (var context = new PhonebookAppContext(builder.Options))
            {
                var phoneBook = new PhoneBook();
                context.PhoneBooks.Add(phoneBook);

                Assert.AreEqual(EntityState.Added, context.Entry(phoneBook).State);
            } 
        }

        [TestMethod]
        public void CanInsertEntryIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertEntry");

            using (var context = new PhonebookAppContext(builder.Options))
            {
                var phoneBook = new PhoneBook
                {
                    Entries = new List<Entry>()
                };

                context.PhoneBooks.Add(phoneBook);

                Assert.AreEqual(EntityState.Added, context.Entry(phoneBook).State);
            } 
        }

        [TestMethod]
        public void CantInsertDuplicateEntryIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CantInsertDuplicateEntry");

            using (var context = new PhonebookAppContext(builder.Options))
            {
                var phoneBook = new PhoneBook
                {
                    Name = "Default",
                    Entries = new List<Entry>
                    {
                        new Entry
                        {
                            Name = "User1",
                            PhoneNumber = "0000000000"
                        },
                        new Entry
                        {
                            Name = "User1",
                            PhoneNumber = "0000000001"
                        }
                    }
                };

                context.PhoneBooks.Add(phoneBook);

                Assert.AreEqual(EntityState.Added, context.Entry(phoneBook).State);
            } 
        }
    }
}
