using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Entities
{
    public class Hammadde
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HamId { get; set; }
        [StringLength(50)]
        public string HamAdi { get; set; }
        public int HamAdet { get; set; }
    }
}
