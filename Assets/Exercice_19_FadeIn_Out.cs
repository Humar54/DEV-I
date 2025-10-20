
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exercice_19_FadeIn_Out : MonoBehaviour
{
    [SerializeField] private Button _btn;
    [SerializeField] private Image _image;
    [SerializeField] private float _delay =2f;

    private int _sceneIndex=1;
    private float _fadeTime;
    private float _changeSceneTimer =-1f;
    

    void Start()
    {
        _btn.onClick.AddListener(FadeInFadeOut);
        _fadeTime = float.MaxValue;
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

        if(_changeSceneTimer > _delay)
        {
            _sceneIndex++;
            SceneManager.LoadScene(_sceneIndex);
            _changeSceneTimer = -1f;
        }

        if(_changeSceneTimer >= 0)
        {
            _changeSceneTimer += Time.deltaTime;
        }
    }

    private void FadeInFadeOut()
    {
        _fadeTime = 0;
        _changeSceneTimer = 0f;
    }

    private void OnDestroy()
    {
        _btn.onClick.RemoveListener(FadeInFadeOut);
    }
}
