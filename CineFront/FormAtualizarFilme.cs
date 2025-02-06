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
    public partial class FormAtualizarFilme : Form
    {
        public Filme _filme;
        public string _token;
        string urlconection = GlobalVariables.ConnectionUrl;
        public FormAtualizarFilme(Filme filme, string token)
        {
            InitializeComponent();
            _filme = filme;
            _token = token;
        }

        private void FormAtualizarFilme_Load(object sender, EventArgs e)
        {
            txtNomeFilme.Text = _filme.FilmeNome;
            txtDuracao.Text = _filme.Duracao.ToString();
            txtHorario.Text = _filme.Horario.ToString();
            txtData.Text = _filme.Data;
            txtSala.Text = _filme.Sala;
        }

        private async void buttonCadastre_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                    string url = $"{urlconection}/atualizarFilme/{_filme.Id}";

                    var model = new
                    {
                       FilmeNome = txtNomeFilme.Text,
                       Duracao = txtDuracao.Text,
                       Horario = txtHorario.Text,
                       Data = txtData.Text,
                       Sala = txtSala.Text,
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
                        MessageBox.Show("Filme atualizado com sucesso.");
                        this.Close();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("Filme não encontrado.");
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
    }
}
