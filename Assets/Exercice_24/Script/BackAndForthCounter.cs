using UnityEngine;
using UnityEngine.UI;

public class BackAndForthCounter : MonoBehaviour
{
    [SerializeField] private Text _text;

    private int _counter;

    public void  IncreaseCounter()
    {
        _counter += 1;
        _text.text = _counter.ToString();
    }
}
