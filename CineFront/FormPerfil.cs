using Guna.UI2.WinForms.Suite;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineFront
{
    public partial class FormPerfil : Form
    {
        Usuario _usuario;
        string imagemBase64;
        string _token;
        string urlconection = GlobalVariables.ConnectionUrl;

        public FormPerfil(Usuario user, string token)
        {
            InitializeComponent();
            _usuario = user;
            _token = token;
        }

        private void FormPerfil_Load(object sender, EventArgs e)
        {
            CarregarFotoDePerfil();
            txtNome.Text = _usuario.UserName;
            txtEmail.Text = _usuario.Email;
            labelAssinatura.Text = _usuario.AssinaturaNome;
        }

        private void CarregarFotoDePerfil()
        {
            if (!string.IsNullOrEmpty(_usuario.Imagem))
            {
                string fotoBase64 = _usuario.Imagem.Trim();

                byte[] imagemBytes = Convert.FromBase64String(fotoBase64);

                using (MemoryStream ms = new MemoryStream(imagemBytes))
                {
                    Image img = Image.FromStream(ms);
                    UserImage.Image = img;
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // Criar o OpenFileDialog no código
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                openFileDialog.Title = "Selecione uma imagem";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Carregar a imagem no PictureBox (opcional)
                    Image image = Image.FromFile(openFileDialog.FileName);
                    UserImage.Image = image;

                    // Converter a imagem para Base64
                    imagemBase64 = ConvertImageToBase64(image);
                }
            }
        }

        private string ConvertImageToBase64(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Salvar a imagem no formato PNG (ou outro formato desejado)
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();

                // Converter para Base64
                return Convert.ToBase64String(imageBytes);
            }
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
                        UserName = txtNome.Text,
                        Email = txtEmail.Text,
                        Imagem = imagemBase64
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
                        MessageBox.Show("Atualizado com sucesso.");
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

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            FormAlterarSenha formAlterarSenha = new FormAlterarSenha(_usuario, _token);
            this.Hide();
            formAlterarSenha.ShowDialog();
            this.Show();
        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
