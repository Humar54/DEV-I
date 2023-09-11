
using UnityEngine;

public class GoRight : MonoBehaviour
{
    [SerializeField] private float _speed =5.0f;

    //Fonction appelée par le Spawner
    public void InitializeVelocity()
    {
        // lorsque la fonction est appelée
        // Cherche la composante RigidBody2D sur l'object possédant le script GoRight
        // accède à la velocité puis lui passe un vecteur vitesse allant vers la droite.
        GetComponent<Rigidbody2D>().velocity = Vector3.right * _speed;
        //Détruit l'object après 6 secondes
        Destroy(gameObject,6f);
    }

}
