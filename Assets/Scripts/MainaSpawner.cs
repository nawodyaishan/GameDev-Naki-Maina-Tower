using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainaSpawner : MonoBehaviour
{
    [SerializeField] GameObject mainaPrefab;

    public void SpawnMaina()
    {
        GameObject mainaObject = Instantiate(mainaPrefab);

        Vector3 temp = transform.position;
        temp.z = 10f;

        mainaObject.transform.position = temp;
    }
} // Class 