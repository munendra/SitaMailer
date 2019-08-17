namespace Mailer.Dto
{
    public class Parcel
    {
        public Parcel()
        {
            Sender = new User();
            Receipient = new User();
            
        }

        public User Sender { get; set; }

        public User Receipient { get; set; }

        public double Weight { get; set; }

        public double Value { get; set; }

        public bool IsInsured { get; set; }
    }
}