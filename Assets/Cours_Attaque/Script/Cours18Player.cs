using UnityEngine;

public class Cours18Player : MonoBehaviour
{

    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _stopingDistance = 0.1f;
    [SerializeField] private float _attackCoolDown = 1.5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _damage = 5;

    private Camera _camera;
    private Cours18_Enemy _enemyTarget;
    private Vector3 _targetPosition;
    private float _attackTimer = float.MaxValue;
    private bool _attackIsActive;
    private Rigidbody _rigidbody;

    void Start()
    {
        _camera = Camera.main;
        _rigidbody =GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray;
            RaycastHit hit;
            ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Cours18_Enemy enemy = hit.collider.GetComponent<Cours18_Enemy>();

                if (enemy != null)
                {
                    _enemyTarget = enemy;
                    _attackIsActive = true;
                    transform.LookAt(_enemyTarget.transform.position);
                }
                else
                {
                    _enemyTarget = null;
                    _targetPosition = hit.point;
                    transform.LookAt(_targetPosition);
                }
            }
        }

        if (_enemyTarget != null)
        {
            _targetPosition = _enemyTarget.transform.position;
        }
        float distance = (transform.position - _targetPosition).magnitude;
        Vector3 direction = (_targetPosition - transform.position).normalized;

        if (distance > _stopingDistance)
        {
            _rigidbody.velocity = direction * _movementSpeed;
            _animator.SetFloat("_speed",1f);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
            _animator.SetFloat("_speed",0f);
        }

        if (_attackIsActive && distance < _stopingDistance && _attackTimer >_attackCoolDown)
        {
            Attack();
        }
        _attackTimer += Time.deltaTime;
    }


    private void Attack()
    {
        _animator.SetTrigger("_attack");
        _attackIsActive = false;
        _attackTimer = 0;
        _enemyTarget.ReceiveDamage(_damage);
    }
}
