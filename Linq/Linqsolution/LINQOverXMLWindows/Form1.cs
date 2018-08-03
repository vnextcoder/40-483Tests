using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml.Linq;

namespace LINQOverXMLWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XDocument prodDoc;
        XElement rootElement;
        private void Form1_Load(object sender, EventArgs e){            
            try
            {
                prodDoc = XDocument.Load("Products.xml");                
                rootElement = prodDoc.Element("Products");
            }
            catch (System.IO.FileNotFoundException)
            {
                prodDoc = new XDocument();
                prodDoc.Declaration = new XDeclaration("1.0", "utf-16", "yes");
                rootElement = new XElement("Products");
                prodDoc.Add(rootElement);
            }
        }
        private void btnAddProduct_Click(object sender, EventArgs e){
            XElement prodElement = new XElement("Product");
            XAttribute pidAttribute = new XAttribute("PID", txtPID.Text);
            XElement pnameElement = new XElement("PName", txtPName.Text);
            XElement priceElement = new XElement("Price", txtPrice.Text);

            prodElement.Add(pidAttribute);
            prodElement.Add(pnameElement);
            prodElement.Add(priceElement);

            rootElement.Add(prodElement);
            MessageBox.Show("Product Inserted");
            txtPID.Clear();
            txtPName.Clear();
            txtPrice.Clear();
            txtPID.Focus();
        }
        private void btnShowProduct_Click(object sender, EventArgs e){
            MessageBox.Show(prodDoc.ToString());
        }
        private void btnSaveDocument_Click(object sender, EventArgs e){
            prodDoc.Save("Products.xml");
            MessageBox.Show("Products.xml Created");
        }
        private void btnShowInGrid_Click(object sender, EventArgs e){
            DataSet dsProduct = new DataSet();
            dsProduct.ReadXml("Products.xml");
            dgProducts.DataSource = dsProduct.Tables[0];
        }

    }
}
