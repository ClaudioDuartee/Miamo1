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
                Padding = 1

            };

            StackLayout verticalLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
            };

            Label NomeProduto = new Label
            {
                TextColor = Color.Black,
                FontSize = 15
            };

            Label DescricaoProduto = new Label
            {
                TextColor = Color.FromHex("#707070"),
                FontSize = 12
            };

            Label TamanhoProduto = new Label
            {
                TextColor = Color.FromHex("#707070"),
                FontSize = 12
            };

            Label CorProduto = new Label
            {
                TextColor = Color.FromHex("#707070"),
                FontSize = 12
            };

            Label PrecoProduto = new Label
            {
                TextColor = Color.FromHex("#707070"),
                FontSize = 12

            };
            Label CategoriaProduto = new Label
            {
                TextColor = Color.FromHex("#707070"),
                FontSize = 12

            };

            NomeProduto.SetBinding(Label.TextProperty, "Titulo");
            DescricaoProduto.SetBinding(Label.TextProperty, "Genero");
            TamanhoProduto.SetBinding(Label.TextProperty, "Produto");
            PrecoProduto.SetBinding(Label.TextProperty, "Preço");
            CorProduto.SetBinding(Label.TextProperty, "Preço");
            CategoriaProduto.SetBinding(Label.TextProperty, "Categoria");

            verticalLayout.Children.Add(NomeProduto);
            verticalLayout.Children.Add(DescricaoProduto);
            verticalLayout.Children.Add(TamanhoProduto);
            verticalLayout.Children.Add(PrecoProduto);
            verticalLayout.Children.Add(CorProduto);
            verticalLayout.Children.Add(CategoriaProduto);
            cellWrapper.Children.Add(verticalLayout);
            View = cellWrapper;








        }
    }
}
