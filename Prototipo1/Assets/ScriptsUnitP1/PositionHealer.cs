using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

//healer giocatore 1
public class PositionHealer : MonoBehaviour {
    public float duration = 0.5f;
    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public int maxRangeHzHealerPlayer1;
    public int maxRangeVtHealerPlayer1;
    public int contMp = 0;
    public SelectionController selection;

    public void Start()
    {
        selection = FindObjectOfType<SelectionController>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x, y);
        maxRangeHzHealerPlayer1 = x;
        maxRangeVtHealerPlayer1 = y;
        turn.isTurn = true;

    }

    public void GoToLeft()
    {
        if (x > 0 && turn.isTurn == true && contMp < 4 && selection.isActiveHealer == true)
        {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x--, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzHealerPlayer1 = x;
            contMp++;

        }
    }

    public void GoToRight()
    {
        if (x < 11 && turn.isTurn == true && contMp < 4 && selection.isActiveHealer == true)
        {
            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x++, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzHealerPlayer1 = x;
            contMp++;
        }
    }

    public void GoToDown()
    {
        if (y > 0 && turn.isTurn == true && contMp < 4 && selection.isActiveHealer == true)
        {
            transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y--);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeVtHealerPlayer1 = y;
            contMp++;
        }
    }

    public void GoToUp()
    {
        if (y < 11 && turn.isTurn == true && contMp < 4 && selection.isActiveHealer == true)
        {
            transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y++);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeVtHealerPlayer1 = y;
            contMp++;
        }
    }


    public void ToPass()
    {

        turn.isTurn = false;
        contMp = 0;
        selection.isActiveHealer = false;
    }

}
