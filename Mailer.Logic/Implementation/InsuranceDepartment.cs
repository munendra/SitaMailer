using Mailer.Dto;
using Mailer.Logic.Interface;

namespace Mailer.Logic.Implementation
{
    public class InsuranceDepartment : IInsuranceDepartment
    {
        public bool IsInsuranceRequired(Parcel parcel)
        {
            if (parcel.Value > 1000)
            {
                return true;
            }

            return false;
        }
    }
}