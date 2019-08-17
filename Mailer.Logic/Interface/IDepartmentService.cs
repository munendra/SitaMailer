using Mailer.Dto;

namespace Mailer.Logic.Interface
{
    public interface IDepartmentService
    {
        IDepartments GetDepartment(Parcel parcel);
    }
}