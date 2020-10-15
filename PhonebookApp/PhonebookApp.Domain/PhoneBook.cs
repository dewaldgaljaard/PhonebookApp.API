using System.Collections.Generic;

namespace PhonebookApp.Domain
{
    public class PhoneBook
    {
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }

        public PhoneBook()
        {
            Entries = new List<Entry>();
        }
    }
}
