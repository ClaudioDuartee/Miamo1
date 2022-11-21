using Miamo1.ModelsMiamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Miamo1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {

        public Contexto contexto;

        private void CarregarLV()
        {
            lvProduto.ItemTemplate = new DataTemplate(typeof(Produto));
            lvProduto.ItemsSource = contexto.Conexao.Query<Produto>("SELECT * FROM Produto").ToList();
            lvProduto.RowHeight = 100;

            lvProduto.ItemTemplate = new DataTemplate(typeof(Categoria));
            lvProduto.ItemsSource = contexto.Conexao.Query<Categoria>("SELECT * FROM Categoria").ToList();
            lvProduto.RowHeight = 100;
        }

        public ListPage()
        {
            InitializeComponent();

            contexto = new Contexto();
            CarregarLV();
        }
    }
   
 
}