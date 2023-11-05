using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cours18_Enemy : MonoBehaviour
{

    [SerializeField] private int _life;

    public void ReceiveDamage(int damage)
    {
        _life -= damage;
        Debug.Log($"Name:{gameObject.name} Life:{_life} damage received: {damage}");
    }

}
