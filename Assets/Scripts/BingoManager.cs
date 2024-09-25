using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BingoManager : MonoBehaviour
{
    public static BingoManager Instance;
    public string wordFormed;
    public int totalScore;
    public Transform wordRack_Parent;
    public Transform bingoBoard_Parent;
    public List<BingoRow> bingoRows;
    public List<GameObject> spawnedBlocks;

    public Sprite pointButtonBlock;
    public Sprite normalButtonBlock;
    // private int blockIndex;

    private void Awake() 
    {
        Instance = this;
    }


    void Start()
    {
        
    }

    public void AddWord(string letter, int points, GameObject gameObject)
    {
        // Instantiate()
        gameObject.transform.parent = wordRack_Parent;
        wordFormed += letter;
        spawnedBlocks.Add(gameObject);
        UpdateBingoRows(letter, points);
        // blockIndex++;
    }

    private void UpdateBingoRows(string letter, int points)
    {
        for (int i = 0; i < bingoRows.Count; i++)
        {
            // bingoRows[i].letterBlocks[blockIndex].letter = letter;
            // bingoRows[i].letterBlocks[blockIndex].letterDispay.text = bingoRows[i].letterBlocks[blockIndex].letter;

            // bingoRows[i].scoreBlock.score += points;
            // bingoRows[i].scoreBlock.scoreDisplay.text = bingoRows[i].scoreBlock.score.ToString();

            FillRow(i, points);
        }
    }

    // private void RemoveWord(string letter, int points)
    // {
        
    // }
    private void FillRow(int x, int points)
    {
        char[] chars = wordFormed.ToCharArray();
        // int points = 0;

        if(chars.Length > bingoRows[x].letterBlocks.Length)
        {
            for (int i = 0; i < bingoRows[x].letterBlocks.Length; i++)
            {
                bingoRows[x].letterBlocks[i].letter = "";
                bingoRows[x].letterBlocks[i].letterDispay.text = bingoRows[x].letterBlocks[i].letter;
                bingoRows[x].scoreBlock.button.image.sprite = normalButtonBlock;
            }
        }
        else
        {   
            for (int i = 0; i < chars.Length; i++)
            {
                bingoRows[x].letterBlocks[i].letter = chars[i].ToString();
                bingoRows[x].letterBlocks[i].letterDispay.text = bingoRows[x].letterBlocks[i].letter;

                bingoRows[x].scoreBlock.score += points;
                bingoRows[x].scoreBlock.scoreDisplay.text = bingoRows[x].scoreBlock.score.ToString();
                bingoRows[x].scoreBlock.button.image.sprite = pointButtonBlock;
                Tweening.TweenIn(bingoRows[x].scoreBlock.button.gameObject, 0.2f);
            }
        }
    }


    public void BingoDec(BingoRow i)
    {
        i.scoreBlock.button.interactable = false;
        // bingoRows[i].scoreBlock.button.image = 
        bingoRows.Remove(i);
    }

    public void TransferToBingo(int i)
    {
        foreach (var item in spawnedBlocks)
        {
            item.transform.parent = bingoBoard_Parent;
        }
    }

    // IEnumerator LoopAnimate()
    // {

    // }
}