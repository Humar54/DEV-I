
using UnityEngine;

public class Parallax_Layer : MonoBehaviour
{
    [SerializeField] private float _size;
    [SerializeField] private float _speedFactor;

    private Transform _transformToFollow;
    private Parallax _parallax;

    public void Init(Transform transformToFollow, Parallax parallax)
    {
        _transformToFollow = transformToFollow;
        _parallax = parallax;
    }

    public void Update()
    {
        //Move the parallax layer with the object to follow
        //The parallax movement speed is equal to the object time the parallax speedFactor
        transform.position += -_parallax.GetXAxisMovement() * Vector3.right * _speedFactor;
        float xDistance = (_transformToFollow.position.x - transform.position.x);

        //If the distance of parallax is to great compare to the target object
        //move the Parallax layer foward or backward
        if (xDistance >= 2*_size)
        {
            transform.position += Vector3.right * 3 * _size;
        }
        if (xDistance <= -2 * _size)
        {
            transform.position -= Vector3.right * 3 * _size;
        }
    }

    public float GetSize()
    {
        return _size;
    }
}
