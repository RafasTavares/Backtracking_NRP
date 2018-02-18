namespace Backtracking_NRP
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtCustoRequisito = new System.Windows.Forms.TextBox();
            this.txtInteresseRequisito = new System.Windows.Forms.TextBox();
            this.txtPesoPatrocinador = new System.Windows.Forms.TextBox();
            this.custoRequisito = new System.Windows.Forms.Label();
            this.interesseRequisito = new System.Windows.Forms.Label();
            this.lblPesoRequi = new System.Windows.Forms.Label();
            this.pnlGerarDados = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQtdRequisitos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQtdPatrocinadores = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQtdRelease = new System.Windows.Forms.TextBox();
            this.pnlGerarDados.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(594, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Gerar dados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCustoRequisito
            // 
            this.txtCustoRequisito.Location = new System.Drawing.Point(260, 51);
            this.txtCustoRequisito.Name = "txtCustoRequisito";
            this.txtCustoRequisito.Size = new System.Drawing.Size(53, 22);
            this.txtCustoRequisito.TabIndex = 1;
            // 
            // txtInteresseRequisito
            // 
            this.txtInteresseRequisito.Location = new System.Drawing.Point(260, 89);
            this.txtInteresseRequisito.Name = "txtInteresseRequisito";
            this.txtInteresseRequisito.Size = new System.Drawing.Size(53, 22);
            this.txtInteresseRequisito.TabIndex = 2;
            // 
            // txtPesoPatrocinador
            // 
            this.txtPesoPatrocinador.Location = new System.Drawing.Point(260, 124);
            this.txtPesoPatrocinador.Name = "txtPesoPatrocinador";
            this.txtPesoPatrocinador.Size = new System.Drawing.Size(53, 22);
            this.txtPesoPatrocinador.TabIndex = 3;
            // 
            // custoRequisito
            // 
            this.custoRequisito.AutoSize = true;
            this.custoRequisito.Location = new System.Drawing.Point(122, 54);
            this.custoRequisito.Name = "custoRequisito";
            this.custoRequisito.Size = new System.Drawing.Size(130, 17);
            this.custoRequisito.TabIndex = 4;
            this.custoRequisito.Text = "Valor max. CUSTO:";
            // 
            // interesseRequisito
            // 
            this.interesseRequisito.AutoSize = true;
            this.interesseRequisito.Location = new System.Drawing.Point(95, 92);
            this.interesseRequisito.Name = "interesseRequisito";
            this.interesseRequisito.Size = new System.Drawing.Size(159, 17);
            this.interesseRequisito.TabIndex = 5;
            this.interesseRequisito.Text = "Valor max. INTERESSE:";
            // 
            // lblPesoRequi
            // 
            this.lblPesoRequi.AutoSize = true;
            this.lblPesoRequi.Location = new System.Drawing.Point(50, 124);
            this.lblPesoRequi.Name = "lblPesoRequi";
            this.lblPesoRequi.Size = new System.Drawing.Size(204, 17);
            this.lblPesoRequi.TabIndex = 6;
            this.lblPesoRequi.Text = "Valor max. PESO patrocinador:";
            // 
            // pnlGerarDados
            // 
            this.pnlGerarDados.Controls.Add(this.label1);
            this.pnlGerarDados.Controls.Add(this.label2);
            this.pnlGerarDados.Controls.Add(this.txtQtdRelease);
            this.pnlGerarDados.Controls.Add(this.label3);
            this.pnlGerarDados.Controls.Add(this.txtQtdRequisitos);
            this.pnlGerarDados.Controls.Add(this.label4);
            this.pnlGerarDados.Controls.Add(this.txtQtdPatrocinadores);
            this.pnlGerarDados.Controls.Add(this.custoRequisito);
            this.pnlGerarDados.Controls.Add(this.button1);
            this.pnlGerarDados.Controls.Add(this.txtPesoPatrocinador);
            this.pnlGerarDados.Controls.Add(this.lblPesoRequi);
            this.pnlGerarDados.Controls.Add(this.txtInteresseRequisito);
            this.pnlGerarDados.Controls.Add(this.interesseRequisito);
            this.pnlGerarDados.Controls.Add(this.txtCustoRequisito);
            this.pnlGerarDados.Location = new System.Drawing.Point(12, 12);
            this.pnlGerarDados.Name = "pnlGerarDados";
            this.pnlGerarDados.Size = new System.Drawing.Size(840, 162);
            this.pnlGerarDados.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Informe os dados para geração automática dos requisítos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Qtd. Patrocinadores:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Custo max. release:";
            // 
            // txtQtdRequisitos
            // 
            this.txtQtdRequisitos.Location = new System.Drawing.Point(500, 86);
            this.txtQtdRequisitos.Name = "txtQtdRequisitos";
            this.txtQtdRequisitos.Size = new System.Drawing.Size(53, 22);
            this.txtQtdRequisitos.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Qtd. Requisítos:";
            // 
            // txtQtdPatrocinadores
            // 
            this.txtQtdPatrocinadores.Location = new System.Drawing.Point(500, 48);
            this.txtQtdPatrocinadores.Name = "txtQtdPatrocinadores";
            this.txtQtdPatrocinadores.Size = new System.Drawing.Size(53, 22);
            this.txtQtdPatrocinadores.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(13, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 163);
            this.panel1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(164, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(493, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Informe os dados para geração automática dos requisítos";
            // 
            // txtQtdRelease
            // 
            this.txtQtdRelease.Location = new System.Drawing.Point(500, 122);
            this.txtQtdRelease.Name = "txtQtdRelease";
            this.txtQtdRelease.Size = new System.Drawing.Size(53, 22);
            this.txtQtdRelease.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 710);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGerarDados);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlGerarDados.ResumeLayout(false);
            this.pnlGerarDados.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCustoRequisito;
        private System.Windows.Forms.TextBox txtInteresseRequisito;
        private System.Windows.Forms.TextBox txtPesoPatrocinador;
        private System.Windows.Forms.Label custoRequisito;
        private System.Windows.Forms.Label interesseRequisito;
        private System.Windows.Forms.Label lblPesoRequi;
        private System.Windows.Forms.Panel pnlGerarDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQtdRequisitos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQtdPatrocinadores;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtQtdRelease;
        private System.Windows.Forms.Label label5;
    }
}