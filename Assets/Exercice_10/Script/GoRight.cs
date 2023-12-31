
using UnityEngine;

public class GoRight : MonoBehaviour
{
    [SerializeField] private float _speed =5.0f;

    //Fonction appel�e par le Spawner
    public void InitializeVelocity()
    {
        // lorsque la fonction est appel�e
        // Cherche la composante RigidBody2D sur l'object poss�dant le script GoRight
        // acc�de � la velocit� puis lui passe un vecteur vitesse allant vers la droite.
        GetComponent<Rigidbody2D>().velocity = Vector3.right * _speed;
        //D�truit l'object apr�s 6 secondes
        Destroy(gameObject,6f);
    }

}
