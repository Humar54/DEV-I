using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text _indexTxt;
    [SerializeField] private Text _scoreTxt;

    public void SetScoreAndIndex(int score,int index)
    {
        _scoreTxt.text = score.ToString();
        _indexTxt.text = index.ToString();
    }
}
