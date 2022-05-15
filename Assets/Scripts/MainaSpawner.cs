using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainaSpawner : MonoBehaviour
{
    public GameObject MainaPrefab;

    public void SpawnBox()
    {
        GameObject mainaObject = Instantiate(MainaPrefab);
        mainaObject.transform.position = transform.position;
    }

} // Class
