using CineFront.Models;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineFront
{
    public partial class FormCadastroCinema : Form
    {
        public Usuario _usuario;
        public string _token;
        string urlconection = GlobalVariables.ConnectionUrl;

        public FormCadastroCinema(Usuario user, string token)
        {
            InitializeComponent();
            _usuario = user;
            _token = token;
        }

        private async void buttonCadastre_Click_1(object sender, EventArgs e)
        {
            string cnpj = txtCNPJ.Text;
            string nome = txtNome.Text;
            string precoIngresso = txtPreco.Text;
            string cep = txtCEP.Text;
            string rua = txtRua.Text;
            string cidade = txtCidade.Text;
            string numero = txtNumero.Text;

            // Cria um objeto com os dados do cinema
            var cinema = new
            {
                CNPJ = cnpj,
                Nome = nome,
                PrecoIngresso = precoIngresso,
                CEP = cep,
                Rua = rua,
                Numero = numero,
                Cidade = cidade
            };

            string jsonContent = JsonConvert.SerializeObject(cinema);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Define o token do usuário logado (admin)
                    string adminToken = _token;
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", adminToken);

                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{urlconection}/cinema", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        MessageBox.Show("Cinema cadastrado com sucesso");
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

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Endereco endereco = await BuscarCEP();

            if(endereco != null)
            {
                txtCidade.Text = endereco.Localidade;
                txtRua.Text = endereco.Logradouro;
                txtCEP.Text = endereco.Cep;
            }
        }

        private async Task<Endereco> BuscarCEP()
        {
            try
            {
                // Monta a URL com o CEP informado
                string urlCEP = $"https://viacep.com.br/ws/{txtCEP.Text}/json/";

                // Cria o HttpClient e faz a requisição
                using (HttpClient client = new HttpClient())
                {
                    string dadosJSON = await client.GetStringAsync(urlCEP);

                    // Desserializa o JSON para o objeto Endereco
                    Endereco endereco = JsonConvert.DeserializeObject<Endereco>(dadosJSON);

                    return endereco;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("CEP Inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }
}
