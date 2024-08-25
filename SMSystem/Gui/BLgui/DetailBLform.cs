using gestpro;
using Microsoft.Data.SqlClient;
using SMSystem.Core;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
 

namespace SMSystem.Gui.BLgui
{
    

    public partial class DetailBLform : Form
    {
        private int _ID;
        private SqlConnection connection;

        public DetailBLform(int ID)
        {
            InitializeComponent();
            _ID = ID;
            // Initialize the connection
            connection = new SqlConnection(initcon());

            // Load data and set ID
            LoadData();
            IDBL.Text = _ID.ToString();
        }

        private string initcon()
        {
            // Retrieve and return the connection string from app.config
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not configured correctly.");
            }
            return connectionString;
        }

        public void LoadData()
        {
            string query = @"
            SELECT
                DETAIL_BL.ID_BL,
                DETAIL_BL.RefArtFini, 
                STKPRDFINI.Designation,
                QTE_BL,
                COLISSAGE_BL,
                PALETISSAGE_BL,
                PUV_BL,
                TVA_BL,
                REMISE_BL
            FROM
                DETAIL_BL
                JOIN STKPRDFINI ON DETAIL_BL.RefArtFini = STKPRDFINI.RefArtFini
            WHERE ID_BL = @id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", _ID);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }

        public void disp_data()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"
                SELECT
                    DETAIL_BL.ID_BL,
                    DETAIL_BL.RefArtFini, 
                    STKPRDFINI.Designation,
                    QTE_BL,
                    COLISSAGE_BL,
                    PALETISSAGE_BL,
                    PUV_BL,
                    TVA_BL,
                    REMISE_BL
                FROM
                    DETAIL_BL
                    JOIN STKPRDFINI ON DETAIL_BL.RefArtFini = STKPRDFINI.RefArtFini
                WHERE ID_BL = @id", connection);

                cmd.Parameters.AddWithValue("@id", _ID);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                dataGridView1.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void calculer()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
                SELECT
                    SUM(QTE_BL * PUV_BL) AS HT,
                    SUM(PUV_BL - (REMISE_BL / 100)) AS remi,
                    SUM(TVA_BL * PUV_BL) AS TVA,
                    SUM(QTE_BL * PUV_BL) + SUM(TVA_BL * PUV_BL) AS TTC
                FROM
                    DETAIL_BL
                WHERE ID_BL = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", _ID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal ht = reader.IsDBNull(reader.GetOrdinal("HT")) ? 0 : reader.GetDecimal(reader.GetOrdinal("HT"));
                            decimal tva = reader.IsDBNull(reader.GetOrdinal("TVA")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TVA"));
                            decimal rem = reader.IsDBNull(reader.GetOrdinal("remi")) ? 0 : reader.GetDecimal(reader.GetOrdinal("remi"));
                            decimal ttc = reader.IsDBNull(reader.GetOrdinal("TTC")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TTC"));

                            THT.Text = ht.ToString("n2");
                            TTVA.Text = tva.ToString("n2");
                            TTTC.Text = (ttc - rem).ToString("n2");
                            REMISE.Text = rem.ToString("n2");
                        }
                        else
                        {
                            THT.Text = "0.00";
                            TTVA.Text = "0.00";
                            TTTC.Text = "0.00";
                        }
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Casting error: " + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void ClearText(Control[] controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.Text = "";
                }
            }
        }
    

    private void button1_Click(object sender, EventArgs e)

        {
            if (REM.Text == "") { REM.Text = "0"; }
            if (QTE.Text != "")
            {
                string a = @" IF EXISTS (SELECT RefArtFini,ID_BL FROM DETAIL_BL where RefArtFini = @REF and ID_BL = @ID)
            update DETAIL_BL 
            set 
            [QTE_BL]=@QTE
           ,[COLISSAGE_BL]=@COL
           ,[PALETISSAGE_BL]=@PAL
           ,PUV_BL=@PU
            ,TVA_BL=@TVA
            ,REMISE_BL=@REM
         where (RefArtFini = @REF AND ID_BL =@ID) 
            else
            INSERT INTO [dbo].[DETAIL_BL]
           ([ID_BL]
           ,[QTE_BL]
           ,[RefArtFini]
           ,[COLISSAGE_BL]
           ,[PALETISSAGE_BL]
           ,PUV_BL,TVA_BL,REMISE_BL)
           
     VALUES (@ID ,@QTE,@REF,@COL,@PAL,@PU,@TVA,@REM)";
                
                connection.Open();
                SqlCommand cmd = new SqlCommand(a, connection);
                cmd.Parameters.AddWithValue("@ID", _ID);
                cmd.Parameters.AddWithValue("@QTE", QTE.Text);
                cmd.Parameters.AddWithValue("@REF", REF.Text);
                cmd.Parameters.AddWithValue("@COL", COL.Text);
                cmd.Parameters.AddWithValue("@PAL", PAL.Text);
                cmd.Parameters.AddWithValue("@PU", PUV.Text);
                cmd.Parameters.AddWithValue("@TVA", TVA.Text);
                cmd.Parameters.AddWithValue("@REM", REM.Text);
                cmd.ExecuteNonQuery();

                connection.Close();
                calculer();
                disp_data();

            }
            else
            {
                MessageBox.Show("la valeur de QTE ne doit pas etre null");
            }
            panel1.Enabled = false;
            Control[] textboxes = { COL, PAL, REM, PUV, QTE, REF, TVA, DESIGNATION };

            ClearText(textboxes);

        }

        private DataTable GetDataTable(SqlConnection connection, string query)
        {


            
            using (SqlCommand command = new SqlCommand(query, connection))
            {   connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
               connection.Close();
                return dataTable;

            }
             
        }



            private void Fcrebnliv_Load(object sender, EventArgs e)
            {
            // TODO: cette ligne de code charge les données dans la table 'gestProDBDataSet2.MODE_REGLEMENT'. Vous pouvez la déplacer ou la supprimer selon les besoins.

            disp_data();
            LB1.BackColor = Color.Transparent;
            LB2.BackColor = Color.Transparent;
            LB3.BackColor = Color.Transparent;
            LB4.BackColor = Color.Transparent;
            LB5.BackColor = Color.Transparent;
            LB6.BackColor = Color.Transparent;
            LB7.BackColor = Color.Transparent;


            DataTable clientTable = GetDataTable(connection, "SELECT ID_CLT, NOM_CLT FROM CLIENT");
            CLIENT.DataSource = clientTable;
            CLIENT.ValueMember = "ID_CLT";
            CLIENT.DisplayMember = "NOM_CLT";

            // Get data for DESIGNATION
            DataTable stkprdfiniTable = GetDataTable(connection, "SELECT RefArtFini, Designation FROM STKPRDFINI");
            DESIGNATION.DataSource = stkprdfiniTable;
            DESIGNATION.ValueMember = "RefArtFini";
            DESIGNATION.DisplayMember = "Designation";

            // Get data for MODEBL
            DataTable modeReglementTable = GetDataTable(connection, "SELECT ID_MODE, LABEL_MODE FROM MODE_REGLEMENT");
            MODEBL.DataSource = modeReglementTable;
            MODEBL.ValueMember = "ID_MODE";
            MODEBL.DisplayMember = "LABEL_MODE";
        

       
        
        calculer();









        }


        public void UpdateStockCheck(string refArtFini, Control qtebl)
        {
            // Step 1: Fetch IsQteInsufAllowed value from parametres table
            int isQteInsufAllowed = 0;



            connection.Open();

            // Query to fetch IsQteInsufAllowed
            string queryParam = "SELECT IsQteInsufAllowed FROM PARAMETRES"; // No QTE filter, fetch the value directly
            using (SqlCommand command = new SqlCommand(queryParam, connection))
            {
                object result = command.ExecuteScalar();
                isQteInsufAllowed = result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
            connection.Close();

            // Step 2: Conditionally execute the stock check if IsQteInsufAllowed is 0
            if (isQteInsufAllowed == 0)
            {
                CheckStockAndShowMessage(refArtFini, qtebl);
            }

        }

        public void CheckStockAndShowMessage(string refArtFini, Control qtebl)
        {

            int quantityStck = 0;


            connection.Open();



            // Query to fetch QTE_STCK
            string queryStock = "SELECT QTEStock FROM STKPRDFINI WHERE RefArtFini = @RefArtFini";
            using (SqlCommand command = new SqlCommand(queryStock, connection))
            {
                command.Parameters.AddWithValue("@RefArtFini", refArtFini);
                object result = command.ExecuteScalar();
                quantityStck = result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }

            connection.Close();


            // Compare the values and show a message if QTE_BL exceeds QTE_STCK
            if (qtebl.Text != "")
            {
                if (Convert.ToInt32(qtebl.Text) > quantityStck)
                {
                    MessageBox.Show("La Quantité excède le stock. la quantité en stock est :'" + quantityStck + "'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    qtebl.Text = "0";
                    qtebl.Focus();
                }
            }
        }





        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand q = new SqlCommand("select ID_CLT from CLIENT WHERE NOM_CLT =@nom", connection);
            q.Parameters.AddWithValue("@nom", CLIENT.Text);
            SqlDataReader d = q.ExecuteReader();
            while (d.Read())
            {
                CLT.Text = d.GetValue(0).ToString();
            }
            d.Close();
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            IDBL.Text = row.Cells["ID_BL"].Value != null ? row.Cells["ID_BL"].Value.ToString() : string.Empty;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            {
                connection.Open();
                SqlCommand q = new SqlCommand("select RefArtfini from STKPRDFINI WHERE Designation =@nom", connection);
                q.Parameters.AddWithValue("@nom", DESIGNATION.Text);
                SqlDataReader f = q.ExecuteReader();
                while (f.Read())
                {
                    REF.Text = f.GetValue(0).ToString();


                }
                f.Close();
                {
                    SqlCommand v = new SqlCommand("select Colissage from STKPRDFINI WHERE Designation =@nom", connection);
                    v.Parameters.AddWithValue("@nom", DESIGNATION.Text);


                    SqlDataReader g = v.ExecuteReader();

                    while (g.Read())
                    {
                        COL.Text = g.GetValue(0).ToString();
                    }
                    g.Close();
                }

                SqlCommand a = new SqlCommand("select Palletissage from STKPRDFINI WHERE Designation =@nom", connection);
                a.Parameters.AddWithValue("@nom", DESIGNATION.Text);
                SqlDataReader h = a.ExecuteReader();
                while (h.Read())
                {
                    PAL.Text = h.GetValue(0).ToString();
                }
                h.Close();
                SqlCommand S = new SqlCommand("select PUVente from STKPRDFINI WHERE Designation =@nom", connection);
                S.Parameters.AddWithValue("@nom", DESIGNATION.Text);
                SqlDataReader G = S.ExecuteReader();
                while (G.Read())
                {
                    PUV.Text = G.GetValue(0).ToString();
                }
                G.Close();
                SqlCommand St = new SqlCommand("select TVA_Vente from STKPRDFINI WHERE Designation =@nom", connection);
                St.Parameters.AddWithValue("@nom", DESIGNATION.Text);
                SqlDataReader Gs = St.ExecuteReader();
                while (Gs.Read())
                {
                    TVA.Text = Gs.GetValue(0).ToString();
                }
                Gs.Close();
                connection.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                QTE.Text = row.Cells["QTE_BL"].Value != null ? row.Cells["QTE_BL"].Value.ToString() : string.Empty;
                PUV.Text = row.Cells["PUV_BL"].Value != null ? row.Cells["PUV_BL"].Value.ToString() : string.Empty;
                DESIGNATION.Text = row.Cells["DESIGNATION"].Value != null ? row.Cells["Designation"].Value.ToString() : string.Empty;
            }
            catch { }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (REM.Text == "") { REM.Text = "0"; }

            string a = @"UPDATE [dbo].[DETAIL_BL]
          SET 
           [QTE_BL]=@QTE
           ,TVA_BL=@tva
            ,REMISE_BL=@REM
           ,[COLISSAGE_BL]=@COL
           ,[PALETISSAGE_BL]=@PAL
           ,PUV_BL=@PU
         where RefArtFini = @REF AND ID_BL =@ID
           
     ";
            connection.Open();
            SqlCommand cmd = new SqlCommand(a, connection);
            cmd.Parameters.AddWithValue("@ID", IDBL.Text);
            cmd.Parameters.AddWithValue("@REF", REF.Text);
            cmd.Parameters.AddWithValue("@QTE", QTE.Text);
            cmd.Parameters.AddWithValue("@COL", COL.Text);
            cmd.Parameters.AddWithValue("@PAL", PAL.Text);
            cmd.Parameters.AddWithValue("@PU", PUV.Text);
            cmd.Parameters.AddWithValue("@tva", TVA.Text);
            cmd.Parameters.AddWithValue("@REM", REM.Text);
            cmd.ExecuteNonQuery();

            connection.Close();
            calculer();
            disp_data();
            Control[] textboxes = { COL, PAL, PUV, REM, TVA, QTE, REF, DESIGNATION };

            ClearText(textboxes);
            panel1.Enabled = false;
        }

        private void PUV_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            valmod.Enabled = false;
            valinsert.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            valinsert.Enabled = false;
            valmod.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("etes vous sure de vouloir supprimer", "Supprimer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string a = @"DELETE FROM [dbo].[DETAIL_BL] WHERE ID_BL = '" + dataGridView1.CurrentRow.Cells["ID_BL"].Value.ToString() + "'  " + " AND RefArtFini ='" + dataGridView1.CurrentRow.Cells["RefArtFini"].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(a, connection);
                connection.Open();
                cmd.ExecuteNonQuery();

                connection.Close();
                calculer();
                disp_data();
            }
        }

        private void ANULLER_Click(object sender, EventArgs e)
        {
            Control[] textboxes = { COL, PAL, PUV, REM, TVA, QTE, REF, DESIGNATION };

            ClearText(textboxes);
            panel1.Enabled = false;

        }

        private void ACTU_Click(object sender, EventArgs e)
        {
            disp_data();
        }



        private void button3_Click(object sender, EventArgs e)
        {

            string a = @"IF EXISTS (SELECT ID_BL FROM BON_LIVRAISON where  ID_BL = @ID)
            update BON_LIVRAISON
            set 
            TOTAL_HT_BL =@ht,
            TOTAL_TVA_BL=@tva,
            TOTAL_TTC_BL=@ttc,
            MODE_BL=@mode,
            ID_CLT=@clt,
                DATE_BL=@date
                WHERE (ID_BL=@ID)
            else
            INSERT INTO [dbo].[BON_LIVRAISON]
           ([ID_BL],TOTAL_HT_BL,TOTAL_TVA_BL,TOTAL_TTC_BL,MODE_BL,ID_CLT,DATE_Bl)
           
     VALUES (@ID,@ht,@tva,@ttc,@mode,@clt,@date )";
            connection.Open();
            SqlCommand cmd = new SqlCommand(a, connection);
            cmd.Parameters.AddWithValue("@ID", _ID);
            cmd.Parameters.AddWithValue("@ht", Convert.ToDecimal(THT.Text));
            cmd.Parameters.AddWithValue("@tva", Convert.ToDecimal(TTVA.Text));
            cmd.Parameters.AddWithValue("@ttc", Convert.ToDecimal(TTTC.Text));
            cmd.Parameters.AddWithValue("@mode", MODEBL.Text);
            cmd.Parameters.AddWithValue("@clt", CLT.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Today);

            cmd.ExecuteNonQuery();

            connection.Close();

            disp_data();
            if (dataGridView1.CurrentRow.Index >= 0)
            {

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_BL"].Value);
                reglement reg = new reglement(id);
                _= reg.ShowDialog();
            }






        }

        private void QTE_TextChanged(object sender, EventArgs e)
        {
            UpdateStockCheck(REF.Text, QTE);



        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Fcrebnliv_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MODEBL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}






