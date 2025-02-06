using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FormCine1 : Form
    {
        private Cinema _cinema;
        private Usuario _usuario;
        private string _token;
        string urlconection = GlobalVariables.ConnectionUrl;

        public FormCine1(Cinema cinema,Usuario user,string token)
        {
            InitializeComponent();
            _cinema = cinema;
            _usuario = user;
            _token = token;
            
        }

        private void FormCine1_Load(object sender, EventArgs e)
        {
            if(_usuario.Role == "Admin")
            {
                buttonAdd.Visible = true;
            }
            labelNomeCine.Text = _cinema.Nome;
            labelEndereco.Text = $"{_cinema.Rua}, {_cinema.Numero}";
            CarregarFotoDePerfil();
            CarregarCatálogo();
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
                    pictureBoxPerfil.Image = img;
                }
            }
        }

        private async void CarregarCatálogo()
        {
            var cinemaID = _cinema.Id;
            var catalogo = await ObterCatalogo(cinemaID);

            catalogoPainel.AutoScroll = true;
            catalogoPainel.Controls.Clear();


            if (catalogo != null && catalogo.Any())
            {
                foreach (var filmes in catalogo)
                {
                    Panel panelCinema = new Panel();

                    //AJUSTE DE TAMANHO DA CAIXA 
                    if (_usuario.Role == "Admin")
                    {
                        panelCinema.Size = new System.Drawing.Size(220, 250);
                    }
                    else
                    {
                        panelCinema.Size = new System.Drawing.Size(220, 180);
                    }

                    panelCinema.Margin = new Padding(15);
                    panelCinema.BackColor = Color.White;
                    panelCinema.Paint += (sender, e) =>
                    {
                        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                        int radius = 20;
                        path.AddArc(0, 0, radius, radius, 180, 90);
                        path.AddArc(panelCinema.Width - radius, 0, radius, radius, 270, 90);
                        path.AddArc(panelCinema.Width - radius, panelCinema.Height - radius, radius, radius, 0, 90);
                        path.AddArc(0, panelCinema.Height - radius, radius, radius, 90, 90);
                        path.CloseAllFigures();
                        panelCinema.Region = new System.Drawing.Region(path);

                        // Desenha a borda
                        using (Pen pen = new Pen(Color.Gray, 2))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    };

                    Label labelNome = new Label();
                    labelNome.Text = filmes.FilmeNome;
                    labelNome.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                    labelNome.Size = new System.Drawing.Size(200, 30);
                    labelNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    labelNome.Location = new Point(10, 10);

                    Label labelHorario = new Label();
                    labelHorario.Text = filmes.Horario.ToString()+"h";
                    labelHorario.Font = new Font("Century Gothic", 10);
                    labelHorario.Size = new System.Drawing.Size(180, 50);
                    labelHorario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    labelHorario.Location = new Point(20, 40);

                    Label labelData = new Label();
                    labelData.Text = filmes.Data.ToString();
                    labelHorario.Font = new Font("Century Gothic", 10);
                    labelHorario.Size = new System.Drawing.Size(180, 50);
                    labelData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    labelData.Location = new Point(60, 100);


                    Button buttonComprar = new Button();
                    buttonComprar.Text = "Comprar";
                    buttonComprar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                    buttonComprar.Size = new System.Drawing.Size(100, 30);
                    buttonComprar.Location = new Point(60, 130);
                    buttonComprar.Cursor = Cursors.Hand;
                    buttonComprar.Click += (sender, e) => ComprarIngresso(filmes,_cinema,_usuario);

                    if(_usuario.Role == "Admin")
                    {
                        Button buttonDeletar = new Button();
                        buttonDeletar.Text = "Deletar";
                        buttonDeletar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                        buttonDeletar.Size = new System.Drawing.Size(100, 30);
                        buttonDeletar.Location = new Point(60, 165);
                        buttonDeletar.Cursor = Cursors.Hand;
                        buttonDeletar.Click += (sender, e) => DeletarFilme(filmes.Id);
                        panelCinema.Controls.Add(buttonDeletar);

                        Button buttonEditar = new Button();
                        buttonEditar.Text = "Editar";
                        buttonEditar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                        buttonEditar.Size = new System.Drawing.Size(100, 30);
                        buttonEditar.Location = new Point(60, 200);
                        buttonEditar.Cursor = Cursors.Hand;
                        buttonEditar.Click += (sender, e) => EditarFilme(filmes, _token);
                        panelCinema.Controls.Add(buttonEditar);
                    }
                 
                    panelCinema.Controls.Add(labelNome);
                    panelCinema.Controls.Add(labelHorario);
                    panelCinema.Controls.Add(labelData);
                    panelCinema.Controls.Add(buttonComprar);
                    

                    catalogoPainel.Controls.Add(panelCinema);
                }
            }
            else
            {
                Label labelMensagem = new Label();
                labelMensagem.Text = "Infelizmente o cinema está sem a programação :(";
                labelMensagem.Font = new Font("Century Gothic", 12, FontStyle.Italic);
                labelMensagem.ForeColor = Color.Gray;
                labelMensagem.AutoSize = true;
                labelMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                labelMensagem.Dock = DockStyle.Fill;
                catalogoPainel.Controls.Add(labelMensagem);
            }
        }

        public async Task<List<Filme>> ObterCatalogo(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"{urlconection}/filmesCinema/{id}"; 

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Filme> filmes = JsonConvert.DeserializeObject<List<Filme>>(jsonResponse);

                    return filmes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter catálogo: {ex.Message}");
                    return new List<Filme>(); 
                }
            }
        }

        private async void DeletarFilme(int id)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja excluir este Filme?", "Confirmar Exclusão", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {

                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

                        string url = $"{urlconection}/removerFilme/{id}";

                        HttpResponseMessage response = await client.DeleteAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Filme deletado com sucesso.");
                            CarregarCatálogo();
                        }
                        else
                        {
                            var errorContent = await response.Content.ReadAsStringAsync();
                            var errorObject = JsonConvert.DeserializeObject<dynamic>(errorContent);
                            MessageBox.Show($"Erro ao deletar filme: {errorObject.message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao conectar ao servidor: {ex.Message}");
                    }
                }
            }
        }

        private void ComprarIngresso(Filme filme, Cinema cinema,Usuario user)
        {
            FormAssentos formAssentos = new FormAssentos(filme, cinema, user);

            this.Hide();
            formAssentos.ShowDialog();
            this.Show();

        }

        private  void EditarFilme(Filme filme, string token)
        {
            FormAtualizarFilme formAtualizarCinema = new FormAtualizarFilme(filme, token);

            this.Hide();
            formAtualizarCinema.ShowDialog();
            this.Show();
            CarregarCatálogo();
        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormPerfil formPerfil = new FormPerfil(_usuario, _token);
            this.Hide();
            formPerfil.ShowDialog();
            this.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja sair?", "Confirmar Saída", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBoxPerfil_Click(object sender, EventArgs e)
        {
            contextMenuFoto.Show(Cursor.Position);
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            FormCadastroFilme formAdicionarFilme = new FormCadastroFilme(_usuario, _token, _cinema);

            this.Hide();
            formAdicionarFilme.ShowDialog();
            this.Show();
            CarregarCatálogo();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIngressos formIngressos = new FormIngressos(_usuario,_token);
            this.Hide();
            formIngressos.ShowDialog();
            this.Show();
        }
    }
}
