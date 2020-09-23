using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPackMenuController : MonoBehaviour
{
    public RectTransform rectTransform;
    public Transform itemParent;
    public CharacterPackMenuItem characterPackMenuItemPrefab;

    public void CreateItem(string buttonName)
    {
        CharacterPackMenuItem collectedItemMenuItem = Instantiate(characterPackMenuItemPrefab, itemParent);
        collectedItemMenuItem.Initialization(buttonName);
    }

    private void OnEnable()
    {
        for(int i = 0; i < itemParent.childCount; i++)
        {
            Destroy(itemParent.GetChild(i).gameObject);
        }
    }
}
