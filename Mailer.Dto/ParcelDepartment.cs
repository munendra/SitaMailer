using System;

namespace Mailer.Dto
{
    public class ParcelDepartment
    {
        public string DepartmentName { get; set; }

        public Parcel Parcel { get; set; }
    }
}