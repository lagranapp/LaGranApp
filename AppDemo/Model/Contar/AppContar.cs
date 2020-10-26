using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppDemo.Model.Contar
{
    [Table("AppContar")]
    public class AppContar
    {
        [Key]
        public int Id { get; set; }
        public int Contador { get; set; }
        [ConcurrencyCheck]
        public int RowVersion { get; set; }
    }
}
