using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FTEC.DONATION.DOMINIO.Entidade;
using FTEC.DONATION.DOMINIO.Repositorio;
using FTEC.DONATION.INFRA.REPOSITORIO;
using System.Collections.Generic;


namespace FTEC.DONATION.INFRA.REPOSITORIO.TEST
{
    [TestClass]
    public class AdmRepositorioTest
    {
        [TestMethod]
        public void InserirTest()
        {
            string strConexao = "Server=localhost; Port=5432; Database=projeto; User Id = postgres; Password = 12345; ";

            Adm admin = new Adm();
            AdmRepositorio  adminRepositorio = new AdmRepositorio(strConexao);
            
            admin.Id = Guid.NewGuid();
            admin.Email = "Admin_teste";
            admin.Senha = "12345";
           

            try
            {
                adminRepositorio.Inserir(admin);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }




        }
    }
}
