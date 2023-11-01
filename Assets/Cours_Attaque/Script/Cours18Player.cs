using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cours18Player : MonoBehaviour
{
    [SerializeField] private Cours18_Fireball _fireballPrefab;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _stopingDistance = 0.1f;
    [SerializeField] private float _attackCoolDown = 1.5f;
    [SerializeField] private int _damage = 5;

    private Camera _camera;
    private Cours18_Enemy _enemyTarget;
    private Vector3 _targetPosition;
    private float _attackTimer = float.MaxValue;
    private bool _attackIsActive;

    void Start()
    {
        _camera = Camera.main;
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

        CheckToSendFireball();


        if (_enemyTarget != null)
        {
            _targetPosition = _enemyTarget.transform.position;
        }
        float distance = (transform.position - _targetPosition).magnitude;
        if (distance > _stopingDistance)
        {
            Vector3 direction = (_targetPosition - transform.position).normalized;
            transform.position += direction * _movementSpeed * Time.deltaTime;
        }
        if (_attackIsActive && distance < _stopingDistance && _attackTimer >_attackCoolDown)
        {
            Attack();
        }
        _attackTimer += Time.deltaTime;
    }

    private void CheckToSendFireball()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray;
            RaycastHit hit;
            ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Cours18_Enemy enemy = hit.collider.GetComponent<Cours18_Enemy>();

                if (enemy != null)
                {
                    transform.LookAt(enemy.transform.position);
                    SendFireball(enemy.transform);
                }
            }
        }
    }

    private void SendFireball(Transform target)
    {
        Cours18_Fireball newFireball = Instantiate(_fireballPrefab,transform.position+new Vector3(0,1,0),Quaternion.identity);
        newFireball.SetTarget(target);
    }

    private void Attack()
    {
        _attackIsActive = false;
        _attackTimer = 0;
        _enemyTarget.ReceiveDamage(_damage);
    }
}
