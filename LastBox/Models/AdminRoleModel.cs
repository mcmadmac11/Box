using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastBox.Models
{
    public class AdminRoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Box> Boxes { get; set; }
        public ICollection<RegisteredUser> RegisteredUsers { get; set; }
    }
}