using System.Collections;
using UnityEngine;

public class Ex22_Spawn_Cube : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _delay = 10f;
    [SerializeField] private int _nb_Cube = 10;

    private GameObject _cube;
    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCube());
    }

    private IEnumerator SpawnCube()
    {
        yield return new WaitForSeconds(1+(float)1/_nb_Cube);
        _cube = Instantiate(_cubePrefab, new Vector3(0, 2, -(float)_index / _nb_Cube), Quaternion.identity);
        _cube.transform.localScale = Vector3.one * (1 - (float)_index / _nb_Cube);
        _cube.name = $"Cube {_index}";
        Material mat = _cube.GetComponent<MeshRenderer>().material;
        _cube.GetComponent<MeshRenderer>().material = mat;
        _cube.GetComponent<MeshRenderer>().material.color = new Color(1f - (float)_index / _nb_Cube, 0, 0);
        _index++;
        if (_index < _nb_Cube)
        {
            StartCoroutine(SpawnCube());
        }

    }

}
