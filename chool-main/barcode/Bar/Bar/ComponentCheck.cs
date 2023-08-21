using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using CoreScanner;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bar
{
    public partial class ComponentCheck : Form
    {

        List<string> ComponentNameList = new List<string>();
        List<CheckBox> checkboxList = new List<CheckBox>();
        List<string> BarcodeComponentList = new List<string>();
        private int idInverterCategory;
        string barcodeData; //바코드로 찍은 값을 저장하는 곳
        private string pattern = @"\d+";
        public ComponentCheck(int idInverterCategory, string inverterName)
        {
            this.WindowState = FormWindowState.Maximized;
            this.idInverterCategory = idInverterCategory;
            InitializeComponent();
            textBox1.Text = inverterName;
            textBox1.Enabled = false;   
        }
        private void ComponentCheck_Load(object sender, EventArgs e)
        {
            try
            {
                CCoreScannerClass cCoreScannerClass;
                //Instantiate CoreScanner Class
                cCoreScannerClass = new CCoreScannerClass();
                //Call Open API
                short[] scannerTypes = new short[1];//Scanner Types you are interested in
                scannerTypes[0] = 2; // 
                short numberOfScannerTypes = 1; // Size of the scannerTypes array
                int status; // Extended API return code
                cCoreScannerClass.Open(0, scannerTypes, numberOfScannerTypes, out status);
                // Subscribe for barcode events in cCoreScannerClass
                cCoreScannerClass.BarcodeEvent += new
                _ICoreScannerEvents_BarcodeEventEventHandler(OnBarcodeEvent);
                // Let's subscribe for events
                int opcode = 1001; // Method for Subscribe events
                string outXML; // XML Output
                string inXML = "<inArgs>" +
                "<cmdArgs>" +
                "<arg-int>1</arg-int>" + // Number of events you want to subscribe
                "<arg-int>1</arg-int>" + // Comma separated event IDs
                "</cmdArgs>" +
                "</inArgs>";
                cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML, out status);

            }
            catch (Exception exp)
            {
                Log.writeLog(exp.ToString());
            }

            checkboxList.Add(checkBox1);
            checkboxList.Add(checkBox2);
            checkboxList.Add(checkBox3);
            checkboxList.Add(checkBox4);
            checkboxList.Add(checkBox5);
            checkboxList.Add(checkBox6);
            checkboxList.Add(checkBox7);
            checkboxList.Add(checkBox8);
            checkboxList.Add(checkBox9);
            checkboxList.Add(checkBox10);
            using (SqlConnection conn = ConnectDB.connectDB_TEAMDB())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT  g.comname,c.comname,f.comname,b.comname,h.comname,e.comname,j.comname,d.comname,a.comname,k.comname,g.comBarcode,c.comBarcode,f.comBarcode,b.comBarcode,h.comBarcode,e.comBarcode,j.comBarcode,d.comBarcode,a.comBarcode,k.comBarcode FROM [dbo].[InverterCategory] i" +
                        " INNER JOIN [dbo].[mapping] m ON i.[IdInverter_Category] = m.[idinverter] " +
                        "INNER Join [dbo].[control] a On m.[idcontrol] = a.idcom INNER Join [dbo].[ct] b On m.[idct] = b.idcom" +
                        " INNER Join [dbo].[Diode] c On m.[iddiode] = c.idcom INNER Join [dbo].[dm] d On m.[iddm] = d.idcom " +
                        "INNER Join [dbo].[Drive] e On m.[iddrive] = e.idcom INNER Join [dbo].[fuse] f On m.[idfuse] = f.idcom " +
                        "INNER Join [dbo].[igbt] g On m.idigbt = g.idcom INNER Join [dbo].[mainCap] h On m.[idmaincap] = h.idcom " +
                        "INNER Join [dbo].[power] j On m.[idpower] = j.idcom " +
                         "INNER Join [dbo].[reactor] k On m.[idreactor] = k.idcom " +
                        "where m.[idInverter]=@idInverter";
                    cmd.Parameters.Add("@idInverter", SqlDbType.Int).Value = idInverterCategory;

                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                richTextBox1.Text = dr[0].ToString();
                                richTextBox2.Text = dr[1].ToString();
                                richTextBox3.Text = dr[2].ToString();
                                richTextBox4.Text = dr[3].ToString();
                                richTextBox5.Text = dr[4].ToString();
                                richTextBox6.Text = dr[5].ToString();
                                richTextBox7.Text = dr[6].ToString();
                                richTextBox8.Text = dr[7].ToString();
                                richTextBox9.Text = dr[8].ToString();
                                richTextBox10.Text = dr[9].ToString();
                                changecolor(richTextBox1);
                                changecolor(richTextBox2);
                                changecolor(richTextBox3);
                                changecolor(richTextBox4);
                                changecolor(richTextBox5);
                                changecolor(richTextBox6);
                                changecolor(richTextBox7);
                                changecolor(richTextBox8);
                                changecolor(richTextBox9);
                                changecolor(richTextBox10);
                                for (int i = 0; i < 10; i++)
                                {
                                    ComponentNameList.Add(dr[i].ToString());
                                    if (dr[i].ToString() == "없음")
                                        checkboxList[i].Checked = true;
                                }
                                for (int i = 10; i < dr.FieldCount; i++)
                                {
                                    BarcodeComponentList.Add(dr[i].ToString());
                                }

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("오류발생");
                        Log.writeLog(ex.ToString());
                    }

                }
            }

        }
        void OnBarcodeEvent(short eventType, ref string pscanData)
        {
            string barcode = pscanData;

            MessageBox.Show(barcode);
            for (int i = 0; i < BarcodeComponentList.Count; i++)
            {
                MessageBox.Show("하이");
                if (BarcodeComponentList[i] == barcode)
                {
                    checkboxList[i].Checked = true;
                    MessageBox.Show("하이");
                }
                if (AreAllCheckboxesChecked(checkboxList))
                {

                    VisualCheckcs vs = new VisualCheckcs(ComponentNameList);
                    vs.ShowDialog();
                    this.Close();
                }
            }

        }
        bool AreAllCheckboxesChecked(List<CheckBox> checkboxList)
        {
            foreach (CheckBox checkbox in checkboxList)
            {
                if (!checkbox.Checked)
                {
                    return false;
                }
            }
            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!AreAllCheckboxesChecked(checkboxList))
                MessageBox.Show("전부 체크해주세요");
            else
            {
                VisualCheckcs vs = new VisualCheckcs(ComponentNameList);
                vs.ShowDialog();
                this.Close();
            }
        }

        private void changecolor(RichTextBox richTextBox)
        {
            int textBoxHeight = richTextBox.Height;
            int topMargin = (textBoxHeight - richTextBox.Font.Height) / 2;
            string pattern = @"\d+";
            MatchCollection matches = Regex.Matches(richTextBox.Text, pattern);
            foreach (Match match in matches)
            {
                string number = match.Value; // 추출된 숫자
                int startIndex = richTextBox.Text.IndexOf(number);
                int length = number.Length;
                richTextBox.Select(startIndex, length);
                richTextBox.SelectionColor = System.Drawing.Color.Red;
                richTextBox.SelectionFont = new System.Drawing.Font(richTextBox.SelectionFont.FontFamily, 23, richTextBox.SelectionFont.Style);
                richTextBox.DeselectAll();
            }

            // 스크롤을 맨 아래로 내리는 로직 추가
            richTextBox.SelectAll();
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.ScrollToCaret();
            richTextBox.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox.SelectionFont = new System.Drawing.Font(richTextBox.SelectionFont.FontFamily, 25, richTextBox.SelectionFont.Style);
            richTextBox.DeselectAll();

            richTextBox.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < BarcodeComponentList.Count; i++)
            {
                MessageBox.Show(BarcodeComponentList[i].ToString());
            }
        }


    }
}
