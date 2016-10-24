using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodersPortal.Models
{
    public class SavedFiles
    {
        [Key]
        public int SavedFilesId { get; set; }
        public string Name { get; set; }

    }
}