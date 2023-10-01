
using System.Collections.Generic;
using UnityEngine;

public class Ex13_Get_Closest_Point : MonoBehaviour
{
    [SerializeField] private Transform _reference;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _nbToInstantiate;
    [SerializeField] private float _range;

    private List<GameObject> _gameObjects = new List<GameObject>();
    private GameObject _closestObject;

    private void Start()
    {
        //instantiate all circle while adding them to the list
        for (int i = 0; i < _nbToInstantiate; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-_range, _range), Random.Range(-_range, _range), 0);
            GameObject newGameObject = Instantiate(_prefab, randomPos, Quaternion.identity);
            newGameObject.transform.SetParent(transform);
            _gameObjects.Add(newGameObject);
        }
    }

    private void Update()
    {
        //réinitialize the value of minDistance to Max.Value
        float minDistance =float.MaxValue;

        //Get the closest object by checking the mininmal distance for each object
        foreach (GameObject gameObject in _gameObjects)
        {
            float distance = (gameObject.transform.position - _reference.position).magnitude;
            if(distance < minDistance)
            {
                minDistance = distance;
                _closestObject =gameObject;
            }
            //Set all objects white
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        //turn the closest object red
        _closestObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
