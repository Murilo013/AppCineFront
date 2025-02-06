using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CineFront
{
    public partial class FormAssentos : Form
    {
        int coluna = 99;
        Button[,] b = new Button[10, 20];
        char letra = 'A'; // 0100 0001 em decimal 65 e em hexa 41
        public Filme _filme;
        public Cinema _cinema;
        public Usuario _usuario;
        string urlconection = GlobalVariables.ConnectionUrl;

        public FormAssentos(Filme filme, Cinema cinema, Usuario user)
        {
            InitializeComponent();
            _filme = filme;
            _cinema = cinema;
            _usuario = user;
        }

        private void FormAssentos_Load(object sender, EventArgs e)
        {
            for (int i1 = 0; i1 < 5; i1++)
            {
                for (int i2 = 0; i2 < 10; ++i2)
                {
                    b[i1, i2] = new Button();
                    b[i1, i2].Name = "Botão " + (i2 + 1);
                    b[i1, i2].Text = "" + letra + (i2 + 1);
                    b[i1, i2].Location = new Point(80 * (i2 + 1), coluna);
                    b[i1, i2].BackColor = Color.ForestGreen;
                    b[i1, i2].Size = new System.Drawing.Size(80, 40);
                    b[i1, i2].Click += new System.EventHandler(this.trocarcor);
                    Controls.Add(b[i1, i2]);
                }
                letra++;
                coluna += 40;
            }
        }

        private void trocarcor(object sender, EventArgs e)
        {
            Button aux = (Button)sender;

            if (aux.BackColor != Color.Red)
            {
                var result = MessageBox.Show("Confirmar assento", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (aux.BackColor == Color.ForestGreen)
                    {
                        aux.BackColor = Color.Red;

                    }
                }
                else if (result == DialogResult.No)
                {
                    if (aux.BackColor == Color.Red)
                    {
                        aux.BackColor = Color.ForestGreen;
                    }
                }
            }
            else
            {
                var result = MessageBox.Show("Remover escolha", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aux.BackColor = Color.ForestGreen;
                }
            }

        }

        private async void buttonAssinar2_Click(object sender, EventArgs e)
        {




            int contagem = 0;
            List<string> assentos = new List<string>();

            for (int i1 = 0; i1 < 5; i1++)
            {
                for (int i2 = 0; i2 < 10; ++i2)
                {
                    if (b[i1, i2].BackColor == Color.Red)
                    {
                        contagem++;
                        string assento = b[i1, i2].Text;
                        assentos.Add(assento);
                    }
                }
            }

            decimal total = contagem * _cinema.PrecoIngresso - (_usuario.AssinaturaDesconto * _cinema.PrecoIngresso);

            string assentosSelecionados = string.Join("\n", assentos);
            MessageBox.Show($"Assentos Selecionados:\n{assentosSelecionados}\n\nTotal: R$ {total:F2}", "Resumo");

            var result = MessageBox.Show("Confirmar Compra", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                var newIngresso = new
                {
                    UsuarioId = _usuario.Id,
                    FilmeNome = _filme.FilmeNome,
                    CinemaNome = _cinema.Nome,
                    FilmeData = _filme.Data,
                    Sala = _filme.Sala,
                    Assentos = assentosSelecionados,
                    Total = total
                };

                string jsonContent = JsonConvert.SerializeObject(newIngresso);

                using (HttpClient client = new HttpClient())
                {
                    try
                    {

                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync($"{urlconection}/ingresso", content);

                        if (response.IsSuccessStatusCode)
                        {

                            var responseContent = await response.Content.ReadAsStringAsync();
                            var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                            MessageBox.Show("Ingresso Adquirido com sucesso!");
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
                this.Close();
            }
        }


        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
