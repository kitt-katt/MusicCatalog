using Avalonia.Controls;
using Avalonia.Interactivity;
using MusicCatalogAppUI.Services;
using MusicCatalogAppUI.ViewModels; 

namespace MusicCatalogAppUI.UI.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }

        // Обработчик для кнопки "Найти"
        private void OnSearchClick(object sender, RoutedEventArgs e)
        {
            string searchQuery = searchBox.Text;
            string searchType = ((ComboBoxItem)dropdownList.SelectedItem).Content.ToString();

            string result = _viewModel.Search(searchType, searchQuery);

            ResultsTextBlock.Text = result;
        }

        // Обработчик для кнопки "Показать все"
        private void OnShowAllClick(object sender, RoutedEventArgs e)
        {
            string allData = _viewModel.ShowAll();
            ResultsTextBlock.Text = allData;
        }
    }
}