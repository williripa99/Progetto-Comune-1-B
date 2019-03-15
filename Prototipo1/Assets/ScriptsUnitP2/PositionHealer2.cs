using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

//healere giocatore 2
public class PositionHealer2 : MonoBehaviour
{
    public float duration = 0.5f;
    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public int maxRangeHzHealerPlayer2;
    public int maxRangeVtHealerPlayer2;
    public int contMp = 0;
    public SelectControllerP2 selectionP2;

    public void Start()
    {
        selectionP2 = FindObjectOfType<SelectControllerP2>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x,y);
        maxRangeHzHealerPlayer2 = x;
        maxRangeVtHealerPlayer2 = y;
        

    }

    public void GoToLeft()
    {
        if (x > 0 && turn.isTurn == false && contMp < 4 && selectionP2.isActiveHealerP2 == true)
        {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x--, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzHealerPlayer2 = x;
            contMp++;

        }
    }

    public void GoToRight()
    {
        if (x < 11 && turn.isTurn == false && contMp < 4 && selectionP2.isActiveHealerP2 == true)
        {
            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x++, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzHealerPlayer2 = x;
            contMp++;
        }
    }

    public void GoToDown()
    {
        if (y > 0 && turn.isTurn == false && contMp < 4 && selectionP2.isActiveHealerP2 == true)
        {
            transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y--);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeVtHealerPlayer2 = y;
            contMp++;
        }
    }

    public void GoToUp()
    {
        if (y < 11 && turn.isTurn == false && contMp < 4 && selectionP2.isActiveHealerP2 == true)
        {
            transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y++);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeVtHealerPlayer2 = y;
            contMp++;
        }
    }


    public void ToPass()
    {

        turn.isTurn = true;
        contMp = 0;
        selectionP2.isActiveHealerP2 = false;
    }

}
