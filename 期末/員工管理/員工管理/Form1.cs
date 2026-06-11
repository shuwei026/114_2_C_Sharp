using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using Microsoft.VisualBasic; // removed - custom prompt used instead

namespace 員工管理
{
    public partial class Form1 : Form
    {
        private List<Employee> employees = new List<Employee>();
        private string dataFilePath = System.IO.Path.Combine(Application.StartupPath, "employees.txt");

        public Form1()
        {
            InitializeComponent();
            // 初始化事件
            this.btnAdd.Click += BtnAdd_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnEdit.Click += BtnEdit_Click;
            this.btnSearch.Click += BtnSearch_Click;
            this.btnExit.Click += BtnExit_Click;
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
            RefreshList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // load employees from file
            try
            {
                if (System.IO.File.Exists(dataFilePath))
                {
                    var lines = System.IO.File.ReadAllLines(dataFilePath, Encoding.UTF8);
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        var parts = line.Split('|');
                        if (parts.Length >= 4 && int.TryParse(parts[0], out int id))
                        {
                            employees.Add(new Employee(id, parts[1], parts[2], parts[3]));
                        }
                    }
                    RefreshList();
                }
                else
                {
                    // create initial file with default data
                    var initial = new[] {
                        "1001|Alice Chen|Sales|Manager",
                        "1002|Bob Lin|IT|Engineer",
                        "1003|Carol Wang|HR|Specialist"
                    };
                    System.IO.File.WriteAllLines(dataFilePath, initial, Encoding.UTF8);
                    Form1_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取資料檔案發生錯誤: {ex.Message}");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var lines = employees.Select(emp => $"{emp.IdNumber}|{emp.Name}|{emp.Department}|{emp.Position}").ToArray();
                System.IO.File.WriteAllLines(dataFilePath, lines, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"儲存資料發生錯誤: {ex.Message}");
            }
        }

        private void RefreshList()
        {
            lstEmployees.Items.Clear();
            foreach (var e in employees)
            {
                lstEmployees.Items.Add($"{e.IdNumber}\t{e.Name}");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new AddForm(employees))
            {
                var dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (var f = new DeleteForm(employees))
            {
                var dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (var f = new EditForm(employees))
            {
                var dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            using (var f = new SearchForm(employees))
            {
                f.ShowDialog();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string PromptInput(string prompt, string title = "", string defaultValue = "")
        {
            using (Form form = new Form())
            {
                form.Width = 400;
                form.Height = 150;
                form.Text = title;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.MinimizeBox = false;
                form.MaximizeBox = false;

                Label lbl = new Label() { Left = 10, Top = 10, Text = prompt, AutoSize = true };
                TextBox txt = new TextBox() { Left = 10, Top = 35, Width = 360, Text = defaultValue };
                Button btnOk = new Button() { Text = "確定", Left = 220, Width = 70, Top = 70, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "取消", Left = 300, Width = 70, Top = 70, DialogResult = DialogResult.Cancel };

                form.Controls.Add(lbl);
                form.Controls.Add(txt);
                form.Controls.Add(btnOk);
                form.Controls.Add(btnCancel);
                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                var dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                    return txt.Text;
                return null;
            }
        }

    }

    
}
