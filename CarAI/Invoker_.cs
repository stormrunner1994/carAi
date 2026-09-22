using System.Drawing;
using System.Windows.Forms;

namespace Invoker_
{
    class Invoker
    {
        public static void invokeProgressBar(ProgressBar myobject, int value, int min, int max)
        {
            if (myobject.InvokeRequired)
            {
                myobject.Invoke((MethodInvoker)(() => myobject.Minimum = min));
                myobject.Invoke((MethodInvoker)(() => myobject.Maximum = max));
                myobject.Invoke((MethodInvoker)(() => myobject.Value = value));
            }
            else
            {
                myobject.Minimum = min;
                myobject.Maximum = max;
                myobject.Value = value;
            }
        }

        public static void Resize(object myobject)
        {
            if (myobject is DataGridView dataGridView)
            {
                dataGridView.Invoke((MethodInvoker)delegate
                {
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                        dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        int colw = dataGridView.Columns[i].Width;
                        dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView.Columns[i].Width = colw;
                    }
                });
            }
        }

        public static void SelectIndex(object myobject, int index)
        {
            if (myobject is ListBox)
            {
                if (((ListBox)myobject).InvokeRequired) ((ListBox)myobject).Invoke((MethodInvoker)(() => ((ListBox)myobject).SelectedIndex = index));
                else ((ListBox)myobject).SelectedIndex = index;
            }
        }

        public static int invokeProgressBarGetMax(ProgressBar myobject)
        {
            int max = 0;
            if (myobject.InvokeRequired)
            {
                myobject.Invoke((MethodInvoker)(() => max = myobject.Maximum));
            }
            else
            {
                max = myobject.Maximum;
            }
            return max;
        }

        public static int invokeSelectedIndex(object myobject)
        {
            int index = -1;
            if (myobject is ComboBox)
            {
                if (((ComboBox)myobject).InvokeRequired) ((ComboBox)myobject).Invoke((MethodInvoker)(() => index = ((ComboBox)myobject).SelectedIndex));
                else index = ((ComboBox)myobject).SelectedIndex;
            }

            return index;
        }

        public static void invokeIcon(object myobject, Form form)
        {
            if (myobject is Icon)
            {
                form.Invoke((MethodInvoker)delegate
                {
                    form.Icon = (Icon)myobject;
                });
            }
        }

        public static void invokeSetLocation(object myobject, Point location)
        {
            if (myobject is PictureBox)
            {
                if (((PictureBox)myobject).InvokeRequired) ((PictureBox)myobject).Invoke((MethodInvoker)(() => ((PictureBox)myobject).Location = location));
                else ((PictureBox)myobject).Location = location;
            }
        }

        public static Point invokeGetLocation(object myobject)
        {
            Point location = new Point();

            if (myobject is PictureBox)
            {
                if (((PictureBox)myobject).InvokeRequired) ((PictureBox)myobject).Invoke((MethodInvoker)(() => location = ((PictureBox)myobject).Location));
                else location = ((PictureBox)myobject).Location;
            }

            return location;
        }

        public static void invokeSelect(object myobject, int index)
        {
            if (myobject is TreeView)
            {
                if (((TreeView)myobject).InvokeRequired) ((TreeView)myobject).Invoke((MethodInvoker)(() => ((TreeView)myobject).SelectedNode = ((TreeView)myobject).Nodes[0]));
                else ((TreeView)myobject).SelectedNode = ((TreeView)myobject).Nodes[0];
            }
        }

        public static void invokeProgressBarValue(ProgressBar myobject, int value)
        {
            if (myobject.InvokeRequired)
            {
                myobject.Invoke((MethodInvoker)(() => myobject.Value = value));
            }
            else
            {
                myobject.Value = value;
            }
        }

        public static void invokeVisible(object myobject, bool visible)
        {
            if (myobject is Label)
            {
                if (((Label)myobject).InvokeRequired) ((Label)myobject).Invoke((MethodInvoker)(() => ((Label)myobject).Visible = visible));
                else ((Label)myobject).Visible = visible;
            }
            else if (myobject is PictureBox)
            {
                if (((PictureBox)myobject).InvokeRequired) ((PictureBox)myobject).Invoke((MethodInvoker)(() => ((PictureBox)myobject).Visible = visible));
                else ((PictureBox)myobject).Visible = visible;
            }
            else if (myobject is TextBox)
            {
                if (((TextBox)myobject).InvokeRequired) ((TextBox)myobject).Invoke((MethodInvoker)(() => ((TextBox)myobject).Visible = visible));
                else ((TextBox)myobject).Visible = visible;
            }
            else if (myobject is ProgressBar)
            {
                if (((ProgressBar)myobject).InvokeRequired) ((ProgressBar)myobject).Invoke((MethodInvoker)(() => ((ProgressBar)myobject).Visible = visible));
                else ((ProgressBar)myobject).Visible = visible;
            }
            else if (myobject is GroupBox)
            {
                if (((GroupBox)myobject).InvokeRequired) ((GroupBox)myobject).Invoke((MethodInvoker)(() => ((GroupBox)myobject).Visible = visible));
                else ((GroupBox)myobject).Visible = visible;
            }
        }

