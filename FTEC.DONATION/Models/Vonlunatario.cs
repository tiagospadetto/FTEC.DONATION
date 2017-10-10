using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FTEC.DONATION.Models
{
    public class Vonlunatario
    {
        public Vonlunatario()
        {
            Id = Guid.NewGuid();
        }
        public string Nome      { get; set; }
        public string Sobrenome { get; set; }
        public string Email     { get; set; }
        public string CPF       { get; set; }
        public string Endereco  { get; set; }
        public string Bairro    { get; set; }
        public string Cidade    { get; set; }
        public string CEP       { get; set; }
        public int Idade        { get; set; }
        public Guid Id          { get; private set; }
    }
}