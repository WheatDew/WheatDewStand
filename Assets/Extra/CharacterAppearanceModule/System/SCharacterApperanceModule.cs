using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;

public class SCharacterApperanceModule : ComponentSystem
{

    public CharacterAppearanceDictionary appearanceDictionary;

    protected override void OnStartRunning()
    {
        
    }

    protected override void OnUpdate()
    {
        SetApperanceTextureJob();
        SetApperanceJob();
    }

    public void SetApperanceTextureJob()
    {
        Entities.ForEach((CCharacterAppearance characterAppearance, CCharacterBasicModule characterBasic) =>
        {
            if (characterAppearance.TextureSetFlag)
            {
                Texture4 texture4 = appearanceDictionary.TextureDictionary[characterBasic.Name];
                characterAppearance.east = texture4.east;
                characterAppearance.west = texture4.west;
                characterAppearance.south = texture4.south;
                characterAppearance.north = texture4.north;
                characterAppearance.TextureSetFlag = false;
            }
        });
    }

    public void SetApperanceJob()
    {
        Entities.ForEach((NavMeshAgent navMeshAgent, Transform transform,CCharacterAppearance characterAppearance,CCharacterBasicModule characterBasic) =>
        {
            switch (GetDirection(new Vector2(navMeshAgent.destination.x,navMeshAgent.destination.z),new Vector2(transform.position.x,transform.position.z) ))
            {
                case "east":
                    characterBasic.meshRenderer.material.mainTexture=characterAppearance.east;
                    break;
                case "west":
                    characterBasic.meshRenderer.material.mainTexture = characterAppearance.west;
                    break;
                case "north":
                    characterBasic.meshRenderer.material.mainTexture = characterAppearance.north;
                    break;
                case "south":
                    characterBasic.meshRenderer.material.mainTexture = characterAppearance.south;
                    break;
            }
        });
    }

    public string GetDirection(Vector2 target,Vector2 reference)
    {
        Vector2 direction = (target - reference).normalized;
        if (direction.x >= Mathf.Pow(2f, -1f / 2f))
            return "west";
        else if (direction.x <= -Mathf.Pow(2f, -1f / 2f))
            return "east";
        else if (direction.y >= Mathf.Pow(2f, -1f / 2f))
            return "north";
        else if (direction.y <= -Mathf.Pow(2f, -1f / 2f))
            return "south";
        return "";
    }
}
