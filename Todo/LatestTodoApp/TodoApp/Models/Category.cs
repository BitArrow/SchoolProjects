using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }
        
        public Category()
        {
            this.Created = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            Category another = obj as Category;
            return another.CategoryId.Equals(this.CategoryId);
        }

        public override int GetHashCode()
        {
            return CategoryId;
        }
    }
}
