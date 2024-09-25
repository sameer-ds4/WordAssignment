using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BingoRow : MonoBehaviour
{
    public LetterBlock[] letterBlocks;
    public ScoreBlock scoreBlock;

    void Start()
    {
        
    }


    private void OnClick()
    {
        scoreBlock.button.onClick.AddListener(RowDef);
    }

    private void RowDef()
    {
        
    }
}


[Serializable]
public class LetterBlock
{
    public string letter;
    public TextMeshProUGUI letterDispay;
}

[Serializable]
public class ScoreBlock
{
    public int score;
    public TextMeshProUGUI scoreDisplay;
    public Button button;
}