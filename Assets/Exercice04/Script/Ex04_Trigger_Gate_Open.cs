using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex04_Trigger_Gate_Open : MonoBehaviour
{

    [SerializeField] GameObject _gate;

    private void OnTriggerEnter(Collider other)
    {
        _gate.transform.localScale = Vector3.zero;
    }
}
