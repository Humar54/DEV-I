using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Cours18_Fireball : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private int _damage;
    [SerializeField] private Material _explosionMaterial;
    [SerializeField] private float _explosionDelay = 1.5f;
    [SerializeField] private float _fireballSpeed = 4f;
    [SerializeField] private GameObject _explosion;


    private Transform _target;
    private Rigidbody _rb;
    private bool _hasExploded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        if(!_hasExploded)
        {
            _rb.velocity = direction * _fireballSpeed;
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Cours18_Enemy>()!=null && !_hasExploded)
        {
            Explosion();
            _explosion.SetActive(true);
            Debug.Log("Explosion");
        }
    }

    private void Explosion()
    {
        transform.localScale = Vector3.one*_radius;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius/2f);
        foreach (Collider collider in hitColliders)
        {
            Cours18_Enemy enemy = collider.GetComponent<Cours18_Enemy>();
            if (enemy != null)
            {
                enemy.ReceiveDamage(_damage);
            }
        }
        _hasExploded = true;
        _rb.velocity =Vector3.zero;
        Destroy(gameObject, _explosionDelay);
    }
}
