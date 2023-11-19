using UnityEngine;

public class Ex23_SpawnedObject : MonoBehaviour
{
    [SerializeField] private float _speed=3f;
    [SerializeField] private float _maxSelfDestroyDelay = 10f;
    private Rigidbody _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        float x =Random.Range(-1f, 1f);
        float y =Random.Range(0f,1f);
        float randomDestroyDelay = Random.Range(0f, _maxSelfDestroyDelay);
        _rb.velocity = new Vector3(x,y,0).normalized*_speed;
        Material mat = _rb.GetComponent<MeshRenderer>().material;
        _rb.GetComponent<MeshRenderer>().material = mat;
        mat.color = Random.ColorHSV(0, 1);
        Counter_Manager._instance.AddCounter();
        Destroy(gameObject, randomDestroyDelay);
    }

    private void OnDestroy()
    {
        Counter_Manager._instance.RemoveCounter();
    }


}
