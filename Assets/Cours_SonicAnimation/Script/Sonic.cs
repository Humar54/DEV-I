

using UnityEngine;

public class Sonic : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    private Vector2 _velocity;

    private int _collisionCount;
    private float _idleTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _idleTimer += Time.deltaTime;
        _velocity = _rigidbody2D.velocity;
        if (Input.GetKey(KeyCode.D))
        {
            _velocity.x = _speed;
            _spriteRenderer.flipX = false;
            _idleTimer = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _velocity.x = -_speed;
            _spriteRenderer.flipX = true;
            _idleTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_collisionCount > 0)
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
                _idleTimer = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _velocity;
        float xVelocity = Mathf.Abs(_velocity.x);
        _animator.SetFloat("x_Speed", xVelocity);
        _animator.SetFloat("x_SpeedMultiplier", xVelocity/4f);
        _animator.SetFloat("idleTimer", _idleTimer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collisionCount++;
        _idleTimer = 0;
        if (_collisionCount > 0)
        {
            _animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _collisionCount--;
        if(_collisionCount <= 0 )
        {
            _animator.SetBool("isJumping", true);
        }
    }
}
