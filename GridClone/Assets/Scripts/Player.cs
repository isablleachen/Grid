using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Board board;
    public GameObject player;
    GameObject undergem;
    public int columns;
    public int rows;
    public int targetX;
    public int targetY;
    public int steps = 6;
    public TextMeshPro step;

    public bool ismatched = false;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        step.text = steps.ToString();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.transform.position = new Vector2(targetX, targetY += 1);
            steps -= 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.transform.position = new Vector2(targetX, targetY -= 1);
            steps -= 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.transform.position = new Vector2(targetX -= 1, targetY);
            steps -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.transform.position = new Vector2(targetX += 1, targetY);
            steps -= 1;
        }
    }

    public void CheckforMatches()
    {
        
    }
}
