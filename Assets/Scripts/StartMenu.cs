using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Start Level is" + SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
