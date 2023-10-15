
using UnityEngine;
using UnityEngine.UI;

public class Exercice_19_FadeIn_Out : MonoBehaviour
{

    [SerializeField] private Image _image;
    private float _fadeTime;
    private float _delay;

    void Start()
    {
        
        _fadeTime = float.MaxValue;
        Exercice_19.OnChangeScene += FadeInFadeOut;
        DontDestroyOnLoad(transform.parent.gameObject);
    }
    private void Update()
    {
        _fadeTime += Time.deltaTime;

        if( _fadeTime < _delay )
        {
            _image.color = new Color(0,0,0,_fadeTime/_delay);
        }
        else
        {
           float value =1- (_fadeTime - _delay) / _delay;
            if(value<0)
            {
                value = 0;
            }
            _image.color = new Color(0, 0, 0, value);
        }

    }

    private void FadeInFadeOut(float delay)
    {
        _fadeTime = 0;
        _delay = delay;
    }

    private void OnDestroy()
    {
        Exercice_19.OnChangeScene -= FadeInFadeOut;
    }

}
