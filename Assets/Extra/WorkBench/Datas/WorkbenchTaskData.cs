using System.Collections;
using System.Collections.Generic;

public class WorkbenchTaskData
{
    private static WorkbenchTaskData _WorkbenchTaskData = new WorkbenchTaskData();
    private static Dictionary<string, WorkTask> Lib;

    public static WorkbenchTaskData CreateInstance()
    {
        Init();
        return _WorkbenchTaskData;
    }

    public static WorkTask GetTaskData(string key)
    {
        return Lib[key];
    }

    private static void Init()
    {
        if (Lib == null)
        {
            Lib = new Dictionary<string, WorkTask>();
            Lib.Add("简单", NewWorkTask("料理",1, 1, "材料", "食物"));
        }
    }

    private static WorkTask NewWorkTask(string ActionName, float costTime, int materialsLength, params string[] items)
    {
        string[] materials = new string[materialsLength];
        for (int i = 0; i < materialsLength; i++)
        {
            materials[i] = items[i];
        }
        string[] products = new string[items.Length - materialsLength];
        for (int i = 0; i < items.Length - materialsLength; i++)
        {
            products[i] = items[i + materialsLength];
        }
        return new WorkTask { ActionName=ActionName, GettingList = products, LosingList = materials, TimeCost = costTime };
    }
}
