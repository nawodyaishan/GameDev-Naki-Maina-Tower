using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public MainaSpawner mainaSpawner;
    [HideInInspector] public MainaScript currentMaina;

    public CameraFollow cameraScript;

    // Making Singleton Instance
    void Awake()
    {
        if (!instance)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
// Class