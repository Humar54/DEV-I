
using UnityEngine;

public class Exercice06TriggerGateOpen : MonoBehaviour
{
    [SerializeField] GameObject _gate;

    private void OnTriggerEnter(Collider other)
    {
        _gate.SetActive(false);

    }
}
