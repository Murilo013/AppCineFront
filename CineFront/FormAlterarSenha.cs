using Newtonsoft.Json.Linq;
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

namespace CineFront
{
    public partial class FormAlterarSenha : Form
    {
        Usuario _usuario;
        string _token;
        string urlconection = GlobalVariables.ConnectionUrl;
        public FormAlterarSenha(Usuario usuario,string token)
        {
            InitializeComponent();
            _usuario = usuario;
            _token = token;
        }

        private async void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                    string url = $"{urlconection}/user/{_usuario.Id}";

                    var model = new
                    {
                        SenhaAtual = txtSenhaAtual.Text,
                        NovaSenha = txtNovaSenha.Text
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
                        MessageBox.Show("Senha Alterada com sucesso");
                        this.Close();
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

        private void FormAlterarSenha_Load(object sender, EventArgs e)
        {

        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
