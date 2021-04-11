using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RoleDto : IDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
    }
}
