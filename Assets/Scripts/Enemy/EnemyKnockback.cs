using UnityEngine;

public class EnemyKnockback : MonoBehaviour {

    private EnemyMovement _em;
    private EnemyHealth _eh;

    private void Start()
    {
        _em = gameObject.GetComponent<EnemyMovement>();
        _eh = gameObject.GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            _em.state = EnemyMovement.eState.knockback;
            _em.bulletDir = transform.position - col.transform.position;
            _eh.health--;
            Destroy(col.gameObject);
            if (_eh.health <= 0) _eh.Die();
        }
    }
}
