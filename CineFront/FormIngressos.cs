using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineFront.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace CineFront
{
    public partial class FormIngressos : Form
    {
        public Usuario _usuario;
        public string _token;
        string urlconection = GlobalVariables.ConnectionUrl;
        public FormIngressos(Usuario user,string token)
        {
            InitializeComponent();
            _usuario = user;
            _token = token;
        }


        private async void FormIngressos_Load(object sender, EventArgs e)
        {
            await CarregarInfos();
            CarregarIngressos();
            CarregarFotoDePerfil();
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


        public async Task CarregarIngressos()
        {
            var ingressos = await ObterIngressos(_usuario.Id);

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();


            if (ingressos != null && ingressos.Any())
            {
                foreach (var ingresso in ingressos)
                {


                    Panel panelIngressos = new Panel();

                    //AJUSTE DE TAMANHO DA CAIXA 
                    if (_usuario.Role == "Admin")
                    {
                        panelIngressos.Size = new System.Drawing.Size(220, 250);
                    }
                    else
                    {
                        panelIngressos.Size = new System.Drawing.Size(220, 180);
                    }

                    panelIngressos.Margin = new Padding(15);
                    panelIngressos.BackColor = Color.White;
                    panelIngressos.Paint += (sender, e) =>
                    {
                        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                        int radius = 20;
                        path.AddArc(0, 0, radius, radius, 180, 90);
                        path.AddArc(panelIngressos.Width - radius, 0, radius, radius, 270, 90);
                        path.AddArc(panelIngressos.Width - radius, panelIngressos.Height - radius, radius, radius, 0, 90);
                        path.AddArc(0, panelIngressos.Height - radius, radius, radius, 90, 90);
                        path.CloseAllFigures();
                        panelIngressos.Region = new System.Drawing.Region(path);


                        using (Pen pen = new Pen(Color.Gray, 2))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    };


                    Label labelNomeFilme = new Label();
                    labelNomeFilme.Text = ingresso.FilmeNome.ToString();
                    labelNomeFilme.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                    labelNomeFilme.Size = new System.Drawing.Size(200, 30);
                    labelNomeFilme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    labelNomeFilme.Location = new Point(10, 10);


                    Label labelCinema = new Label();
                    labelCinema.Text = ingresso.CinemaNome.ToString();
                    labelCinema.Font = new Font("Century Gothic", 10);
                    labelCinema.Size = new System.Drawing.Size(180, 50);
                    labelCinema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    labelCinema.Location = new Point(20, 60);

                    Label labelAssento = new Label();
                    labelAssento.Text = $"Assentos:{ingresso.Assentos.ToString()}";
                    labelAssento.Font = new Font("Century Gothic", 10);
                    labelAssento.Size = new System.Drawing.Size(180, 50);
                    labelAssento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    labelAssento.Location = new Point(20, 100);


                    panelIngressos.Controls.Add(labelNomeFilme);
                    panelIngressos.Controls.Add(labelCinema);
                    panelIngressos.Controls.Add(labelAssento);


                    //REGRA PARA BOTOES
                    if (_usuario.Role == "Admin")
                    {
                        Button buttonDeletar = new Button();
                        buttonDeletar.Text = "Deletar";
                        buttonDeletar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                        buttonDeletar.Size = new System.Drawing.Size(100, 30);
                        buttonDeletar.Location = new Point(60, 165);
                        buttonDeletar.Cursor = Cursors.Hand;
                        buttonDeletar.Click += (sender, e) => DeletarIngreso(ingresso.Id);
                        panelIngressos.Controls.Add(buttonDeletar);


                        Button buttonEditar = new Button();
                        buttonEditar.Text = "Editar";
                        buttonEditar.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                        buttonEditar.Size = new System.Drawing.Size(100, 30);
                        buttonEditar.Location = new Point(60, 200);
                        buttonEditar.Cursor = Cursors.Hand;
                        //buttonEditar.Click += (sender, e) => EditarCinema(cinema, _token);
                        panelIngressos.Controls.Add(buttonEditar);


                    }
                    flowLayoutPanel1.Controls.Add(panelIngressos);
                }
            }
            else
            {
                Label labelMensagem = new Label();
                labelMensagem.Text = "Não possue ingressos";
                labelMensagem.Font = new Font("Century Gothic", 12, FontStyle.Italic);
                labelMensagem.ForeColor = Color.Gray;
                labelMensagem.AutoSize = true;
                labelMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                labelMensagem.Dock = DockStyle.Fill;
                flowLayoutPanel1.Controls.Add(labelMensagem);
            }

        }

        public async Task<List<Ingresso>> ObterIngressos(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"{urlconection}/ingresso/{id}";

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Ingresso> ingressos = JsonConvert.DeserializeObject<List<Ingresso>>(jsonResponse);

                    return ingressos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter cinemas: {ex.Message}");
                    return new List<Ingresso>();
                }
            }
        }

        //public async Task<Filme> ObterFilme(int id)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            string url = $"{urlconection}/filmesCinema/{id}";

        //            HttpResponseMessage response = await client.GetAsync(url);
        //            response.EnsureSuccessStatusCode();

        //            string jsonResponse = await response.Content.ReadAsStringAsync();

        //            var filmes = JsonConvert.DeserializeObject<List<Filme>>(jsonResponse);

        //            return filmes?.FirstOrDefault();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Erro ao obter filme: {ex.Message}");
        //            return null;
        //        }
        //    }
        //}


        //public async Task<Cinema> ObterCinema(int id)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            string url = $"{urlconection}/cinema/{id}";

        //            HttpResponseMessage response = await client.GetAsync(url);
        //            response.EnsureSuccessStatusCode();

        //            string jsonResponse = await response.Content.ReadAsStringAsync();

        //            Cinema cinema = JsonConvert.DeserializeObject<Cinema>(jsonResponse);

        //            return cinema;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Erro ao obter cinema: {ex.Message}");
        //            return null;
        //        }
        //    }
        //}

        public async Task DeletarIngreso(int id)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja excluir este ingresso?", "Confirmar Exclusão", MessageBoxButtons.YesNo);

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
                            MessageBox.Show("Ingresso deletado com sucesso.");
                            await CarregarIngressos();
                        }
                        else
                        {
                            var errorContent = await response.Content.ReadAsStringAsync();
                            var errorObject = JsonConvert.DeserializeObject<dynamic>(errorContent);
                            MessageBox.Show($"Erro ao deletar ingresso: {errorObject.message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao conectar ao servidor: {ex.Message}");
                    }
                }
            }
        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

