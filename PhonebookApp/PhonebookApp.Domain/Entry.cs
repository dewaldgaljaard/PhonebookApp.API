namespace PhonebookApp.Domain
{
    public class Entry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneBookId { get; set; }
        public PhoneBook PhoneBook{get;set;}
    }
}
