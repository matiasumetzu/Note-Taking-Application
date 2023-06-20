using System.Data;

namespace Note_Taking_Application
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;

        public NoteTaker()
        {
            InitializeComponent();
        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previousNotes.DataSource = notes;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (previousNotes.CurrentRow != null)
                {
                    notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();
                }
            }
            catch (Exception ex) { Console.WriteLine("Not a valid note"); }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = noteBox.Text;
            }
            else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;
        }

        private void newNoteButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (previousNotes.CurrentRow != null && previousNotes.CurrentRow.Index < notes.Rows.Count)
            {
                titleBox.Text = notes.Rows[previousNotes.CurrentRow.Index].Field<string>("Title");
                noteBox.Text = notes.Rows[previousNotes.CurrentRow.Index].Field<string>("Note");
                editing = true;
            }
        }


        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (previousNotes.CurrentRow != null && previousNotes.CurrentRow.Index < notes.Rows.Count)
            {
                titleBox.Text = notes.Rows[previousNotes.CurrentRow.Index].Field<string>("Title");
                noteBox.Text = notes.Rows[previousNotes.CurrentRow.Index].Field<string>("Note");
                editing = true;
            }
        }
    }
}