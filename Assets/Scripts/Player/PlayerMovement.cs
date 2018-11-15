using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [HideInInspector] public Vector3 velocity = new Vector2();

    private Rigidbody2D rgb2;
	private InputManager im;
    private Vector2 gPos;

    [SerializeField] private float _moveSpeed = 0.2f;
    [SerializeField] private float _moveSpeedMax = 1;
    [SerializeField] private float _accel = 0;
    [SerializeField] private float _accelMax = 1;
    [SerializeField] private float _accelIncrease = 1f;
    [SerializeField] private float _friction = 0.5f;
    [SerializeField] private float _frictionFast = 0.8f;

	void Start()
	{
		Vector2 gPos = transform.position;
		rgb2 = GetComponent<Rigidbody2D>();
		im = GetComponent<InputManager>();
	}

	void Update()
	{
		Moving();
	}

	void Moving()
	{
		if (im.Up())
		{
			if (_accel <= _accelMax)
			{
                _accel += _accelIncrease;
			}
			velocity.y += _moveSpeed * _accel * Time.deltaTime;
			if (velocity.y > _moveSpeedMax)
				velocity.y = _moveSpeedMax;
		}
		else if (im.Down())
		{

			if (_accel <= _accelMax)
			{
                _accel += _accelIncrease;
			}

			velocity.y -= _moveSpeed * _accel * Time.deltaTime;
			if (velocity.y < -_moveSpeedMax)
				velocity.y = -_moveSpeedMax;
		}
		else
		{
			float frictionUpdated = _friction;
			if (im.Left() || im.Right()) frictionUpdated = _frictionFast;
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

		if (im.Right())
		{
			if (_accel <= _accelMax)
			{
                _accel += _accelIncrease;
			}

			velocity.x += _moveSpeed * _accel * Time.deltaTime;
			if (velocity.x > _moveSpeedMax)
				velocity.x = _moveSpeedMax;
		}
		else if (im.Left())
        {
			if (_accel <= _accelMax)
			{
                _accel += _accelIncrease;
			}

			velocity.x -= _moveSpeed * _accel * Time.deltaTime;
			if (velocity.x < -_moveSpeedMax)
				velocity.x = -_moveSpeedMax;
		}
		else
		{
			float frictionUpdated = _friction;
			if (im.Up() || im.Down()) frictionUpdated = _frictionFast;
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

		if (!im.Up() && !im.Down() && !im.Left() && !im.Right())
		{
            _accel = 0;
		}

		rgb2.velocity = Vector2.zero;
		rgb2.MovePosition(transform.position + velocity);
	}
}