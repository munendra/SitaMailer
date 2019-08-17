using Mailer.Dto;
using Mailer.Logic.Interface;

namespace Mailer.Logic.Implementation
{
    public class MailDepartment : IDepartments
    {
        public double? WeightMin { get; set; }
        public double? WeightMax { get; set; }
        public string Name { get; }
        public double Value { get; set; }

        public MailDepartment()
        {
            WeightMin = 0;
            WeightMax = 1;
            Value = 0;
            Name = "Mail";
        }

        public ParcelStatus Handle(Parcel parcel)
        {
            return new ParcelStatus
            {
                Parcel = parcel,
                Department = Name
            };
        }
    }
}