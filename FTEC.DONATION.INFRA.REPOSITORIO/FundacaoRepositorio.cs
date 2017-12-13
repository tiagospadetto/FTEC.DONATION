using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using System.Data;

using FTEC.DONATION.DOMINIO.Repositorio;
using FTEC.DONATION.DOMINIO.Entidade;

namespace FTEC.DONATION.INFRA.REPOSITORIO
{
    public class FundacaoRepositorio : IFundacaoRepositorio
    {
        private string strConexao;

        public FundacaoRepositorio(string strConexao)
        {

            this.strConexao = strConexao;

        }

        
        public void Inserir(Funcacao fundacao,String tipo)
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
                            if(tipo == "aprovar")
                            {
                                comando.CommandText = "insert into fund_aprov (id,nome,tipo,email,senha) values(@ID,@NOME,@TIPO,@EMAIL,@SENHA);";

                                comando.Parameters.AddWithValue("ID", fundacao.Id);
                                comando.Parameters.AddWithValue("NOME", fundacao.Nome);
                                comando.Parameters.AddWithValue("TIPO", fundacao.Tipo);
                                comando.Parameters.AddWithValue("EMAIL", fundacao.Email);
                                comando.Parameters.AddWithValue("SENHA", fundacao.Senha);

                            }else
                            {
                                comando.CommandText = "insert into fund (id,nome,tipo,email,senha) values(@ID,@NOME,@TIPO,@EMAIL,@SENHA);";

                                comando.Parameters.AddWithValue("ID", fundacao.Id);
                                comando.Parameters.AddWithValue("NOME", fundacao.Nome);
                                comando.Parameters.AddWithValue("TIPO", fundacao.Tipo);
                                comando.Parameters.AddWithValue("EMAIL", fundacao.Email);
                                comando.Parameters.AddWithValue("SENHA", fundacao.Senha);

                            }
                            
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
        public void Aprova(Guid id)
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

                            comando.CommandText = "update fund_aprov set integrada = 1 where id = @ID";

                            comando.Parameters.AddWithValue("ID", id.ToString());

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

        public List<Funcacao> Listar()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;

                comando.CommandText = "select * from fund_aprov where integrada = 0";


                NpgsqlDataReader leitor = comando.ExecuteReader();

                List<Funcacao> fundacoes = new List<Funcacao>();

                while (leitor.Read())
                {
                    Funcacao fundacao = new Funcacao();
                    fundacao.Id = Guid.Parse(leitor["id"].ToString());
                    fundacao.Nome = leitor["nome"].ToString();
                    fundacao.Tipo = leitor["tipo"].ToString();
                    fundacao.Email = leitor["email"].ToString();
                    fundacao.Senha= leitor["senha"].ToString();
      
                    fundacoes.Add(fundacao);

                }

                return fundacoes;

            }
        }

        public List<Funcacao> ListarAprovadas()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;

                comando.CommandText = "select * from fund ";


                NpgsqlDataReader leitor = comando.ExecuteReader();

                List<Funcacao> fundacoes = new List<Funcacao>();

                while (leitor.Read())
                {
                    Funcacao fundacao = new Funcacao();
                    fundacao.Id = Guid.Parse(leitor["id"].ToString());
                    fundacao.Nome = leitor["nome"].ToString();
                    fundacao.Tipo = leitor["tipo"].ToString();
                    fundacao.Email = leitor["email"].ToString();
                    fundacao.Senha = leitor["senha"].ToString();

                    fundacoes.Add(fundacao);

                }

                return fundacoes;

            }
        }

        public Funcacao Acesso(string email, string senha)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from fund where email=@email and senha=@senha";

                comando.Parameters.AddWithValue("email", email);
                comando.Parameters.AddWithValue("senha", senha);

                NpgsqlDataReader leitor = comando.ExecuteReader();

                Funcacao fund = null;

                while (leitor.Read())
                {
                    fund = new Funcacao();
                    fund.Id = Guid.Parse(leitor["id"].ToString());
                    fund.Email = leitor["email"].ToString();
                    fund.Senha = leitor["senha"].ToString();

                }

                return fund;

            }
        }
    }
}
