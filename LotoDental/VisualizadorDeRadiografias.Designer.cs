namespace LotoDental
{
    partial class VisualizadorDeRadiografias
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
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Radiografia2 = new System.Windows.Forms.PictureBox();
            this.Radiografia1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radiografia2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radiografia1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(51, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(600, 58);
            this.label2.TabIndex = 47;
            this.label2.Text = "Visualizador de Radiografías";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(47, 95);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(192, 44);
            this.button4.TabIndex = 50;
            this.button4.Text = "Buscar Paciente";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(246, 108);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(204, 22);
            this.txtBuscar.TabIndex = 49;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(47, 165);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(422, 181);
            this.dataGridView1.TabIndex = 48;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Radiografia2
            // 
            this.Radiografia2.Location = new System.Drawing.Point(698, 550);
            this.Radiografia2.Name = "Radiografia2";
            this.Radiografia2.Size = new System.Drawing.Size(647, 388);
            this.Radiografia2.TabIndex = 52;
            this.Radiografia2.TabStop = false;
            this.Radiografia2.Click += new System.EventHandler(this.Radiografia2_Click);
            this.Radiografia2.DoubleClick += new System.EventHandler(this.Radiografia2_DoubleClick);
            // 
            // Radiografia1
            // 
            this.Radiografia1.Location = new System.Drawing.Point(698, 50);
            this.Radiografia1.Name = "Radiografia1";
            this.Radiografia1.Size = new System.Drawing.Size(647, 388);
            this.Radiografia1.TabIndex = 51;
            this.Radiografia1.TabStop = false;
            this.Radiografia1.Click += new System.EventHandler(this.Radiografia1_Click);
            this.Radiografia1.DoubleClick += new System.EventHandler(this.Radiografia1_DoubleClick);
            // 
            // VisualizadorDeRadiografias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1796, 950);
            this.Controls.Add(this.Radiografia2);
            this.Controls.Add(this.Radiografia1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Name = "VisualizadorDeRadiografias";
            this.Text = "VisualizadorDeRadiografias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VisualizadorDeRadiografias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radiografia2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radiografia1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox Radiografia1;
        private System.Windows.Forms.PictureBox Radiografia2;
    }
}