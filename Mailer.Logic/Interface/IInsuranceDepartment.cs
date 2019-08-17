using Mailer.Dto;

namespace Mailer.Logic.Interface
{
    public interface IInsuranceDepartment
    {
        bool IsInsuranceRequired(Parcel parcel);
    }
}