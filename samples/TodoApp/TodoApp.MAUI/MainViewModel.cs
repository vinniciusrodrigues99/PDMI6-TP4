using System.Windows.Input;
using TodoApp.Data;
using TodoApp.Data.Models;
using TodoApp.Data.MVVM;

namespace TodoApp.MAUI
{
    public class MainViewModel : TodoListViewModel
    {
        private ITodoService _service;
        private IMVVMHelper _helper;
        public MainViewModel(IMVVMHelper helper, ITodoService service) : base(helper, service)
        {
            RefreshItemsCommand = new Command(async () => await LoadItemsAsync());
            _helper = helper;
            _service = service;
        }

        public ICommand AddItemCommand
            => new Command<Entry>(async (Entry entry) => await AddItemAsync(entry.Text));

        public ICommand RefreshItemsCommand { get; }

        public ICommand SelectItemCommand
            => new Command<TodoItem>(async (TodoItem item) => await UpdateItemAsync(item.Id, !item.IsComplete));

        private async Task LoadItemsAsync()
        {
            try
            {
                var items = await _service.GetItemsAsync();
                Items.Clear();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                await _helper.DisplayErrorAlertAsync("Erro", $"Erro ao carregar itens: {ex.Message}");
            }
        }
    }
}
