using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WordPanel : MonoBehaviour
{
    public RectTransform[] spawnLocations;
    public BingoManager bingoManager;

    public WordTile[] wordTiles;
    private int spawnIndex;


    void Start()
    {
        StartCoroutine(SpawnTiles());
    }

    IEnumerator SpawnTiles()
    {
        yield return new WaitForSeconds(0.18f);
        WordTile tile = Instantiate(wordTiles[spawnIndex], spawnLocations[spawnIndex].position, Quaternion.identity,transform);
        // tile.bingoManager = bingoManager;
        spawnIndex++;

        if(spawnIndex < spawnLocations.Length)
            StartCoroutine(SpawnTiles());
    }
}
