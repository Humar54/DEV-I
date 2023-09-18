using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex12_distance : MonoBehaviour
{
    [SerializeField] private Transform _A;
    [SerializeField] private float _speed =5f;

    private Rigidbody2D _aRigidBody;

    void Start()
    {
        _aRigidBody = _A.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Trouve la direction  A->B avec le Vecteur (position B - position A) normalisé
        Vector3 direction = (transform.position - _A.position).normalized;
        // applique une vitesse au rigidBody de l'objet _A. Le vecteur vitesse résultant est un vecteur allant dans la direction A->B avec une taille de "_speed"
        _aRigidBody.velocity = direction * _speed;
        //Debug.Log(direction.magnitude + "[m/s]");
        Debug.Log(_aRigidBody.velocity.magnitude + "[m/s]");

        //Si la distance entre A et B est plus petite que 5 [m], rend le Sprite Renderer vert et a l'inverse  rend le SpriteRenderer rouge si la distance est plus grande que 5 [m].
        if ((_A.position - transform.position).magnitude < 5f)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
