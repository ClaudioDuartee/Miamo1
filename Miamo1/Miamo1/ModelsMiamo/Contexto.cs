using SQLite;//
using PCLExt.FileStorage.Folders;//
using System;
using System.Collections.Generic;
using System.Text;

namespace Miamo1.ModelsMiamo
{
    public class Contexto
    {
        public SQLiteConnection Conexao;

        public Contexto()
        {
            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile("Miamo",PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
            Conexao= new SQLiteConnection(arquivo.Path);


            Conexao.CreateTable<Produto>();
            Conexao.CreateTable<Categoria>();

        }

        public void Cadastrar<T>(T modelo)
        {
           Conexao.Insert(modelo);
        }

        public void Editar<T>(T modelo)
        {
            Conexao.Update(modelo);
        }

        public void Excluir<T>(T modelo)
        {
            Conexao.Delete(modelo);
        }




    }

    

    
}
