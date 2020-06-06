namespace NovoClasses
{
    partial class fContasPagar_Show
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDocumento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFornecedorNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVencimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBaixa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCcusto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorDocumento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.optEmissao = new System.Windows.Forms.RadioButton();
            this.optVencimento = new System.Windows.Forms.RadioButton();
            this.optPagamento = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblTotalDocumentos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colDocumento,
            this.colFornecedor,
            this.colFornecedorNome,
            this.colEmissao,
            this.colVencimento,
            this.colBaixa,
            this.colCcusto,
            this.colValorDocumento,
            this.colPG});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 89);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1019, 319);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            // 
            // colDocumento
            // 
            this.colDocumento.Text = "Documento";
            this.colDocumento.Width = 100;
            // 
            // colFornecedor
            // 
            this.colFornecedor.Text = "Fornecedor";
            this.colFornecedor.Width = 70;
            // 
            // colFornecedorNome
            // 
            this.colFornecedorNome.Text = "Nome do Fornecedor";
            this.colFornecedorNome.Width = 300;
            // 
            // colEmissao
            // 
            this.colEmissao.Text = "Emissão";
            this.colEmissao.Width = 80;
            // 
            // colVencimento
            // 
            this.colVencimento.Text = "Vencimento";
            this.colVencimento.Width = 80;
            // 
            // colBaixa
            // 
            this.colBaixa.Text = "Baixa";
            this.colBaixa.Width = 80;
            // 
            // colCcusto
            // 
            this.colCcusto.Text = "C.Custo";
            this.colCcusto.Width = 70;
            // 
            // colValorDocumento
            // 
            this.colValorDocumento.Text = "Valor Documento";
            this.colValorDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValorDocumento.Width = 100;
            // 
            // colPG
            // 
            this.colPG.Text = "Pago";
            this.colPG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // optEmissao
            // 
            this.optEmissao.AutoSize = true;
            this.optEmissao.Location = new System.Drawing.Point(12, 12);
            this.optEmissao.Name = "optEmissao";
            this.optEmissao.Size = new System.Drawing.Size(64, 17);
            this.optEmissao.TabIndex = 1;
            this.optEmissao.Text = "Emissão";
            this.optEmissao.UseVisualStyleBackColor = true;
            // 
            // optVencimento
            // 
            this.optVencimento.AutoSize = true;
            this.optVencimento.Checked = true;
            this.optVencimento.Location = new System.Drawing.Point(12, 35);
            this.optVencimento.Name = "optVencimento";
            this.optVencimento.Size = new System.Drawing.Size(81, 17);
            this.optVencimento.TabIndex = 2;
            this.optVencimento.TabStop = true;
            this.optVencimento.Text = "Vencimento";
            this.optVencimento.UseVisualStyleBackColor = true;
            // 
            // optPagamento
            // 
            this.optPagamento.AutoSize = true;
            this.optPagamento.Location = new System.Drawing.Point(12, 58);
            this.optPagamento.Name = "optPagamento";
            this.optPagamento.Size = new System.Drawing.Size(79, 17);
            this.optPagamento.TabIndex = 3;
            this.optPagamento.Text = "Pagamento";
            this.optPagamento.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(99, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 63);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Intervalo";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(131, 23);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(107, 22);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 22);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // lblTotalDocumentos
            // 
            this.lblTotalDocumentos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTotalDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDocumentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDocumentos.Location = new System.Drawing.Point(858, 419);
            this.lblTotalDocumentos.Name = "lblTotalDocumentos";
            this.lblTotalDocumentos.Size = new System.Drawing.Size(97, 23);
            this.lblTotalDocumentos.TabIndex = 5;
            this.lblTotalDocumentos.Text = "0,00";
            this.lblTotalDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(738, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total dos Documentos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.lblFornecedor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtFornecedor);
            this.groupBox2.Location = new System.Drawing.Point(358, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 71);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outros Filtros";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gold;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(150, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(344, 21);
            this.label4.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Centro Custos";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 20);
            this.textBox1.TabIndex = 12;
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.BackColor = System.Drawing.Color.Gold;
            this.lblFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFornecedor.Location = new System.Drawing.Point(150, 19);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(344, 21);
            this.lblFornecedor.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fornecedor";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(85, 19);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(68, 20);
            this.txtFornecedor.TabIndex = 9;
            this.txtFornecedor.TextChanged += new System.EventHandler(this.txtFornecedor_TextChanged);
            this.txtFornecedor.Leave += new System.EventHandler(this.txtFornecedor_Leave);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::NovoClasses.Properties.Resources.pesquisar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(896, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 55);
            this.button1.TabIndex = 8;
            this.button1.Text = "Pesquisar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(35, 418);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(58, 20);
            this.txtID.TabIndex = 9;
            // 
            // fContasPagar_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalDocumentos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.optPagamento);
            this.Controls.Add(this.optVencimento);
            this.Controls.Add(this.optEmissao);
            this.Controls.Add(this.listView1);
            this.Name = "fContasPagar_Show";
            this.Text = "Contas a Pagar - Show";
            this.Load += new System.EventHandler(this.fContasPagar_Show_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colFornecedor;
        private System.Windows.Forms.ColumnHeader colFornecedorNome;
        private System.Windows.Forms.ColumnHeader colEmissao;
        private System.Windows.Forms.ColumnHeader colVencimento;
        private System.Windows.Forms.ColumnHeader colBaixa;
        private System.Windows.Forms.ColumnHeader colCcusto;
        private System.Windows.Forms.ColumnHeader colValorDocumento;
        private System.Windows.Forms.ColumnHeader colPG;
        private System.Windows.Forms.ColumnHeader colDocumento;
        private System.Windows.Forms.RadioButton optEmissao;
        private System.Windows.Forms.RadioButton optVencimento;
        private System.Windows.Forms.RadioButton optPagamento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblTotalDocumentos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
    }
}