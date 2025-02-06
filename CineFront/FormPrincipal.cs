using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineFront
{
    public partial class FormPrincipal : Form
    {
        public Usuario _usuario;
        public string _token;
        string urlconection = GlobalVariables.ConnectionUrl;

        public FormPrincipal(Usuario user, string token)
        {
            InitializeComponent();
            this.Shown += new EventHandler(FormPrincipal_Shown);
            this.Activated += new EventHandler(FormPrincipal_Activated);
            _usuario = user;
            _token = token;
        }

        private async void FormPrincipal_Activated(object sender, EventArgs e)
        {
            await AtualizarDadosDoUsuario();
        }

        private async Task AtualizarDadosDoUsuario()
        {
            await CarregarInfos();
            CarregarFotoDePerfil();
            await CarregarCinemas("Todas");
            await CarregarCidadesComboBox();
        }

        private async void FormPrincipal_Shown(object sender, EventArgs e)
        {
            await AtualizarDadosDoUsuario();
        }


        public async Task CarregarInfos()
        {
            try
            {
                string url = $"{urlconection}/user/{_usuario.Id}";

                using (HttpClient client = new HttpClient())
                {

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {

                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        Usuario usuario = JsonConvert.DeserializeObject<Usuario>(jsonResponse);

                        _usuario = usuario;
                        labelAssinaturauser.Text = usuario.AssinaturaNome.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao carregar o usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar a requisição: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private async Task CarregarCinemas(string cidadeSelecionada)
        {
            var cinemas = await ObterCinemasParceirosAsync();

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();


            if (cinemas != null && cinemas.Any())
            {
                foreach (var cinema in cinemas)
                {
                    if (cinema.Cidade == cidadeSelecionada || cidadeSelecionada == "Todas")
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
                            //BORDA DA CAIXA DO CONTEUDO CINEMA
                            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                            int radius = 20;
                            path.AddArc(0, 0, radius, radius, 180, 90);
                            path.AddArc(panelCinema.Width - radius, 0, radius, radius, 270, 90);
                            path.AddArc(panelCinema.Width - radius, panelCinema.Height - radius, radius, radius, 0, 90);
                            path.AddArc(0, panelCinema.Height - radius, radius, radius, 90, 90);
                            path.CloseAllFigures();
                            panelCinema.Region = new System.Drawing.Region(path);


                            using (Pen pen = new Pen(Color.Gray, 2))
                            {
                                e.Graphics.DrawPath(pen, path);
                            }
                        };


                        Label labelNome = new Label();
                        labelNome.Text = cinema.Nome;
                        labelNome.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                        labelNome.Size = new System.Drawing.Size(200, 30);
                        labelNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        labelNome.Location = new Point(10, 10);


                        Label labelEndereco = new Label();
                        labelEndereco.Text = $"{cinema.Rua}, {cinema.Numero}";
                        labelEndereco.Font = new Font("Century Gothic", 10);
                        labelEndereco.Size = new System.Drawing.Size(180, 50);
                        labelEndereco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        labelEndereco.Location = new Point(20, 60);


                        Button buttonAcessar = new Button();
                        buttonAcessar.Text = "Acessar";
                        buttonAcessar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                        buttonAcessar.Size = new System.Drawing.Size(100, 30);
                        buttonAcessar.Location = new Point(60, 130);
                        buttonAcessar.Cursor = Cursors.Hand;
                        buttonAcessar.Click += (sender, e) => PanelCinema_Click(sender, e, cinema);



                        panelCinema.Controls.Add(labelNome);
                        panelCinema.Controls.Add(labelEndereco);
                        panelCinema.Controls.Add(buttonAcessar);


                        //REGRA PARA BOTOES
                        if (_usuario.Role == "Admin")
                        {
                            Button buttonDeletar = new Button();
                            buttonDeletar.Text = "Deletar";
                            buttonDeletar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                            buttonDeletar.Size = new System.Drawing.Size(100, 30);
                            buttonDeletar.Location = new Point(60, 165);
                            buttonDeletar.Cursor = Cursors.Hand;
                            buttonDeletar.Click += (sender, e) => DeletarCinema(cinema.Id);
                            panelCinema.Controls.Add(buttonDeletar);


                            Button buttonEditar = new Button();
                            buttonEditar.Text = "Editar";
                            buttonEditar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                            buttonEditar.Size = new System.Drawing.Size(100, 30);
                            buttonEditar.Location = new Point(60, 200);
                            buttonEditar.Cursor = Cursors.Hand;
                            buttonEditar.Click += (sender, e) => EditarCinema(cinema, _token);
                            panelCinema.Controls.Add(buttonEditar);


                        }
                        flowLayoutPanel1.Controls.Add(panelCinema);
                    }
                }
            }
            else
            {
                Label labelMensagem = new Label();
                labelMensagem.Text = "Infelizmente não achamos cinemas parceiros :(";
                labelMensagem.Font = new Font("Century Gothic", 12, FontStyle.Italic);
                labelMensagem.ForeColor = Color.Gray;
                labelMensagem.AutoSize = true;
                labelMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                labelMensagem.Dock = DockStyle.Fill;
                flowLayoutPanel1.Controls.Add(labelMensagem);
            }
        }



        private async void DeletarCinema(int id)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja excluir este cinema?", "Confirmar Exclusão", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {

                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

                        string url = $"{urlconection}/cinema/{id}";

                        HttpResponseMessage response = await client.DeleteAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Cinema deletado com sucesso.");
                            await CarregarCinemas("Todas");
                        }
                        else
                        {
                            var errorContent = await response.Content.ReadAsStringAsync();
                            var errorObject = await JsonConvert.DeserializeObject<dynamic>(errorContent);
                            MessageBox.Show($"Erro ao deletar cinema: {errorObject.message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao conectar ao servidor: {ex.Message}");
                    }
                }
            }
        }

        private void PanelCinema_Click(object sender, EventArgs e, Cinema cinema)
        {
            FormCine1 formCinema = new FormCine1(cinema, _usuario, _token);

            this.Hide();
            formCinema.ShowDialog();
            this.Show();
        }


        public async Task<List<Cinema>> ObterCinemasParceirosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"{urlconection}/cinema";

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Cinema> cinemas = JsonConvert.DeserializeObject<List<Cinema>>(jsonResponse);

                    return cinemas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter cinemas: {ex.Message}");
                    return new List<Cinema>();
                }
            }
        }

        public async Task CarregarCidadesComboBox()
        {
            var cinemas = await ObterCinemasParceirosAsync();

            foreach (var cinema in cinemas)
            {
                if (!comboBoxCidades.Items.Contains(cinema.Cidade))
                {
                    comboBoxCidades.Items.Add(cinema.Cidade);
                }
            }
        }

        private async void labelAssinaturas_Click(object sender, EventArgs e)
        {
            FormAssinatura formAssinatura = new FormAssinatura(_usuario);

            this.Hide();
            formAssinatura.ShowDialog();
            this.Show();
            await CarregarInfos();

        }

        private async void EditarCinema(Cinema cinema, string token)
        {
            FormAtualizarCinema formAtualizarCinema = new FormAtualizarCinema(cinema, token);

            this.Hide();
            formAtualizarCinema.ShowDialog();
            await CarregarCinemas("Todas");
            this.Show();
        }

        private async void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            FormCadastroCinema formCadastroCinema = new FormCadastroCinema(_usuario, _token);

            this.Hide();
            formCadastroCinema.ShowDialog();
            await CarregarCinemas("Todas");
            this.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if (_usuario.Role == "Admin")
            {
                buttonAdd.Visible = true;
            }
        }

        private void pictureBoxPerfil_Click(object sender, EventArgs e)
        {
            contextMenuFoto.Show(Cursor.Position);
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

        private async void comboBoxCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cidadeSelecionada = comboBoxCidades.SelectedItem.ToString();
            await CarregarCinemas(cidadeSelecionada);

        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIngressos formIngressos = new FormIngressos(_usuario,_token);
            this.Hide();
            formIngressos.ShowDialog();
            this.Show();
        }

        private void pedidosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormIngressos formIngressos = new FormIngressos(_usuario,_token);
            this.Hide();
            formIngressos.ShowDialog();
            this.Show();
        }
    }
}

