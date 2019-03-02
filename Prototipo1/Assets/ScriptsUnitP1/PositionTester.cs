using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

//tank giocatore 1
public class PositionTester : MonoBehaviour {
    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public int maxRangeHzTankPlayer1;
    public int maxRangeVtTankPlayer1;
    public int contMp = 0;
    public SelectionController selection;
    

    public void Start()
    {
        selection = FindObjectOfType<SelectionController>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x, y);
        maxRangeHzTankPlayer1 = x;
        maxRangeVtTankPlayer1 = y;
        turn.isTurn = true;
        
    }

	public void GoToLeft()
    {
        if (x > 0 && turn.isTurn == true && contMp < 2 && selection.isActiveTank == true)
        {
            x--;
            transform.position = grid.GetWorldPosition(x, y);
            //turn.isTurn = false;
            turn.ContRound += 1;
            maxRangeHzTankPlayer1 = x;
            contMp++;
            
        }
    }

    public void GoToRight()
    {
        if (x < 11 && turn.isTurn == true && contMp < 2 && selection.isActiveTank == true)
        {
            x++;
            transform.position = grid.GetWorldPosition(x, y);
            //turn.isTurn = false;
            turn.ContRound += 1;
            maxRangeHzTankPlayer1 = x;
            contMp++;
        }
    }

    public void GoToDown()
    {
        if (y > 0 && turn.isTurn == true && contMp < 2 && selection.isActiveTank == true)
        {
            y--;
            transform.position = grid.GetWorldPosition(x, y);
            //turn.isTurn = false;
            turn.ContRound += 1;
            maxRangeVtTankPlayer1 = y;
            contMp++;
        }
    }

    public void GoToUp()
    {
        if (y < 11 && turn.isTurn == true && contMp < 2 && selection.isActiveTank == true)
        {
            y++;
            transform.position = grid.GetWorldPosition(x, y);
            //turn.isTurn = false;
            turn.ContRound += 1;
            maxRangeVtTankPlayer1 = y;
            contMp++;
        }
    }


    public void ToPass()
    {

        turn.isTurn = false;
        selection.isActiveTank = false;
        contMp = 0;

    }

}
