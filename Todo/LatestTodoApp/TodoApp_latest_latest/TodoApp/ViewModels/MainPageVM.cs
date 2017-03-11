using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoApp.ViewModels;
using ToDoApp.Models;
using TodoApp.Service;

namespace ToDoApp.ViewModels
{
    public class MainPageVM : BaseVM
    {
        private ObservableCollection<ToDo> _filteredTodos;

        public ObservableCollection<ToDo> FilteredToDos
        {
            get
            {
                return _filteredTodos;
            }
            private set
            {
                _filteredTodos = value;
                base.RaisePropertyChanged("FilteredToDos");
            }
        }

        private ObservableCollection<ToDo> _todos;

        public ObservableCollection<ToDo> ToDos
        {
            get { return _todos; }
            set { _todos = value; }
        }

        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        private CategoryService _categoryService;
        private TodoService _todoService;

        public MainPageVM()
        {
            _todos = new ObservableCollection<ToDo>();
            _categories = new ObservableCollection<Category>();
            _filteredTodos = new ObservableCollection<ToDo>();
            _categoryService = new CategoryService();
            _todoService = new TodoService();
        }

        public void LoadData()
        {
            LoadCategories();
            LoadTodoes();

            _filteredTodos = _todos;
        }

        private void LoadCategories()
        {

            _categories = new ObservableCollection<Category>(_categoryService.getAllCategories());
         
        }

        private void LoadTodoes()
        {
            _todos = new ObservableCollection<ToDo>(_todoService.getAllTodos());
            //_todos.Add(new ToDo() { ToDoId = 1, Heading = "Todo 1", Category = _categories.First(), Content = "This needs to be done", Done = false, DueDate = DateTime.Today, Priority = Priority.Normal });
            //_todos.Add(new ToDo() { ToDoId = 2, Heading = "Todo 2", Category = _categories.First(), Content = "This needs to be done", Done = false, DueDate = DateTime.Today, Priority = Priority.Normal });
            //_todos.Add(new ToDo() { ToDoId = 3, Heading = "Todo 3", Category = _categories.ElementAt(1), Content = "This needs to be done 3", Done = false, DueDate = DateTime.Today, Priority = Priority.Normal });
            //_todos.Add(new ToDo() { ToDoId = 4, Heading = "Todo 4", Category = _categories.ElementAt(1), Content = "This needs to be done 4", Done = false, DueDate = DateTime.Today, Priority = Priority.Normal });
        }

        public void FilterTodosByCategory(Category category)
        {
            var result = this._todos.Where(x => x.CategoryId == category.CategoryId).ToList();
            FilteredToDos = new ObservableCollection<ToDo>(result);
            
        }

        public void RemoveFilters()
        {
            FilteredToDos = _todos;
        }
    }
}
