using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public WinCondition winCondition;
    public float health;

    void Start()
    {
        winCondition = GameObject.Find("GameManager").GetComponent<WinCondition>();
    }

    public void Die()
    {
        winCondition.aliveEnemies--;
        Destroy(gameObject);
    }
}
