using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiPagos.Models
{
    public class Pagos
    {
        [Key]
        public int id { get; set; }


        public int valor { get; set; }

        public string producto_origen { get; set; }

        public string producto_destino { get; set; }

        public DateTime fecha { get; set; }
    }
}
