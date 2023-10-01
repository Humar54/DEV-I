using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice14 : MonoBehaviour
{
    [SerializeField] private List<Transform> _listTransform = new List<Transform>();
    [SerializeField] private Transform _movingObject;
    [SerializeField] private int _indexToRemove;

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
        foreach (Transform t in _listTransform) 
        { 
            if((_currentTarget.position-_movingObject.position).magnitude < _minDistance)
            {
                _currentTargetIndex++;
                int count = _listTransform.Count;
                _currentTargetIndex = _currentTargetIndex%count;
                _currentTarget = _listTransform[_currentTargetIndex];
            }
        }
        Vector3 direction = (_currentTarget.position- _movingObject.position).normalized;
        _movingObject.position += direction * _speed * Time.deltaTime;

    }

    public void RemoveIndex()
    {
        if(_indexToRemove <_listTransform.Count && _listTransform.Count > 1)
        {
            Destroy(_listTransform[_indexToRemove].gameObject);
            _listTransform.RemoveAt(_indexToRemove);
            _currentTargetIndex = _currentTargetIndex % _listTransform.Count;
            _currentTarget = _listTransform[_currentTargetIndex];   
        }
    }
}
