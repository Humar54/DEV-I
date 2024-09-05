
using UnityEngine;

public class Empty : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, _rotationSpeed * Time.deltaTime, 0f));
    }
}
