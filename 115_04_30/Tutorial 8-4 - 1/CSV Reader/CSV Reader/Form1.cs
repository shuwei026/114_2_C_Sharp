using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSV_Reader

{
    struct Student
    {
        public string Class;
        public string ID;
        public string Name;
        public int[] scores;


    }
    public partial class Form1 : Form
    {
        private List<Student> gradeBook = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputfile;
                char[] delim = { ',' };
                // Clear any existing data
                gradeBook.Clear();
                averagesListBox.Items.Clear();

                using (inputfile = File.OpenText("Grades.csv"))
                {
                    string line;
                    while (!inputfile.EndOfStream)
                    {
                        line = inputfile.ReadLine();
                        string[] fields = line.Split(delim);
                        // Expected format: class, studentID, name, score1, score2, score3, score4, score5
                        if (fields.Length == 8)
                        {
                            Student student = new Student();
                            student.Class = fields[0];
                            student.ID = fields[1];
                            student.Name = fields[2];
                            student.scores = new int[5];

                            bool parseError = false;
                            for (int i = 0; i < 5; i++)
                            {
                                int s;
                                if (!int.TryParse(fields[3 + i], out s))
                                {
                                    parseError = true;
                                    break;
                                }
                                student.scores[i] = s;
                            }

                            if (parseError)
                            {
                                MessageBox.Show("Invalid score value in line: " + line);
                                continue;
                            }

                            gradeBook.Add(student);
                        }
                        else
                        {
                            MessageBox.Show("Invalid line format: " + line);
                        }
                    }
                }

                // Populate the list box from gradeBook
                foreach (var stu in gradeBook)
                {
                    int total = 0;
                    for (int i = 0; i < stu.scores.Length; i++)
                        total += stu.scores[i];

                    double average = (double)total / stu.scores.Length;
                    string output = string.Format("{0} {1} {2} {3:F2}", stu.Class, stu.ID, stu.Name, average);
                    averagesListBox.Items.Add(output);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the file: " + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
