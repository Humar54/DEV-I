using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice03 : MonoBehaviour
{

    [SerializeField] private float _scaleSpeed = 1.0f;
    [SerializeField] private float _maxScale = 6.0f;

    private Vector3 _direction =new Vector3(0,1,0) ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.y > _maxScale)
        {
            _direction = new Vector3(0, -1, 0);
        }
        if(transform .localScale.y < 0)
        {
            _direction = new Vector3(0, 1, 0);
        }

        transform.localScale += _direction * _scaleSpeed * Time.deltaTime;
    }
}
