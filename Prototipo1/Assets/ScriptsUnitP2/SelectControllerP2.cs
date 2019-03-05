using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class SelectControllerP2 : MonoBehaviour {

    public int contSelectionP2;
    public PositionTester2 tankP2;
    public PositionHealer2 healerP2;
    public BaseGrid grid;
    public int x, y;
    public KeyCode confirmUnitButton;
    public bool isActiveTankP2;
    public bool isActiveHealerP2;
    public TurnManager turn;
    public HudManagerTest Text;

    void Start()
    {
        Text = FindObjectOfType<HudManagerTest>();
        turn = FindObjectOfType<TurnManager>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        contSelectionP2 = 0;
        transform.position = grid.GetWorldPosition(x, y);
        gameObject.GetComponent<MeshRenderer>().enabled = false;


    }


    void Update()
    {
        ConfirmUnit();
        if (turn.isTurn == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void ContTankP2()
    {
        transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y);
        x = tankP2.x;
        y = tankP2.y;
        Text.unitP2.text = "Tank ";
    }

    public void ContHealerP2()
    {
        transform.position = grid.GetWorldPosition(healerP2.x, healerP2.y);
        x = healerP2.x;
        y = healerP2.y;
        Text.unitP2.text = "healer ";
    }

    public void AddContP2()
    {
        contSelectionP2 += 1;
        if (contSelectionP2 > 2 /* 4*/)
        {
            contSelectionP2 = 1;
        }
    }

    public void ConfirmUnit()
    {
        if (Input.GetKeyDown(confirmUnitButton) && contSelectionP2 == 1)
        {
            Debug.Log("attiva tank");
            isActiveTankP2 = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
        if (Input.GetKeyDown(confirmUnitButton) && contSelectionP2 == 2)
        {
            Debug.Log("attiva healer");
            isActiveHealerP2 = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
