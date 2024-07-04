using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        ObservableCollection<MainPageModel> collection;

        public MainPage()
        {
            InitializeComponent();

            _CV.ItemTemplate = new(GetItemTemplate);

            collection = [];
            for (int i = 0; i < 3; i++)
            {
                collection.Add(new MainPageModel
                {
                    Text = "Test " + Random.Shared.Next(1000, 10000),
                    SecondaryText = "Test2 " + Random.Shared.Next(1000, 10000)
                });
            }

            _CV.ItemsSource = collection;
        }

        private View GetItemTemplate()
        {
            Label text = new Label();
            Label text2 = new Label();

            Grid layout = new()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                }
            };
            layout.Add(text, 0, 0);
            layout.Add(text2, 0, 1);

            Border card = new()
            {
                Margin = new Thickness(16, 8),
                Content = layout,
                Padding = 4,
                BackgroundColor = Colors.LightGray,
            };

            card.BindingContextChanged += (s, e) =>
            {
                if (card.BindingContext is MainPageModel mpm)
                {
                    text.Text = mpm.Text;
                    text2.Text = mpm.SecondaryText;
                }
            };

            return card;
        }

        private void New_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                collection.Add(new MainPageModel
                {
                    Text = "Test " + Random.Shared.Next(1000, 10000),
                    SecondaryText = "Test2 " + Random.Shared.Next(1000, 10000)
                });
            }
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            if (collection.Count > 0)
                collection.RemoveAt(collection.Count-1);
        }

        private void Header_Clicked(object sender, EventArgs e)
        {
            if (_CV.Header == null)
            {
                _CV.Header = new ContentView { HeightRequest = 64 };
                _Header.Text = "H: On";
            }
            else
            {
                _CV.Header = null;
                _Header.Text = "H: Off";
            }
        }

        private void Footer_Clicked(object sender, EventArgs e)
        {
            if (_CV.Footer == null)
            {
                _CV.Footer = new ContentView { HeightRequest = 64 };
                _Footer.Text = "F: On";
            }
            else
            {
                _CV.Footer = null;
                _Footer.Text = "F: Off";
            }
        }
    }

    public class MainPageModel
    {
        public string Text { get; set; }
        public string SecondaryText { get; set; }
    }
}