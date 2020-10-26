using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LaGranAppDAL.Model.Usuario
{
    public class lgaUsuarios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Usuario { get; set; }
        [Required]
        [MaxLength(50)]
        public string Clave { get; set; }
        [Required]        
        public string AppId { get; set; }
        public string Email { get; set; }
        [ConcurrencyCheck]
        public int RowVersion { get; set; }
    }
}
