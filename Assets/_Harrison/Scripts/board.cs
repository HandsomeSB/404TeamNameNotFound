using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public GameObject prefabRed, prefabBlack;

    public GameObject[][] boardtiles;

    int height = 8, width = 8;

    public void GenerateBoard(){
      boardtiles = new GameObject[height][];
      for(int row = 0; row < height; row++){
        boardtiles[row] = new GameObject[width];
        for(int col = 0; col < width; col++){
          GameObject srcTile = ((col + row) % 2 == 0) ? prefabRed : prefabBlack;

        }



      }
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
