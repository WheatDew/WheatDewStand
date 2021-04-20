using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private BasicBuiding basicBuidingPrefab;

    [SerializeField]
    private CBuildingMenu buildingMenuPrefab;
    [System.NonSerialized]
    public CBuildingMenu buildingMenu;

    [SerializeField]
    private BluePrintButton BluePrintButtonPrefab;
    [System.NonSerialized]
    public BluePrintButton bluePrintButton;

    private void Start()
    {
        BlueMainButtonInitialized();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OpenBuildingMenu();
        }
        
    }

    public void BlueMainButtonInitialized()
    {
        bluePrintButton = Instantiate(BluePrintButtonPrefab,FindObjectOfType<Canvas>().transform);
    }

    public void DisplayBluePrint()
    {

    }

    public void OpenBuildingMenu()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo);
        if (hitInfo.point != Vector3.zero&&hitInfo.collider.tag=="Building")
        {
            Debug.Log("点击");
            if(buildingMenu==null)
            buildingMenu = Instantiate(buildingMenuPrefab, FindObjectOfType<Canvas>().transform);
            buildingMenu.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    public void CloseBuildingMenu()
    {
        if(buildingMenu!=null)
        Destroy(buildingMenu.gameObject);
    }

    public void AddBuiding()
    {
        BasicBuiding basicBuiding = Instantiate(basicBuidingPrefab);
    }
}
