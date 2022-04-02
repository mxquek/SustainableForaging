namespace SustainableForaging.Core.Models
{
    public class Forager
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }

        public Forager()
        {

        }
        public Forager(string id, string firstName, string lastName, string state)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            State = state;
        }
    }
}
