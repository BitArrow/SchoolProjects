using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace TodoApp.Service
{
    public class CategoryService:BaseService
    {

        public CategoryService() : base("http://localhost:4015/api/Categories/")
        {

        }

        public List<Category> getAllCategories()
        {
            return base.getData<List<Category>>("");
        }
    }
}
