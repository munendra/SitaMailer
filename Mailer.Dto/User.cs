namespace Mailer.Dto
{
    public class User
    {
        public User()
        {
            Address = new Address();
        }


        public string Name { get; set; }

        public Address Address { get; set; }
    }
}