        public static void invokeChecked(object myobject, bool isChecked)
        {
            if (myobject is CheckBox)
            {
                if (((CheckBox)myobject).InvokeRequired) ((CheckBox)myobject).Invoke((MethodInvoker)(() => ((CheckBox)myobject).Checked = isChecked));
                else ((CheckBox)myobject).Checked = isChecked;
            }
        }

        public static bool invokeIsChecked(object myobject)
        {
            bool isChecked = false;
            if (myobject is CheckBox)
            {
                if (((CheckBox)myobject).InvokeRequired) ((CheckBox)myobject).Invoke((MethodInvoker)(() => isChecked = ((CheckBox)myobject).Checked));
                else isChecked = ((CheckBox)myobject).Checked;
            }
            return isChecked;
        }


        public static void invokeNodeAdd(object myobject, string text)
        {
            if (myobject is TreeNode)
            {
                if (((TreeNode)myobject).TreeView.InvokeRequired) ((TreeNode)myobject).TreeView.Invoke((MethodInvoker)(() => ((TreeNode)myobject).Nodes.Add(text)));
                else ((TreeNode)myobject).Nodes.Add(text);
            }
            else if (myobject is TreeView)
            {
                if (((TreeView)myobject).InvokeRequired) ((TreeView)myobject).Invoke((MethodInvoker)(() => ((TreeView)myobject).Nodes.Add(text)));
                else ((TreeView)myobject).Nodes.Add(text);
            }
        }

        public static void invokeItemsAdd(object myobject, string text)
        {
            if (myobject is ListBox)
            {
                if (((ListBox)myobject).InvokeRequired) ((ListBox)myobject).Invoke((MethodInvoker)(() => ((ListBox)myobject).Items.Add(text)));
                else ((ListBox)myobject).Items.Add(text);
            }
            else if (myobject is ComboBox)
            {
                if (((ComboBox)myobject).InvokeRequired) ((ComboBox)myobject).Invoke((MethodInvoker)(() => ((ComboBox)myobject).Items.Add(text)));
                else ((ComboBox)myobject).Items.Add(text);
            }
        }

        public static void invokeItemsRemoveAt(object myobject, int at)
        {
            if (myobject is ListBox)
            {
                if (((ListBox)myobject).InvokeRequired) ((ListBox)myobject).Invoke((MethodInvoker)(() => ((ListBox)myobject).Items.RemoveAt(at)));
                else ((ListBox)myobject).Items.RemoveAt(at);
            }
        }
        public static int invokeItemsCount(object myobject)
        {
            int count = -1;
            if (myobject is ListBox)
            {
                if (((ListBox)myobject).InvokeRequired) ((ListBox)myobject).Invoke((MethodInvoker)(() => count = ((ListBox)myobject).Items.Count));
                else count = ((ListBox)myobject).Items.Count;
            }
            else if (myobject is ComboBox)
            {
                if (((ComboBox)myobject).InvokeRequired) ((ComboBox)myobject).Invoke((MethodInvoker)(() => count = ((ComboBox)myobject).Items.Count));
                else count = ((ComboBox)myobject).Items.Count;
            }
            return count;
        }

        public static void invokeItemsClear(object myobject)
        {
            if (myobject is ListBox)
            {
                if (((ListBox)myobject).InvokeRequired) ((ListBox)myobject).Invoke((MethodInvoker)(() => ((ListBox)myobject).Items.Clear()));
                else ((ListBox)myobject).Items.Clear();
            }
            else if (myobject is ComboBox)
            {
                if (((ComboBox)myobject).InvokeRequired) ((ComboBox)myobject).Invoke((MethodInvoker)(() => ((ComboBox)myobject).Items.Clear()));
                else ((ComboBox)myobject).Items.Clear();
            }
        }

