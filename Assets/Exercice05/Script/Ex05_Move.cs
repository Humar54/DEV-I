using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex05_Move : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _direction = new Vector3(0, 0, 0);
    [SerializeField] private float _speed = 4f;
    [SerializeField] private KeyCode _up;
    [SerializeField] private KeyCode _down;
    [SerializeField] private KeyCode _left;
    [SerializeField] private KeyCode _right;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_up))
        {
            _direction.z = 1;
        }
        else if (Input.GetKey(_down))
        {
            _direction.z = -1;
        }
        else if (Input.GetKey(_right))
        {
            _direction.x = 1;
        }
        else if (Input.GetKey(_left))
        {
            _direction.x = -1;
        }
        else
        {
            _direction=Vector3.zero;
        }

        transform.position += _direction * _speed * Time.deltaTime;
    }
}

