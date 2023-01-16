using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Entities
{
    public class Stok
    {
        [Key]
        public int StokId { get; set; }
        [ForeignKey("Urun")]
        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public Urun User { get; set; }

        [ForeignKey("Hammadde")]
        public int HamId { get; set; }
        public Hammadde Hammadde { get; set; }
        public int StokSayi { get; set; }
    }
}
