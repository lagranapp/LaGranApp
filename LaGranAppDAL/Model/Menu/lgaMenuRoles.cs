using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LaGranAppDAL.Model.Menu
{
    public class lgaMenuRoles
    {
        [Key]
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string RoleId { get; set; }
        public string AppId { get; set; }
        [ConcurrencyCheck]
        public int RowVersion { get; set; }
    }
}
