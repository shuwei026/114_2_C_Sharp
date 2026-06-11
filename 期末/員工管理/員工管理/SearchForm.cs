using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 員工管理
{
    public class SearchForm : Form
    {
        private List<Employee> employees;
        private TextBox txtKeyword;
        private Button btnSearch, btnClose;

        public SearchForm(List<Employee> employees)
        {
            this.employees = employees;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "查詢員工";
            this.Width = 500;
            this.Height = 300;

            Label lbl = new Label() { Left = 10, Top = 20, Text = "輸入員工編號或姓名:" };
            txtKeyword = new TextBox() { Left = 160, Top = 20, Width = 300 };
            btnSearch = new Button() { Left = 160, Top = 60, Text = "查詢", Width = 80 };
            btnClose = new Button() { Left = 260, Top = 60, Text = "關閉", Width = 80 };

            btnSearch.Click += BtnSearch_Click;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(lbl);
            this.Controls.Add(txtKeyword);
            this.Controls.Add(btnSearch);
            this.Controls.Add(btnClose);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword)) return;

            List<Employee> results = new List<Employee>();
            if (int.TryParse(keyword, out int id))
            {
                results.AddRange(employees.Where(x => x.IdNumber == id));
            }
            results.AddRange(employees.Where(x => x.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0));
            results = results.Distinct().ToList();

            if (!results.Any())
            {
                MessageBox.Show("找不到員工。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var sb = new StringBuilder();
            foreach (var r in results)
            {
                sb.AppendLine($"員工編號：{r.IdNumber}");
                sb.AppendLine($"姓名：{r.Name}");
                sb.AppendLine($"部門：{r.Department}");
                sb.AppendLine($"職位：{r.Position}");
                sb.AppendLine(new string('-', 30));
            }
            MessageBox.Show(sb.ToString(), "查詢結果");
        }
    }
}