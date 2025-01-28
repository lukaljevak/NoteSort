using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteSort
{
    public partial class Notes : Form
    {
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        
        public Notes()
        {
            InitializeComponent();
        }
        DataTable notesList = new DataTable();
        bool isEditing = false;
        private void Notes_Load(object sender, EventArgs e)
        {
            notesList.Columns.Add("Title");
            notesList.Columns.Add("Description");
            dataGridView1.DataSource = notesList;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditing = true;

            txtTitle.Text = notesList.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            txtDescription.Text = notesList.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                notesList.Rows[dataGridView1.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                notesList.Rows[dataGridView1.CurrentCell.RowIndex]["Title"] = txtTitle.Text;
                notesList.Rows[dataGridView1.CurrentCell.RowIndex]["Description"] = txtDescription.Text;
            }
            else
            {
                notesList.Rows.Add(txtTitle.Text, txtDescription.Text);
            }
            
            txtTitle.Text = "";
            txtDescription.Text = "";
            isEditing = false;
        }
    }
}
