using System;
using System.Collections.Generic;
using System.Text;
using Mailer.Dto;
using Mailer.Logic.Interface;

namespace Mailer.Logic.Implementation
{
    public class BaseDepartment
    {
        private readonly IInsuranceDepartment _insuranceDepartment;

        public BaseDepartment(IInsuranceDepartment insuranceDepartment)
        {
            _insuranceDepartment = insuranceDepartment;
        }

        public Parcel Handle(Parcel parcel)
        {
            if (_insuranceDepartment.IsInsuranceRequired(parcel))
            {
                parcel.IsInsured = true;
            }

            return parcel;
        }
    }
}