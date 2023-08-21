using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bar
{
    public partial class Add : Form
    {
        public Add()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }
        private void Search_Click(object sender, EventArgs e)
        {   
            string inverterBarcode = InverterBarcode.Text.Trim().Substring(22);
            using (SqlConnection conn = ConnectDB.connectDB_TEAMDB())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "SELECT i.[Inverter],i.[inverterCategory], g.comname,c.comname,f.comname,b.comname,h.comname,e.comname,j.comname,d.comname,a.comname FROM [dbo].[Inverter] i INNER JOIN [dbo].[mapping] m ON i.[inverterCategory] = m.[idinverter] INNER Join [dbo].[control] a On m.[idcontrol] = a.idcom INNER Join [dbo].[ct] b On m.[idct] = b.idcom INNER Join [dbo].[Diode] c On m.[iddiode] = c.idcom INNER Join [dbo].[dm] d On m.[iddm] = d.idcom INNER Join [dbo].[Drive] e On m.[iddrive] = e.idcom INNER Join [dbo].[fuse] f On m.[idfuse] = f.idcom INNER Join [dbo].[igbt] g On m.idigbt = g.idcom INNER Join [dbo].[mainCap] h On m.[idmaincap] = h.idcom INNER Join [dbo].[power] j On m.[idpower] = j.idcom where i.[Inverter_barcode]=@inverterBarcode";
                    cmd.Parameters.Add("@inverterBarcode", SqlDbType.VarChar).Value = inverterBarcode;
                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                InverterName.Text = dr[0].ToString();
                                richTextBox1.Text = dr[2].ToString();
                                richTextBox2.Text = dr[3].ToString();
                                richTextBox3.Text = dr[4].ToString();
                                richTextBox4.Text = dr[5].ToString();
                                richTextBox5.Text = dr[6].ToString();
                                richTextBox6.Text = dr[7].ToString();
                                richTextBox7.Text = dr[8].ToString();
                                richTextBox8.Text = dr[9].ToString();
                                richTextBox9.Text = dr[10].ToString();

                                changecolor(richTextBox1);
                                changecolor(richTextBox2);
                                changecolor(richTextBox3);
                                changecolor(richTextBox4);
                                changecolor(richTextBox5);
                                changecolor(richTextBox6);
                                changecolor(richTextBox7);
                                changecolor(richTextBox8);
                                changecolor(richTextBox9);
                            }
                            else
                            {
                                MessageBox.Show("없는 바코드입니다.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.writeLog(ex.ToString());
                    }
                }
            }
        }
        private void changecolor(RichTextBox richTextbox)
        {
            string pattern = @"\d+";
            MatchCollection matches = Regex.Matches(richTextbox.Text, pattern);
            foreach (Match match in matches)
            {
                string number = match.Value; // 추출된 숫자

                int startIndex = richTextBox1.Text.IndexOf(number);
                int length = number.Length;

                richTextbox.Select(startIndex, length);
                richTextbox.SelectionColor = System.Drawing.Color.Red;

                richTextbox.SelectionFont = new System.Drawing.Font(richTextbox.SelectionFont.FontFamily, 25, richTextbox.SelectionFont.Style);
                richTextbox.DeselectAll();
            }
            richTextbox.ScrollBars = RichTextBoxScrollBars.None;
            richTextbox.SelectAll();
            richTextbox.SelectionFont = new System.Drawing.Font(richTextbox.SelectionFont.FontFamily, 25, richTextbox.SelectionFont.Style);
            richTextbox.DeselectAll();
            richTextbox.Enabled = false;
        }




    }
}

