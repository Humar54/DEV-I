using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice14 : MonoBehaviour
{
    [SerializeField] private List<Transform> _listTransform = new List<Transform>();
    [SerializeField] private Transform _movingObject;
    [SerializeField] private float _minDistance = 0.5f;
    [SerializeField] private float _speed = 5f;


    private Transform _currentTarget;
    private int _currentTargetIndex;

    private void Start()
    {
        _currentTarget = _listTransform[0];
    }

    private void Update()
    {
        if ((_currentTarget.position - _movingObject.position).magnitude < _minDistance)
        {
            _currentTargetIndex++;
            int count = _listTransform.Count;
            _currentTargetIndex = _currentTargetIndex % count;
            _currentTarget = _listTransform[_currentTargetIndex];
        }

        Vector3 direction = (_currentTarget.position - _movingObject.position).normalized;
        _movingObject.position += direction * _speed * Time.deltaTime;
    }

    public void RemoveRandomCircle()
    {
        int indexToRemove = Random.Range(0, _listTransform.Count);
        Destroy(_listTransform[indexToRemove].gameObject);
        _listTransform.RemoveAt(indexToRemove);
    }
}
