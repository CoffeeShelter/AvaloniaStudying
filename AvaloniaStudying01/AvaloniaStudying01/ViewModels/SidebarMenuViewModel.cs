using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace AvaloniaStudying01.ViewModels
{
    public partial class SidebarMenuViewModel : ObservableObject
    {
        public SidebarMenuViewModel()
        {
            SelectedListItem = Items.First(vm => vm.ModelType == typeof(HomePageViewModel));
        }


        [ObservableProperty]
        private bool _isPaneOpen = true;

        [ObservableProperty]
        private ObservableObject _currentPage = new HomePageViewModel();

        [ObservableProperty]
        private ListItemTemplate? _selectedListItem;

        partial void OnSelectedListItemChanged(ListItemTemplate? value)
        {
            if (value is null) return;
            var instance = Activator.CreateInstance(value.ModelType);
            if (instance == null) return;
            CurrentPage = (ObservableObject)instance;
        }
         
        public ObservableCollection<ListItemTemplate> Items { get; } =
        [
            new ListItemTemplate(typeof(HomePageViewModel)),
            new ListItemTemplate(typeof(ButtonPageViewModel)),
        ];

        [RelayCommand]
        private void TriggerPane()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }

    public class ListItemTemplate
    {
        public ListItemTemplate(Type type)
        {
            ModelType = type;
            Label = type.Name.Replace("PageViewModel", "");
        }

        public string Label { get; }
        public Type ModelType { get; }
    }
}