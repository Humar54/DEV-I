using UnityEngine;

public class SonicWithRaycast : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rayYOffset = 1.35f;
    [SerializeField] private float _rayCastLength = 0.05f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;
    private bool _canJump;
    private float _idleTimer = 0;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

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
            if (_canJump)
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
        if(CheckIfGrounded())
        {
            _canJump = true;
            _animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!CheckIfGrounded())
        {
            _canJump = false;
            _animator.SetBool("isJumping", true);
        }
    }

    private bool CheckIfGrounded()
    {
        Vector2 origine = transform.position + new Vector3(0,-_rayYOffset,0);
        Vector2 direction = -transform.up;
        RaycastHit2D hit = Physics2D.Raycast(origine, direction, _rayCastLength, _layerMask);
        Debug.DrawRay(origine, direction * _rayCastLength, Color.red);
        if (hit.collider!=null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
