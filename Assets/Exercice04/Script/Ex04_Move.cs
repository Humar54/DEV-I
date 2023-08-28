using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex04_Move : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _direction = new Vector3(0, 0, 0);
    [SerializeField] private float _speed = 4f; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            _direction.z = 1;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            _direction.z =- 1;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            _direction.x = 1;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            _direction.x= - 1;
        }

        transform.position += _direction * _speed * Time.deltaTime;
    }
}
