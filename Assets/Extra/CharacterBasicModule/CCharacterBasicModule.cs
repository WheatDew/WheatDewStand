using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class CCharacterBasicModule : MonoBehaviour
{
    public GameObject Prefab;

    void Start()
    {
        // Create entity prefab from the game object hierarchy once
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, settings);
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        // Efficiently instantiate a bunch of entities from the already converted entity prefab
        var instance = entityManager.Instantiate(prefab);

        // Place the instantiated entity in a grid with some noise
        var position = transform.TransformPoint(float3.zero);
        entityManager.SetComponentData(instance, new Translation { Value = position });

    }
}
