using System.Configuration;
using System;
using System.Windows.Forms;
using SMSystem.Core;


namespace SMSystem
{
    public class Startup
    {
        public static string ConnectionString { get; private set; }

        public Startup()
        {
            try
            {
                var connectionStringSettings = ConfigurationManager.ConnectionStrings["DefaultConnection"];
                if (connectionStringSettings == null)
                {
                    throw new ConfigurationErrorsException("Connection string 'DefaultConnection' not found in app.config");
                }
                ConnectionString = connectionStringSettings.ConnectionString;
                if (string.IsNullOrEmpty(ConnectionString))
                {
                    throw new ConfigurationErrorsException("Connection string 'DefaultConnection' is empty");
                }
                Console.WriteLine($"Connection string loaded: {ConnectionString}"); // For debugging
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show($"Configuration error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Re-throw the exception to stop the application
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error in Startup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Re-throw the exception to stop the application
            }
        }
    }
}
