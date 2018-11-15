using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

    public GameObject bullet;
    private Vector3 bulletPos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            bulletPos = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
            Destroy(other.gameObject);
            Instantiate(bullet, bulletPos, Quaternion.identity);
        }
    }
}
