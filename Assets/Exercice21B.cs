using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Exercice21B : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private float _speed =3f;
    [SerializeField] private float _stoppingDistance = 0.5f;
    [SerializeField] private TextMeshProUGUI _timerTxt;

    private Coroutine _timerCoroutine;
    private int _timer;

    
    void Start()
    {
        Vector2 direction =(_target.position - transform.position).normalized;  
        GetComponent<Rigidbody2D>().velocity = direction *_speed;
        StartCoroutine(AutoStopCoroutine());
        _timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    private bool CheckIfStopDistanceIsReached()
    {
        return ((_target.position - transform.position).magnitude <= _stoppingDistance);
    }


    private void Stop()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private IEnumerator AutoStopCoroutine()
    {
        yield return new WaitUntil(() => CheckIfStopDistanceIsReached());
        StopCoroutine(_timerCoroutine);
        Stop();
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _timer++;
            _timerTxt.text = _timer.ToString();
        }
    }

 
}
