using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termometre.Consol1.Concrete
{
    public class RandomTemp
    {
        [Key]
        public int ID { get; set; }
        public int Tempreture { get; set; }
    }
}

    

