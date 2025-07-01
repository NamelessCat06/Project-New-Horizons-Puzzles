using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomiser : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    public GameObject[] positions;
    public List<int> takeList = new List<int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        takeList = new List<int>(new int[positions.Length]);
        for (int i = 0; i < positions.Length; i++)
        {
            int randomNumber = UnityEngine.Random.Range(1, puzzlePieces.Length+1);
            while (takeList.Contains(randomNumber))
            {
                randomNumber = UnityEngine.Random.Range(1, puzzlePieces.Length+1);
            }

            if (positions[i].transform.childCount == 0)
            {
                Instantiate(puzzlePieces[randomNumber - 1], positions[i].transform);
            }
            takeList[i] = randomNumber;
        }
    }
    
    
            
}
