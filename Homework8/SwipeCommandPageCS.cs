using System;

using Xamarin.Forms;

namespace Homework8
{
	public class SwipeCommandPageCS : ContentPage
	{
		public SwipeCommandPageCS()
		{
			var boxView = new BoxView { Color = Color.Teal, WidthRequest = 300, HeightRequest = 300, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };
			var label = new Label();
			label.SetBinding(Label.TextProperty, "SwipeDirection");

			var leftSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Left, CommandParameter = "Left" };
			leftSwipeGesture.SetBinding(SwipeGestureRecognizer.CommandProperty, "SwipeCommand");

			var rightSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Right, CommandParameter = "Right" };
			rightSwipeGesture.SetBinding(SwipeGestureRecognizer.CommandProperty, "SwipeCommand");

			boxView.GestureRecognizers.Add(leftSwipeGesture);
			boxView.GestureRecognizers.Add(rightSwipeGesture);

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = {
					new Label { Margin = new Thickness(0,10), Text = "Swipe inside the box with a single finger." },
					boxView,
					label
				}
			};
			BindingContext = new SwipeCommandPageViewModel();
		}
	}
}
