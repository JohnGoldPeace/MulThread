using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MulThread
{
    class TaskItem
    {
        public const int MaxVal = 100;
        public const int MinVal = 0;
        private int _value = MinVal;
        public enum TaskState { waiting, running };
        public int value
        {
            get { return _value; }
            set { _value = value; }
        }
        private TaskState _state = TaskState.waiting;

        public TaskState state
        {
            get { return _state; }
            set { _state = value; }
        }
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

    }
    class TaskData
    {
        #region Const define 
        public const int MaxOnline = 4;
        public const int MaxWait = 6;
        #endregion 
        public Action<TaskItem> A_UpdateData;
        public Action<int> A_CountChange;
        public Action A_TaskFinish;
        private object _obLock = new object();
        private object _obLockForFinTask = new object();
        private Semaphore RunSem = new Semaphore(MaxOnline, MaxOnline);
        private int _CurCount = 0;
        private List<TaskItem> LItems = new List<TaskItem>();
        private List<Task> LTasks = new List<Task>();
        private CancellationTokenSource _TaskToken = new CancellationTokenSource();
        public int CurCount { get { return _CurCount; } }
       
        public TaskData()
        {
      
        }
        public void RunTask(object ob)
        {
            RunSem.WaitOne();
            TaskItem TmpItem = null;
            lock (_obLock)
            {
                if (LItems.Count > 0)
                {
                    TmpItem = LItems[0];
                    LItems.RemoveAt(0);
                }
            }
            //TaskItem TmpItem = ob as TaskItem;
            if (TmpItem != null)
            {
                TmpItem.state = TaskItem.TaskState.running;
                while (TmpItem.value++ < TaskItem.MaxVal && !_TaskToken.IsCancellationRequested)
                {
                    if (A_UpdateData!=null)
                        A_UpdateData(TmpItem);
                    Thread.Sleep(100);
                }
            }
            lock (_obLock)
            {
                _CurCount--;
                if (A_CountChange != null)
                    A_CountChange(_CurCount);
            }
            RunSem.Release();
        }
        public bool AddTask(TaskItem ArgItem)
        {
            bool ret = true;
            Task tmpTask = null;
            lock (_obLock)
            {
                if (CurCount < (MaxOnline + MaxWait))
                {
                    _CurCount++;
                    LItems.Add(ArgItem);
                    tmpTask = Task.Factory.StartNew(new Action<object>(RunTask), ArgItem);
                    tmpTask.ContinueWith(new Action<Task>(RemoveFinTask));
                    if (A_CountChange != null)
                        A_CountChange(_CurCount);
                }
                else
                    ret = false;
            }
            if (tmpTask!=null)
            {
                lock (_obLockForFinTask)
                {
                    LTasks.Add(tmpTask);
                }
            }
            return ret;
        }
        private void RemoveFinTask(Task ArgTask)
        {
            lock (_obLockForFinTask)
            {
                LTasks.Remove(ArgTask);
            }
        }
        public void Stop()
        {
            Task.Factory.StartNew(new Action(() => {
                _TaskToken.Cancel();
                Task.WaitAll(LTasks.ToArray());
                if (A_TaskFinish != null)
                    A_TaskFinish();
            }));
        }
    }
}
