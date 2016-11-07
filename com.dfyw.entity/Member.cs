using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace com.dfyw.entity
{
    public class Member:Entity
    {
        [Required]
        [MaxLength(24)]
        public string Account { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// 用户角色 0 普通会员 1 管理员 2 组长
        /// </summary>
        [Required] 
        public int Role { get; set; }

        [Required]
        public Guid ParentId { get; set; }
    }
}
