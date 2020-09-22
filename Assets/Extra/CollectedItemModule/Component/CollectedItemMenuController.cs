using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedItemMenuController : MonoBehaviour
{
    public RectTransform rectTransform;
    public Transform itemParent;
    public CCollectedItemMenuItem collectedItemMenuItemPrefab;

    public void CreateItem(string buttonName,CCharacterCollectedAbility characterCollectedAbility,CCollectedItem collectedItem)
    {
        CCollectedItemMenuItem collectedItemMenuItem = Instantiate(collectedItemMenuItemPrefab, itemParent);
        collectedItemMenuItem.Initialization(buttonName, characterCollectedAbility, collectedItem);
    }

    private void OnEnable()
    {
        for(int i = 0; i < itemParent.childCount; i++)
        {
            Destroy(itemParent.GetChild(i).gameObject);
        }
    }
}
