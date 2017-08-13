using Fiap.PlataformaNet.Exercicio4.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Fiap.PlataformaNet.Exercicio4.Classes.Dados
{
    public class DaoEventos : Dao<Evento>
    {
        public override void Incluir(Evento evento)
        {
            var sql = "INSERT INTO TBEventos VALUES (@DATA, @DESCRICAO, @RESPONSAVEL)";

            using (cn = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@DATA", evento.Data);
                    cmd.Parameters.AddWithValue("@DESCRICAO", evento.Descricao);
                    cmd.Parameters.AddWithValue("@RESPONSAVEL", evento.Responsavel);

                    cmd.ExecuteNonQuery();
                }

                cn.Close();
            }
        }

        // TODO: Este método precisa receber algum delegate
        public override void Atualizar(Validacao<Evento> validar, Evento evento)
        {
            var sql = "UPDATE TBEventos SET DATA = @DATA, DESCRICAO = @DESCRICAO, RESPONSAVEL = @RESPONSAVEL WHERE ID = @ID";

            using (cn = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@DATA", evento.Data);
                    cmd.Parameters.AddWithValue("@DESCRICAO", evento.Descricao);
                    cmd.Parameters.AddWithValue("@RESPONSAVEL", evento.Responsavel);
                    cmd.Parameters.AddWithValue("@ID", evento.Id);

                    cmd.ExecuteNonQuery();
                }

                cn.Close();
            }
        }

        public override IEnumerable<Evento> Buscar(Validacao<Evento> validacao)
        {
            var eventos = new List<Evento>();

            var sql = "SELECT ID, DATA, DESCRICAO, RESPONSAVEL FROM TBEventos";

            using (cn = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var e = new Evento()
                        {
                            Id = (int)reader["ID"],
                            Data = (DateTime)reader["DATA"],
                            Descricao = (string)reader["DESCRICAO"],
                            Responsavel = (string)reader["RESPONSAVEL"]
                        };

                        if (validacao(e))
                            eventos.Add(e);
                    }
                }
            }

            return eventos;
        }

        public override IEnumerable<Evento> Listar(params int[] id)
        {
            var sql = "SELECT ID, DATA, DESCRICAO, RESPONSAVEL FROM TBEventos";

            var eventos = new List<Evento>();

            using (cn = new SqlConnection(connectionString))
            {
                using (cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var e = new Evento()
                        {
                            Id = (int)reader["ID"],
                            Data = (DateTime)reader["DATA"],
                            Descricao = (string)reader["DESCRICAO"],
                            Responsavel = (string)reader["RESPONSAVEL"]
                        };

                        eventos.Add(e);
                    }
                }
            }

            return eventos;
        }
    }
}
