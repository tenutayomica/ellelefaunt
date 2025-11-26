using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool tutorial1needed = true;

    void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "menu") Screen.lockCursor = false;
        else Screen.lockCursor = true;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Close()
    {
        Application.Quit();
    }
}
