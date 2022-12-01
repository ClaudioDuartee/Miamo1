using Miamo1.CellsMiamo;
using Miamo1.ModelsMiamo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Miamo1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagerCategoria : ContentPage
    {

        //public Contexto contexto;

        string urlApi = "https://miamoapi.azurewebsites.net/api";
        public ManagerCategoria()
        {
            InitializeComponent();

            //contexto = new Contexto();
            CarregarDados();
        }

        private void CarregarDados()
        {

            try
            {
                HttpClient client = new HttpClient();

                //execução metodo GET

                var response = client.GetAsync(urlApi + "/Categoria").Result;

                //le o resultado em json

                var json = response.Content.ReadAsStringAsync().Result;

                //transforma o json em lista de objetos (dto) / (Deserializa)

                var categorias = JsonConvert.DeserializeObject<List<Categoria>>(json);

                //Define o Template do Item

                lvCategoria.ItemTemplate = new DataTemplate(typeof
                    (CategoriaCells));

                //associa a lista de generos vinda da api ao list view
                lvCategoria.ItemsSource = categorias;
            }
            catch
            {

                DisplayAlert("Erro", "Erro ao carregar os dados", "OK");
            }
           
        }


        public void Limpar()
        {
          
            txtCategoria.Text = txtCategoria.Text = txtCategoria.Text = string.Empty;
            txtCategoria.Focus();
            CarregarDados();


        }
        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
        

            try
            {
                if (string.IsNullOrEmpty(txtCategoria.Text))
                {
                    DisplayAlert("Erro", "Informe o Nome do Produto", "OK");
                    return;
                }
            }
            catch (Exception ex)
            {

                DisplayAlert("Erro", ex.Message, "OK");
            }

            Categoria categoria = new Categoria();
           
            categoria.Categorias = txtCategoria.Text;

            var json = JsonConvert.SerializeObject(categoria);
            var dados = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //metodo post API
            var client = new HttpClient();
            var response = client.PostAsync(urlApi + "/Categoria", dados);

            if(response.Result.StatusCode == HttpStatusCode.OK)
            {
                DisplayAlert("Sucesso", "Categoria Cadastrada com Sucesso", "OK");
                txtCategoria.Text = "";
                CarregarDados();
            }
            else
            {
                DisplayAlert("Erro", "Produto Não Cadastrado", "OK");
            }


        }

        private void btnExcluir_Clicked(object sender, EventArgs e)
        {

        }

        private void btnNovo_Clicked(object sender, EventArgs e)
        {
            {
                Limpar();
            }

        }

        private void lvCategoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
        }
    }
}