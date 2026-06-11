using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 員工管理
{
    public class AddForm : Form
    {
        private List<Employee> employees;
        private TextBox txtId, txtName, txtDept, txtPos;
        private Button btnOk, btnCancel;

        public AddForm(List<Employee> employees)
        {
            this.employees = employees;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "新增員工";
            this.Width = 400;
            this.Height = 300;

            Label lblId = new Label() { Left = 10, Top = 20, Text = "員工編號:" };
            txtId = new TextBox() { Left = 100, Top = 20, Width = 250 };
            Label lblName = new Label() { Left = 10, Top = 60, Text = "姓名:" };
            txtName = new TextBox() { Left = 100, Top = 60, Width = 250 };
            Label lblDept = new Label() { Left = 10, Top = 100, Text = "部門:" };
            txtDept = new TextBox() { Left = 100, Top = 100, Width = 250 };
            Label lblPos = new Label() { Left = 10, Top = 140, Text = "職稱:" };
            txtPos = new TextBox() { Left = 100, Top = 140, Width = 250 };

            btnOk = new Button() { Left = 100, Top = 190, Text = "新增", Width = 80 };
            btnCancel = new Button() { Left = 200, Top = 190, Text = "取消", Width = 80 };

            btnOk.Click += BtnOk_Click;
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblId);
            this.Controls.Add(txtId);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblDept);
            this.Controls.Add(txtDept);
            this.Controls.Add(lblPos);
            this.Controls.Add(txtPos);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text.Trim(), out int id))
            {
                MessageBox.Show("員工編號格式錯誤。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (employees.Any(x => x.IdNumber == id))
            {
                MessageBox.Show("員工編號已存在。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("姓名不可為空。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var emp = new Employee(id, name, txtDept.Text.Trim(), txtPos.Text.Trim());
            employees.Add(emp);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}