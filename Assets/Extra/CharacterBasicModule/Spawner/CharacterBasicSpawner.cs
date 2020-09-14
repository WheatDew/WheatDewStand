using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class CharacterBasicSpawner : MonoBehaviour
{
    public GameObject characterPrefabOrigin;


    void Start()
    {
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(characterPrefabOrigin, settings);
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;


        var instance = entityManager.Instantiate(prefab);

        entityManager.SetComponentData(instance, new Translation { Value = Vector3.zero });

    }
}
