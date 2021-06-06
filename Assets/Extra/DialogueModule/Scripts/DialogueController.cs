using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text textContent;
    public Text characterName;
    public Animator TextBox;
    public DialogueClipLib clipLib;
    public string currentClip;
    public int currentPointer;
    public Button[] Selections;


    private void Start()
    {
        clipLib.InitializationLib();
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
        if (clipLib.lib[currentClip][currentPointer].Length > 0)
        {
            if (clipLib.lib[currentClip][currentPointer][0] == '@')
            {
                characterName.text = clipLib.lib[currentClip][currentPointer].Substring(1);
                currentPointer++;
                textContent.text = clipLib.lib[currentClip][currentPointer];
            }
            else
                textContent.text = clipLib.lib[currentClip][currentPointer];
        }
        
    }

    public void SetNextText()
    {
        if (currentClip != null)
        {
            currentPointer++;
            if (currentPointer < clipLib.lib[currentClip].Count)
            {
                if (clipLib.lib[currentClip][currentPointer][0] == '@')
                {
                    characterName.text = clipLib.lib[currentClip][currentPointer].Substring(1);
                    SetNextText();
                }
                else if(clipLib.lib[currentClip][currentPointer][0] == '$')
                {
                    TextBox.SetTrigger("shake");
                    SetNextText();
                }
                else if (clipLib.lib[currentClip][currentPointer][0] == '#')
                {
                    string[] tempStr = clipLib.lib[currentClip][currentPointer].Split(' ');
                    SetSelection(tempStr[1],tempStr[2],tempStr[3]);
                    SetNextText();
                }
                else
                {
                    SetTextValue(clipLib.lib[currentClip][currentPointer]);
                }
                
            }
        }
    }

    public void SetTextValue(string content)
    {
        textContent.text = content;
    }

    //添加对话选项
    public void SetSelection(string number,string buttonText,string dialogueName)
    {
        int selectionID = int.Parse(number);
        Selections[selectionID].transform.GetChild(0).GetComponent<Text>().text = buttonText;
        Selections[selectionID].gameObject.SetActive(true);
        Selections[selectionID].onClick.AddListener(delegate
        {
            foreach (var item in Selections)
            {
                SetLibClip(dialogueName);
                item.gameObject.SetActive(false);
            }
        });
    }
}
