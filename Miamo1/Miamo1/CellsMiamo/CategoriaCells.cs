using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Miamo1.CellsMiamo
{
    public class CategoriaCells : ViewCell
    {
        public CategoriaCells()
        {
            StackLayout CategoriaCell = new StackLayout
            {
                BackgroundColor = Color.FromHex("#eee"),
                Padding = 1
            };

            StackLayout verticalLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            Label ID = new Label();
            Label Categoria = new Label();


            ID.SetBinding(Label.TextProperty, "ID");
            Categoria.SetBinding(Label.TextProperty, "Categoria");

            verticalLayout.Children.Add(ID);
            verticalLayout.Children.Add(Categoria);

            CategoriaCell.Children.Add(verticalLayout);

            View = CategoriaCell;
        }
    }
}
 