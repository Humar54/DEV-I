using System.Collections;
using UnityEngine;

public class Exercice21_ChangeColor : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

   
    private IEnumerator MyCoroutine()
    {
        yield return new WaitUntil(() => (transform.position.y < -2f));
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
