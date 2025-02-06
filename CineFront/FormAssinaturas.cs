using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace CineFront
{
    public partial class FormAssinatura : Form
    {
        public Usuario _usuario;
        string urlconection = GlobalVariables.ConnectionUrl;
        public FormAssinatura(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private async void atualizarAssinatura(int idAssinatura)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string url = $"{urlconection}/userAssinatura/{_usuario.Id}";

                    var model = new
                    {
                        AssinaturaId = idAssinatura
                    };

                    string json = JsonConvert.SerializeObject(model);
                    var request = new HttpRequestMessage
                    {
                        Method = new HttpMethod("PATCH"),
                        RequestUri = new Uri(url),
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };

                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Assinatura adquirida");
                        this.Close();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("Assinatura não encontrada.");
                    }
                    else
                    {
                        MessageBox.Show($"Permissão Negada");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar informações: {ex.Message}");
            }
        }

        private void buttonAssinar2_Click(object sender, EventArgs e)
        {
            atualizarAssinatura(3);
        }

        private void buttonAssinar1_Click(object sender, EventArgs e)
        {
            atualizarAssinatura(2);
        }

        private void buttonAssinar3_Click(object sender, EventArgs e)
        {
            atualizarAssinatura(4);
        }
    }
}
