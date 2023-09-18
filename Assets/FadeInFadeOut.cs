using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _fadeDelay = 3f;

    private float _timer;
    private bool _fadeIn;

    private void Start()
    {
        _timer = _fadeDelay;
    }
    public void FadeIn()
    {
        _timer = 0;
        _fadeIn = true;
    }

    public void FadeOut()
    {
        _timer = 0;
        _fadeIn = false;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < _fadeDelay) 
        { 
            if(_fadeIn ) 
            {
                _renderer.color = new Color(1f,1f,1f, _timer/ _fadeDelay);
            }
            else
            {
                _renderer.color = new Color(1f, 1f, 1f, 1f - _timer / _fadeDelay);
            }
        }
    }
}
