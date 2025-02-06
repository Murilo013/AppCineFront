namespace CineFront
{
    partial class FormCine1
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
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.labelNomeCine = new System.Windows.Forms.Label();
            this.labelEndereco = new System.Windows.Forms.Label();
            this.X = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.catalogoPainel = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuFoto = new Guna.UI.WinForms.GunaContextMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAdd = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.pictureBoxPerfil = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.contextMenuFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            this.guna2Elipse1.TargetControl = this;
            // 
            // labelNomeCine
            // 
            this.labelNomeCine.AutoSize = true;
            this.labelNomeCine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.labelNomeCine.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeCine.ForeColor = System.Drawing.Color.White;
            this.labelNomeCine.Location = new System.Drawing.Point(419, 22);
            this.labelNomeCine.Name = "labelNomeCine";
            this.labelNomeCine.Size = new System.Drawing.Size(129, 29);
            this.labelNomeCine.TabIndex = 6;
            this.labelNomeCine.Text = "NomeCine";
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndereco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.labelEndereco.Location = new System.Drawing.Point(26, 473);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(94, 24);
            this.labelEndereco.TabIndex = 8;
            this.labelEndereco.Text = "Endereço";
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
            this.X.Location = new System.Drawing.Point(924, 88);
            this.X.Name = "X";
            this.X.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.X.ShadowDecoration.Parent = this.X;
            this.X.Size = new System.Drawing.Size(37, 37);
            this.X.TabIndex = 21;
            this.X.Text = "<";
            this.X.Click += new System.EventHandler(this.X_Click);
            // 
            // catalogoPainel
            // 
            this.catalogoPainel.Location = new System.Drawing.Point(12, 107);
            this.catalogoPainel.Name = "catalogoPainel";
            this.catalogoPainel.Size = new System.Drawing.Size(857, 340);
            this.catalogoPainel.TabIndex = 22;
            // 
            // contextMenuFoto
            // 
            this.contextMenuFoto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.pedidosToolStripMenuItem,
            this.toolStripMenuItem2});
            this.contextMenuFoto.Name = "contextMenuFoto";
            this.contextMenuFoto.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.contextMenuFoto.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.contextMenuFoto.RenderStyle.ColorTable = null;
            this.contextMenuFoto.RenderStyle.RoundedEdges = true;
            this.contextMenuFoto.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.contextMenuFoto.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.contextMenuFoto.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.contextMenuFoto.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.contextMenuFoto.RenderStyle.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.SystemDefault;
            this.contextMenuFoto.Size = new System.Drawing.Size(181, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Ver Perfil";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pedidosToolStripMenuItem.Text = "Ingressos";
            this.pedidosToolStripMenuItem.Click += new System.EventHandler(this.pedidosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "Sair";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.CheckedState.Parent = this.buttonAdd;
            this.buttonAdd.CustomImages.Parent = this.buttonAdd;
            this.buttonAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.buttonAdd.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.HoverState.Parent = this.buttonAdd;
            this.buttonAdd.Location = new System.Drawing.Point(898, 248);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.buttonAdd.ShadowDecoration.Parent = this.buttonAdd;
            this.buttonAdd.Size = new System.Drawing.Size(53, 53);
            this.buttonAdd.TabIndex = 23;
            this.buttonAdd.Text = "+";
            this.buttonAdd.Visible = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click_1);
            // 
            // pictureBoxPerfil
            // 
            this.pictureBoxPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.pictureBoxPerfil.Image = global::CineFront.Properties.Resources.iconLogin;
            this.pictureBoxPerfil.Location = new System.Drawing.Point(875, 3);
            this.pictureBoxPerfil.Name = "pictureBoxPerfil";
            this.pictureBoxPerfil.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureBoxPerfil.ShadowDecoration.Parent = this.pictureBoxPerfil;
            this.pictureBoxPerfil.Size = new System.Drawing.Size(76, 75);
            this.pictureBoxPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPerfil.TabIndex = 9;
            this.pictureBoxPerfil.TabStop = false;
            this.pictureBoxPerfil.Click += new System.EventHandler(this.pictureBoxPerfil_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.guna2PictureBox2.Image = global::CineFront.Properties.Resources.logo;
            this.guna2PictureBox2.Location = new System.Drawing.Point(12, -2);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
            this.guna2PictureBox2.Size = new System.Drawing.Size(137, 82);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 2;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::CineFront.Properties.Resources.fundo;
            this.guna2PictureBox1.Location = new System.Drawing.Point(-144, -28);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(1131, 108);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // FormCine1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(975, 516);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.catalogoPainel);
            this.Controls.Add(this.X);
            this.Controls.Add(this.pictureBoxPerfil);
            this.Controls.Add(this.labelEndereco);
            this.Controls.Add(this.labelNomeCine);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCine1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCine1";
            this.Load += new System.EventHandler(this.FormCine1_Load);
            this.contextMenuFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label labelNomeCine;
        private System.Windows.Forms.Label labelEndereco;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureBoxPerfil;
        private Guna.UI2.WinForms.Guna2GradientCircleButton X;
        private System.Windows.Forms.FlowLayoutPanel catalogoPainel;
        private Guna.UI.WinForms.GunaContextMenuStrip contextMenuFoto;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private Guna.UI2.WinForms.Guna2GradientCircleButton buttonAdd;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
    }
}