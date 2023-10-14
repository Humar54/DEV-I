
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _currentScoreTxt;
    [SerializeField] private Text _scoreIndexTxt;
    [SerializeField] private List<ScoreText> _scoreTextList;

    private List<Score> _scoreList =new List<Score>();
    private int _scoreIndex;
    private int _score;

    [SerializeField] private string _playerPrefScoreName = "Score";
    [SerializeField] private string _playerPrefIndexName = "Index";
    [SerializeField] private string _playerPrefCounter = "Counter";


    private void Start()
    {
        Load();
    }
    public void NewScore()
    {
        _scoreIndex++;
        _score = Random.Range(0, 1000);
        _scoreList.Add(new Score(_scoreIndex, _score));


        OrderList();
        UpdateVisual();
        Save();
    }

    private void OrderList()
    {
        _scoreList = _scoreList.OrderByDescending(x => x._score).ToList();
        if (_scoreList.Count > _scoreTextList.Count)
        {
            _scoreList.Remove(_scoreList.Last());
        }
    }

    private void Save()
    {
        for (int i = 0; i < _scoreList.Count; i++)
        {
            PlayerPrefs.SetInt(_playerPrefScoreName + i, _scoreList[i]._score);
            PlayerPrefs.SetInt(_playerPrefIndexName + i, _scoreList[i]._index);
            PlayerPrefs.SetInt(_playerPrefCounter,_scoreIndex);
        }
        PlayerPrefs.Save();
    }

    private void Load()
    {
        for (int i = 0; i < _scoreTextList.Count; i++)
        {
            int index = PlayerPrefs.GetInt(_playerPrefIndexName + i);
            int score = PlayerPrefs.GetInt(_playerPrefScoreName + i);
            _scoreList.Add(new Score(index,score));
        }
        _scoreIndex= PlayerPrefs.GetInt(_playerPrefCounter);
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        _currentScoreTxt.text = _score.ToString();
        _scoreIndexTxt.text = _scoreIndex.ToString();
        int index = 0;
        for (int i = 0; i < _scoreList.Count; i++)
        {
            _scoreTextList[i].SetScoreAndIndex(_scoreList[i]._score, _scoreList[i]._index);
        }
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        _scoreList.Clear();
        foreach (ScoreText score in _scoreTextList)
        {
            score.SetScoreAndIndex(0,0);
        }
        _score = 0;
        _scoreIndex = 0;
        UpdateVisual();
    }


}

public class Score
{
    public int _index;
    public int _score;

    public Score(int index, int score)
    {
        _index = index;
        _score = score;
    }   
}
