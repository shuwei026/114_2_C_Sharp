using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 員工管理
{
    public class DeleteForm : Form
    {
        private List<Employee> employees;
        private TextBox txtId;
        private Button btnDelete, btnCancel;

        public DeleteForm(List<Employee> employees)
        {
            this.employees = employees;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "刪除員工";
            this.Width = 350;
            this.Height = 180;

            Label lblId = new Label() { Left = 10, Top = 20, Text = "員工編號:" };
            txtId = new TextBox() { Left = 100, Top = 20, Width = 200 };
            btnDelete = new Button() { Left = 60, Top = 60, Text = "刪除", Width = 80 };
            btnCancel = new Button() { Left = 160, Top = 60, Text = "取消", Width = 80 };

            btnDelete.Click += BtnDelete_Click;
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblId);
            this.Controls.Add(txtId);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnCancel);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text.Trim(), out int id))
            {
                MessageBox.Show("員工編號格式錯誤。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var emp = employees.FirstOrDefault(x => x.IdNumber == id);
            if (emp == null)
            {
                MessageBox.Show("找不到員工。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var dr = MessageBox.Show($"確定要刪除 員工: {emp.Name} 嗎?", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                employees.Remove(emp);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}