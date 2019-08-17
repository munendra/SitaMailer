using Mailer.Dto;
using Mailer.Logic.Interface;

namespace Mailer.Logic.Implementation
{
    public class MailDepartment : BaseDepartment, IDepartments
    {
        public double? MinmumWeight { get; set; }
        public double? MaximumWeight { get; set; }
        public string Name { get; }


        public MailDepartment(IInsuranceDepartment insuranceDepartment) : base(insuranceDepartment)
        {
            MinmumWeight = 0;
            MaximumWeight = 1;
            Name = "Mail";
        }

        public ParcelStatus Handle(Parcel parcel)
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