namespace Domain
{
    public class Client
    {
        protected Client() { }

        public Client(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
