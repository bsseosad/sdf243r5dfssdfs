using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace Bar
{
    public partial class INVCheck : Form
    {
        public INVCheck()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCompo addcompo = new AddCompo();
            addcompo.ShowDialog();
            this.Close();
        }

        private void INVCheck_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = ConnectDB.connectDB_TEAMDB())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT [InverterSortCategory],[idInverterSortCategory] from [dbo].[inverterSortCategory]";

                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                InverterCategory.Items.Add(dr[0].ToString());
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

        private void EnterButton_Click(object sender, EventArgs e)
        {
            
            string selectedItem = ComponentCombo.SelectedItem.ToString().Trim();
            using (SqlConnection conn = ConnectDB.connectDB_TEAMDB())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"select [IdInverter_Category] " +
                                      $"from [dbo].[InverterCategory] " +
                                      $"where [Inverter] = @selectedItem ";
                    cmd.Parameters.Add("@selectedItem", SqlDbType.VarChar).Value = selectedItem;
                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ComponentCombo.Items.Add(dr[0].ToString());
                                ComponentCheck componentCheck = new ComponentCheck((int)dr[0],selectedItem);
                                componentCheck.ShowDialog();
                                this.Close();
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

        private void InverterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem=InverterCategory.SelectedItem.ToString().Trim();        

            ComponentCombo.Items.Clear();
            using (SqlConnection conn = ConnectDB.connectDB_TEAMDB())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT ic.[Inverter] " +
                                      $"FROM [dbo].[InverterCategory] ic " +
                                      $"JOIN [dbo].[inverterSortCategory] isc ON ic.[Inverter_category] = isc.[idInverterSortCategory] " +
                                      $"WHERE isc.[InverterSortCategory] = @selectedItem1";

                    cmd.Parameters.Add("@selectedItem1", SqlDbType.VarChar).Value = selectedItem;
                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ComponentCombo.Items.Add(dr[0].ToString());
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
    }
}