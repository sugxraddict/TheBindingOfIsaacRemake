using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int playerLives = 3;
    private float _invincibleTime = 3f;
    public float initialTime = 3f;
    public GameObject heartSprite;



    // Update is called once per frame
    void Update()
    {
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("LoseScreen", LoadSceneMode.Single);
        }
        _invincibleTime -= Time.deltaTime;
        //Debug.Log(playerLives);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
      
        if (_invincibleTime <= 0)
            {
                playerLives--;
                _invincibleTime = initialTime;
            }


    }
}
