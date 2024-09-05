
using UnityEngine;

public class Exercice04_Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed =4f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,_rotationSpeed*Time.deltaTime,0f));
    }
}
