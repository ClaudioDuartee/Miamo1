
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
    public partial class ManagerPage : ContentPage

    {
        public Contexto contexto;
        public ManagerPage()
        {
            InitializeComponent();

            contexto = new Contexto();
            CarregarLV();
        }

        private void CarregarLV()
        {
            lvProduto.ItemTemplate = new DataTemplate(typeof(Produto));
            lvProduto.ItemsSource = contexto.Conexao.Query<Produto>("SELECT * FROM Produto").ToList();
            lvProduto.RowHeight = 100;

            lvProduto.ItemTemplate = new DataTemplate(typeof(Categoria));
            lvProduto.ItemsSource = contexto.Conexao.Query<Categoria>("SELECT * FROM Categoria").ToList();
            lvProduto.RowHeight = 100;

        }

        public void Limpar()
        {
            txtID.Text = "0";
            txtTitulo.Text = txtGenero.Text = txtProduto.Text = string.Empty;
            txtTitulo.Focus();
            CarregarLV();


        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTitulo.Text))
                {
                    DisplayAlert("Erro", "Informe o Titulo", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(txtGenero.Text))
                {
                    DisplayAlert("Erro", "Informe o Genero", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(txtProduto.Text))
                {
                    DisplayAlert("Erro", "Informe o Produto", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(txtProduto.Text))
                {
                    DisplayAlert("Erro", "Informe o Preço", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(txtProduto.Text))
                {
                    DisplayAlert("Erro", "Informe a Categoria", "OK");
                    return;
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");

            }
            //Preenchendo Propriedades
            Produto produto = new Produto();
            produto.ID = Convert.ToInt32(txtID.Text);
            produto.Titulo = txtTitulo.Text;
            produto.Genero = txtGenero.Text;
            produto.Produtos = txtProduto.Text;
            produto.Preço = Convert.ToInt32(txtPreço.Text);
            produto.Categoria = Convert.ToInt32(txtCategoria.Text);


            if (txtID.Text == "0")
            {
                contexto.Cadastrar(produto);
                DisplayAlert("Sucesso", "Produto Cadastrado Com Sucesso", "OK");
                CarregarLV();
                Limpar();
            }
            else
            {
                contexto.Editar(produto);
                DisplayAlert("Sucesso", "Produto Editado Com Sucesso", "OK");
                CarregarLV();
                Limpar();
            }


        }





        private void btnExcluir_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "0")
                {
                    contexto.Conexao.Execute($"DELETE FROM Produto Where ID={txtID.Text}");
                    DisplayAlert("Sucesso", "Produto Eliminado com Sucesso", "OK");
                    CarregarLV();
                    Limpar();

                }
                else
                {
                    DisplayAlert("Erro", "Selecione Um Produto", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");

            }


        }

        private void btnNovo_Clicked(object sender, EventArgs e)
        {


            {
                Limpar();
            }

        }

        private void lvProduto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            try
            {
                var produto = (Produto)e.SelectedItem;
                txtID.Text = produto.ID.ToString();
                txtTitulo.Text = produto.Titulo;
                txtGenero.Text = produto.Genero;
                txtProduto.Text = produto.Produtos;
                txtPreço.Text = produto.Preço.ToString();



            }
            catch (Exception ex)
            {

                DisplayAlert("Erro", ex.Message, "OK");
            }
        }


    }
    }
