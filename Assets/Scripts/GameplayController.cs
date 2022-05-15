using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public MainaSpawner mainaSpawner;
    [HideInInspector] public MainaScript currentMaina;

    public CameraFollow cameraScript;
    private int moveCount;


    // Making Singleton Instance
    void Awake()
    {
        if (!instance)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainaSpawner.SpawnMaina();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentMaina.DropMaina();
        }
    }

    public void spawnNewMaina()
    {
        Invoke("NewMaina", 2f);
    }

    void NewMaina()
    {
        mainaSpawner.SpawnMaina();
    }

    public void moveCamera()
    {
        moveCount++;
        if (moveCount == 3)

        {
            moveCount = 0;
            cameraScript.targetPos.y += 2f;
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
// Class