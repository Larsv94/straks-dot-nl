using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace straks_nl.Data.Entities
{
    public class ArticleCategorie
    {
        [Key, Column(Order = 0)]
        public int ArticleID { get; set; }
        [Key, Column(Order = 1)]
        public int CategorieID { get; set; }

        public virtual Categorie Categorie {get;set;}
        public virtual Article Article { get; set; }
    }
}
