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
using Newtonsoft.Json; // Biblioteca para manipulação de JSON

namespace CineFront
{
    public partial class FormLogin : Form
    {
        string urlconection = GlobalVariables.ConnectionUrl;
        public FormLogin()
        {
            InitializeComponent();
        }

        private async void buttonEntrar_Click(object sender, EventArgs e)
        {
            buttonEntrar.Visible = false;
            buttonCadastre.Visible = false;
            loading.Visible = true;

            string username = txtUsuario.Text;
            string password = txtSenha.Text;

            // Cria um objeto com os dados de login
            var loginData = new
            {
                UserName = username,
                Senha = password
            };

            // Converte o objeto para JSON
            string jsonContent = JsonConvert.SerializeObject(loginData);

            using (HttpClient client = new HttpClient())
            {
                try
                {

                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{urlconection}/user/login", content);

                    if (response.IsSuccessStatusCode)
                    {

                        var responseContent = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);

                        string token = responseObject.token;
                        int id = responseObject.id;
                        var user = await pegarInfo(id);

                        FormPrincipal principal = new FormPrincipal(user,token);
                        this.Hide();
                        principal.ShowDialog();
                        this.Show();
                    }
                    else
                    {                     
                        var errorContent = await response.Content.ReadAsStringAsync();
                        var errorObject = JsonConvert.DeserializeObject<dynamic>(errorContent);
                        MessageBox.Show($"Erro: {errorObject.message}");
                        buttonEntrar.Visible = true;
                        buttonCadastre.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar ao servidor: {ex.Message}");
                }
                finally
                {
                    loading.Visible = false;
                }
            }
        }

        public async Task<Usuario> pegarInfo(int usuarioId)
        {
            try
            {
                // URL da API (substitua pela URL real da sua API)
                string url = $"{urlconection}/user/{usuarioId}";

                // Criando o cliente HTTP
                using (HttpClient client = new HttpClient())
                {
                    // Realiza a requisição GET
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // Lê a resposta como string (JSON)
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Desserializa o JSON para um objeto de usuário
                        Usuario usuario = JsonConvert.DeserializeObject<Usuario>(jsonResponse);

                        return usuario;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao carregar o usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Erro ao realizar a requisição: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCadastre_Click(object sender, EventArgs e)
        {
            FormCadastro formCadastro = new FormCadastro();

            this.Hide();

            // Mostra o novo formulário
            formCadastro.ShowDialog();

            // Fecha o formulário atual
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar)
            {
                txtSenha.UseSystemPasswordChar = false; 
                pictureEye.Image = Properties.Resources.olhoaberto1; 
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true; 
                pictureEye.Image = Properties.Resources.olhofechado1; 
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }
    }
}
