using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }
        public int MachineTemp { get; set; }
    }
}