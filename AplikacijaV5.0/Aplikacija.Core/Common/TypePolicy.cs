using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.Core
{
    public class TypePolicy
    {
        [Key, ForeignKey("CapacityMoney")]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public virtual CapacityMoney CapacityMoney { get; set; }

    }
}
