using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex04_Move : MonoBehaviour
{
    [SerializeField] private float _speed = 4f; 

    private Vector3 _direction = new Vector3(0, 0, 0);


    void Update()
    {
        float x_direction = 0;
        float z_direction = 0;
        
        if(Input.GetKey(KeyCode.W))
        {
            z_direction = 1;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            z_direction = - 1;
        }
        else
        {
            z_direction = 0;
        }

        if(Input.GetKey(KeyCode.D))
        {
            x_direction = 1;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            x_direction = - 1;
        }
        else
        {
            x_direction = 0;
        }

        _direction =new Vector3(x_direction ,0, z_direction).normalized;
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
