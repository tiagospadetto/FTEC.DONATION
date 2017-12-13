using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using System.Data;

using FTEC.DONATION.DOMINIO.Entidade;
using FTEC.DONATION.DOMINIO.Repositorio;

namespace FTEC.DONATION.INFRA.REPOSITORIO
{
    public class VoluntarioRepositorio : IVoluntarioRepositorio
    {
        private  String strConexao ;

        public VoluntarioRepositorio(String strConexao)
        {
            this.strConexao = strConexao;

        }

        public void Inserir(EVoluntario voluntario)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();

                    using (NpgsqlTransaction transacao = con.BeginTransaction())
                    {
                        try
                        {
                            NpgsqlCommand comando = new NpgsqlCommand();

                            comando.Connection = con;
                            comando.Transaction = transacao;

                            comando.CommandText = "insert into volunt (id,nome,sobrenome,sexo,email,senha) values(@ID,@NOME,@SOBRENOME,@SEXO,@EMAIL,@SENHA);";

                            comando.Parameters.AddWithValue("ID", voluntario.Id);
                            comando.Parameters.AddWithValue("NOME", voluntario.Nome);
                            comando.Parameters.AddWithValue("SOBRENOME", voluntario.Sobrenome);
                            comando.Parameters.AddWithValue("SEXO", voluntario.Sexo);
                            comando.Parameters.AddWithValue("EMAIL", voluntario.Email);
                            comando.Parameters.AddWithValue("SENHA", voluntario.Senha);

                            comando.ExecuteNonQuery();

                            transacao.Commit();
                        }
                        catch (Exception ex)
                        {
                             String mensagem = (ex.Message);


                            transacao.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public EVoluntario Acesso(string email, string senha)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from volunt where email=@email and senha=@senha";

                comando.Parameters.AddWithValue("email", email);
                comando.Parameters.AddWithValue("senha", senha);

                NpgsqlDataReader leitor = comando.ExecuteReader();

                EVoluntario voluntario = null;

                while (leitor.Read())
                {
                    voluntario = new EVoluntario();
                    voluntario.Id = Guid.Parse(leitor["id"].ToString());
                    voluntario.Nome = leitor["nome"].ToString();
                    voluntario.Sexo = leitor["sexo"].ToString();
                    voluntario.Sobrenome = leitor["sobrenome"].ToString();
                    voluntario.Email = leitor["email"].ToString();
                    voluntario.Senha = leitor["senha"].ToString();

                }

                return voluntario;

            }
        }

        public List<EVoluntario> List()
        {

            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;

                comando.CommandText = "select * from volunt ";


                NpgsqlDataReader leitor = comando.ExecuteReader();

                List<EVoluntario> voluntarios = new List<EVoluntario>();

                while (leitor.Read())
                {
                    EVoluntario voluntario = new EVoluntario();
                    voluntario.Id = Guid.Parse(leitor["id"].ToString());
                    voluntario.Nome = leitor["nome"].ToString();
                    voluntario.Sobrenome = leitor["sobrenome"].ToString();
                    voluntario.Sexo = leitor["sexo"].ToString();
                    voluntario.Email = leitor["email"].ToString();
                    voluntario.Senha = leitor["senha"].ToString();

                    voluntarios.Add(voluntario);

                }

                return voluntarios;

            }

        }
    }
}
