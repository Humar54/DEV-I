
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed=20f;
    [SerializeField] private float _rayCastLength = 1000;
    [SerializeField] private LayerMask _layer ;
    
    void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        Vector3 origine = transform.position;
        Vector3 direction = transform.forward;
        Ray ray =new Ray(origine,direction);
        RaycastHit hit;

        

        if(Physics.Raycast(ray,out hit,_rayCastLength, _layer))
        {
            string name = hit.collider.gameObject.name;
            Debug.Log($"Name:{name} --- Hit Distance:{hit.distance} --- Hit Position:{hit.point} --- {name} position: {hit.collider.transform.position}");
            Debug.DrawRay(origine, direction * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(origine, direction * _rayCastLength, Color.red);
        }
        
    }
}
