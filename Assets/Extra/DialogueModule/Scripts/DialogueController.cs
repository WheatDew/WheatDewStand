using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text textContent;
    public DialogueClipLib clipLib;
    public string currentClip;
    public int currentPointer;


    private void Start()
    {
        SetLibClip("测试对话");
    }



    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SetNextText();
        }
    }

    public void SetLibClip(string clipName)
    {
        currentClip = clipName;
        currentPointer = 0;
        textContent.text = clipLib.lib[clipName][currentPointer];
    }

    public void SetNextText()
    {
        if (currentClip != null)
        {
            currentPointer++;
            if (currentPointer < clipLib.lib[currentClip].Count)
                SetTextValue(clipLib.lib[currentClip][currentPointer]);
            else
                ;
        }
    }

    public void SetTextValue(string content)
    {
        textContent.text = content;
    }

}
