using UnityEngine;
using UnityEngine.UI;

public class Ex11_Shield : MonoBehaviour
{
    [SerializeField] private Text _text;
    private int _value;

    private void Start()
    {
        _text.text = _value.ToString();
    }

    public void  IncreaseValue()
    {
        _value++;
        _text.text = _value.ToString();
    }
}
