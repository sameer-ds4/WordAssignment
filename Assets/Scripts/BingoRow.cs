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
        // scoreBlock.button.onClick.AddListener(RowDef());
    }

    public void RowDef(int i)
    {
        BingoManager.Instance.TransferToBingo(this);
        // BingoManager.Instance.BingoDec(this);
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