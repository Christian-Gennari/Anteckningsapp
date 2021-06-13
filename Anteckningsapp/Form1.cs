using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anteckningsapp
{
    public partial class Form1 : Form
    {

        DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();

            table.Columns.Add("Rubrik", typeof(String));
            table.Columns.Add("Anteckning", typeof(String));

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Anteckning"].Visible = false;
            dataGridView1.Columns["Rubrik"].Width = 179;

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            // Raderar text i både rubrik & anteckningsrutan 
            textTitle.Clear();
            textMessage.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Sparar texten i både rubrik & anteckningsrutan i Table
            table.Rows.Add(textTitle.Text, textMessage.Text);

            textTitle.Clear();
            textMessage.Clear();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            
            // Kollar den markerade rowen i datagriden och sparar dess index i en var
            int index = dataGridView1.CurrentCell.RowIndex;
            
            // Kollar så att någon row är markerad
            if (index > -1)
            {
                // Visar upp den sparade texten
                textTitle.Text = table.Rows[index].ItemArray[0].ToString();
                textMessage.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Kollar den markerade rowen i datagriden och sparar dess index i en var
            int index = dataGridView1.CurrentCell.RowIndex;


            // Raderar den markerade rowen
            table.Rows[index].Delete();
        }

    }
}

