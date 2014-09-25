using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.WordParser.Helpers
{
    class TaskContainer
    {
        private int _max;
        private List<Task> _taskList;

        public TaskContainer(int max)
        {
            _max = max;
            _taskList = new List<Task>(max);
        }

        public void AddAndRun(Task task)
        {
            while (_taskList.Count >= _max)
            {
                System.Threading.Thread.Sleep(10);
            }
            _taskList.Add(task);
            task.ContinueWith(x =>
                {
                    _taskList.Remove(x);
                });
        }
    }
}
