using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using KanjiApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace KanjiApp.ViewModels
{
	public class SideMenuViewModel:BindableBase
	{
		public INavigationService _navigationService { get; set; }

		public ObservableCollection<MenuListItem> MenuItems { get; set; }

		public SideMenuViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			MenuItems = new ObservableCollection<MenuListItem>()
			{
				new MenuListItem(){
					Text = "N3",
					URI = "NavigationPage/HomePage?levelID=3",
					Image = "N.png",
					IsSeparatorVisible = true
				},
				new MenuListItem(){
					Text = "N4",
					URI = "NavigationPage/HomePage?levelID=4",
					Image = "N.png",
					IsSeparatorVisible = true
				},
				new MenuListItem(){
					Text = "N5",
					URI = "NavigationPage/HomePage?levelID=5",
					Image = "N.png",
					IsSeparatorVisible = true
				},
				new MenuListItem(){
					Text = "Cài đặt",
					URI = "NavigationPage/Settings",
					Image = "cai_dat.png",
					IsSeparatorVisible = true
				},
				new MenuListItem(){
					Text = "Tất cả",
					URI = "NavigationPage/KanjiList",
					Image = "tat_ca.png",
					IsSeparatorVisible = true
				},
				new MenuListItem(){
					Text = "Hướng dẫn",
					URI = "",
					Image = "huong_dan.png",
					IsSeparatorVisible = true
				},
				new MenuListItem(){
					Text = "Giới thiệu",
					URI = "",
					Image = "gioi_thieu.png",
					IsSeparatorVisible = true
				},
				new MenuListItem(){
					Text = "Tiến trình học",
					URI = "",
					Image = "tien_trinh_hoc.png",
					IsSeparatorVisible = false
				}
			};
		}

		public ICommand MenuItemClickCommand
		{
			get
			{
				return new Command(async (item) =>
				{
					string URI = ((MenuListItem)item).URI;
					await _navigationService.NavigateAsync(new Uri(URI, UriKind.Relative));
				});
			}
		}
	}
}
