using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Service;

namespace ToDoApp.Models
{
    public class ToDo
    {
        private CategoryService _service;
        public ToDo()
        {
            _service = new CategoryService();
        }
        public int ToDoId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public DateTime DueDate { get; set; }
        public bool Done { get; set; }
        public Priority Priority { get; set; }

        public int CategoryId { get; set; }

        //Kuidas hoolitsead selle eest,, et Category väärustataks laisalt?
        //Andmebaasis on lihtne, aga läbi veebiteenuste.
        //Kirjutame ise lihtsa laisa väärtustamise!
        public Category Category
        {
            get
            {
                if (_category == null && CategoryId != 0)
                {
                    _category = _service.getAllCategories().Where(x => x.CategoryId == CategoryId).FirstOrDefault();
                }
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        private Category _category;

    }


    public enum Priority
    {
        High = 0,
        Normal = 1,
        Low = 2
    }
}
