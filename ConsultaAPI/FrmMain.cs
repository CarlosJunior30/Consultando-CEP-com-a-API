using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Correios;

namespace ConsultaAPI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCEp.Text))
                MessageBox.Show("O campo de CEP está vazio", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {
                try
                {

                
                CorreiosApi correiosApi = new CorreiosApi();
                var retorno = correiosApi.consultaCEP(txtCEp.Text);

                if(retorno is null)
                {
                    MessageBox.Show("O CEP não foi encontrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                txtUF.Text = retorno.uf;
                txtCidade.Text = retorno.cidade;
                txtEndereco.Text = retorno.end;
                txtComplemento1.Text = retorno.complemento;
                txtComplemento2.Text = retorno.complemento2;
                txtBairro.Text = retorno.bairro;
                    // txtUnidadePostagem.Text = retorno.unidadesPostagem[0];
                }
                catch(Exception erro)
                {
                    MessageBox.Show("Erro ao consultar o CEP:  " + erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Said da aplicação?", "Saindo...",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            Application.Exit();
        }

        private void txtCEp_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
