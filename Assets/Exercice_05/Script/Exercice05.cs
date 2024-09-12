
using UnityEngine;

public class Exercice05 : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed = 1.0f;
    [SerializeField] private float _maxScale = 6.0f;

    private Vector3 _direction =new Vector3(0,1,0) ;

    void Update()
    {
        // If the scale is greater then the max scale direction to decrease
        if(transform.localScale.y > _maxScale)
        {
            _direction = new Vector3(0, -1, 0);
        }
        // If the scale is smaller then 0 set the scale direction to increase
        if(transform .localScale.y < 0)
        {
            _direction = new Vector3(0, 1, 0);
        }

        //Enlarge the scale in the given direction every second
        transform.localScale += _direction * _scaleSpeed * Time.deltaTime;
    }
}
