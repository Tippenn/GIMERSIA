using UnityEngine;
using System.Collections.Generic;
public interface ITaskReceiver
{
    void AddTask(ChefTask task);
    ChefTask CurrentTask { get; }
    Queue<ChefTask> TaskQueue { get; }
    ChefController Chef { get; }
}
