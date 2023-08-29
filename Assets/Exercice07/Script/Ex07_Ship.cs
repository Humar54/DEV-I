using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex07_Ship : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed = 30f;
    [SerializeField] private float _maxSpeed = 3f;
    [SerializeField] private float _acceleration = 1f;
    
    private float _speed = 0f;

    private Rigidbody2D _rigidbody;
   


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, _rotationSpeed) * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-new Vector3(0,0, _rotationSpeed) * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.W)) 
        {
            _speed += _acceleration*Time.deltaTime;
            if(_speed > _maxSpeed )
            {
                _speed = _maxSpeed;
            }
        }

        if( Input.GetKey(KeyCode.S))
        {
            _speed -= _acceleration * Time.deltaTime;
            if( _speed < 0 )
            {
                _speed = 0;
            }
        }
        _rigidbody.velocity = transform.up * _speed;
    }
}
