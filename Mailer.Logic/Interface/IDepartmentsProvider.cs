using Mailer.Dto;

namespace Mailer.Logic.Interface
{
    public interface IDepartmentsProvider
    {
        IDepartments Departments(Parcel parcel);
    }
}