        public static void invokeEnable(object myobject, bool enable)
        {
            if (myobject is Label)
            {
                if (((Label)myobject).InvokeRequired) ((Label)myobject).Invoke((MethodInvoker)(() => ((Label)myobject).Enabled = enable));
                else ((Label)myobject).Enabled = enable;
            }
            else if (myobject is TextBox)
            {
                if (((TextBox)myobject).InvokeRequired) ((TextBox)myobject).Invoke((MethodInvoker)(() => ((TextBox)myobject).Enabled = enable));
                else ((TextBox)myobject).Enabled = enable;
            }
            else if (myobject is TabControl)
            {
                if (((TabControl)myobject).InvokeRequired) ((TabControl)myobject).Invoke((MethodInvoker)(() => ((TabControl)myobject).Enabled = enable));
                else ((TabControl)myobject).Enabled = enable;
            }
            else if (myobject is PictureBox)
            {
                if (((PictureBox)myobject).InvokeRequired) ((PictureBox)myobject).Invoke((MethodInvoker)(() => ((PictureBox)myobject).Enabled = enable));
                else ((PictureBox)myobject).Enabled = enable;
            }
            else if (myobject is GroupBox)
            {
                if (((GroupBox)myobject).InvokeRequired) ((GroupBox)myobject).Invoke((MethodInvoker)(() => ((GroupBox)myobject).Enabled = enable));
                else ((GroupBox)myobject).Enabled = enable;
            }
            else if (myobject is Button)
            {
                if (((Button)myobject).InvokeRequired) ((Button)myobject).Invoke((MethodInvoker)(() => ((Button)myobject).Enabled = enable));
                else ((Button)myobject).Enabled = enable;
            }
            else if (myobject is ToolStripMenuItem)
            {
                if (((ToolStripMenuItem)myobject).GetCurrentParent().InvokeRequired) ((ToolStripMenuItem)myobject).GetCurrentParent().Invoke((MethodInvoker)(() => ((ToolStripMenuItem)myobject).Enabled = enable));
                else ((ToolStripMenuItem)myobject).Enabled = enable;
            }
            if (myobject is TreeView)
            {
                if (((TreeView)myobject).InvokeRequired) ((TreeView)myobject).Invoke((MethodInvoker)(() => ((TreeView)myobject).Enabled = enable));
                else ((TreeView)myobject).Enabled = enable;
            }
            if (myobject is ComboBox)
            {
                if (((ComboBox)myobject).InvokeRequired) ((ComboBox)myobject).Invoke((MethodInvoker)(() => ((ComboBox)myobject).Enabled = enable));
                else ((ComboBox)myobject).Enabled = enable;
            }
            if (myobject is RichTextBox)
            {
                if (((RichTextBox)myobject).InvokeRequired) ((RichTextBox)myobject).Invoke((MethodInvoker)(() => ((RichTextBox)myobject).Enabled = enable));
                else ((RichTextBox)myobject).Enabled = enable;
            }
            if (myobject is CheckBox)
            {
                if (((CheckBox)myobject).InvokeRequired) ((CheckBox)myobject).Invoke((MethodInvoker)(() => ((CheckBox)myobject).Enabled = enable));
                else ((CheckBox)myobject).Enabled = enable;
            }
            if (myobject is ListBox)
            {
                if (((ListBox)myobject).InvokeRequired) ((ListBox)myobject).Invoke((MethodInvoker)(() => ((ListBox)myobject).Enabled = enable));
                else ((ListBox)myobject).Enabled = enable;
            }
        }

        public static void invokeTextSet(object myobject, string text)
        {
            if (myobject is Label)
            {
                if (((Label)myobject).InvokeRequired) ((Label)myobject).Invoke((MethodInvoker)(() => ((Label)myobject).Text = text));
                else ((Label)myobject).Text = text;
            }
            else if (myobject is TextBox)
            {
                if (((TextBox)myobject).InvokeRequired) ((TextBox)myobject).Invoke((MethodInvoker)(() => ((TextBox)myobject).Text = text));
                else ((TextBox)myobject).Text = text;
            }
            else if (myobject is Button)
            {
                if (((Button)myobject).InvokeRequired) ((Button)myobject).Invoke((MethodInvoker)(() => ((Button)myobject).Text = text));
                else ((Button)myobject).Text = text;
            }
            else if (myobject is RichTextBox)
            {
                if (((RichTextBox)myobject).InvokeRequired) ((RichTextBox)myobject).Invoke((MethodInvoker)(() => ((RichTextBox)myobject).Text = text));
                else ((RichTextBox)myobject).Text = text;
            }
            else if (myobject is GroupBox)
            {
                if (((GroupBox)myobject).InvokeRequired) ((GroupBox)myobject).Invoke((MethodInvoker)(() => ((GroupBox)myobject).Text = text));
                else ((GroupBox)myobject).Text = text;
            }
            else if (myobject is Form)
            {
                if (((Form)myobject).InvokeRequired) ((Form)myobject).Invoke((MethodInvoker)(() => ((Form)myobject).Text = text));
                else ((Form)myobject).Text = text;
            }
        }

        public static void invokeInvalidate(object myobject)
        {
            if (((Panel)myobject).InvokeRequired) ((Panel)myobject).Invoke((MethodInvoker)(() => ((Panel)myobject).Invalidate()));
            else ((Panel)myobject).Invalidate();
        }

