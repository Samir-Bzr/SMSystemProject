using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMSystem.Code;
using Microsoft.Data.SqlClient;
using System.Configuration;


namespace gestpro
{
    public partial class reglement : Form
    {
        private int _id;
        private SqlConnection connection;

        public reglement(int id)
        {
            _id = id;
            InitializeComponent();
            // Initialize the connection
            connection = new SqlConnection(initcon());
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

        private DataTable GetDataTable(SqlConnection connection, string query)
        {



            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                connection.Close();
                return dataTable;

            }

        }
    
    private void reglement_Load(object sender, EventArgs e)
        {


            // Get data for MODEBL
        
            DataTable modeReglementTable = GetDataTable( connection, "SELECT ID_MODE, LABEL_MODE FROM MODE_REGLEMENT");
            comboBox1.DataSource = modeReglementTable;
            comboBox1.ValueMember = "ID_MODE";
            comboBox1.DisplayMember = "LABEL_MODE";

            panel2.Enabled = false;
            panel2.Visible = false;
            label3.Enabled = false;
            textBox2.Enabled = false;
            textBox2.Enabled = false;
            textBox1.Visible = false;
            textBox2.Visible = false;

            connection.Open();

            // Query to fetch IsQteInsufAllowed
            string queryParam = "SELECT TOTAL_TTC_BL FROM BON_LIVRAISON where ID_BL=@id"; // No QTE filter, fetch the value directly
            using (SqlCommand command = new SqlCommand(queryParam, connection))

            {
                command.Parameters.AddWithValue("@id", _id);
                object result = command.ExecuteScalar();
                textBox1.Text = Convert.ToString(result);

            }
            int idClt = 0;
            string getIdCltQuery = "SELECT ID_CLT FROM BON_LIVRAISON WHERE ID_BL = @ID_BL";
            using (SqlCommand cmd = new SqlCommand(getIdCltQuery, connection))
            {
                cmd.Parameters.AddWithValue("@ID_BL", _id);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    idClt = Convert.ToInt32(result);

                }
            }
                string MT_REGL_ESPECE = "SELECT MONT_REGLEMENT FROM HIST_REGL_CLT WHERE ID_BL = @ID_BL AND ID_CLT=@IDCLT";
                using (SqlCommand cm = new SqlCommand(MT_REGL_ESPECE, connection))
                {
                    cm.Parameters.AddWithValue("@ID_BL", _id);
                    cm.Parameters.AddWithValue("@IDCLT", idClt);
                    object res = cm.ExecuteScalar();
                    if (res != DBNull.Value)
                    {
                        textBox2.Text = Convert.ToString(res);
                    }
                    connection.Close();
                }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "CHEQUE":
                    {
                        panel2.Visible = true;
                        panel2.Enabled = true;
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        textBox2.Visible = true;

                        lb2.Visible =false;
                        textBox4.Visible = false;
                        lb3.Text = "N° Cheque";
                        lb4.Text = "Date de cheque";
                        label3.Enabled = true;
                        textBox2.Enabled = true;

                        break;
                    }
                case "A TERME":
                    {
                        label3.Enabled = true;
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        panel2.Visible = false;
                        break;
                    }
                case "ESPECE":
                    {
                        label3.Enabled = true;
                        textBox2.Enabled = true;
                        panel2.Visible = false;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox1.Enabled = true;
                        break;
                    }
              
