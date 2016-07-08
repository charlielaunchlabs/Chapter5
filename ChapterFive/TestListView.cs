using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ChapterFive
{

	public class ListItem
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}
	public class TestListView : ContentView
	{
		ListView listView = new ListView();

		public TestListView()
		{
			Content = new Label { Text = "Hello ContentView" };


			listView.ItemsSource = new ListItem[] 
			{
			 new ListItem {Title = "First", Description="1st item"},
			 new ListItem {Title = "Second", Description="2nd item"},
			 new ListItem {Title = "Third", Description="3rd item"}
			};

			listView.ItemTemplate = new DataTemplate(typeof(TextCell));
			listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Title");
			listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Description");

		

			listView.RowHeight = 80;
			listView.BackgroundColor = Color.Black;
			listView.ItemTemplate = new DataTemplate(typeof(ListItemCell));
			Content = listView;

		}
		public void tapped(ContentPage el)
		{

			listView.ItemTapped += async (sender, e) =>
			 {
				 ListItem item = (ListItem)e.Item;
				 if (item.Title.ToString() == "Second")
				 {
					await el.DisplayAlert(item.Title.ToString()  , " Next Page was selected.", "OK");
					await Navigation.PushAsync(new ListViewButton());

				 }else
				 
					await el.DisplayAlert("Tapped", item.Title.ToString() + " was selected.", "OK");
				 	((ListView)sender).SelectedItem = null;


			 };

		}

	}


	class ListItemCell : ViewCell
	{
		
		public ListItemCell()
		{
			
			
			Label titleLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontSize = 25,
				FontAttributes = Xamarin.Forms.FontAttributes.Bold,
				TextColor = Color.White
			};
			titleLabel.SetBinding(Label.TextProperty, "Title");
			Label descLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontSize = 12,
				TextColor = Color.White
			};
			descLabel.SetBinding(Label.TextProperty, "Description");
			StackLayout viewLayoutItem = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { titleLabel, descLabel }
			};
			Label priceLabel = new Label
			{
				HorizontalOptions = LayoutOptions.End,
				FontSize = 25,
				TextColor = Color.Aqua
			};

			priceLabel.SetBinding(Label.TextProperty, "Price");
			StackLayout viewLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(25, 10, 55, 15),
				Children = { viewLayoutItem, priceLabel}
			};


		
			View = viewLayout;
		}


	}
}


