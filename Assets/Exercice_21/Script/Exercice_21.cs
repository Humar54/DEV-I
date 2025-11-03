using System.Collections;

using UnityEngine;

public class Exercice_21 : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private bool _startCoroutine;
    [SerializeField] private float _spawnCubeDelay;
    private Coroutine _currentCoroutine;
 
    private IEnumerator MainCubeSpawingCoroutine()
    {
        yield return new WaitForSeconds(_spawnCubeDelay);
        Instantiate(_object, transform);
        _currentCoroutine=StartCoroutine(MainCubeSpawingCoroutine());
    }

    public void StartSpawning()
    {
        if (_currentCoroutine == null)
        {
            _currentCoroutine=StartCoroutine(MainCubeSpawingCoroutine());
        }

    }

    public void StopSpawning()
    {
        if( _currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
    }
}
