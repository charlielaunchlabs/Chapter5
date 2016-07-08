using System;

using Xamarin.Forms;
using System.Collections.Generic;
namespace ChapterFive
{
	public class NextPage : ContentPage
	{
		public class ListItem
		{
			public string Source { get; set; }
			public string Title { get; set; }
			public string Description { get; set; }
			public string Price { get; set; }
		}

		public NextPage()
		{
			var listView = new ListView();
			listView.ItemsSource = new ListItem[] {
				new ListItem {Title = "First", Description="1st item", Price="$1.00"},
				new ListItem {Title = "Second", Description="2nd item", Price="$20.00"},
				new ListItem {Title = "Third", Description="3rd item", Price="$300.00"}
			};
			listView.RowHeight = 80;
			listView.BackgroundColor = Color.Black;
			listView.ItemTemplate = new DataTemplate(typeof(ListItemCell));
			Content = listView;

			listView.ItemTapped += async (sender, e) =>
			{
				ListItem item = (ListItem)e.Item;
				await DisplayAlert("Tapped", item.Title.ToString() + " was selected.", "OK");
				((ListView)sender).SelectedItem = null;
			};

			this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
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


				var button = new Button
				{
					Text = "Buy Now",
					BackgroundColor = Color.Teal,
					HorizontalOptions = LayoutOptions.EndAndExpand
				};
				button.SetBinding(Button.CommandParameterProperty, new Binding("."));
				button.Clicked += (sender, e) =>
				{
					var b = (Button)sender;
					var item = (ListItem)b.CommandParameter;
					((ContentPage)((ListView)((StackLayout)((StackLayout)b.ParentView).ParentView).ParentView).ParentView).DisplayAlert("Clicked", item.Title.ToString() + " button was clicked", "OK");
				};

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
					TextColor = Color.Accent
				};
				priceLabel.SetBinding(Label.TextProperty, "Price");

				StackLayout viewLayout = new StackLayout()
				{
					HorizontalOptions = LayoutOptions.StartAndExpand,
					Orientation = StackOrientation.Horizontal,
					Padding = new Thickness(25, 10, 55, 15),
					Children = { viewLayoutItem, priceLabel ,button}
				};

				View = viewLayout;
			}

		}
	}
}


