using Guna.UI2.AnimatorNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GPA_Calculator
{
    public partial class Manage_Batch_Database_Form : Form
    {
        private readonly List<Control[]> courseControls = new List<Control[]>();
        private const int MaxCourses = 17;
        private readonly Database_Connection db = new Database_Connection();
        public Manage_Batch_Database_Form()
        {
            InitializeComponent();
            AddCourseControl();
            InitializeCourseControls();
            InitializeBatchComboBox();
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            GPA_Cal_Form f = new GPA_Cal_Form();
            f.Show();
        }

        private ComboBox cboBatch;

        private void InitializeBatchComboBox()
        {
            Label lblBatch = new Label
            {
                Text = "Edit Saved Batch Subjects And Credits:",
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

            this.Controls.Add(cboBatch);

            LoadBatchItemsIntoComboBox();

            cboBatch.SelectedIndexChanged += CboBatch_SelectedIndexChanged;
        }

        private void LoadBatchItemsIntoComboBox()
        {
            List<string> batchItems = GetBatchItemsFromDatabase();

            cboBatch.Items.Clear();
            cboBatch.Items.AddRange(batchItems.ToArray());
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in GetSubjectsFromDatabase: " + ex.Message);
            }

            return batchItems; ;
        }
        private List<(int Id, string Subject, int Credits)> GetSubjectsFromDatabase(string batch)
        {
            List<(int Id, string Subject, int Credits)> subjects = new List<(int Id ,string Subject, int Credits)>();

            try
            {

                db.con.Open();
                string query = "SELECT ID ,Course, Credits FROM Courses WHERE Batch = @Batch";

                using (db.cmd = new System.Data.SQLite.SQLiteCommand(query, db.con))
                {
                    db.cmd.Parameters.AddWithValue("@Batch", batch);

                    using (db.dr = db.cmd.ExecuteReader())
                    {
                        while (db.dr.Read())
                        {
                            int Id = db.dr.GetInt32(0);
                            string subject = db.dr.GetString(1);
                            int credits = db.dr.GetInt32(2);
                            subjects.Add((Id, subject, credits));
                        }
                    }
                }
                db.con.Close();

            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                MessageBox.Show($"SQLite Exception in GetSubjectsFromDatabase: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in GetSubjectsFromDatabase: {ex.Message}");
            }

            return subjects;
        }
        private void CboBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cboBatch = (ComboBox)sender;
                string selectedBatch = cboBatch.SelectedItem?.ToString();

                List<(int Id, string Subject, int Credits)> subjects = GetSubjectsFromDatabase(selectedBatch);


                if (subjects.Count > 0)
                {
                    ClearCourseControls();
                    AddCourseControls(subjects.Count);

                    for (int i = 0; i < subjects.Count; i++)
                    {
                        var controlSet = courseControls[i];
                        ((TextBox)controlSet[0]).Text = subjects[i].Id.ToString();
                        ((TextBox)controlSet[1]).Text = subjects[i].Subject;
                        ((TextBox)controlSet[2]).Text = subjects[i].Credits.ToString();
                    }
                }
                linkLabel1.Visible = false;
                label1.Visible = false;
                txt_newbatch.Visible = false;
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                MessageBox.Show($"SQLite Exception in GetSubjectsFromDatabase: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in GetSubjectsFromDatabase: {ex.Message}");
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

        private void AddCourseControl()
        {
            try
            {
                Label lblID = new Label
                {
                    Text = "ID:",
                    AutoSize = true,
                    Width = 50,
                    TextAlign = ContentAlignment.MiddleRight
                };
                TextBox txtId = new TextBox
                {
                    Width = 50,
                    ReadOnly = true
                };

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

                int yPos = courseControls.Count * 30 + 100;
                int xOffset = 30;
                int spacing = 10;

                lblID.Location = new Point(xOffset, yPos);
                txtId.Location = new Point(lblID.Right , yPos);

                lblCourse.Location = new Point(txtId.Right + spacing, yPos);
                txtCourse.Location = new Point(lblCourse.Right , yPos);

                lblCredits.Location = new Point(txtCourse.Right + spacing, yPos);
                txtCredits.Location = new Point(lblCredits.Right + spacing, yPos);

                this.Controls.Add(lblID);
                this.Controls.Add(txtId);
                this.Controls.Add(lblCourse);
                this.Controls.Add(txtCourse);
                this.Controls.Add(lblCredits);
                this.Controls.Add(txtCredits);

                courseControls.Add(new Control[] { txtId, txtCourse, txtCredits, lblID, lblCourse, lblCredits });
            }
            catch (AccessViolationException ex)
            {
                MessageBox.Show($"AccessViolationException caught: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in AddCourseControl: {ex.Message}");
            }
        }


        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddCourseControls(1);
        }

        private void InitializeCourseControls()
        {
            AddCourseControls(15);
        }

        private void AddCourseControls(int count)
        {
            try
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
            catch (AccessViolationException ex)
            {
                MessageBox.Show($"AccessViolationException caught: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in AddCourseControls: {ex.Message}");
            }
        }

       
        private void Manage_Batch_Database_Form_Load(object sender, EventArgs e)
        {

            try
            {
                WinAPI.AnimateWindow(this.Handle, 500, WinAPI.BLEND);
            }
            catch (AccessViolationException ex)
            {
                MessageBox.Show($"AccessViolationException caught: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in form load event: {ex.Message}");
            }
        }
        public void Clear()
        {
            radioUpdateCourse.Checked = false;
            radioUpdateCredits.Checked = false;
            ClearCourseControls();
            txt_newbatch.Clear();
            AddCourseControls(15);
            if (cboBatch != null)
            {
                cboBatch.SelectedIndex = -1;
            }
            linkLabel1.Visible = true;
            label1.Visible = true;
            txt_newbatch.Visible = true;
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            radioUpdateCourse.Checked = false;
            radioUpdateCredits.Checked = false;
            ClearCourseControls();
            txt_newbatch.Clear();
            AddCourseControls(15);
            if (cboBatch != null)
            {
                cboBatch.SelectedIndex = -1;
            }
            linkLabel1.Visible = true;
            label1.Visible = true;
            txt_newbatch.Visible = true;
        }

        private bool BatchExists(string batch)
        {
            bool exists = false;

            try
            {
                using (var con = new System.Data.SQLite.SQLiteConnection(db.con))
                {
                    con.Open();
                    string query = "SELECT COUNT(1) FROM Courses WHERE Batch = @Batch";

                    using (var cmd = new System.Data.SQLite.SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Batch", batch);
                        exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in BatchExists: {ex.Message}");
            }

            return exists;
        }


        private void Btn_save_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txt_newbatch.Text))
                {
                    MessageBox.Show("Please Enter a Batch!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (BatchExists(txt_newbatch.Text))
                {
                    MessageBox.Show("This batch already exists. Please choose a different batch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool atLeastOneSubjectFilled = false;

                var courseControlsCopy = courseControls.ToList();

                foreach (var controlSet in courseControlsCopy)
                {
                    string subject = ((TextBox)controlSet[1]).Text;
                    if (string.IsNullOrEmpty(subject))
                    {
                        continue;
                    }
                    if (!int.TryParse(((TextBox)controlSet[2]).Text, out int credits))
                    {
                        continue;
                    }


                    atLeastOneSubjectFilled = true;
                    break;
                }

                if (!atLeastOneSubjectFilled)
                {
                    MessageBox.Show("Please enter at least one subject and its credits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool flag = true;
                foreach (var controlSet in courseControlsCopy)
                {
                    string subject = ((TextBox)controlSet[1]).Text;
                    if (string.IsNullOrEmpty(subject))
                    {
                        continue;
                    }
                    if (!int.TryParse(((TextBox)controlSet[2]).Text, out int credits))
                    {
                        continue;
                    }

                    if (SubjectExists(txt_newbatch.Text, subject))
                    {
                        MessageBox.Show("Subject already exists in the database. Please choose a different subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (credits > 6)
                    {
                        MessageBox.Show("Credits cannot be more than 6.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (var con = new System.Data.SQLite.SQLiteConnection(db.con))
                    {

                        con.Open();
                        string query = "INSERT INTO Courses (Batch, Course, Credits) VALUES (@Batch, @Course, @Credits)";

                        using (var cmd = new System.Data.SQLite.SQLiteCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Batch", txt_newbatch.Text);
                            cmd.Parameters.AddWithValue("@Course", subject);
                            cmd.Parameters.AddWithValue("@Credits", credits);
                            cmd.ExecuteNonQuery();
                        }

                    }
                }
                if (flag)
                {
                    MessageBox.Show("Batch inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    LoadBatchItemsIntoComboBox();
                }
                flag = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in Insert: {ex.Message}");
            }


        }
        private bool SubjectExists(string batch, string subject)
        {
            bool exists = false;

            try
            {
                using (var con = new System.Data.SQLite.SQLiteConnection(db.con))
                {
                    con.Open();
                    string query = "SELECT COUNT(1) FROM Courses WHERE Batch = @Batch AND Course = @Course";

                    using (var cmd = new System.Data.SQLite.SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Batch", batch);
                        cmd.Parameters.AddWithValue("@Course", subject);
                        exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in SubjectExists: {ex.Message}");
            }

            return exists;
        }


        private void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string batch = cboBatch.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(batch))
                {
                    MessageBox.Show("Please select a Batch!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!radioUpdateCourse.Checked && !radioUpdateCredits.Checked)
                {
                    MessageBox.Show("Please select an operation (Update Course or Update Credits).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var controlSet in courseControls)
                {
                    TextBox txtId = (TextBox)controlSet[0];
                    TextBox txtCourse = (TextBox)controlSet[1];
                    TextBox txtCredits = (TextBox)controlSet[2];

                    string id = txtId.Text;
                    string subject = txtCourse.Text;
                    string creditsText = txtCredits.Text;

                    if (radioUpdateCourse.Checked)
                    {
                        if (string.IsNullOrEmpty(subject))
                        {
                            MessageBox.Show("Subject Cannot be Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        UpdateCourse(id, subject);
                    }
                    else if (radioUpdateCredits.Checked)
                    {
                        if (string.IsNullOrEmpty(subject))
                        {
                            MessageBox.Show("Subject Cannot be Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!int.TryParse(creditsText, out int credits))
                        {
                            MessageBox.Show("Credits Cannot be Empty or Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (!SubjectExists(batch, subject))
                        {
                            MessageBox.Show("Subject does not exist in the database. Please enter a valid subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (credits > 6)
                        {
                            MessageBox.Show("Credits cannot be more than 6.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        UpdateCredits(id, credits);
                    }
                }

                MessageBox.Show("Updates Completed Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                LoadBatchItemsIntoComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in Update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateCourse(string id, string subject)
        {
            try
            {
                using (var con = new System.Data.SQLite.SQLiteConnection(db.con))
                {
                    con.Open();
                    string query = "UPDATE Courses SET Course = @NewCourse WHERE ID = @ID";

                    using (var cmd = new System.Data.SQLite.SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@NewCourse", subject);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in UpdateCourse: {ex.Message}");
            }
        }
        private void UpdateCredits(string id, int credits)
        {
            try
            {
                using (var con = new System.Data.SQLite.SQLiteConnection(db.con))
                {
                    con.Open();
                    string query = "UPDATE Courses SET Credits = @Credits WHERE ID = @ID";

                    using (var cmd = new System.Data.SQLite.SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Credits", credits);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in UpdateCredits: {ex.Message}");
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            bool flag = true;
            try
            {
                string batch = cboBatch.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(batch))
                {
                    MessageBox.Show("Please Select a Batch!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var controlSet in courseControls)
                {
                    string subject = ((TextBox)controlSet[0]).Text;

                    using (var con = new System.Data.SQLite.SQLiteConnection(db.con))
                    {
                        con.Open();
                        string query = "DELETE FROM Courses WHERE Batch = @Batch";

                        using (var cmd = new System.Data.SQLite.SQLiteCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Batch", batch);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                if (flag)
                {
                    MessageBox.Show("Batch Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    LoadBatchItemsIntoComboBox();
                }
                flag = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in Delete: {ex.Message}");
            }
        }
    }
}
