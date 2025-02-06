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
    public partial class FormCadastroFilme : Form
    {
        public string _token;
        public Usuario _usuario;
        public Cinema _cinema;
        string urlconection = GlobalVariables.ConnectionUrl;
        public FormCadastroFilme(Usuario user,string token,Cinema cinema)
        {
            InitializeComponent();
            _usuario = user;
            _cinema = cinema;
            _token = token;
        }

        private async void buttonCadastre_Click(object sender, EventArgs e)
        {
            string filmeNome = txtNomeFilme.Text;
            string duracao = txtDuracao.Text;
            string horario = txtHorario.Text;
            string data = txtData.Text;
            string sala = txtSala.Text;
            

            var filme = new
            {
                FilmeNome = filmeNome,
                Duracao = duracao,
                Horario = horario,
                Data = data,
                Sala = sala,
                CinemaId = _cinema.Id
            };

            string jsonContent = JsonConvert.SerializeObject(filme);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string adminToken = _token;
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", adminToken);

                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{urlconection}/adicionarFilme/{_cinema.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        MessageBox.Show("Filme cadastrado com sucesso");
                        this.Close();
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Erro: {errorContent}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar ao servidor: {ex.Message}");
                }
            }
        }

        private void FromAdicionarFilme_Load(object sender, EventArgs e)
        {

        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
