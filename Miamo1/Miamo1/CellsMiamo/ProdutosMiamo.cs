using Miamo1.ModelsMiamo;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Miamo1.CellsMiamo
{
    public class ProdutosMiamo : ViewCell
    {
        public ProdutosMiamo()
        {
            StackLayout cellWrapper = new StackLayout
            {
                BackgroundColor = Color.FromHex("#eee"),
                Padding = 10

            };

            StackLayout verticalLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
            };

            Label Titulo = new Label
            {
                TextColor = Color.Black,
                FontSize = 15
            };

            Label Genero = new Label
            {
                TextColor = Color.FromHex("#707070"),
                FontSize = 12
            };

            Label Produto = new Label
            {
                TextColor = Color.FromHex("#707070"),
                FontSize = 12
            };

            Label Preço = new Label
            {
                TextColor = Color.FromHex("#707070"),
                FontSize = 12

            };
            Label Categoria = new Label
            {
                TextColor = Color.FromHex("#707070"),
                FontSize = 12

            };

            Titulo.SetBinding(Label.TextProperty, "Titulo");
            Genero.SetBinding(Label.TextProperty, "Genero");
            Produto.SetBinding(Label.TextProperty, "Produto");
            Preço.SetBinding(Label.TextProperty, "Preço");
            Categoria.SetBinding(Label.TextProperty, "Categoria");

            verticalLayout.Children.Add(Titulo);
            verticalLayout.Children.Add(Genero);
            verticalLayout.Children.Add(Produto);
            verticalLayout.Children.Add(Preço);
            verticalLayout.Children.Add(Categoria);
            cellWrapper.Children.Add(verticalLayout);
            View = cellWrapper;








        }
    }
}
