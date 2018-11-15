using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour {

    private GameObject[] _enemies;
    public int aliveEnemies;

    void Start()
    {
        if (_enemies == null)
            _enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i=0; i< _enemies.Length; i++)
        {
            aliveEnemies++;
        }
    }
    // Update is called once per frame
    void Update () {
        if (aliveEnemies <= 0)
        {
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
        }
    }
}
