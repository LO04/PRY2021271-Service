using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using Azure.Storage.Blobs;
using Cap_Pantalla.Services;
using Cap_Pantalla.Model;

namespace Cap_Pantalla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            if(timer1.Enabled)
            {
                timer2.Start();
            }
        }

        private void btcapturar_Click(object sender, EventArgs e)
        {
            //contador = 0;
            //timer1.Start();

            this.Visible = false;
        }

        private void btguardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog dg = new SaveFileDialog();
            dg.Filter = "Imagen | .png";

            if (dg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageFormat formato = ImageFormat.Png;
                pictureBoxing.Image.Save(dg.FileName, formato);
            }


        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            Rectangle limites = Screen.GetBounds(Point.Empty);
            Bitmap imgb = new Bitmap(limites.Width, limites.Height);
            Graphics graf = Graphics.FromImage(imgb);
            graf.CopyFromScreen(Point.Empty, Point.Empty, limites.Size);
            pictureBoxing.Image = imgb;

            this.Visible = true;

        }

        private async void timer2_Tick(object sender, EventArgs e)
        {

            //Image imagen = this.pictureBoxing.BackgroundImage;

            //string pathDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string Date = DateTime.Now.ToString("dd-MM-yyyy");
            string filename = String.Format("file{0}-{1}.jpg", Date, DateTime.Now.Ticks);
            string directorio = "C:\\IMAGENES";
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            string ruta = Path.Combine(directorio, filename);
            pictureBoxing.Image.Save(ruta, ImageFormat.Jpeg);

            var blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=montracblobstorage;AccountKey=38jbNkUcrrfKlFWiEWBgVL3LuXRjumPkKQZZroJ7JSJo17TQgwbMDI3oOr5LwNMwrr9TxUtUtumD+AStBF/MNw==;EndpointSuffix=core.windows.net";
            var blobStorageContainerName = "fileupload";
            var container = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);

            var blob = container.GetBlobClient(filename);
            var stream = File.OpenRead(ruta);
            await blob.UploadAsync(stream);

            var request = new ScreenshotRequest()
            {
                Date = DateTime.Now.ToUniversalTime(),
                Name = filename,
                Blob = blob.Uri.AbsoluteUri
            };
            try
            {
                var urlService = new Screenshot();
                await urlService.SendScreenshot(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //imagen.Save(pathDocuments);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
