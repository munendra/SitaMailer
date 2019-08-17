using Mailer.Dto;

namespace Mailer.Logic.Interface
{
    public interface IDepartments
    {
        double? MinmumWeight { get; set; }
        double? MaximumWeight { get; set; }
        string Name { get; }
       
        ParcelDepartment Handle(Parcel parcel);
    }
}