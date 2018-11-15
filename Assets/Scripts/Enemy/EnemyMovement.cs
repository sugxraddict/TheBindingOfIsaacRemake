using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [HideInInspector] public enum eState     { walk, knockback, changingDirection }
    [HideInInspector] public enum eDirection { left, right, up, down }
    [HideInInspector] public eState state = eState.walk;
    [HideInInspector] public eDirection direction = eDirection.left;
    [HideInInspector] public Vector3 bulletDir = new Vector2();
    [HideInInspector] public Vector3 velocity = new Vector2();

    private Rigidbody2D _rgb2;
    private float _changeDirectionTimer;
    private float _knockbackForce;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveSpeedMax;
    [SerializeField] private float _accel;
    [SerializeField] private float _accelMax;
    [SerializeField] private float _accelIncrease;
    [SerializeField] private float _friction;
    [SerializeField] private float _frictionFast;
    [SerializeField] private float _changeDirectionTimeMin;
    [SerializeField] private float _changeDirectionTimeMax;
    [SerializeField] private float _knockbackForceDefault;
    [SerializeField] private float _knockbackForceDecrease;
    [SerializeField] private float _health;

    void Start () {
        _rgb2 = GetComponent<Rigidbody2D>();
        _changeDirectionTimer = randomDirectionTime();
        _knockbackForce = _knockbackForceDefault;
        randomDirection(true, true, true, true);
    }

    void Update()
    {
        // Check for direction change
        if (_changeDirectionTimer > 0)
        {
            _changeDirectionTimer--;
        }
        else
        {
            // Change direction
            if (state == eState.walk) state = eState.changingDirection;
            _changeDirectionTimer = randomDirectionTime();
        }

        StateMachine();
        Moving();
    }

    private void StateMachine()
    {
        // State Machine
        switch (state)
        {
            case eState.changingDirection:
                randomDirection(true, true, true, true);
                state = eState.walk;
                break;
            case eState.knockback:
                velocity.x = 0;
                velocity.y = 0;
                _rgb2.AddForce(bulletDir * _knockbackForce);
                _knockbackForce -= _knockbackForceDecrease;
                if (_knockbackForce <= 0)
                {
                    _knockbackForce = _knockbackForceDefault;
                    state = eState.walk;
                }
                break;
        }
    }

    private void Moving()
    {
        // MOVE UP:
        if (getDirectionVertical() == -1 && state == eState.walk)
        {
            if (_accel <= _accelMax)
            {
                _accel += _accelIncrease;
            }
            velocity.y += _moveSpeed * _accel * Time.deltaTime;
            if (velocity.y > _moveSpeedMax)
                velocity.y = _moveSpeedMax;
        }
        // MOVE DOWN:
        else if (getDirectionVertical() == 1 && state == eState.walk)
        {

            if (_accel <= _accelMax)
            {
                _accel += _accelIncrease;
            }

            velocity.y -= _moveSpeed * _accel * Time.deltaTime;
            if (velocity.y < -_moveSpeedMax)
                velocity.y = -_moveSpeedMax;
        }
        // NOT MOVING UP OR DOWN:
        else
        {
            float frictionUpdated = _friction;
            if (getDirectionHorizontal() == -1 || getDirectionHorizontal() == 1) frictionUpdated = _frictionFast;
            if (velocity.y > 0)
            {
                velocity.y -= frictionUpdated * Time.deltaTime;
                if (velocity.y < 0) velocity.y = 0;
            }
            else if (velocity.y < 0)
            {
                velocity.y += frictionUpdated * Time.deltaTime;
                if (velocity.y > 0) velocity.y = 0;
            }
        }

        // MOVE RIGHT:
        if (getDirectionHorizontal() == 1 && state == eState.walk)
        {
            if (_accel <= _accelMax)
            {
                _accel += _accelIncrease;
            }

            velocity.x += _moveSpeed * _accel * Time.deltaTime;
            if (velocity.x > _moveSpeedMax)
                velocity.x = _moveSpeedMax;
        }
        // MOVE LEFT:
        else if (getDirectionHorizontal() == -1 && state == eState.walk)
        {
            if (_accel <= _accelMax)
            {
                _accel += _accelIncrease;
            }

            velocity.x -= _moveSpeed * _accel * Time.deltaTime;
            if (velocity.x < -_moveSpeedMax)
                velocity.x = -_moveSpeedMax;
        }
        // NOT MOVING RIGHT OR LEFT
        else
        {
            float frictionUpdated = _friction;
            if (getDirectionVertical() == 1 || getDirectionVertical() == -1) frictionUpdated = _frictionFast;
            if (velocity.x > 0)
            {
                velocity.x -= frictionUpdated * Time.deltaTime;
                if (velocity.x < 0) velocity.x = 0;
            }
            else if (velocity.x < 0)
            {
                velocity.x += frictionUpdated * Time.deltaTime;
                if (velocity.x > 0) velocity.x = 0;
            }
        }

        // IF NOT PRESSING ANY MOVEMENT KEY:
        if (
            getDirectionVertical() != 1 &&
            getDirectionVertical() != -1 &&
            getDirectionHorizontal() != -1 &&
            getDirectionHorizontal() != 1
        )
        {
            _accel = 0;
        }

        // MOVEMENT
        _rgb2.velocity = Vector2.zero;
        _rgb2.MovePosition(transform.position + velocity);
    }

    private float getDirectionHorizontal()
    {
        switch (direction) {
            case eDirection.left: return -1f;
            case eDirection.right: return 1f;
        }

        return 0;
    }

    private float getDirectionVertical()
    {
        switch (direction)
        {
            case eDirection.up: return -1f;
            case eDirection.down: return 1f;
        }

        return 0;
    }

    private float randomDirectionTime()
    {
        return Random.Range(_changeDirectionTimeMin, _changeDirectionTimeMax) * Time.deltaTime;
    }

    private void randomDirection(bool leftBool, bool rightBool, bool upBool, bool downBool)
    {
        int randomDirectionNumber = -1;
        while (randomDirectionNumber == -1)
        {
            randomDirectionNumber = Random.Range(0, 4);
            if (!leftBool && randomDirectionNumber == 0) randomDirectionNumber = -1;
            if (!rightBool && randomDirectionNumber == 1) randomDirectionNumber = -1;
            if (!upBool && randomDirectionNumber == 2) randomDirectionNumber = -1;
            if (!downBool && randomDirectionNumber == 3) randomDirectionNumber = -1;
        }
        switch(randomDirectionNumber)
        {
            case 0: direction = eDirection.left; break;
            case 1: direction = eDirection.right; break;
            case 2: direction = eDirection.up; break;
            case 3: direction = eDirection.down; break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Rock")
        {
            _accel = 0;
            var leftBool = true;
            var rightBool = true;
            var upBool = true;
            var downBool = true;
            if (transform.position.x < col.gameObject.transform.position.x) rightBool = false;
            if (transform.position.x > col.gameObject.transform.position.x) leftBool = false;
            if (transform.position.y < col.gameObject.transform.position.x) downBool = false;
            if (transform.position.y > col.gameObject.transform.position.x) upBool = false;
            randomDirection(leftBool, rightBool, upBool, downBool);
        }
    }
}