        public static string invokeTextGet(object myobject)
        {
            string text = "";
            if (myobject is Label)
            {
                if (((Label)myobject).InvokeRequired) ((Label)myobject).Invoke((MethodInvoker)(() => text = ((Label)myobject).Text));
                else text = ((Label)myobject).Text;
            }
            else if (myobject is TextBox)
            {
                if (((TextBox)myobject).InvokeRequired) ((TextBox)myobject).Invoke((MethodInvoker)(() => text = ((TextBox)myobject).Text));
                else text = ((TextBox)myobject).Text;
            }
            else if (myobject is Button)
            {
                if (((Button)myobject).InvokeRequired) ((Button)myobject).Invoke((MethodInvoker)(() => text = ((Button)myobject).Text));
                else text = ((Button)myobject).Text;
            }
            else if (myobject is RichTextBox)
            {
                if (((RichTextBox)myobject).InvokeRequired) ((RichTextBox)myobject).Invoke((MethodInvoker)(() => text = ((RichTextBox)myobject).Text));
                else text = ((RichTextBox)myobject).Text;
            }
            else if (myobject is GroupBox)
            {
                if (((GroupBox)myobject).InvokeRequired) ((GroupBox)myobject).Invoke((MethodInvoker)(() => text = ((GroupBox)myobject).Text));
                else text = ((GroupBox)myobject).Text;
            }
            else if (myobject is ComboBox)
            {
                if (((ComboBox)myobject).InvokeRequired) ((ComboBox)myobject).Invoke((MethodInvoker)(() => text = ((ComboBox)myobject).Text));
                else text = ((ComboBox)myobject).Text;
            }
            else if (myobject is ListBox)
            {
                if (((ListBox)myobject).InvokeRequired) ((ListBox)myobject).Invoke((MethodInvoker)(() => text = ((ListBox)myobject).Text));
                else text = ((ListBox)myobject).Text;
            }

            return text;
        }

        public static void invokeClearColumns(object myobject)
        {
            if (myobject is DataGridView)
            {
                if (((DataGridView)myobject).InvokeRequired) ((DataGridView)myobject).Invoke((MethodInvoker)(() => ((DataGridView)myobject).Columns.Clear()));
                else ((DataGridView)myobject).Columns.Clear();
            }
        }
        public static void invokeClearRows(object myobject)
        {
            if (myobject is DataGridView)
            {
                if (((DataGridView)myobject).InvokeRequired) ((DataGridView)myobject).Invoke((MethodInvoker)(() => ((DataGridView)myobject).Rows.Clear()));
                else ((DataGridView)myobject).Rows.Clear();
            }
        }

        public static void invokeAutoResizeColumns(object myobject, DataGridViewAutoSizeColumnsMode mode)
        {
            if (myobject is DataGridView)
            {
                if (((DataGridView)myobject).InvokeRequired) ((DataGridView)myobject).Invoke((MethodInvoker)(() => ((DataGridView)myobject).AutoResizeColumns(mode)));
                else ((DataGridView)myobject).AutoResizeColumns(mode);
            }
        }

        public static void invokeAddRow(object myobject, string[] cells)
        {
            if (myobject is DataGridView)
            {
                if (((DataGridView)myobject).InvokeRequired) ((DataGridView)myobject).Invoke((MethodInvoker)(() => ((DataGridView)myobject).Rows.Add(cells)));
                else ((DataGridView)myobject).Rows.Add(cells);
            }
        }

        public static void invokeAddColumn(object myobject, string column, string headerText)
        {
            if (myobject is DataGridView)
            {
                if (((DataGridView)myobject).InvokeRequired) ((DataGridView)myobject).Invoke((MethodInvoker)(() => ((DataGridView)myobject).Columns.Add(column, headerText)));
                else ((DataGridView)myobject).Columns.Add(column, headerText);
            }
        }


        public static void invokeAppendText(object myobject, string text)
        {
            if (myobject is Label)
            {
                if (((Label)myobject).InvokeRequired) ((Label)myobject).Invoke((MethodInvoker)(() => ((Label)myobject).Text += text));
                else ((Label)myobject).Text += text;
            }
            else if (myobject is TextBox)
            {
                if (((TextBox)myobject).InvokeRequired) ((TextBox)myobject).Invoke((MethodInvoker)(() => ((TextBox)myobject).Text += text));
                else ((TextBox)myobject).Text += text;
            }
            else if (myobject is Button)
            {
                if (((Button)myobject).InvokeRequired) ((Button)myobject).Invoke((MethodInvoker)(() => ((Button)myobject).Text += text));
                else ((Button)myobject).Text += text;
            }
            else if (myobject is RichTextBox)
            {
                if (((RichTextBox)myobject).InvokeRequired) ((RichTextBox)myobject).Invoke((MethodInvoker)(() => ((RichTextBox)myobject).Text += text));
                else ((RichTextBox)myobject).Text += text;
            }
        }

    }
}