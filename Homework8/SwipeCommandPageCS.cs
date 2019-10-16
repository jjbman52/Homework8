using System;

using Xamarin.Forms;

namespace Homework8
{
	public class SwipeCommandPageCS : ContentPage
	{
		public SwipeCommandPageCS()
		{
			var boxView = new BoxView { WidthRequest = 300, HeightRequest = 300, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };
			var img = new Image();
			img.SetBinding(Image.SourceProperty, "Img");

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
					new Image { Margin = new Thickness(0,10), Source = "Chick1" },
					boxView,
					img
				}
			};
			BindingContext = new SwipeCommandPageViewModel();
		}
	}
}
