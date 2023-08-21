using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
namespace Bar
{
    public partial class VisualCheckcs : Form
    {
        List<string> compolist;
        string asd = "";
        string zxc = "";
        public VisualCheckcs(List<string> compo)
        {
            compolist = compo;  
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }
        private void VisualCheck_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string destinationFileName = $"output_{currentTime}.xlsx";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "전진검사 양식(*.xlsx)|*.xlsx"; // 필터 설정
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = openFileDialog.FileName;
                    string destinationFolderPath = "D:\\";

                    // 엑셀 파일 불러오기
                    using (ExcelPackage sourcePackage = new ExcelPackage(new FileInfo(sourceFilePath)))
                    {
                        ExcelWorksheet sourceWorksheet = sourcePackage.Workbook.Worksheets[1];

                        sourceWorksheet.Cells["H28"].Value = compolist[0];
                        sourceWorksheet.Cells["H29"].Value = compolist[1];
                        sourceWorksheet.Cells["H30"].Value = compolist[2];
                        sourceWorksheet.Cells["H31"].Value = compolist[3];
                        sourceWorksheet.Cells["H32"].Value = compolist[4];
                        sourceWorksheet.Cells["H34"].Value = compolist[5];
                        sourceWorksheet.Cells["H36"].Value = compolist[6];
                        sourceWorksheet.Cells["H38"].Value = compolist[7];
                        sourceWorksheet.Cells["H40"].Value = compolist[8];
                        ExcelPackage destinationPackage = new ExcelPackage();
                        destinationPackage.Workbook.Worksheets.Add("Sheet1", sourceWorksheet);
                        string destinationFilePath = Path.Combine(destinationFolderPath, destinationFileName); // 저장할 파일 경로 지정
                        destinationPackage.SaveAs(new FileInfo(destinationFilePath));
                        destinationPackage.Dispose();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.writeLog(ex.ToString());
                this.Close();
            }
        }
    }
}


