using System.Collections;
using UnityEngine;

public class Random_Generator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _maxRandomdelay;

    private void Start()
    {
        StartCoroutine(SpawnObjectCoroutine());
    }

    private IEnumerator SpawnObjectCoroutine()
    {
        float randomValue = Random.RandomRange(0, _maxRandomdelay);
        yield return new WaitForSeconds(randomValue);
        Instantiate(_prefab, transform.position, Quaternion.identity);
        StartCoroutine(SpawnObjectCoroutine());
    }
}
