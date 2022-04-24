using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HistorialNavegación.Models;
using HistorialNavegación.Services;
using HistorialNavegación.Services.Interfaces;

namespace HistorialNavegación
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //Obtener de chrome
            ChromeHistory chrome = new ChromeHistory();
            ChromeDataGrid.DataSource = chrome.GetDataTable();

            //Obtener de Opera
            OperaHistory opera = new OperaHistory();
            OperaDataGrid.DataSource = opera.GetDataTable();

            var browserList = new List<Browser>
            {
                new Browser() { Name = "Chrome", DataTable = chrome.GetDataTable() },
                new Browser() { Name = "Opera", DataTable = opera.GetDataTable() },

            };

            foreach (var browser in browserList)
            {
                if (browser.DataTable != null)
                {
                    // rows that contains all information about the browser history
                    foreach (dynamic row in browser.DataTable.Rows)
                    {
                        var request = new UrlRequest
                        {
                            Browser = browser.Name,
                            Url = row[0],
                            Title = row[1],
                            Time = row[2],
                            Date = row[3]
                        };
                        try
                        {
                            var urlService = new UrlService();
                            await urlService.SendUrl(request);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
