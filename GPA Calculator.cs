using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GPA_Calculator
{
    public partial class GPA_Cal_Form : Form
    {
        private readonly List<Control[]> courseControls = new List<Control[]>();
        private const int MaxCourses = 17;
        private readonly Database_Connection db = new Database_Connection();
        public GPA_Cal_Form()
        {
            InitializeComponent();
            InitializeBatchComboBox();
            InitializeCourseControls();
        }

        private ComboBox cboBatch;
        private void InitializeBatchComboBox()
        {
            Label lblBatch = new Label
            {
                Text = "Batch:",
                AutoSize = true,
                Location = new Point(30, 10)
            };
            this.Controls.Add(lblBatch);

            cboBatch = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 150,
                Location = new Point(lblBatch.Right + 10, lblBatch.Top)
            };

            List<string> batchItems = GetBatchItemsFromDatabase();

            cboBatch.Items.AddRange(batchItems.ToArray());

            cboBatch.SelectedIndexChanged += CboBatch_SelectedIndexChanged;
            this.Controls.Add(cboBatch);
        }

        private List<string> GetBatchItemsFromDatabase()
        {
            List<string> batchItems = new List<string>();

            try
            {
                using (var con = new System.Data.SQLite.SQLiteConnection(db.con))
                {
                    con.Open();
                    string query = "SELECT DISTINCT Batch FROM Courses";

                    using (var cmd = new System.Data.SQLite.SQLiteCommand(query, con))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string batch = dr.GetString(0);
                                batchItems.Add(batch);
                            }
                        }
                    }
                }
            }
            catch (AccessViolationException ex)
            {
                MessageBox.Show($"AccessViolationException caught: {ex.Message}");
                // Handle the access violation (e.g., log the error and notify the user)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in GetSubjectsFromDatabase: " + ex.Message);
            }

            return batchItems;
        }


        private List<(string Subject, int Credits)> GetSubjectsFromDatabase(string batch)
        {
            List<(string Subject, int Credits)> subjects = new List<(string Subject, int Credits)>();

            try
            {
                
                    db.con.Open();
                    string query = "SELECT Course, Credits FROM Courses WHERE Batch = @Batch";

                    using (db.cmd = new System.Data.SQLite.SQLiteCommand(query, db.con))
                    {
                        db.cmd.Parameters.AddWithValue("@Batch", batch);

                        using (db.dr = db.cmd.ExecuteReader())
                        {
                            while (db.dr.Read())
                            {
                                string subject = db.dr.GetString(0);
                                int credits = db.dr.GetInt32(1);
                                subjects.Add((subject, credits));
                            }
                        }
                    }
                    db.con.Close();
                
            }
            catch (System.Data.SQLite.SQLiteException ex)
    {
        MessageBox.Show($"SQLite Exception in GetSubjectsFromDatabase: {ex.Message}");
        // Handle SQLite specific exceptions
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Exception in GetSubjectsFromDatabase: {ex.Message}");
        // Handle other exceptions
    }

            return subjects;
        }

        private void CboBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cboBatch = (ComboBox)sender;
                string selectedBatch = cboBatch.SelectedItem?.ToString();

                List<(string Subject, int Credits)> subjects = GetSubjectsFromDatabase(selectedBatch);


                if (subjects.Count > 0)
                {
                    ClearCourseControls();
                    AddCourseControls(subjects.Count);

                    for (int i = 0; i < subjects.Count; i++)
                    {
                        var controlSet = courseControls[i];
                        ((TextBox)controlSet[0]).Text = subjects[i].Subject;
                        ((TextBox)controlSet[1]).Text = subjects[i].Credits.ToString();
                    }
                }
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                MessageBox.Show($"SQLite Exception in GetSubjectsFromDatabase: {ex.Message}");
                // Handle SQLite specific exceptions
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in GetSubjectsFromDatabase: {ex.Message}");
                // Handle other exceptions
            }


        }



        private void ClearCourseControls()
        {
            foreach (var controlSet in courseControls)
            {
                foreach (var control in controlSet)
                {
                    this.Controls.Remove(control);
                }
            }
            courseControls.Clear();
        }


        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddCourseControls(1);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 500, WinAPI.BLEND);
        }

        private void InitializeCourseControls()
        {

            AddCourseControls(5);

        }
        private void AddCourseControls(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (courseControls.Count >= MaxCourses)
                {
                    MessageBox.Show($"You can only add up to {MaxCourses} courses.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddCourseControl();
            }
        }

        private void AddCourseControl()
        {
            Label lblCourse = new Label
            {
                Text = "Subject:",
                AutoSize = true,
                Width = 80,
                TextAlign = ContentAlignment.MiddleRight
            };
            TextBox txtCourse = new TextBox { Width = 250 };

            Label lblCredits = new Label
            {
                Text = "Credits:",
                AutoSize = true,
                Width = 50,
                TextAlign = ContentAlignment.MiddleRight
            };
            TextBox txtCredits = new TextBox { Width = 50 };

            Label lblGrade = new Label
            {
                Text = "Grade:",
                AutoSize = true,
                Width = 50,
                TextAlign = ContentAlignment.MiddleRight
            };
            ComboBox cboGrade = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 50
            };
            cboGrade.Items.AddRange(new object[] { "-", "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D" });

            int yPos = courseControls.Count * 30 + 50;
            int xOffset = 30;
            int spacing = 10;

            lblCourse.Location = new Point(xOffset, yPos);
            txtCourse.Location = new Point(lblCourse.Right + spacing, yPos);

            lblCredits.Location = new Point(txtCourse.Right + spacing, yPos);
            txtCredits.Location = new Point(lblCredits.Right + spacing, yPos);

            lblGrade.Location = new Point(txtCredits.Right + spacing, yPos);
            cboGrade.Location = new Point(lblGrade.Right + spacing, yPos);

            this.Controls.Add(lblCourse);
            this.Controls.Add(txtCourse);
            this.Controls.Add(lblCredits);
            this.Controls.Add(txtCredits);
            this.Controls.Add(lblGrade);
            this.Controls.Add(cboGrade);

            courseControls.Add(new Control[] { txtCourse, txtCredits, cboGrade, lblCourse, lblCredits, lblGrade });
        }
        private double GradePoints(string grade)
        {
            switch (grade)
            {
                case "A+": return 4.0;
                case "A": return 4.0;
                case "A-": return 3.7;
                case "B+": return 3.3;
                case "B": return 3.0;
                case "B-": return 2.7;
                case "C+": return 2.3;
                case "C": return 2.0;
                case "C-": return 1.7;
                case "D+": return 1.3;
                case "D": return 1.0;
                default: return 0.0;
            }
        }

        private void Btn_cal_Click(object sender, System.EventArgs e)
        {
            double totalCredits = 0;
            double totalQualityPoints = 0;

            foreach (var controlSet in courseControls)
            {
                var txtCourse = (TextBox)controlSet[0];
                var txtCredits = (TextBox)controlSet[1];
                var cboGrade = (ComboBox)controlSet[2];

                string courseName = txtCourse.Text;

                if (!string.IsNullOrWhiteSpace(courseName))
                {
                    if (!int.TryParse(txtCredits.Text, out int credits))
                    {
                        MessageBox.Show("Please enter valid Credits for the Subject!.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (credits > 6)
                    {
                        MessageBox.Show("Credits cannot be more than 6.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string grade = cboGrade.SelectedItem?.ToString().Trim();
                    if (string.IsNullOrEmpty(grade))
                    {
                        MessageBox.Show("Please Select a Grade for the Subject!.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    totalCredits += credits;
                    double qualityPoints = credits * GradePoints(grade);
                    totalQualityPoints += qualityPoints;
                }
            }

            if (totalCredits == 0)
            {
                MessageBox.Show("Fields Are Empty", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double gpa = totalQualityPoints / totalCredits;
            txt_gpa.Text = gpa.ToString("F2");
        }
    
        private void Btn_clear_Click(object sender, EventArgs e)
        {
            ClearCourseControls();
            AddCourseControls(5);
            txt_gpa.Clear();
            if (cboBatch != null) 
            {
                cboBatch.SelectedIndex = -1; 
            }
        }

        private void Btn_addbatches_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Batch_Database_Form mbdf = new Manage_Batch_Database_Form();
            mbdf.Show();
        }

        private void Guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
