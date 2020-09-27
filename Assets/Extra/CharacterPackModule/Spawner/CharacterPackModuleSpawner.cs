using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterPackModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject CharacterPackModuleUIGroupPrefab;
    [SerializeField]
    private GameObject CharacterPackModuleSpawnerExpansionPrefab;

    private void Start()
    {

        string studentNumberValue = "080121139";
        double frequency1 = Math.Pow(int.Parse(studentNumberValue.Substring(1, 1)), 7)
            + Math.Pow(int.Parse(studentNumberValue.Substring(2, 1)), 6) + Math.Pow(int.Parse(studentNumberValue.Substring(3, 1)), 5)
            + Math.Pow(int.Parse(studentNumberValue.Substring(4, 1)), 4) + Math.Pow(int.Parse(studentNumberValue.Substring(5, 1)), 3)
            + Math.Pow(int.Parse(studentNumberValue.Substring(6, 1)), 2) + Math.Pow(int.Parse(studentNumberValue.Substring(7, 1)), 1)
            + Math.Pow(int.Parse(studentNumberValue.Substring(8, 1)), 8) + 317;

        Debug.Log(frequency1);
        double frequency2 = frequency1 % 10;
        double frequency3 = frequency2 * 10 + 400;
        Debug.Log(frequency3);

        //targetValue = (int)frequency3;
        //Debug.Log(targetValue);

        GameObject characterPackModuleUIGroup = Instantiate(CharacterPackModuleUIGroupPrefab,FindObjectOfType<Canvas>().transform);
        GameObject characterPackModuleSpawnerExpansion = Instantiate(CharacterPackModuleSpawnerExpansionPrefab, transform);
    }
}
