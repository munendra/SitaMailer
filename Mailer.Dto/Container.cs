using System;
using System.Collections.Generic;

namespace Mailer.Dto
{
    public class Container
    {
        public Container()
        {
            Parcels = new List<Parcel>();
        }
        public long Id { get; set; }

        public DateTime ShippingDate { get; set; }

        public List<Parcel> Parcels { get; set; }
    }
}