
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace PREINSPECTION
{
    public partial class Mapping : Form
    {
        string selectedItem = null;
        public Mapping(string selectedItem)
        {
             this.selectedItem =selectedItem;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            label6.Text = selectedItem;
            this.selectedItem = selectedItem;

        }

        private void Mapping_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = ConnectDB.connectDB())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT part.name as partName,  part_group.name As partGroupName " +
                                          "FROM part INNER JOIN part_group ON part.group_id = part_group.id";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                switch (reader[1].ToString())
                                {
                                    case "IGBT":
                                        IGBTCombo.Items.Add(reader[0].ToString());
                                        break;

                                    case "DIODE":
                                        DIODECombo.Items.Add(reader[0].ToString());
                                        break;

                                    case "콘덴서":
                                        CAPCombo.Items.Add(reader[0].ToString());
                                        break;

                                    case "리액터":
                                        REACCombo.Items.Add(reader[0].ToString());
                                        break;

                                    case "CT":
                                        CTCombo.Items.Add(reader[0].ToString());
                                        break;

                                    default:
                                        MessageBox.Show("잘못되었습니다.");
                                        break;
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

        private void IGBTinsert_Click(object sender, EventArgs e)
        {
            string SelectedIGBT = "";

            if (IGBTCombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
                return;
            }
            else
            {
                SelectedIGBT = IGBTCombo.SelectedItem.ToString();
                using (SqlConnection connection = ConnectDB.connectDB())
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "MERGE INTO mapping AS target " +
                                              "USING (SELECT id FROM part WHERE name = @PartNameIGBT) AS sourcePart " +
                                              "ON target.partgroup_id = (SELECT id FROM part_group WHERE name = 'IGBT') " +
                                              "AND target.item_id = (SELECT id FROM item WHERE name =@ItemName) " +
                                              "WHEN MATCHED THEN " +
                                              "UPDATE SET part_id = sourcePart.id " +
                                              "WHEN NOT MATCHED THEN " +
                                                "INSERT (part_id, item_id, partgroup_id) " +
                                                "VALUES (sourcePart.id, (SELECT id FROM item WHERE name = @ItemName), (SELECT id FROM part_group WHERE name = 'IGBT')); ";
                        command.Parameters.Add("@PartNameIGBT", SqlDbType.VarChar).Value = SelectedIGBT;
                        command.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = selectedItem;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("부품 업데이트에 성공하였습니다!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("부품 업데이트에 실패하였습니다!");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }

        private void DIODEinsert_Click(object sender, EventArgs e)
        {
            string SelectedDIODE = "";

            if (DIODECombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
                return;
            }
            else
            {
                SelectedDIODE = DIODECombo.SelectedItem.ToString();
                using (SqlConnection connection = ConnectDB.connectDB())
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "MERGE INTO mapping AS target " +
                                              "USING (SELECT id FROM part WHERE name = @PartNameDIODE) AS sourcePart " +
                                              "ON target.partgroup_id = (SELECT id FROM part_group WHERE name = 'DIODE') " +
                                               "AND target.item_id = (SELECT id FROM item WHERE name =@ItemName) " +
                                              "WHEN MATCHED THEN " +
                                                "UPDATE SET part_id = sourcePart.id " +
                                              "WHEN NOT MATCHED THEN " +
                                                "INSERT (part_id, item_id, partgroup_id) " +
                                                "VALUES (sourcePart.id, (SELECT id FROM item WHERE name = @ItemName), (SELECT id FROM part_group WHERE name = 'DIODE')); ";
                        command.Parameters.Add("@PartNameDIODE", SqlDbType.VarChar).Value = SelectedDIODE;
                        command.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = selectedItem;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("부품 업데이트에 성공하였습니다!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("부품 업데이트에 실패하였습니다!");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }

        private void CAPinsert_Click(object sender, EventArgs e)
        {
            string SelectedCAP = "";

            if (CAPCombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
                return;
            }
            else
            {
                SelectedCAP = CAPCombo.SelectedItem.ToString();
                using (SqlConnection connection = ConnectDB.connectDB())
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "MERGE INTO mapping AS target " +
                                              "USING (SELECT id FROM part WHERE name = @PartNameCAP) AS sourcePart " +
                                              "ON target.partgroup_id = (SELECT id FROM part_group WHERE name = '콘덴서') " +
                                               "AND target.item_id = (SELECT id FROM item WHERE name =@ItemName) " +
                                              "WHEN MATCHED THEN " +
                                                "UPDATE SET part_id = sourcePart.id " +
                                              "WHEN NOT MATCHED THEN " +
                                                "INSERT (part_id, item_id, partgroup_id) " +
                                                "VALUES (sourcePart.id, (SELECT id FROM item WHERE name = @ItemName), (SELECT id FROM part_group WHERE name = '콘덴서')); ";
                        command.Parameters.Add("@PartNameCAP", SqlDbType.VarChar).Value = SelectedCAP;
                        command.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = selectedItem;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("부품 업데이트에 성공하였습니다!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("부품 업데이트에 실패하였습니다!");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }

        private void REACinsert_Click(object sender, EventArgs e)
        {
            string SelectedREAC = "";

            if (REACCombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
                return;
            }
            else
            {
                SelectedREAC = REACCombo.SelectedItem.ToString();
                using (SqlConnection connection = ConnectDB.connectDB())
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "MERGE INTO mapping AS target " +
                                              "USING (SELECT id FROM part WHERE name = @PartNameREAC) AS sourcePart " +
                                              "ON target.partgroup_id = (SELECT id FROM part_group WHERE name = '리액터') " +
                                               "AND target.item_id = (SELECT id FROM item WHERE name =@ItemName) " +
                                              "WHEN MATCHED THEN " +
                                                "UPDATE SET part_id = sourcePart.id " +
                                              "WHEN NOT MATCHED THEN " +
                                                "INSERT (part_id, item_id, partgroup_id) " +
                                                "VALUES (sourcePart.id, (SELECT id FROM item WHERE name = @ItemName), (SELECT id FROM part_group WHERE name = '리액터')); ";
                        command.Parameters.Add("@PartNameREAC", SqlDbType.VarChar).Value = SelectedREAC;
                        command.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = selectedItem;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("부품 업데이트에 성공하였습니다!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("부품 업데이트에 실패하였습니다!");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }

        private void CTinsert_Click(object sender, EventArgs e)
        {
            string SelectedCT = "";

            if (CTCombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
                return;
            }
            else
            {
                SelectedCT = CTCombo.SelectedItem.ToString().Trim();
                using (SqlConnection connection = ConnectDB.connectDB())
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "MERGE INTO mapping AS target " +
                                              "USING (SELECT id FROM part WHERE name = @PartNameCT) AS sourcePart " +
                                              "ON target.partgroup_id = (SELECT id FROM part_group WHERE name = 'CT') " +
                                               "AND target.item_id = (SELECT id FROM item WHERE name =@ItemName) " +
                                              "WHEN MATCHED THEN " +
                                                "UPDATE SET part_id = sourcePart.id " +
                                              "WHEN NOT MATCHED THEN " +
                                                "INSERT (part_id, item_id, partgroup_id) " +
                                                "VALUES (sourcePart.id, (SELECT id FROM item WHERE name = @ItemName), (SELECT id FROM part_group WHERE name = 'CT')); ";
                        command.Parameters.Add("@PartNameCT", SqlDbType.VarChar).Value = SelectedCT;
                        command.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = selectedItem;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("부품 업데이트에 성공하였습니다!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("부품 업데이트에 실패하였습니다!");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }
    }
}
