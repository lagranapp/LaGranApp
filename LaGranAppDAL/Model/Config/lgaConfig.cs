using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LaGranAppDAL.Model.Config
{
    public class lgaConfig
    {
        [Key]
        public int Id { get; set; }
        public int DbVersion { get; set; }
    }
}
