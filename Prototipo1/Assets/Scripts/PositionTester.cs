using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class PositionTester : MonoBehaviour {
    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public int maxRangeHzPlayer1;
    public int maxRangeVtPlayer1;
    public int contMp = 0;
    

    public void Start()
    {
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x, y);
        maxRangeHzPlayer1 = x;
        maxRangeVtPlayer1 = y;
        turn.isTurn = true;
        
    }

	public void GoToLeft()
    {
        if (x > 0 && turn.isTurn == true && contMp < 2)
        {
            x--;
            transform.position = grid.GetWorldPosition(x, y);
            //turn.isTurn = false;
            turn.ContRound += 1;
            maxRangeHzPlayer1 = x;
            contMp++;
            
        }
    }

    public void GoToRight()
    {
        if (x < 11 && turn.isTurn == true && contMp < 2)
        {
            x++;
            transform.position = grid.GetWorldPosition(x, y);
            //turn.isTurn = false;
            turn.ContRound += 1;
            maxRangeHzPlayer1 = x;
            contMp++;
        }
    }

    public void GoToDown()
    {
        if (y > 0 && turn.isTurn == true && contMp < 2)
        {
            y--;
            transform.position = grid.GetWorldPosition(x, y);
            //turn.isTurn = false;
            turn.ContRound += 1;
            maxRangeVtPlayer1 = y;
            contMp++;
        }
    }

    public void GoToUp()
    {
        if (y < 11 && turn.isTurn == true && contMp < 2)
        {
            y++;
            transform.position = grid.GetWorldPosition(x, y);
            //turn.isTurn = false;
            turn.ContRound += 1;
            maxRangeVtPlayer1 = y;
            contMp++;
        }
    }


    public void ToPass()
    {

        turn.isTurn = false;
        contMp = 0;
    }

}
