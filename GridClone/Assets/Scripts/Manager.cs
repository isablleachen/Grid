using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private Board board;
    private Gem gem;
    private GameObject NeighborGems;
    public GameObject player;
    private GameObject othergem;
    public Text RestartMessage;
    public int columns;
    public int rows;
    public int targetX;
    public int targetY;
    public int steps;
    public TextMeshPro step;

    public bool ismatched = false;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        gem = FindObjectOfType<Gem>();
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        RestartMessage.enabled = false;

        steps = 6;
    }

    // Update is called once per frame
    void Update()
    {
        columns = targetX;
        rows = targetY;

        step.text = steps.ToString();
        //player control for moving the gems
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.transform.position = new Vector2(targetX, targetY += 1); //player move
            steps -= 1; //number discount
            //up swipe
            NeighborGems = board.Allgems[columns, rows + 1];
            NeighborGems.GetComponent<Gem>().rows -= 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.transform.position = new Vector2(targetX, targetY -= 1);
            steps -= 1;
            //down swipe
            NeighborGems = board.Allgems[columns, rows - 1];
            NeighborGems.GetComponent<Gem>().rows += 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.transform.position = new Vector2(targetX -= 1, targetY);
            steps -= 1;
            //left swipe
            NeighborGems = board.Allgems[columns - 1, rows];
            NeighborGems.GetComponent<Gem>().columns += 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.transform.position = new Vector2(targetX += 1, targetY);
            steps -= 1;
            //right swipe
            NeighborGems = board.Allgems[columns + 1, rows];
            NeighborGems.GetComponent<Gem>().columns -= 1;
        }

        if (steps <= 0)
        {
            RestartMessage.enabled = true;
            Destroy(step);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        } //restart the scene
    }

}
