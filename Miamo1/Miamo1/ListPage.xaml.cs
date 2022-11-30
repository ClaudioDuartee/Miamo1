using Miamo1.CellsMiamo;
using Miamo1.ModelsMiamo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        string urlApi = "https://miamoapi.azurewebsites.net/api";
        private void CarregarLV()
        {
            try
            {
                HttpClient client = new HttpClient();

                //execução metodo GET

                var response = client.GetAsync(urlApi + "/Produtos").Result;

                //le o resultado em json

                var json = response.Content.ReadAsStringAsync().Result;

                //transforma o json em lista de objetos (dto) / (Deserializa)

                var produtos1 = JsonConvert.DeserializeObject<List<Produto>>(json);

                //Define o Template do Item

                lvProduto.ItemTemplate = new DataTemplate(typeof
                    (ProdutosMiamo));

                //associa a lista de generos vinda da api ao list view
                lvProduto.ItemsSource = produtos1;



            }
            catch
            {

                DisplayAlert("Erro", "Erro ao carregar os dados", "OK");
            }

            //lvProduto.ItemTemplate = new DataTemplate(typeof(Produto));
            //lvProduto.ItemsSource = contexto.Conexao.Query<Produto>("SELECT * FROM Produto").ToList();
            //lvProduto.RowHeight = 100;

            //lvProduto.ItemTemplate = new DataTemplate(typeof(Categoria));
            //lvProduto.ItemsSource = contexto.Conexao.Query<Categoria>("SELECT * FROM Categoria").ToList();
            //lvProduto.RowHeight = 100;
        }

        public ListPage()
        {
            InitializeComponent();

            //contexto = new Contexto();
            CarregarLV();
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();

            ///execução metodo GET

            var response = client.GetAsync(urlApi + "/Produtos").Result;

            ////le o resultado em json

            var json = response.Content.ReadAsStringAsync().Result;

            ////transforma o json em lista de objetos (dto) / (Deserializa)

            var produtos1 = JsonConvert.DeserializeObject<List<Produto>>(json);

            //Define o Template do Item

            lvProduto.ItemTemplate = new DataTemplate(typeof
                (ProdutosMiamo));

            //associa a lista de generos vinda da api ao list view
            lvProduto.ItemsSource = produtos1;

        }
    }
   
 
}