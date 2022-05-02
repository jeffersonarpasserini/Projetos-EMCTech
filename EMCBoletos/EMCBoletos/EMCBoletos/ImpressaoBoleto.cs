using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EMCEmissorTitulos
{
    public partial class ImpressaoBoleto : Form
    {
        public ImpressaoBoleto()
        {
            InitializeComponent();
        }

        private void visualizarImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVisualizarImagem form = new FormVisualizarImagem(GerarImagem());
            form.ShowDialog();
            
        }

        private string GerarImagem()
        {
            string address = webBrowser.Url.ToString();
            int width = 670;
            int height = 805;

            int webBrowserWidth = 670;
            int webBrowserHeight = 805;

            System.Drawing.Bitmap bmp = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, webBrowserWidth, webBrowserHeight, width, height);

            string file = Path.Combine(Environment.CurrentDirectory, "boleto.bmp");

            bmp.Save(file);

            return file;
        }

        private void enviarImagemPorEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnviarEmail form = new EnviarEmail(GerarImagem());
            form.ShowDialog();
        }

        private void gerarArquivoPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imagePath = GerarImagem();

            string pdfPath = Path.Combine(Environment.CurrentDirectory, "boleto.pdf");

            Document doc = new Document();
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
                doc.Open();
                Image gif = Image.GetInstance(imagePath);
                gif.ScaleAbsolute(520f, 624f);
                doc.Add(gif);
            }
            catch (DocumentException dex)
            {
                MessageBox.Show(dex.Message);
            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                doc.Close();
            }

            System.Diagnostics.Process.Start(pdfPath);
        }

        private void PrintDocument(object sender,  WebBrowserDocumentCompletedEventArgs e)
        {
            // Print the document now that it is fully loaded.
            ((WebBrowser)sender).Print();

            // Dispose the WebBrowser now that the task is complete. 
            ((WebBrowser)sender).Dispose();
        }
    }
}