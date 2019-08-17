using Mailer.Dto;
using Mailer.Logic.Interface;

namespace Mailer.Logic.Implementation
{
    public class HeavyDepartment : BaseDepartment, IDepartments
    {
        public double? MinmumWeight { get; set; }
        public double? MaximumWeight { get; set; }
        public string Name { get; }


        public  HeavyDepartment(IInsuranceDepartment insuranceDepartment) : base(insuranceDepartment)
        {
            MinmumWeight = 10;
            MaximumWeight = null;
            Name = "Heavy";
        }

        public new ParcelDepartment Handle(Parcel parcel)
        {
            parcel =  base.Handle(parcel);
            return new ParcelDepartment
            {
                Parcel = parcel,
                DepartmentName = Name
            };
        }
    }
}