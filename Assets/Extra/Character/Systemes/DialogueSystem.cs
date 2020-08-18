using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class DialogueSystem : ComponentSystem
{
    private DialogueBox m_dialogueBox;

    protected override void OnStartRunning()
    {
        //初始化DialogueBox
        Entities.ForEach((DialogueBox dialogueBox) =>
        {
            m_dialogueBox = dialogueBox;
            dialogueBox.DisplayContent = dialogueBox.transform.GetComponent<UnityEngine.UI.Text>();
            m_dialogueBox.isDisplay = false;
            m_dialogueBox.Content = "";
            Debug.Log("DialogueSystem.m_dialogueBox Initialization successfully");
        });
    }

    protected override void OnUpdate()
    {
        ClickCharacterJob();
        UpdataDialogueBoxJob();
    }

    private void ClickCharacterJob()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CharacterControllerStatus selfStatus=null;

            Entities.ForEach((CharacterControllerStatus status) =>
            {
                if (status.isConscriptSelected)
                {
                    RaycastHit hit;

                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                        if (hit.collider.tag == "Character")
                        {
                            selfStatus = status;
                            status.CharacterDialogueWith = hit.collider.transform;
                        }
                }
            });

            if (selfStatus&&Vector3.Distance(selfStatus.transform.position, selfStatus.CharacterDialogueWith.position) < 3)
            {
                m_dialogueBox.isDisplay = true;
                Entities.ForEach((CharacterControllerStatus targetStatus) => {
                    if (selfStatus.CharacterDialogueWith == targetStatus.transform)
                        m_dialogueBox.Content = targetStatus.ContentDialogueWith;
                });
            }
        }

        Entities.ForEach((CharacterControllerStatus status) =>
        {
            if(status.CharacterDialogueWith&&Vector3.Distance(status.transform.position,status.CharacterDialogueWith.position)>5)
            {
                m_dialogueBox.isDisplay = false;
                m_dialogueBox.Content = "";
                status.CharacterDialogueWith = null;
            }
        });
    }

    private void UpdataDialogueBoxJob()
    {
        //控制显示和隐藏
        m_dialogueBox.transform.localScale = (m_dialogueBox.isDisplay) ? Vector3.one : Vector3.zero;

        //控制内容
        m_dialogueBox.DisplayContent.text = m_dialogueBox.Content;

    }
}
