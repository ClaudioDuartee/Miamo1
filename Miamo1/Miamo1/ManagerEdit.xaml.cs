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
    public partial class ManagerEdit : ContentPage
    {

        string urlApi = "https://miamoapi.azurewebsites.net/api";
        public ManagerEdit()
        {
            InitializeComponent();
            CarregarLV();
        }

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


        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtNomeProduto.Text))
                {
                    DisplayAlert("Erro", "Informe o Nome do Produto", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(txtDescricaoProduto.Text))
                {
                    DisplayAlert("Erro", "Informe a DescriçãoProduto", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(txtTamanhoProduto.Text))
                {
                    DisplayAlert("Erro", "Informe o TamanhoProduto", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(txtPrecoProduto.Text))
                {
                    DisplayAlert("Erro", "Informe o Preço", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(txtCorProduto.Text))
                {
                    DisplayAlert("Erro", "Informe a Cor", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(txtCategoriaProduto.Text))
                {
                    DisplayAlert("Erro", "Informe a Categoria", "OK");
                    return;
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");

            }

            Produto produto = new Produto();
            produto.IdProduto = Convert.ToInt32(txtID.Text);
            produto.NomeProduto = txtNomeProduto.Text;
            produto.DescricaoProduto = txtDescricaoProduto.Text;
            produto.TamanhoProduto = txtTamanhoProduto.Text;
            produto.PrecoProduto = Convert.ToDouble(txtPrecoProduto.Text);
            produto.CorProduto = txtCorProduto.Text;
            produto.UrlImagemProduto = "";
            produto.IdFornecedor = Convert.ToInt32(txtIdFornecedor.Text);
            produto.IdCategoriaProduto = Convert.ToInt32(txtCategoriaProduto.Text);

            var json = JsonConvert.SerializeObject(produto);
            var dados = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //metodo post API
            var client = new HttpClient();
            var response = client.PutAsync(urlApi + "/Produtos", dados);

            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                DisplayAlert("Sucesso", "Editado com Sucesso", "OK");
                txtNomeProduto.Text = "";
                txtTamanhoProduto.Text = "";
                txtDescricaoProduto.Text = "";
                txtCorProduto.Text = "";
                txtIdFornecedor.Text = "";
                txtPrecoProduto.Text = "";
                txtCategoriaProduto.Text = "";
                CarregarLV();
            }
            else
            {
                DisplayAlert("Erro", "Não foi possivel Editar", "OK");
            }


        }

        //private void btnExcluir_Clicked(object sender, EventArgs e)
        //{
           
        //}

        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            txtID.Text = "0";
            txtNomeProduto.Text = txtDescricaoProduto.Text = txtTamanhoProduto.Text = txtCategoriaProduto.Text = txtCorProduto.Text = txtIdFornecedor.Text = txtPrecoProduto.Text = string.Empty;
            txtNomeProduto.Focus();
            CarregarLV();


        }

        private void lvProduto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}