using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Miamo1.CellsMiamo
{
    public class CategoriaView : ContentView
    {
        public CategoriaView()
        {
            StackLayout cellwrapper = new StackLayout
            {
                BackgroundColor = Color.FromHex("#eee"),
                Padding = 1

            };

            StackLayout verticalLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
            };

            Label Categoria = new Label
            {
                TextColor = Color.Black,
                FontSize = 15
            };

            Categoria.SetBinding(Label.TextProperty, "Categoria");

            verticalLayout.Children.Add(Categoria);
            cellwrapper.Children.Add(verticalLayout);
           
        }
    }
}