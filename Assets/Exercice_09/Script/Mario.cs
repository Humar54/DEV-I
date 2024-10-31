
using UnityEngine;

public class Mario : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _velocity;
    private int _collisionCount;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = _rigidbody2D.velocity;
        if(Input.GetKey(KeyCode.D))
        {
            _velocity.x = _speed;
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            _velocity.x = -_speed;
            _spriteRenderer.flipX = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(_collisionCount>0)
            {
                _velocity.y = _jumpSpeed;
                _rigidbody2D.velocity = _velocity;
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collisionCount++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _collisionCount--;
    }
}
