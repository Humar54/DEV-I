using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex05_Move : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Vector3 _direction = new Vector3(0, 0, 0);


    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _direction.x = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _direction.x = -1;
        }
        else
        {
            _direction = Vector3.zero;
        }

        transform.position += _direction * _speed * Time.deltaTime;
    }
}

