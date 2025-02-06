namespace CineFront
{
    partial class FormCadastroFilme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.X = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.buttonCadastre = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NomeLabel = new System.Windows.Forms.Label();
            this.CNPJlabel = new System.Windows.Forms.Label();
            this.txtData = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtHorario = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDuracao = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNomeFilme = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSala = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 25;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = null;
            // 
            // X
            // 
            this.X.CheckedState.Parent = this.X;
            this.X.CustomImages.Parent = this.X;
            this.X.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.X.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.X.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.ForeColor = System.Drawing.Color.White;
            this.X.HoverState.Parent = this.X;
            this.X.Location = new System.Drawing.Point(751, 90);
            this.X.Name = "X";
            this.X.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.X.ShadowDecoration.Parent = this.X;
            this.X.Size = new System.Drawing.Size(37, 37);
            this.X.TabIndex = 34;
            this.X.Text = "<";
            this.X.Click += new System.EventHandler(this.X_Click);
            // 
            // buttonCadastre
            // 
            this.buttonCadastre.CheckedState.Parent = this.buttonCadastre;
            this.buttonCadastre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCadastre.CustomImages.Parent = this.buttonCadastre;
            this.buttonCadastre.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.buttonCadastre.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.buttonCadastre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCadastre.ForeColor = System.Drawing.Color.White;
            this.buttonCadastre.HoverState.Parent = this.buttonCadastre;
            this.buttonCadastre.Location = new System.Drawing.Point(301, 390);
            this.buttonCadastre.Name = "buttonCadastre";
            this.buttonCadastre.ShadowDecoration.Parent = this.buttonCadastre;
            this.buttonCadastre.Size = new System.Drawing.Size(180, 45);
            this.buttonCadastre.TabIndex = 33;
            this.buttonCadastre.Text = "Cadastrar";
            this.buttonCadastre.Click += new System.EventHandler(this.buttonCadastre_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(230, 25);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(344, 40);
            this.guna2HtmlLabel1.TabIndex = 23;
            this.guna2HtmlLabel1.Text = "Adicionar Programação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(309, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(309, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Horário";
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeLabel.ForeColor = System.Drawing.Color.Black;
            this.NomeLabel.Location = new System.Drawing.Point(309, 153);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(70, 20);
            this.NomeLabel.TabIndex = 29;
            this.NomeLabel.Text = "Duração";
            // 
            // CNPJlabel
            // 
            this.CNPJlabel.AutoSize = true;
            this.CNPJlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CNPJlabel.ForeColor = System.Drawing.Color.Black;
            this.CNPJlabel.Location = new System.Drawing.Point(309, 91);
            this.CNPJlabel.Name = "CNPJlabel";
            this.CNPJlabel.Size = new System.Drawing.Size(47, 20);
            this.CNPJlabel.TabIndex = 28;
            this.CNPJlabel.Text = "Filme";
            // 
            // txtData
            // 
            this.txtData.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.txtData.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtData.DefaultText = "";
            this.txtData.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtData.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtData.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtData.DisabledState.Parent = this.txtData;
            this.txtData.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtData.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtData.FocusedState.Parent = this.txtData;
            this.txtData.ForeColor = System.Drawing.Color.Black;
            this.txtData.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtData.HoverState.Parent = this.txtData;
            this.txtData.Location = new System.Drawing.Point(301, 283);
            this.txtData.Name = "txtData";
            this.txtData.PasswordChar = '\0';
            this.txtData.PlaceholderText = "";
            this.txtData.SelectedText = "";
            this.txtData.ShadowDecoration.Parent = this.txtData;
            this.txtData.Size = new System.Drawing.Size(180, 35);
            this.txtData.TabIndex = 27;
            // 
            // txtHorario
            // 
            this.txtHorario.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.txtHorario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHorario.DefaultText = "";
            this.txtHorario.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHorario.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHorario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHorario.DisabledState.Parent = this.txtHorario;
            this.txtHorario.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHorario.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHorario.FocusedState.Parent = this.txtHorario;
            this.txtHorario.ForeColor = System.Drawing.Color.Black;
            this.txtHorario.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHorario.HoverState.Parent = this.txtHorario;
            this.txtHorario.Location = new System.Drawing.Point(301, 226);
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.PasswordChar = '\0';
            this.txtHorario.PlaceholderText = "";
            this.txtHorario.SelectedText = "";
            this.txtHorario.ShadowDecoration.Parent = this.txtHorario;
            this.txtHorario.Size = new System.Drawing.Size(180, 36);
            this.txtHorario.TabIndex = 26;
            // 
            // txtDuracao
            // 
            this.txtDuracao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.txtDuracao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDuracao.DefaultText = "";
            this.txtDuracao.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDuracao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDuracao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDuracao.DisabledState.Parent = this.txtDuracao;
            this.txtDuracao.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDuracao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDuracao.FocusedState.Parent = this.txtDuracao;
            this.txtDuracao.ForeColor = System.Drawing.Color.Black;
            this.txtDuracao.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDuracao.HoverState.Parent = this.txtDuracao;
            this.txtDuracao.Location = new System.Drawing.Point(301, 165);
            this.txtDuracao.Name = "txtDuracao";
            this.txtDuracao.PasswordChar = '\0';
            this.txtDuracao.PlaceholderText = "";
            this.txtDuracao.SelectedText = "";
            this.txtDuracao.ShadowDecoration.Parent = this.txtDuracao;
            this.txtDuracao.Size = new System.Drawing.Size(180, 36);
            this.txtDuracao.TabIndex = 25;
            // 
            // txtNomeFilme
            // 
            this.txtNomeFilme.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.txtNomeFilme.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNomeFilme.DefaultText = "";
            this.txtNomeFilme.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNomeFilme.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNomeFilme.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNomeFilme.DisabledState.Parent = this.txtNomeFilme;
            this.txtNomeFilme.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNomeFilme.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNomeFilme.FocusedState.Parent = this.txtNomeFilme;
            this.txtNomeFilme.ForeColor = System.Drawing.Color.Black;
            this.txtNomeFilme.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNomeFilme.HoverState.Parent = this.txtNomeFilme;
            this.txtNomeFilme.Location = new System.Drawing.Point(301, 106);
            this.txtNomeFilme.Name = "txtNomeFilme";
            this.txtNomeFilme.PasswordChar = '\0';
            this.txtNomeFilme.PlaceholderText = "";
            this.txtNomeFilme.SelectedText = "";
            this.txtNomeFilme.ShadowDecoration.Parent = this.txtNomeFilme;
            this.txtNomeFilme.Size = new System.Drawing.Size(180, 36);
            this.txtNomeFilme.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(309, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Sala";
            // 
            // txtSala
            // 
            this.txtSala.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.txtSala.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSala.DefaultText = "";
            this.txtSala.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSala.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSala.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSala.DisabledState.Parent = this.txtSala;
            this.txtSala.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSala.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSala.FocusedState.Parent = this.txtSala;
            this.txtSala.ForeColor = System.Drawing.Color.Black;
            this.txtSala.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSala.HoverState.Parent = this.txtSala;
            this.txtSala.Location = new System.Drawing.Point(301, 338);
            this.txtSala.Name = "txtSala";
            this.txtSala.PasswordChar = '\0';
            this.txtSala.PlaceholderText = "";
            this.txtSala.SelectedText = "";
            this.txtSala.ShadowDecoration.Parent = this.txtSala;
            this.txtSala.Size = new System.Drawing.Size(180, 35);
            this.txtSala.TabIndex = 35;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::CineFront.Properties.Resources.fundo;
            this.guna2PictureBox1.Location = new System.Drawing.Point(-90, -24);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(1015, 108);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 32;
            this.guna2PictureBox1.TabStop = false;
            // 
            // FormCadastroFilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSala);
            this.Controls.Add(this.X);
            this.Controls.Add(this.buttonCadastre);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NomeLabel);
            this.Controls.Add(this.CNPJlabel);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtHorario);
            this.Controls.Add(this.txtDuracao);
            this.Controls.Add(this.txtNomeFilme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCadastroFilme";
            this.Text = "FromAdicionarFilme";
            this.Load += new System.EventHandler(this.FromAdicionarFilme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Guna.UI2.WinForms.Guna2GradientCircleButton X;
        private Guna.UI2.WinForms.Guna2GradientButton buttonCadastre;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NomeLabel;
        private System.Windows.Forms.Label CNPJlabel;
        private Guna.UI2.WinForms.Guna2TextBox txtData;
        private Guna.UI2.WinForms.Guna2TextBox txtHorario;
        private Guna.UI2.WinForms.Guna2TextBox txtDuracao;
        private Guna.UI2.WinForms.Guna2TextBox txtNomeFilme;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtSala;
    }
}