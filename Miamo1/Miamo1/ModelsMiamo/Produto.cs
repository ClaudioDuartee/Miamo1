using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miamo1.ModelsMiamo
{
    public class Produto
    {
        [PrimaryKey,AutoIncrement]

        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Produtos { get; set; }
        public int Preço { get; set; }

        public int Categoria { get; set; }


    }
}
