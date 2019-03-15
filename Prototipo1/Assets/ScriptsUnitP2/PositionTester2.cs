using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

//tank giocatore 2
public class PositionTester2 : MonoBehaviour {
    public float duration = 0.5f;
    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public SelectControllerP2 selectionP2;
    public int maxRangeHzTankPlayer2;
    public int maxRangeVtTankPlayer2;
    public int contMp = 0;


    public void Start()
    {

        selectionP2 = FindObjectOfType<SelectControllerP2>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x, y);
        maxRangeHzTankPlayer2 = x;
        maxRangeVtTankPlayer2 = y;
        

    }

    public void GoToLeft()
    {
        if (x > 0 && turn.isTurn == false && contMp < 2 && selectionP2.isActiveTankP2 == true)
        {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x--, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzTankPlayer2 = x;
            contMp++;

        }
    }

    public void GoToRight()
    {
        if (x < 11 && turn.isTurn == false && contMp < 2 && selectionP2.isActiveTankP2 == true)
        {
            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x++, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzTankPlayer2 = x;
            contMp++;
        }
    }

    public void GoToDown()
    {
        if (y > 0 && turn.isTurn == false && contMp < 2 && selectionP2.isActiveTankP2 == true)
        {
            transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y--);
            transform.DOMoveZ(y, duration).SetAutoKill(false); ;
            turn.ContRound += 1;
            maxRangeVtTankPlayer2 = y;
            contMp++;
        }
    }

    public void GoToUp()
    {
        if (y < 11 && turn.isTurn == false && contMp < 2 && selectionP2.isActiveTankP2 == true)
        {
            transform.DOLocalRotate(new Vector3(0,90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y++);
            transform.DOMoveZ(y, duration).SetAutoKill(false); ;
            turn.ContRound += 1;
            maxRangeVtTankPlayer2 = y;
            contMp++;
        }
    }


    public void ToPass()
    {
        turn.isTurn = true;
        contMp = 0;
        selectionP2.isActiveTankP2 = false;
    }



}
