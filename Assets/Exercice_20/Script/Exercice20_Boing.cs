using UnityEngine;

public class Exercice20_Boing : MonoBehaviour
{
    [SerializeField] private float _maxVolumeSpeed = 5f;

    private AudioSource _collisionSound;
    private Rigidbody _rigidbody;

    void Start()
    {
        _collisionSound =GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float ratio = _rigidbody.velocity.y / _maxVolumeSpeed;
        _collisionSound.volume=ratio*ratio;
        _collisionSound.Play();
    }
}
