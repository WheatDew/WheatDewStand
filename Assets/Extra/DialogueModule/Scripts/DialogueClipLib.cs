using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueClipLib : MonoBehaviour
{
    public Dictionary<string, List<string>> lib = new Dictionary<string, List<string>>();


    public void InitializationLib()
    {
        string[] DialogueLines = File.ReadAllLines("Assets\\Data\\对话数据.txt");

        string currentName = "";
        for (int i = 0; i < DialogueLines.Length; i++)
        {
            if (DialogueLines[i].Length != 0 && DialogueLines[i][0] == '^')
            {
                currentName = DialogueLines[i].Substring(1);
                lib.Add(currentName, new List<string>());

            }
            else if (DialogueLines[i].Length != 0)
            {
                lib[currentName].Add(DialogueLines[i]);
            }
        }
    }
}
