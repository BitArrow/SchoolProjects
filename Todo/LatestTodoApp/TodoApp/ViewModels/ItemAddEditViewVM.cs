using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Service;
using TodoApp.ViewModels;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class ItemAddEditViewVm:BaseVM
    {
        private ToDo _todo;

        public ToDo ToDo
        {
            get { return _todo; }
            set {
                _todo = value;
                base.RaisePropertyChanged("ToDo");
            }
        }

        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
        {
            get
            {
                return _categories;
            }
            private set
            {
                _categories = value;
                base.RaisePropertyChanged("Categories");
            }
        }
        private TodoService _todoService;
        private CategoryService _categoryService;

        private Category _selected;


        public Category SelectedCategory
        {
            get {  if(_selected == null)
                { return new Category(); }
                return _selected; }
            set
            {
                _selected = value;
                base.RaisePropertyChanged("SelectedCategory");
            }
        }

        public ItemAddEditViewVm()
        {
            _todo = new ToDo();
            _todoService = new TodoService();
        }

        public ItemAddEditViewVm(ToDo todo)
        {
            ToDo = todo;
            _todoService = new TodoService();
            _categoryService = new CategoryService();
            this.SelectedCategory = ToDo.Category;
        }

        public void Load()
        {
            Categories = new ObservableCollection<Category>(this._categoryService.getAllCategories());
        }

        public void Save()
        {
            if (_todo.CategoryId == 0)
            {
                _todo.CategoryId = SelectedCategory.CategoryId;
                //_todo.Category
            }
            if (_todo.ToDoId == 0)
            {
                ToDo = _todoService.addNewTodo(_todo);
            }else
            {
                ToDo = _todoService.updateTodo(_todo);
            }
           // x
            
        }
    }
}
