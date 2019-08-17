using Mailer.Dto;
using Mailer.Logic.Interface;

namespace Mailer.Logic.Implementation
{
    public class RegularDepartment : BaseDepartment, IDepartments
    {
        public double? MinmumWeight { get; set; }
        public double? MaximumWeight { get; set; }
        public string Name { get; }
        public double Value { get; set; }

       
        public RegularDepartment(IInsuranceDepartment insuranceDepartment):base(insuranceDepartment)
        {
            MinmumWeight = 1;
            MaximumWeight = 10;
            Value = 0;
            Name = "Regular";
        }

        public new ParcelStatus Handle(Parcel parcel)
        {
            parcel = base.Handle(parcel);
            return new ParcelStatus
            {
                Parcel = parcel,
                Department = Name
            };
        }
    }
}