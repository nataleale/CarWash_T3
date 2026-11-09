namespace Carwash_T3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLavado = new System.Windows.Forms.Button();
            this.btnMecanica = new System.Windows.Forms.Button();
            this.VentaProductos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLavado
            // 
            this.btnLavado.Location = new System.Drawing.Point(23, 21);
            this.btnLavado.Name = "btnLavado";
            this.btnLavado.Size = new System.Drawing.Size(75, 23);
            this.btnLavado.TabIndex = 0;
            this.btnLavado.Text = "Lavado";
            this.btnLavado.UseVisualStyleBackColor = true;
            // 
            // btnMecanica
            // 
            this.btnMecanica.Location = new System.Drawing.Point(23, 61);
            this.btnMecanica.Name = "btnMecanica";
            this.btnMecanica.Size = new System.Drawing.Size(75, 23);
            this.btnMecanica.TabIndex = 1;
            this.btnMecanica.Text = "Mecanica";
            this.btnMecanica.UseVisualStyleBackColor = true;
            // 
            // VentaProductos
            // 
            this.VentaProductos.Location = new System.Drawing.Point(23, 105);
            this.VentaProductos.Name = "VentaProductos";
            this.VentaProductos.Size = new System.Drawing.Size(112, 23);
            this.VentaProductos.TabIndex = 2;
            this.VentaProductos.Text = "VentaProductos";
            this.VentaProductos.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VentaProductos);
            this.Controls.Add(this.btnMecanica);
            this.Controls.Add(this.btnLavado);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLavado;
        private System.Windows.Forms.Button btnMecanica;
        private System.Windows.Forms.Button VentaProductos;
    }
}

