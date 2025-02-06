using Guna.UI2.WinForms.Suite;
using Newtonsoft.Json;
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
    public partial class FormCadastro : Form
    {
        string imagemBase64;
        string urlconection = GlobalVariables.ConnectionUrl;
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string username = txtUsernameCadastro.Text;
            string email = txtEmailCadastro.Text;
            string password = txtSenhaCadastro.Text;

            // Cria um objeto com os dados de login
            var registerData = new
            {
                UserName = username,
                Email = email,
                Imagem = imagemBase64,
                Senha = password,
            };

            // Converte o objeto para JSON
            string jsonContent = JsonConvert.SerializeObject(registerData);

            using (HttpClient client = new HttpClient())
            {
                try
                {

                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{urlconection}/user", content);

                    if (response.IsSuccessStatusCode)
                    {

                        var responseContent = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        MessageBox.Show("Usuario Cadastrado com Sucesso");
                        this.Close();
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        var errorObject = JsonConvert.DeserializeObject<dynamic>(errorContent);
                        MessageBox.Show($"Erro: {errorObject.message}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar ao servidor: {ex.Message}");
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
                    pictureBox.Image = image;

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
    }
}
