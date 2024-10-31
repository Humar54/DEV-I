
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private List<Parallax_Layer> _layers;
    [SerializeField] private Transform _objectToFollow;

    private Vector3 _movement;
    private Vector3 _previousPos;

    void Start()
    {
        //Instanciate 3 parallax layer for each layer with an offset on the x axis of  -size,0 size
        foreach (Parallax_Layer layer in _layers)
        {
            for (int i = -1; i <= 1; i++)
            {
                GameObject newLayer = Instantiate(layer.gameObject, i * layer.GetSize() * Vector3.right, Quaternion.identity, transform);
                
                newLayer.GetComponent<Parallax_Layer>().Init(_objectToFollow,this);
            }
        }
        
    }

    void Update()
    {
        //Find the change in position of the objectToFollow for the parallax
        _movement = _objectToFollow.position- _previousPos;
        _previousPos= _objectToFollow.position;
    }

    public float GetXAxisMovement()
    {
        return _movement.x;
    }
}
