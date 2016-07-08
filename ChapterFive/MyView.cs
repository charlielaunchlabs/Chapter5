using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ChapterFive
{
	


	public class MyView : ContentView
	{
		
		public class ListItems
		{
			public string Title { get; set; }
			public string Description { get; set; }
		}

		public class Group : List<ListItems>
		{
			public String Key { get; private set; }
			public Group(String key, List<ListItems> items)
			{
				Key = key;
				foreach (var item in items)
					this.Add(item);
			}
		}


		ListView listView;
		public MyView()
		{


			List<Group> itemsGrouped = new List<Group> {
				new Group ("Important", new List<ListItems> {
					new ListItems {Title = "First", Description="1st item"},
					new ListItems {Title = "Second", Description="2nd item"},
							}),
				new Group ("Less Important", new List<ListItems>{
					new ListItems {Title = "Third", Description="3rd item"}
				})
			};
			
			Content = new Label { Text = "Hello ContentView" };
			listView = new ListView()
			{
				IsGroupingEnabled = true,
				GroupDisplayBinding = new Binding("Key"),
				ItemTemplate = new DataTemplate(typeof(TextCell))
				{
					Bindings = {
									{ TextCell.TextProperty, new Binding("Title") },
									{ TextCell.DetailProperty, new Binding("Description") }
									}
				}
			};
			listView.ItemsSource = itemsGrouped;
			this.Content = listView;
			//this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

		}

		public void selected(ContentPage el)
		{ 
			listView.ItemSelected += async (sender, e) =>
			 {
				if (e.SelectedItem == null) return;
				ListItems itemx = (ListItems)e.SelectedItem;
				await el.DisplayAlert("Selected",  itemx.Title +" was selected.", "OK");
				 ((ListView)sender).SelectedItem = null;

			 };

		}


	}
}


