using straks_nl.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace straks_nl.Data.Entities
{
    public class UserEditableEntity : TimeTrackedEntity
    {
        public string CreatedByID { get; set; }
        public ApplicationUser CreatedBy { get; set; }

        public string ModifiedByID { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
    }
}
