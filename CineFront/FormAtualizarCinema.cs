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
    public partial class FormAtualizarCinema : Form
    {
        public Cinema _cinema;
        public string _token;
        string urlconection = GlobalVariables.ConnectionUrl;
        public FormAtualizarCinema(Cinema cinema,string token)
        {
            InitializeComponent();
            _cinema = cinema;
            _token = token;
        }

        private void AtualizarCinema_Load(object sender, EventArgs e)
        {
            txtNome.Text = _cinema.Nome;
            txtCEP.Text = _cinema.CEP;
            txtPreco.Text = _cinema.PrecoIngresso.ToString();
            txtCidade.Text = _cinema.Cidade;
            txtRua.Text = _cinema.Rua;
            txtNumero.Text = _cinema.Numero;
        }

        private async void buttonCadastre_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                    string url = $"{urlconection}/cinema/{_cinema.Id}";

                    var model = new
                    {
                        Nome = txtNome.Text,
                        CEP = txtCEP.Text,
                        Cidade = txtCidade.Text,
                        Rua = txtRua.Text,
                        Numero = txtNumero.Text,
                        PrecoIngresso = txtPreco.Text
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
                        MessageBox.Show("Cinema atualizado com sucesso.");
                        this.Close();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("Cinema não encontrado.");
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
