using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTEC.DONATION.DOMINIO.Entidade;

namespace FTEC.DONATION.DOMINIO.Repositorio
{
    public interface IAdmRepositorio
    {
        void Inserir(Adm administrador);

        void Alterar(Adm administrador);

        void Excluir(Guid id);

        Adm Procurar(Guid id);

        Adm ValidAdm(String email, String senha);


    }
}
