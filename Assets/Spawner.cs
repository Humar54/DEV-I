using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _ySpawnRange = 3f;
    [SerializeField] private float _randomSpawnMaxDelay = 5f;
    [SerializeField] private GameObject _squarePrefab;

    private float _timer;
    private float _spawnDelay;


    // Update is called once per frame
    void Update()
    {
        //Incr�ment le timer avec le temps qui passe
        _timer += Time.deltaTime;

        if (_timer > _spawnDelay)
        {
            _timer = 0;
            //Trouve un d�lais d'instanciation au hazard
            _spawnDelay = Random.Range(0, _randomSpawnMaxDelay);
            //Trouve une position y au hazard (d�calage)
            float randomYPosition = Random.Range(-_ySpawnRange, _ySpawnRange);
            //Trouve la position du Spawner
            Vector3 SpawnerPosition = transform.position;
            //Instancie un objet � la position du spawner + la position de d�calage y d�termin�e au hazard
            GameObject newObject = Instantiate(_squarePrefab,new Vector3(SpawnerPosition.x, SpawnerPosition.y+ randomYPosition, SpawnerPosition.z),Quaternion.identity);
            //Va chercher le script GoRight de l'object qui vient juste d'�tre instanci� et appel la fonction InitializeVelocity;
            newObject.GetComponent<GoRight>().InitializeVelocity();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,new Vector3(0.5f,2*_ySpawnRange,0));
    }
}
