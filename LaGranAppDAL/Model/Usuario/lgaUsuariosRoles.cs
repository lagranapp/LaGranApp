using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LaGranAppDAL.Model.Usuario
{
    public class lgaUsuariosRoles
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string RoleId { get; set; }
        [ConcurrencyCheck]
        public int RowVersion { get; set; }
    }
}
