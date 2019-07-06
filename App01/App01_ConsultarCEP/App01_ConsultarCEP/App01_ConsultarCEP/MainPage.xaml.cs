using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnbuscar.Clicked += buscarcep;
        }

        private void buscarcep(object sender, EventArgs args)
        {
            string cep = txtcep.Text.Trim();

            if (validcep(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.Buscarenderecoviacep(cep);

                    if (end != null)
                    {
                        lblresultado.Text = string.Format("Endereço: {0} - {1}, {2},{3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("Erro", "O endereço não foi encontrado para o cep informado: "+cep, "Ok");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro Crítico", ex.Message, "Ok");
                }
            }
        }

        private bool validcep(string cep)
        {
            bool valido = true;
            int novocep = 0;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "Cep Inválido! O cep deve conter 8 caracteres.", "Ok");
                valido = false;
            }

            if(!int.TryParse(cep, out novocep))
            {
                DisplayAlert("Erro", "Cep Inválido! O cep deve ser composto apenas por números.", "Ok");
                valido = false;
            }
            return valido;
        }
    }
}
