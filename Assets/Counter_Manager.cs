using UnityEngine;
using UnityEngine.UI;

public class Counter_Manager : MonoBehaviour
{
    public static Counter_Manager _instance;

    [SerializeField] private Text _text;

    private int _counter;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this ;
        }
        else if(_instance!=this)
        {
            Destroy(this) ;
        }
        DontDestroyOnLoad(this);
    }

    public void RemoveCounter()
    {
        _counter--;
        UpdateText();
    }

    public void AddCounter()
    {
        _counter++;
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _counter.ToString();
    }
}
