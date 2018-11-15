using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
