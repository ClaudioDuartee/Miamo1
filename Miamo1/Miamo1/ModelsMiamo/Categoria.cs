using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miamo1.ModelsMiamo
{
    public class Categoria
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Categorias { get; set; }
    }
}
