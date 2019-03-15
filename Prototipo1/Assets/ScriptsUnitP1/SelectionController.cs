using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class SelectionController : MonoBehaviour {
    public int contSelectionP1;
    public PositionTester tankP1;
    public PositionHealer healerP1;
    public BaseGrid grid;
    public int x, y;
    public KeyCode confirmUnitButton;
    public bool isActiveTank;
    public bool isActiveHealer;
    public TurnManager turn;
    public HudManagerTest Text;

    void Start()
    {
        Text = FindObjectOfType<HudManagerTest>();
        turn = FindObjectOfType<TurnManager>();
        tankP1 = FindObjectOfType<PositionTester>();
        healerP1 = FindObjectOfType<PositionHealer>();
        contSelectionP1 = 0;
        transform.position = grid.GetWorldPosition(x,y);
        gameObject.GetComponent<MeshRenderer>().enabled = false;


    }


    void Update()
    {
        ConfirmUnit();
        if(turn.isTurn == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
    }

    public void ContTankP1()
    {
       
        transform.position = grid.GetWorldPosition(tankP1.x , tankP1.y);
        x = tankP1.x;
        y = tankP1.y;
        Text.unitP1.text = "Tank ";
    }

    public void ContHealerP1()
    {
        transform.position = grid.GetWorldPosition(healerP1.x, healerP1.y);
        x = healerP1.x;
        y = healerP1.y;
        Text.unitP1.text = "healer ";
    }

    public void AddCont()
    {
        contSelectionP1 += 1;
        if(contSelectionP1 > 2 /* 4*/)
        {
            contSelectionP1 = 1;
        }
    }

    public void ConfirmUnit()
    {
        if(Input.GetKeyDown(confirmUnitButton) && contSelectionP1 == 1)
        {
            Debug.Log("attiva tank");
            isActiveTank = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
        if (Input.GetKeyDown(confirmUnitButton) && contSelectionP1 == 2)
        {
            Debug.Log("attiva healer");
            isActiveHealer = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }



}
