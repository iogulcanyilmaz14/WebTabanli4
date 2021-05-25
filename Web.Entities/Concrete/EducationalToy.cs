using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Entities;

namespace Web.Entities.Concrete
{
   public class EducationalToy :IEntity
    {
        public int Id { get; set; }
        public int EducationalId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }

    }
}
