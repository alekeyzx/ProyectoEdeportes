namespace ProyectoEdeportes
{
    partial class Inicio
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCalcularBono = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCalcularEdad = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.IndianRed;
            this.panel4.Location = new System.Drawing.Point(12, 427);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1196, 5);
            this.panel4.TabIndex = 17;
            // 
            // btnCalcularBono
            // 
            this.btnCalcularBono.FlatAppearance.BorderSize = 0;
            this.btnCalcularBono.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.btnCalcularBono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularBono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnCalcularBono.Location = new System.Drawing.Point(12, 301);
            this.btnCalcularBono.Name = "btnCalcularBono";
            this.btnCalcularBono.Size = new System.Drawing.Size(1196, 131);
            this.btnCalcularBono.TabIndex = 16;
            this.btnCalcularBono.Text = "Calcular bono";
            this.btnCalcularBono.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.IndianRed;
            this.panel3.Location = new System.Drawing.Point(12, 290);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1196, 5);
            this.panel3.TabIndex = 15;
            // 
            // btnCalcularEdad
            // 
            this.btnCalcularEdad.FlatAppearance.BorderSize = 0;
            this.btnCalcularEdad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.btnCalcularEdad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularEdad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnCalcularEdad.Location = new System.Drawing.Point(12, 164);
            this.btnCalcularEdad.Name = "btnCalcularEdad";
            this.btnCalcularEdad.Size = new System.Drawing.Size(1196, 131);
            this.btnCalcularEdad.TabIndex = 14;
            this.btnCalcularEdad.Text = "Calcular edad del jugador";
            this.btnCalcularEdad.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(12, 123);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(1196, 35);
            this.txtID.TabIndex = 18;
            this.txtID.Text = "ID";
            this.txtID.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1220, 442);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnCalcularBono);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnCalcularEdad);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCalcularBono;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCalcularEdad;
        private System.Windows.Forms.TextBox txtID;
    }
}