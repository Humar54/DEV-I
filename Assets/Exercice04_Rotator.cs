
using UnityEngine;

public class Exercice04_Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed =4f;


    // Update is called once per frame
    void Update()
    {
        //  Rotate the object with this script by (_rotationSpeed) degrees per second by incrementing the rotation every frame
        transform.Rotate(new Vector3(0f,_rotationSpeed*Time.deltaTime,0f));
    }
}
