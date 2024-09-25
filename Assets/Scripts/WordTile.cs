using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTile : MonoBehaviour
{
    // public BingoManager bingoManager;
    public string letter;
    public int points;
    private RectTransform originalLocation;


    void Start()
    {
        originalLocation = transform as RectTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        BingoManager.Instance.AddWord(letter, points, this.gameObject);
    }
}
