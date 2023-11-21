
using System.Collections.Generic;
using UnityEngine;

public class EX25_Random_generator : MonoBehaviour
{
    [SerializeField] private GameObject _blueSphere;
    [SerializeField] private GameObject _yellowSphere;
    [SerializeField] private GameObject _redSphere;

    private List<Vector3> _possiblePosition = new List<Vector3>();

    void Start()
    {
        foreach (Transform child in transform)
        {
            _possiblePosition.Add(child.position);
        }
        int randomBlueSphereIndex = Random.Range(0, _possiblePosition.Count);
        Instantiate(_blueSphere, _possiblePosition[randomBlueSphereIndex], Quaternion.identity,transform);
        _possiblePosition.RemoveAt(randomBlueSphereIndex);
        int randomYellowSphereIndex = Random.Range(0, _possiblePosition.Count);
        Instantiate(_yellowSphere, _possiblePosition[randomYellowSphereIndex], Quaternion.identity,transform);
        _possiblePosition.RemoveAt(randomYellowSphereIndex);
        foreach (Vector3 position in _possiblePosition)
        {
            Instantiate(_redSphere, position, Quaternion.identity,transform);
        }
    }
}
