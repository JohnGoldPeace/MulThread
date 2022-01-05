using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace MulThread
{
    public partial class MainForm : Form
    {
        private Dictionary<TaskItem, ListViewItem> _ListDataDic;
        private TaskData _TaskData;
        private bool bStop = false;
        private int Count = 0;
        public MainForm()
        {
            InitializeComponent();
            _ListDataDic = new Dictionary<TaskItem, ListViewItem>();
            _TaskData = new TaskData();
            _TaskData.A_UpdateData += HandleDataUpdate;
            _TaskData.A_CountChange += HandleCountChange;
            _TaskData.A_TaskFinish += HandleTaskFin;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Count++;
            TaskItem tmpDataItem = new TaskItem();
            tmpDataItem.ID = Count;
            ListViewItem tmpViewItem = new ListViewItem();
            _ListDataDic[tmpDataItem] = tmpViewItem;
            AddNewItem(tmpViewItem, tmpDataItem);
            _TaskData.AddTask(tmpDataItem);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TaskListView.View = View.Details;
        }
        private void HandleCountChange(int ArgCount)
        {
            if (bStop)
                return;
            this.Invoke(new Action(() => {
                if (ArgCount == (TaskData.MaxOnline + TaskData.MaxWait))
                {
                    this.AddBtn.Enabled = false;
                }
                else
                    this.AddBtn.Enabled = true;
                UpdateIndexNum();
            }));
        }
        private void HandleDataUpdate( TaskItem ArgItem)
        {
            if (bStop)
                return;
            this.Invoke(new Action(() => {
                if (ArgItem.value == TaskItem.MaxVal)//移除
                {
                    if (_ListDataDic.ContainsKey(ArgItem))
                    {
                        this.TaskListView.Items.Remove(_ListDataDic[ArgItem]);
                        _ListDataDic.Remove(ArgItem);
                        //UpdateIndexNum();
                    }
                }
                else//更新状态
                {
                    _ListDataDic[ArgItem].SubItems[1].Text = ArgItem.state.ToString();
                    _ListDataDic[ArgItem].SubItems[2].Text = ArgItem.value + "%";
                }
            }));
        }

        private void HandleTaskFin()
        {
            this.Invoke(new Action(() =>
            {
                this.Close();
            }));
        }
        private void AddNewItem(ListViewItem ViewItem,TaskItem DataItem)
        {
            ViewItem.SubItems.Add(DataItem.state.ToString());
            ViewItem.SubItems.Add(DataItem.value.ToString()+"%");
            ViewItem.SubItems.Add(DataItem.ID.ToString());
            this.TaskListView.Items.Add(ViewItem);
        }
        private void UpdateIndexNum() 
        {
            this.TaskListView.BeginUpdate();
            for (int tmpIndex = 0; tmpIndex < TaskListView.Items.Count; tmpIndex++)
            {
                TaskListView.Items[tmpIndex].Text = (tmpIndex + 1).ToString();
            }
            this.TaskListView.EndUpdate();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_TaskData.CurCount > 0)
            {
                if (MessageBox.Show("Task is running! Continue to close?", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
                else if (!bStop)
                {
                    this.Enabled = false;
                    bStop = true;
                    _TaskData.Stop();
                    e.Cancel = true;
                }
                else { }
            }
            else { }
            
        }
    }
}
