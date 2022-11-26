using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Miamo1.ModelsMiamo
{
    public class Produto
    {

        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }

        public string DescricaoProduto { get; set; }
        public string TamanhoProduto { get; set; }

        public string PrecoProduto { get; set; }

        public string CorProduto { get; set; }
      
        public int CategoriaProduto { get; set; }


    }
}
