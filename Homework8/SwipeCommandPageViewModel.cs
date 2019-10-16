using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homework8
{
	public class SwipeCommandPageViewModel : INotifyPropertyChanged
	{
        public string[] imgs = {"Chick1","Chick2","Chick3","Chick4","Chick5","Duck1","Duck2","Duck3","Duck4","Duck5"};

		public ICommand SwipeCommand => new Command<string>(Swipe);

        public string img { get; private set; }

        public bool gameVisible = true;
        public bool resultsVisible = false;

        public int count = 0;

        public int Count { get { return count; } }
        public string Img { get { return img; } }
        public bool GameVisible { get { return gameVisible; } }
        public bool ResultsVisible { get { return resultsVisible; } }

		public SwipeCommandPageViewModel()
		{
			img = imgs[new Random().Next(0,9)];
		}

		void Swipe(string value)
		{
            if (value == "Right" && img.TrimEnd(img[img.Length - 1]) == "Chick" || value == "Left" && img.TrimEnd(img[img.Length - 1]) == "Duck")
            {
                img = imgs[new Random().Next(0, 9)];
                OnPropertyChanged("Img");
                count++;
            }
            else
            {
                gameVisible = false;
                resultsVisible = true;
                OnPropertyChanged("Count");
                OnPropertyChanged("GameVisible");
                OnPropertyChanged("ResultsVisible");
            }
        }

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}

