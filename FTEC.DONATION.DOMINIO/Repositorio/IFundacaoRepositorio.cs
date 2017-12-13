using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTEC.DONATION.DOMINIO.Entidade;

namespace FTEC.DONATION.DOMINIO.Repositorio
{
    public interface IFundacaoRepositorio
    {

        void Inserir(Funcacao fundacao, String tipo);

        List<Funcacao> Listar();

        List<Funcacao> ListarAprovadas();

        void Aprova(Guid id);

        Funcacao Acesso(String email, String senha);

    }
}
