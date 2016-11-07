using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace com.dfyw.entity
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public bool IsDeleted { get; set; }
    }
}
