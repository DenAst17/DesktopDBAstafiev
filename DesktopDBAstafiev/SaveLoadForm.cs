using DesktopDBAstafiev.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopDBAstafiev
{
    public partial class SaveLoadForm: Form
    {
        // Method to save the database to a file
        public bool SaveDatabase(Database db)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Database Files (*.db)|*.db",
                Title = "Save Database"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Use the Database's SaveToDisk method
                    db.SaveToDisk(sfd.FileName);
                    MessageBox.Show("Database saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        // Method to load the database from a file
        public Database LoadDatabase()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Database Files (*.db)|*.db",
                Title = "Load Database"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Use the Database's LoadFromDisk static method
                    Database loadedDb = Database.LoadFromDisk(ofd.FileName);
                    if (loadedDb != null)
                    {
                        return loadedDb;
                    }
                    else
                    {
                        MessageBox.Show("Failed to load the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }
    }
}
