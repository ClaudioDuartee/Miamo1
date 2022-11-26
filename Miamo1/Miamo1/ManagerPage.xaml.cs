
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
    public partial class ManagerPage : ContentPage

    {
        //public Contexto contexto;
        string urlApi = "https://miamoapi.azurewebsites.net/api";
        public ManagerPage()
        {
            InitializeComponent();

            //contexto = new Contexto();
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

            //lvProduto.ItemTemplate = new DataTemplate(typeof(Produto));
            //lvProduto.ItemsSource = contexto.Conexao.Query<Produto>("SELECT * FROM Produto").ToList();
            //lvProduto.RowHeight = 100;

            //lvProduto.ItemTemplate = new DataTemplate(typeof(Categoria));
            //lvProduto.ItemsSource = contexto.Conexao.Query<Categoria>("SELECT * FROM Categoria").ToList();
            //lvProduto.RowHeight = 100;

        }

        public void Limpar()
        {
            txtID.Text = "0";
            txtNomeProduto.Text = txtDescricaoProduto.Text = txtTamanhoProduto.Text = string.Empty;
            txtNomeProduto.Focus();
            CarregarLV();


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
            produto.TamanhoProduto = txtTamanhoProduto.Text;
            produto.DescricaoProduto = txtDescricaoProduto.Text;
            produto.CorProduto = txtCorProduto.Text;
            produto.PrecoProduto = txtPrecoProduto.Text;
            produto.CategoriaProduto = Convert.ToInt32(txtCategoriaProduto.Text);

            var json = JsonConvert.SerializeObject(produto);
            var dados = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //metodo post API
            var client = new HttpClient();
            var response = client.PostAsync(urlApi + "/Produtos", dados);

            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                DisplayAlert("Sucesso", "Categoria Cadastrada com Sucesso", "OK");
                txtNomeProduto.Text = "";
                txtTamanhoProduto.Text = "";
                txtDescricaoProduto.Text = "";
                txtCorProduto.Text = "";
                txtPrecoProduto.Text = "";
                txtCategoriaProduto.Text = "";
                CarregarLV();
            }
            else
            {
                DisplayAlert("Erro", "Informe a Categoria", "OK");
            }

            //Preenchendo Propriedades


            //if (txtID.Text == "0")
            //{
            //    contexto.Cadastrar(produto);
            //    DisplayAlert("Sucesso", "Produto Cadastrado Com Sucesso", "OK");
            //    CarregarLV();
            //    Limpar();
            //}
            //else
            //{
            //    contexto.Editar(produto);
            //    DisplayAlert("Sucesso", "Produto Editado Com Sucesso", "OK");
            //    CarregarLV();
            //    Limpar();
            //}


        }





        private void btnExcluir_Clicked(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtID.Text != "0")
            //    {
            //        contexto.Conexao.Execute($"DELETE FROM Produto Where ID={txtID.Text}");
            //        DisplayAlert("Sucesso", "Produto Eliminado com Sucesso", "OK");
            //        CarregarLV();
            //        Limpar();

            //    }
            //    else
            //    {
            //        DisplayAlert("Erro", "Selecione Um Produto", "OK");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    DisplayAlert("Erro", ex.Message, "OK");

            //}


        }

        private void btnNovo_Clicked(object sender, EventArgs e)
        {


            {
                Limpar();
            }

        }

        private void lvProduto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            //    try
            //    {
            //        var produto = (Produto)e.SelectedItem;
            //        txtID.Text = produto.ID.ToString();
            //        txtTitulo.Text = produto.Titulo;
            //        txtGenero.Text = produto.Genero;
            //        txtProduto.Text = produto.Produtos;
            //        txtPreço.Text = produto.Preço.ToString();



            //    }
            //    catch (Exception ex)
            //    {

            //        DisplayAlert("Erro", ex.Message, "OK");
            //    }
            //}


        }
    }
}
