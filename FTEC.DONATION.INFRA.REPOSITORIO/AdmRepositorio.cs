using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using System.Data;

using FTEC.DONATION.DOMINIO.Entidade;
using FTEC.DONATION.DOMINIO.Repositorio;

using FTEC.DONATION.INFRA.REPOSITORIO;


namespace FTEC.DONATION.INFRA.REPOSITORIO
{
    public class AdmRepositorio : IAdmRepositorio
    {
        private string strConexao;

        public AdmRepositorio(string strConexao)
        {

            this.strConexao = strConexao;

        }


        public void Alterar(Adm administrador)
        {
            //throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Adm administrador)
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

                            comando.CommandText = "insert into administrador (id,email,senha) values(@ID, @EMAIL, @SENHA);";

                            comando.Parameters.AddWithValue("ID", administrador.Id);
                            comando.Parameters.AddWithValue("EMAIL", administrador.Email);
                            comando.Parameters.AddWithValue("SENHA", administrador.Senha);

                            comando.ExecuteNonQuery();

                            transacao.Commit();
                        }
                        catch (Exception ex)
                        {
                          // String mensagem = (ex.Message);

                            
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

        public Adm Procurar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Adm ValidAdm(string email, string senha)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from administrador where email=@email and senha=@senha";

                comando.Parameters.AddWithValue("email", email);
                comando.Parameters.AddWithValue("senha", senha);

                NpgsqlDataReader leitor = comando.ExecuteReader();

                Adm admin = null;

                while (leitor.Read())
                {
                    admin = new Adm();
                    admin.Id = Guid.Parse(leitor["id"].ToString());
                    admin.Email= leitor["email"].ToString();
                    admin.Senha = leitor["senha"].ToString();

                }

                return admin;

            }
        }
    }

        


    }








