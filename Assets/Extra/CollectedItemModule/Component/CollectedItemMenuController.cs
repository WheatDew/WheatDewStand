using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedItemMenuController : MonoBehaviour
{
    public RectTransform rectTransform;
    public Transform itemParent;
    public CCollectedItem collectedItemPrefab;

    public void CreateItemParent()
    {
        CCollectedItem collectedItem = Instantiate(collectedItemPrefab, itemParent);
    }
}
