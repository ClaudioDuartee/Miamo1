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
    public partial class ManagerCategoria : ContentPage
    {

        public Contexto contexto;
        public ManagerCategoria()
        {
            InitializeComponent();

            contexto = new Contexto();
            CarregarLV();
        }

        private void CarregarLV()
        {
            lvCategoria.ItemTemplate = new DataTemplate(typeof(Categoria));
            lvCategoria.ItemsSource = contexto.Conexao.Query<Categoria>("SELECT * FROM Categoria").ToList();
            lvCategoria.RowHeight = 100;


        }

        public void Limpar()
        {
            txtID.Text = "0";
            txtCategoria.Text = txtCategoria.Text = txtCategoria.Text = string.Empty;
            txtCategoria.Focus();
            CarregarLV();


        }
        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCategoria.Text))
                {
                    DisplayAlert("Erro", "Informe a Categoria", "OK");
                    return;
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");

            }
            Categoria categoria = new Categoria();
            categoria.ID = Convert.ToInt32(txtID.Text);
            categoria.Categorias = txtCategoria.Text;

            if (txtID.Text == "0")
            {
                contexto.Cadastrar(categoria);
                DisplayAlert("Sucesso", "Categoria Cadastrado Com Sucesso", "OK");
                CarregarLV();
                Limpar();
            }
            else
            {
                contexto.Editar(categoria);
                DisplayAlert("Sucesso", "Categoria Editado Com Sucesso", "OK");
                CarregarLV();
                Limpar();
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
            try
            {
                var categoria = (Categoria)e.SelectedItem;
                txtID.Text = categoria.ID.ToString();
                txtCategoria.Text = categoria.Categorias;




            }
            catch (Exception ex)
            {

                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}