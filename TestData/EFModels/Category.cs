using System.Collections.Generic;
using TestCore.EFModels;

namespace TestData.EFModels
{
    public class Category : ModelBase
    {
        public Category()
        {
            this.Articles = new List<Article>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        // Relations
        public virtual ICollection<Article> Articles { get; set; }
    }
}