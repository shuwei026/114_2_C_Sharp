using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 員工管理
{
    public class EditForm : Form
    {
        private List<Employee> employees;
        private TextBox txtId, txtName, txtDept, txtPos;
        private Button btnLoad, btnSave, btnCancel;
        private Employee current;

        public EditForm(List<Employee> employees)
        {
            this.employees = employees;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "修改員工";
            this.Width = 400;
            this.Height = 350;

            Label lblId = new Label() { Left = 10, Top = 20, Text = "員工編號:" };
            txtId = new TextBox() { Left = 100, Top = 20, Width = 250 };
            btnLoad = new Button() { Left = 100, Top = 50, Text = "載入", Width = 80 };
            btnLoad.Click += BtnLoad_Click;

            Label lblName = new Label() { Left = 10, Top = 90, Text = "姓名:" };
            txtName = new TextBox() { Left = 100, Top = 90, Width = 250 };
            Label lblDept = new Label() { Left = 10, Top = 130, Text = "部門:" };
            txtDept = new TextBox() { Left = 100, Top = 130, Width = 250 };
            Label lblPos = new Label() { Left = 10, Top = 170, Text = "職稱:" };
            txtPos = new TextBox() { Left = 100, Top = 170, Width = 250 };

            btnSave = new Button() { Left = 100, Top = 210, Text = "儲存", Width = 80 };
            btnCancel = new Button() { Left = 200, Top = 210, Text = "取消", Width = 80 };

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblId);
            this.Controls.Add(txtId);
            this.Controls.Add(btnLoad);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblDept);
            this.Controls.Add(txtDept);
            this.Controls.Add(lblPos);
            this.Controls.Add(txtPos);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text.Trim(), out int id))
            {
                MessageBox.Show("員工編號格式錯誤。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            current = employees.FirstOrDefault(x => x.IdNumber == id);
            if (current == null)
            {
                MessageBox.Show("找不到員工。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtName.Text = current.Name;
            txtDept.Text = current.Department;
            txtPos.Text = current.Position;
            txtId.ReadOnly = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (current == null)
            {
                MessageBox.Show("請先載入員工資料。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("姓名不可為空。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            current.Name = name;
            current.Department = txtDept.Text.Trim();
            current.Position = txtPos.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}