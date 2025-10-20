
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exercice_19 : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private float _delay = 2f;

  



    public void ChangeScene()
    {
   
        Invoke("LoadScene", _delay);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
        DontDestroyOnLoad(gameObject);
    }
}
