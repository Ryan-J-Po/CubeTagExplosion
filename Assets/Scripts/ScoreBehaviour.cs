using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{
    public TagBehaviour Player;
    public Text ScoreText;
    private string _startText;

    // Start is called before the first frame update
    void Start()
    {
        _startText = ScoreText.text;   
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = _startText + " " + (int)Player.Score;   
    }
}
