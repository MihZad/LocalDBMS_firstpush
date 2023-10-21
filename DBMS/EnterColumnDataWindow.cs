using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalDBMS
{
    public partial class EnterColumnDataWindow : Form
    {
        int columnNum = -1;
        public string DRcolumnName = string.Empty;
        public string DRChosenType = string.Empty;
        public EnterColumnDataWindow(int i)
        {
            columnNum = i;
            InitializeComponent();
            CDddl.Items.Clear();
            CDddl.Items.Add(Int.TypeValue);
            CDddl.Items.Add(Char.TypeValue);
            CDddl.Items.Add(String.TypeValue);
            CDddl.Items.Add(Real.TypeValue);
            CDddl.Items.Add(CharInvl.TypeValue);
            CDddl.Items.Add(StringInvl.TypeValue);
        }

        private void EnterColumnDataWindow_Load(object sender, EventArgs e)
        {
            this.Text = $"Колонка #{columnNum + 1}: введення даних";
        }

        private void CDokButton_Click(object sender, EventArgs e)
        {
            DRChosenType = CDddl.GetItemText(CDddl.SelectedItem);
            DRcolumnName = CDtextBox.Text;
        }

        private void CDtextBox_DoubleClick(object sender, EventArgs e)
        {
            CDtextBox.Text = "";
        }
    }
}
