using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SCharacterBasicModule : ComponentSystem
{
    public UCharacterStatus CharacterStatusUI;

    protected override void OnUpdate()
    {
        SelectionJob();
        HungerJob();
        UCharacterStatusUpdataJob();
    }

    public void SelectionJob()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit);
            if (raycastHit.collider!=null&&raycastHit.collider.tag == "Character")
            {
                Entities.ForEach((CCharacterBasicModule characterBasic) =>
                {
                    characterBasic.isSelected = false;
                    if (characterBasic == null)
                    {
                        Debug.Log("characterBasic is empty");
                    }
                    if (raycastHit.collider.transform.parent.gameObject == null)
                    {
                        Debug.Log("raycastHit.collider.transform.parent.gameObjec is empty");
                    }
                    if (characterBasic.gameObject == raycastHit.collider.transform.parent.gameObject)
                    {
                        characterBasic.isSelected = true;
                        CharacterStatusUI.Health.text = characterBasic.Health.ToString();
                        CharacterStatusUI.Hunger.text = characterBasic.Hunger.ToString();
                        CharacterStatusUI.gameObject.SetActive(true);
                    }
                });
            }
        }
    }

    public void HungerJob()
    {
        Entities.ForEach((CCharacterBasicModule basic) =>
        {
            basic.HungerTimer += Time.DeltaTime;
            if (basic.HungerTimer > basic.HungerDecreaseCycle)
            {
                basic.Hunger -= 1;
                basic.HungerTimer = 0;
            }
        });
    }

    public void UCharacterStatusUpdataJob()
    {
        Entities.ForEach((CCharacterBasicModule basic) =>
        {
            if (basic.isSelected)
            {
                CharacterStatusUI.Hunger.text = basic.Hunger.ToString();
                CharacterStatusUI.Health.text = basic.Health.ToString();
            }
        });
    }
}
