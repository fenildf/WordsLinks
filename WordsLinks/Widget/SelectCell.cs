﻿using WordsLinks.Util;
using Xamarin.Forms;

namespace WordsLinks.Widget
{
    public class SelectCell : ViewCell
    {
        private static ImageSource checkImg = BasicUtils.AssembleImage("yes.png");

        public Label CellText { get; set; }
        private Image CheckImage;

        public bool IsSelected
        {
            get { return (bool)CheckImage.GetValue(Image.IsVisibleProperty); }
            set { CheckImage.SetValue(Image.IsVisibleProperty, value); }
        }

        public SelectCell()
        {
            Height = 60;
            CellText = new Label()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            CellText.SetBinding(Label.TextProperty, "Text");

            CheckImage = new Image()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Margin = new Thickness(10),
                IsVisible = false,
            };

            CheckImage.SetBinding(Image.IsVisibleProperty, "IsSelected");
            CheckImage.Source = checkImg;

            var layout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 8,
                Padding = new Thickness(16, 4, 4, 4),
            };
            layout.Children.Add(CellText);
            layout.Children.Add(CheckImage);

            View = layout;
        }

        public SelectCell(string name, bool isSelect) : this()
        {
            CellText.SetValue(Label.TextProperty, name);
            IsSelected = isSelect;
        }
    }

    
}
