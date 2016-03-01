using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastBox.Models
{
    [Authorize]
    public class AdminModel
    {
        public int Id { get; set; }
        internal virtual Role Role { get; set; }
        public ICollection<Box> AdminBoxes { get; set; }

        

        

    }
}