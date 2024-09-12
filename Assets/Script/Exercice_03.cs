
using UnityEngine;

public class Exercice_03 : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yRange = 5f;

    private Vector3 _direction = new Vector3(0, 1, 0);


    void Update()
    {
        // if the position is greater then the Range in Y direct the cube downward
        if(transform.position.y >= _yRange)
        {
            _direction.y = -1;
        }
        // if the position is smaller then the Range in Y direct the cube downward
        if (transform.position.y <= -_yRange)
        {
            _direction.y = 1;
        }
        // increment the cube position every frame by the given speed 
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
