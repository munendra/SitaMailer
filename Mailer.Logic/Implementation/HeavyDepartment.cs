using Mailer.Dto;
using Mailer.Logic.Interface;

namespace Mailer.Logic.Implementation
{
    public class HeavyDepartment : IDepartments
    {
        public double? WeightMin { get; set; }
        public double? WeightMax { get; set; }
        public string Name { get; }
        public double Value { get; set; }

        public HeavyDepartment()
        {
            WeightMin = 10;
            WeightMax = null;
            Value = 0;
            Name = "Heavy";
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