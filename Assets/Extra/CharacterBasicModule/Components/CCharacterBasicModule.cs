using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class CCharacterBasicModule : MonoBehaviour
{
    public string Name;
    public bool isSelected;
    public float Health=100, Hunger=100;
    public float HungerTimer=0;
    public float HungerDecreaseCycle=5;
    public MeshRenderer meshRenderer;
}
