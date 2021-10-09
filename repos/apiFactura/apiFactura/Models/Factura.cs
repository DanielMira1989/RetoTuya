using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class Factura
    {
        [Key]
        public int id { get; set; }


        public string producto { get; set; }

        public int cantidad { get; set; }

        public int valor { get; set; }

    }
}
