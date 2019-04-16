using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    public int columns;
    public int rows;
    public int TargetX;
    public int TargetY;
    private GameObject NeighborGems;
    private Board board;
    private ScoreScript scorescript;
    private Vector2 Position1;
    private Vector2 Position2;
    public Vector2 tempPosition;
    public float swipeAngle = 0;

    public bool Matched = false;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        scorescript = FindObjectOfType<ScoreScript>();
        TargetX = (int)transform.position.x;
        TargetY = (int)transform.position.y;
        rows = TargetY;
        columns = TargetX;
    }

    // Update is called once per frame
    void Update()
    {

        Matches(); //call match function
        //if (Matched)
        //{
            //SpriteRenderer GemSprite = GetComponent<SpriteRenderer>();
            //GemSprite.color = new Color(0f, 0f, 0f, 0.5f);
        //}
        TargetX = columns;
        TargetY = rows;
        if (Mathf.Abs(TargetX - transform.position.x) > .1)
        {
            tempPosition = new Vector2(TargetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, 0.5f);
        } else
        {
            tempPosition = new Vector2(TargetX, transform.position.y);
            transform.position = tempPosition;
            board.Allgems[columns, rows] = this.gameObject;
        }

        if (Mathf.Abs(TargetY - transform.position.y) > .1)
        {
            tempPosition = new Vector2(transform.position.x, TargetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, 0.5f);
        }
        else
        {
            tempPosition = new Vector2(transform.position.x, TargetY);
            transform.position = tempPosition;
            board.Allgems[columns, rows] = this.gameObject;
        }
    }

    public void OnMouseDown()
    {
        Position1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(Position1);

    }

    public void OnMouseUp()
    {
        Position2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(Position2);
        Calculate();
    }

    public void Calculate()
    {
        swipeAngle = Mathf.Atan2(Position2.y - Position1.y, Position2.x - Position1.x) * 180 / Mathf.PI;
        Debug.Log(swipeAngle);
        MovePieces();
    }

    public void MovePieces() //test for modification(move pieces by mouseclicked)
    {
        if (swipeAngle > -45 && swipeAngle <= 45 && columns < board.columns)
        {
            NeighborGems = board.Allgems[columns + 1, rows];
            NeighborGems.GetComponent<Gem>().columns -= 1;
            columns += 1;
        }//right swipe
        else if (swipeAngle > 45 && swipeAngle <= 135 && rows < board.rows)
        {
            NeighborGems = board.Allgems[columns, rows + 1];
            NeighborGems.GetComponent<Gem>().rows -= 1;
            rows += 1;
        }//up swipe
        else if ((swipeAngle > 135 || swipeAngle <= -135) && columns > 0)
        {
            NeighborGems = board.Allgems[columns - 1, rows];
            NeighborGems.GetComponent<Gem>().columns += 1;
            columns -= 1;
        }//left swipe
        else if (swipeAngle < -45 && swipeAngle >= -135 && rows > 0)
        {
            NeighborGems = board.Allgems[columns, rows - 1];
            NeighborGems.GetComponent<Gem>().rows += 1;
            rows -= 1;
        }//down swipe
    }

    public void Matches() //match if three gems are of same tag
    {
        if (columns > 0 && columns < board.columns - 1)
        {
            GameObject leftGem = board.Allgems[columns - 1, rows];
            GameObject rightGem = board.Allgems[columns + 1, rows];
            if (leftGem.tag == this.gameObject.tag && rightGem.tag == this.gameObject.tag)
            {
                leftGem.GetComponent<Gem>().Matched = true;
                rightGem.GetComponent<Gem>().Matched = true;
                Matched = true;
                board.DestroyMatches();
                scorescript.score += 6;
            }
        }
        if (rows > 0 && rows < board.rows - 1)
        {
            GameObject upperGem = board.Allgems[columns, rows + 1];
            GameObject lowerGem = board.Allgems[columns, rows - 1];
            if (upperGem.tag == this.gameObject.tag && lowerGem.tag == this.gameObject.tag)
            {
                upperGem.GetComponent<Gem>().Matched = true;
                lowerGem.GetComponent<Gem>().Matched = true;
                Matched = true;
                board.DestroyMatches();
                scorescript.score += 6;
            }
        }

    }



}

