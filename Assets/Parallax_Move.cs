using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Move : MonoBehaviour
{

    [SerializeField] private float _speed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }
}
