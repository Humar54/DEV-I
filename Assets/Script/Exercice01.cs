using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice01 : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yRange = 5f;

    private Vector3 _direction = new Vector3(0, 1, 0);


    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= _yRange)
        {
            _direction.y = -1;
        }

        if(transform.position.y <= -_yRange)
        {
            _direction.y = 1;
        }

        transform.position += _direction * _speed * Time.deltaTime;
    }
}
