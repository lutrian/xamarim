using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico.Modelo
{
    public class ViaCEPServico
    {
        private static string enderecourl = "https://viacep.com.br/ws/{0}/json/";
        public static Endereco Buscarenderecoviacep(string cep)
        {
            string novoenderecourl = string.Format(enderecourl, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoenderecourl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if(end.cep == null)
            {
                return null;
            }
            return end;
        }
    }
}