                case "VIREMENT BANCAIRE":
                    {
                        panel2.Visible = true;
                        panel2.Enabled = true;
                        label3.Enabled = true;
                        textBox2.Enabled = true;
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        lb2.Visible = true;
                        lb2.Text = " compte bancaire client";
                        lb3.Text = "N° DE VIREMENT ";
                        lb4.Text = "Date de virement";

                        break;
                    }
                case "VERSEMENT BANCAIRE":
                    {
                        panel2.Visible = true;
                        panel2.Enabled = true;
                        label3.Enabled = true;
                        textBox2.Enabled = true;
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        lb2.Visible = false;
                        textBox4.Visible = false;
                        lb3.Text = "NUM VERSEMENT";
                        lb4.Text = "Date de versement";


                        break;
                    }
            }
        }

        private void lb1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            connection.Open();
            int idClt = 0;
            string getIdCltQuery = "SELECT ID_CLT FROM BON_LIVRAISON WHERE ID_BL = @ID_BL";
            using (SqlCommand cmd = new SqlCommand(getIdCltQuery, connection))
            {
                cmd.Parameters.AddWithValue("@ID_BL", _id);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    idClt = Convert.ToInt32(result);

                }
            }

            // Step 1: Retrieve ID_CLT from BON_LIVRAISON


            if (comboBox1.Text == "ESPECE")
            {
                // Step 2: Insert into HIST_REGL_CLT and Update CLIENT

                string updateAndInsertQuery1 = @" 
IF EXISTS (SELECT 1 FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)
     BEGIN
     if (SELECT MONT_TTC_BL FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)!=@mont
            BEGIN
    UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE - ((SELECT MONT_TTC_BL FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)-(SELECT MONT_REGLEMENT FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID))
    WHERE ID_CLT = @ID_CLT;

    UPDATE HIST_REGL_CLT
    SET MONT_TTC_BL = @mont,
        MONT_REGLEMENT = @MON,
        DATE_REGLEMENT = @DATE,
        MODE_REGLEMENT = @MODE
    WHERE ID_CLT = @ID_CLT AND ID_BL = @ID;
        UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE + @B - @C
    WHERE ID_CLT = @ID_CLT;
                END
ELSE
BEGIN
UPDATE CLIENT
SET  SOLDE_CREANCE = SOLDE_CREANCE -(SELECT MONT_REGLEMENT FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)
END
  END
ELSE
BEGIN
 
    INSERT INTO HIST_REGL_CLT (ID_CLT, ID_BL, MONT_TTC_BL, MONT_REGLEMENT, DATE_REGLEMENT, MODE_REGLEMENT)
    VALUES (@ID_CLT, @ID, @mont, @MON, @DATE, @MODE);

    
    UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE + @B - @C
    WHERE ID_CLT = @ID_CLT;
END
";

                using (SqlCommand cmd = new SqlCommand(updateAndInsertQuery1, connection))
                {
                    // Add parameters for the UPDATE query
                    cmd.Parameters.AddWithValue("@ID", _id);
                    cmd.Parameters.AddWithValue("@mont", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ID_CLT", idClt);
                    cmd.Parameters.AddWithValue("@B", textBox1.Text);  // Replace `yourBValue` with the actual value
                    cmd.Parameters.AddWithValue("@C", textBox2.Text);  // Replace `yourCValue` with the actual value

                    // Add parameters for the INSERT query
                    cmd.Parameters.AddWithValue("@MON", textBox2.Text);  // Replace `yourMonValue` with the actual value
                    cmd.Parameters.AddWithValue("@DATE", DateTime.Today); // Replace `yourDateValue` with the actual value
                    cmd.Parameters.AddWithValue("@MODE", comboBox1.Text); // Replace `yourModeValue` with the actual value

                    cmd.ExecuteNonQuery();
                }
                Close();
            }
            else if (comboBox1.Text == "VERSEMENT BANCAIRE")
            {
                if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    textBox6.Text = DateTime.Today.ToString();
                string updateAndInsertQuery2 = @"
IF EXISTS (SELECT 1 FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)
     BEGIN
     if (SELECT MONT_TTC_BL FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)!=@mont
            BEGIN
    UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE - ((SELECT MONT_TTC_BL FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)-(SELECT MONT_REGLEMENT FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID))
    WHERE ID_CLT = @ID_CLT;

    UPDATE HIST_REGL_CLT
    SET MONT_TTC_BL = @mont,
        MONT_REGLEMENT = @MON,
        DATE_REGLEMENT = @DATE,
        MODE_REGLEMENT = @MODE
         NUM_VERSEMENT=@NUM,
         DATE_VERSEMENT=@DTV
    WHERE ID_CLT = @ID_CLT AND ID_BL = @ID;
        UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE + @B - @C
    WHERE ID_CLT = @ID_CLT;
                END
ELSE
BEGIN
UPDATE CLIENT
SET  SOLDE_CREANCE = SOLDE_CREANCE -(SELECT MONT_REGLEMENT FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)
END
  END
ELSE
BEGIN

    INSERT INTO HIST_REGL_CLT(ID_CLT, ID_BL, MONT_TTC_BL, MONT_REGLEMENT, DATE_REGLEMENT, MODE_REGLEMENT,  NUM_VERSEMENT=@NUM,
        DATE_VERSEMENT=@DTV)
    VALUES(@ID_CLT, @ID, @mont, @MON, @DATE, @MODE);


                UPDATE CLIENT
    SET SOLDE_CREANCE = SOLDE_CREANCE + @B - @C
    WHERE ID_CLT = @ID_CLT;
                END
";

                using (SqlCommand Q = new SqlCommand(updateAndInsertQuery2, connection))
                {
                    // Add parameters for the UPDATE query
                    Q.Parameters.AddWithValue("@ID", _id);
                    Q.Parameters.AddWithValue("@mont", textBox1.Text);
                    Q.Parameters.AddWithValue("@ID_CLT", idClt);
                    Q.Parameters.AddWithValue("@B", textBox1.Text);
                    Q.Parameters.AddWithValue("@C", textBox2.Text);

                    // Add parameters for the INSERT query
                    Q.Parameters.AddWithValue("@MON", textBox2.Text);
                    Q.Parameters.AddWithValue("@DATE", DateTime.Today);
                    Q.Parameters.AddWithValue("@MODE", comboBox1.Text);
                    Q.Parameters.AddWithValue("@NUM", lb3.Text);
                    Q.Parameters.AddWithValue("@DTV", Convert.ToDateTime(lb4.Text));

                    Q.ExecuteNonQuery();
                }

                }
                Close();
            }
            else if (comboBox1.Text == "A TERME")
            {
                textBox2.Visible = false;
                string updateAndInsertQuery1 = @" 
IF EXISTS (SELECT 1 FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)
     BEGIN
     if (SELECT MONT_TTC_BL FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)!=@mont
            BEGIN
    UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE - ((SELECT MONT_TTC_BL FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)
    WHERE ID_CLT = @ID_CLT;

    UPDATE HIST_REGL_CLT
    SET MONT_TTC_BL = @mont,
        
        DATE_REGLEMENT = @DATE,
        MODE_REGLEMENT = @MODE
    WHERE ID_CLT = @ID_CLT AND ID_BL = @ID;
        UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE + @B 
    WHERE ID_CLT = @ID_CLT;
                END

  END
ELSE
BEGIN
 
    INSERT INTO HIST_REGL_CLT (ID_CLT, ID_BL, MONT_TTC_BL,  DATE_REGLEMENT, MODE_REGLEMENT)
    VALUES (@ID_CLT, @ID, @mont,  @DATE, @MODE);

    
    UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE + @B 
    WHERE ID_CLT = @ID_CLT;
END
";

                using (SqlCommand cmd = new SqlCommand(updateAndInsertQuery1, connection))
                {
                    // Add parameters for the UPDATE query
                    cmd.Parameters.AddWithValue("@ID", _id);
                    cmd.Parameters.AddWithValue("@mont", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ID_CLT", idClt);
                    cmd.Parameters.AddWithValue("@B", textBox1.Text);  // Replace `yourBValue` with the actual value
                                                                       // Replace `yourCValue` with the actual value

                    // Add parameters for the INSERT query

                    cmd.Parameters.AddWithValue("@DATE", DateTime.Today); // Replace `yourDateValue` with the actual value
                    cmd.Parameters.AddWithValue("@MODE", comboBox1.Text); // Replace `yourModeValue` with the actual value

                    cmd.ExecuteNonQuery();
                
                }
                Close();
            }
            else if (comboBox1.Text == "VIREMENT BANCAIRE")
            {
                if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    string UPDATE = @" IF EXISTS (SELECT 1 FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)
     BEGIN
     if (SELECT MONT_TTC_BL FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)!=@mont
            BEGIN
    UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE - ((SELECT MONT_TTC_BL FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)-(SELECT MONT_REGLEMENT FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID))
    WHERE ID_CLT = @ID_CLT;

    UPDATE HIST_REGL_CLT
    SET MONT_TTC_BL = @mont,
        MONT_REGLEMENT = @MON,
        DATE_REGLEMENT = @DATE,
        MODE_REGLEMENT = @MODE
         NUM_VIREMENT=@NUM,
         DATE_VIREMENT=@DTV,
         NUM_COMPTCLT =@NUMCLT  
    WHERE ID_CLT = @ID_CLT AND ID_BL = @ID;
        UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE + @B - @C
    WHERE ID_CLT = @ID_CLT;
                END
ELSE
BEGIN
UPDATE CLIENT
SET  SOLDE_CREANCE = SOLDE_CREANCE -(SELECT MONT_REGLEMENT FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)
END
  END
   else
begin
        INSERT INTO HIST_REGL_CLT (ID_CLT, MONT_REGLEMENT, DATE_REGLEMENT, MODE_REGLEMENT,NUM_VIREMENT,DATE_VIREMENT,NUM_COMPTCLT)
        VALUES (@ID_CLT, @MON, @DATE, @MODE,@NUM,@DTV,@NUMCLT);
        UPDATE CLIENT 
        SET SOLDE_CREANCE = SOLDE_CREANCE + @B - @C
        WHERE ID_CLT = @ID_CLT;
END
           ";
                using (SqlCommand cmd = new SqlCommand(UPDATE, connection))
                {
                    // Add parameters for the UPDATE query
                    cmd.Parameters.AddWithValue("@ID", _id);
                    cmd.Parameters.AddWithValue("@ID_CLT", idClt);
                    cmd.Parameters.AddWithValue("@B", textBox1.Text);  // Replace `yourBValue` with the actual value
                    cmd.Parameters.AddWithValue("@C", textBox2.Text);  // Replace `yourCValue` with the actual value
                    cmd.Parameters.AddWithValue("@NUMCLT", textBox4.Text);
                    cmd.Parameters.AddWithValue("@MON", textBox2.Text);  // Replace `yourMonValue` with the actual value
                    cmd.Parameters.AddWithValue("@DATE", DateTime.Today); // Replace `yourDateValue` with the actual value
                    cmd.Parameters.AddWithValue("@MODE", comboBox1.Text); // Replace `yourModeValue` with the actual value
                    cmd.Parameters.AddWithValue("@NUM", lb3.Text);
                    cmd.Parameters.AddWithValue("@DTV", Convert.ToDateTime(lb4.Text));
                    cmd.ExecuteNonQuery();
                }
            }
                Close();
            }
            else if (comboBox1.Text == "CHEQUE")

            {   
                if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    string updateAndInsertQuery = @"  IF EXISTS (SELECT 1 FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)
     BEGIN
     if (SELECT MONT_TTC_BL FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)!=@mont
            BEGIN
    UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE - ((SELECT MONT_TTC_BL FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)-(SELECT MONT_REGLEMENT FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID))
    WHERE ID_CLT = @ID_CLT;

    UPDATE HIST_REGL_CLT
    SET MONT_TTC_BL = @mont,
        MONT_REGLEMENT = @MON,
        DATE_REGLEMENT = @DATE,
        MODE_REGLEMENT = @MODE
         NUM_CHEQUE=@NUM,
         DATE_CHEQUE=@DTV,
         
    WHERE ID_CLT = @ID_CLT AND ID_BL = @ID;
        UPDATE CLIENT 
    SET SOLDE_CREANCE = SOLDE_CREANCE + @B - @C
    WHERE ID_CLT = @ID_CLT;
                END
                ELSE
                    BEGIN
                    UPDATE CLIENT
                    SET  SOLDE_CREANCE = SOLDE_CREANCE -(SELECT MONT_REGLEMENT FROM HIST_REGL_CLT WHERE ID_CLT = @ID_CLT AND ID_BL = @ID)
                    END
                END
                else
begin
        INSERT INTO HIST_REGL_CLT (ID_CLT, MONT_REGLEMENT, DATE_REGLEMENT, MODE_REGLEMENT,NUM_CHEQUE,DATE_CHEQUE)
        VALUES (@ID_CLT, @MON, @DATE, @MODE,@NUM,@DTV);
        UPDATE CLIENT 
        SET SOLDE_CREANCE = SOLDE_CREANCE + @B - @C
        WHERE ID_CLT = @ID_CLT;
end
           ";

                    using (SqlCommand cmd = new SqlCommand(updateAndInsertQuery, connection))
                    {
                        // Add parameters for the UPDATE query
                        cmd.Parameters.AddWithValue("@ID", _id);
                        cmd.Parameters.AddWithValue("@ID_CLT", idClt);
                        cmd.Parameters.AddWithValue("@B", textBox1.Text);  // Replace `yourBValue` with the actual value
                        cmd.Parameters.AddWithValue("@C", textBox2.Text);  // Replace `yourCValue` with the actual value

                        // Add parameters for the INSERT query
                        cmd.Parameters.AddWithValue("@MON", textBox2.Text);  // Replace `yourMonValue` with the actual value
                        cmd.Parameters.AddWithValue("@DATE", DateTime.Today); // Replace `yourDateValue` with the actual value
                        cmd.Parameters.AddWithValue("@MODE", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@NUM", lb3.Text);
                        cmd.Parameters.AddWithValue("@DTV", Convert.ToDateTime(lb4.Text));

                        cmd.ExecuteNonQuery();
                    }
                }
                connection.Close();
            
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void reglement_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show(" vouler vous imprimer le bon", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes) 
            {
                //newbonval newbonval = new newbonval();
                //newbonval.ShowPreview();
            }
            else
            {
                Close();
            }
        }  
    }
}

       
    


