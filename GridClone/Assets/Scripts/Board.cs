using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[] gems;
    public GameObject gemPrefab;
    public GameObject[,] Allgems;
    public int rows; 
    public int columns; 

    // Start is called before the first frame update
    void Start()
    {
        Setboard();
    }

    public void Setboard()
    {
        for(int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                Vector2 tempPosition = new Vector2(c, r);
                GameObject backgroundTile = Instantiate(gemPrefab,tempPosition,Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "(" + c + "," + r + " ) ";
                int gemToUse = Random.Range(0, gems.Length);
                GameObject gem = Instantiate(gems[gemToUse], tempPosition, Quaternion.identity);
                gem.transform.parent = this.transform;
                gem.name = "(" + c + "," + r + " ) ";
            }

            //GameObject undergem = GameObject.Find("(2,3)");
            //Destroy(undergem);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
