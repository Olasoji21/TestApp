using AtmosUserManager.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenHairousApp.Shared.DBEntities
{
    public class Product : AuditableEntity
    {
        public int?                 Price               { get; set; }

        public int?                 Stock               { get; set; }

        public int?                 CategoryId          { get; set; }

        public string               Name                { get; set; }

        public string               ImageUrl            { get; set; }
    }
}
