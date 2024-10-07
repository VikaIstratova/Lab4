using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Лаб_3___2__;

namespace Лаб_4____2__
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 5 * btnAdd.Width + 2 * tsSeparator1.Width + 30;
            btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0);
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            gvPlanes.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Назва літака";
            gvPlanes.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Country";
            column.Name = "Країна";
            gvPlanes.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Producer";
            column.Name = "Виробник";
            gvPlanes.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Seats";
            column.Name = "Кількість місць";
            gvPlanes.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Max_Speed";
            column.Name = "Максимальна швидкість";
            gvPlanes.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Time";
            column.Name = "Час польоту";
            column.Width = 80;
            gvPlanes.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "Toilet";
            column.Name = "Туалет";
            column.Width = 60;
            gvPlanes.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "Duty_free";
            column.Name = "Дьюті-фрі";
            column.Width = 60;
            gvPlanes.Columns.Add(column);

            bindSrcPlanes.Add(new Plane("Мрія", "Україна", "Володя", 300, 500, 3600, true, false));
            EventArgs args = new EventArgs(); OnResize(args);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Plane plane = new Plane();

            fPlane ft = new fPlane( plane);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcPlanes.Add(plane); 
            }


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Plane plane = (Plane)bindSrcPlanes.List[bindSrcPlanes.Position];

            fPlane ft = new fPlane( plane);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcPlanes.List[bindSrcPlanes.Position] = plane;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис" , "Видалення запису" , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcPlanes.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблюцю ? \n \nВсі данні будуть втрачені ", "Очищення данних ", MessageBoxButtons.OKCancel , MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcPlanes.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок" , "Вихід з програми" , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void gvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
