namespace CineFront
{
    partial class FormAssentos
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
            this.BorderRadiusForm = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.buttonAssinar2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.X = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.SuspendLayout();
            // 
            // BorderRadiusForm
            // 
            this.BorderRadiusForm.BorderRadius = 25;
            this.BorderRadiusForm.TargetControl = this;
            // 
            // buttonAssinar2
            // 
            this.buttonAssinar2.CheckedState.Parent = this.buttonAssinar2;
            this.buttonAssinar2.CustomImages.Parent = this.buttonAssinar2;
            this.buttonAssinar2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.buttonAssinar2.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.buttonAssinar2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssinar2.ForeColor = System.Drawing.Color.White;
            this.buttonAssinar2.HoverState.Parent = this.buttonAssinar2;
            this.buttonAssinar2.Location = new System.Drawing.Point(433, 450);
            this.buttonAssinar2.Name = "buttonAssinar2";
            this.buttonAssinar2.ShadowDecoration.Parent = this.buttonAssinar2;
            this.buttonAssinar2.Size = new System.Drawing.Size(132, 38);
            this.buttonAssinar2.TabIndex = 45;
            this.buttonAssinar2.Text = "Comprar";
            this.buttonAssinar2.Click += new System.EventHandler(this.buttonAssinar2_Click);
            // 
            // X
            // 
            this.X.CheckedState.Parent = this.X;
            this.X.CustomImages.Parent = this.X;
            this.X.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(148)))));
            this.X.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.X.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.ForeColor = System.Drawing.Color.White;
            this.X.HoverState.Parent = this.X;
            this.X.Location = new System.Drawing.Point(951, 12);
            this.X.Name = "X";
            this.X.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.X.ShadowDecoration.Parent = this.X;
            this.X.Size = new System.Drawing.Size(37, 37);
            this.X.TabIndex = 46;
            this.X.Text = "<";
            this.X.Click += new System.EventHandler(this.X_Click);
            // 
            // FormAssentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.X);
            this.Controls.Add(this.buttonAssinar2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAssentos";
            this.Text = "FormAssentos";
            this.Load += new System.EventHandler(this.FormAssentos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse BorderRadiusForm;
        private Guna.UI2.WinForms.Guna2GradientButton buttonAssinar2;
        private Guna.UI2.WinForms.Guna2GradientCircleButton X;
    }
}