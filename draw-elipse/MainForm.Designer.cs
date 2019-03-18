namespace draw_elipse
{
    partial class MainForm
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
            this.workSpace = new System.Windows.Forms.PictureBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelDDA = new System.Windows.Forms.Label();
            this.labelBresenham = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // workSpace
            // 
            this.workSpace.Location = new System.Drawing.Point(12, 171);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(500, 500);
            this.workSpace.TabIndex = 0;
            this.workSpace.TabStop = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(201, 50);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 31);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // labelDDA
            // 
            this.labelDDA.AutoSize = true;
            this.labelDDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDDA.Location = new System.Drawing.Point(51, 100);
            this.labelDDA.Name = "labelDDA";
            this.labelDDA.Size = new System.Drawing.Size(78, 24);
            this.labelDDA.TabIndex = 2;
            this.labelDDA.Text = "DDA: 0s";
            // 
            // labelBresenham
            // 
            this.labelBresenham.AutoSize = true;
            this.labelBresenham.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBresenham.Location = new System.Drawing.Point(309, 100);
            this.labelBresenham.Name = "labelBresenham";
            this.labelBresenham.Size = new System.Drawing.Size(136, 24);
            this.labelBresenham.TabIndex = 3;
            this.labelBresenham.Text = "Bresenham: 0s";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 683);
            this.Controls.Add(this.labelBresenham);
            this.Controls.Add(this.labelDDA);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.workSpace);
            this.Name = "MainForm";
            this.Text = "Area de trabajo";
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox workSpace;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelDDA;
        private System.Windows.Forms.Label labelBresenham;
    }
}

