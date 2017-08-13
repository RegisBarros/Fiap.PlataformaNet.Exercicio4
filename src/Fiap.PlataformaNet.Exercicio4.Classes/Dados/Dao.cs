using System.Collections.Generic;
using System.Data.SqlClient;

namespace Fiap.PlataformaNet.Exercicio4.Classes.Dados
{
    public abstract class Dao<T>
    {
        protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\reginaldo\fundamentosNet\Fiap.PlataformaNet.Exercicio4\database\DBEVENTOS.mdf;Integrated Security=True;Connect Timeout=30";

        protected SqlConnection cn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;

        public abstract void Incluir(T elemeto);

        public abstract void Atualizar(T elemeto);

        public abstract IEnumerable<T> Listar(params int[] id);

        public abstract IEnumerable<T> Buscar(Validacao<T> obj);
    }
}
