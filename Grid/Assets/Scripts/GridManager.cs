using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    int[,] _gems = new int[Cols, Rows];
    const int Rows = 3;
    const int Cols = 5;

    public GameObject _gemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < Cols; x++)
        {
            for (int y = 0; y < Rows; y++)
            {
                int color = Random.Range(0, 9);
                _gems[x, y] = color;
            }
        } //using double loop, check the coordinate of the gem and then pick a color for it

        InstantiateGems();
    }

    void InstantiateGems()
    {
        for (int x = 0; x < Cols; x++)
        {
            for (int y = 0; y < Rows; y++)
            {
                Debug.Log("Gems" + x + "," + y + ":" + _gems[x, y]);
                GameObject gem = GameObject.Instantiate(_gemPrefab);
                gem.transform.position = new Vector3(x*1, y*1, 0);
                //gem.GetComponent<NameofScript>().SetColor(_gems[x,y]);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
