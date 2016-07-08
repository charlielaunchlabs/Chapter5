using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ChapterFive
{
	public class App : Application
	{
		public App()
		{

			MyView x = new MyView();
			TestListView y = new TestListView();

			// The root page of your application
			var content = new ContentPage
			{
				Title = "ChapterFive",
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Start"
						},y,x,new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "End"
						}
					}
				}
			};

			x.selected(content);
			y.tapped(content);
			MainPage = new NavigationPage(content);
		}


		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}



}

