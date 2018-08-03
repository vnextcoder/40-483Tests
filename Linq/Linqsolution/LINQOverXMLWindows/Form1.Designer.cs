namespace LINQOverXMLWindows
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnShowProduct = new System.Windows.Forms.Button();
            this.btnSaveDocument = new System.Windows.Forms.Button();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.btnShowInGrid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product ID";
            // 
            // txtPID
            // 
            this.txtPID.Location = new System.Drawing.Point(121, 12);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(195, 22);
            this.txtPID.TabIndex = 1;
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(121, 56);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(195, 22);
            this.txtPName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(121, 108);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(195, 22);
            this.txtPrice.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Price";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(346, 11);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(234, 33);
            this.btnAddProduct.TabIndex = 6;
            this.btnAddProduct.Text = "AddProduct";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnShowProduct
            // 
            this.btnShowProduct.Location = new System.Drawing.Point(346, 59);
            this.btnShowProduct.Name = "btnShowProduct";
            this.btnShowProduct.Size = new System.Drawing.Size(234, 33);
            this.btnShowProduct.TabIndex = 7;
            this.btnShowProduct.Text = "ShowProduct";
            this.btnShowProduct.UseVisualStyleBackColor = true;
            this.btnShowProduct.Click += new System.EventHandler(this.btnShowProduct_Click);
            // 
            // btnSaveDocument
            // 
            this.btnSaveDocument.Location = new System.Drawing.Point(346, 111);
            this.btnSaveDocument.Name = "btnSaveDocument";
            this.btnSaveDocument.Size = new System.Drawing.Size(234, 33);
            this.btnSaveDocument.TabIndex = 8;
            this.btnSaveDocument.Text = "SaveDocument";
            this.btnSaveDocument.UseVisualStyleBackColor = true;
            this.btnSaveDocument.Click += new System.EventHandler(this.btnSaveDocument_Click);
            // 
            // dgProducts
            // 
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Location = new System.Drawing.Point(12, 177);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(568, 209);
            this.dgProducts.TabIndex = 9;
            // 
            // btnShowInGrid
            // 
            this.btnShowInGrid.Location = new System.Drawing.Point(12, 405);
            this.btnShowInGrid.Name = "btnShowInGrid";
            this.btnShowInGrid.Size = new System.Drawing.Size(234, 33);
            this.btnShowInGrid.TabIndex = 10;
            this.btnShowInGrid.Text = "ShowInGrid";
            this.btnShowInGrid.UseVisualStyleBackColor = true;
            this.btnShowInGrid.Click += new System.EventHandler(this.btnShowInGrid_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 450);
            this.Controls.Add(this.btnShowInGrid);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.btnSaveDocument);
            this.Controls.Add(this.btnShowProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnShowProduct;
        private System.Windows.Forms.Button btnSaveDocument;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.Button btnShowInGrid;
    }
}

