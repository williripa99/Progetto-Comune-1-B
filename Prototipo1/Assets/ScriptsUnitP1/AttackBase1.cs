using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AttackBase1 : MonoBehaviour {
    public LifeManager lm;
    public TurnManager turn;
    public int att = 1;
    public PositionTester tank;
    public PositionTester2 tankP2;
    public PositionHealer2 healerP2;
    public int RangeHzTank;
    public int RangeVtTank;
    public int RangeHzHealer;
    public int RangeVtHealer;
    public bool isAttack;
    public KeyCode attackButton;
    public SelectionController selection;

    // Use this for initialization
    void Start () {

        selection = FindObjectOfType<SelectionController>();
        tank = FindObjectOfType<PositionTester>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAttack = false;

    }
	
    void Update()
    {

        SetAttackBase();
        SetDirectionAttackBase();

    }

    public void SetRange()
    {

        RangeHzTank = tank.maxRangeHzTankPlayer1 - tankP2.maxRangeHzTankPlayer2;
        RangeVtTank = tank.maxRangeVtTankPlayer1 - tankP2.maxRangeVtTankPlayer2;
        RangeHzHealer = tank.maxRangeHzTankPlayer1 - healerP2.maxRangeHzHealerPlayer2;
        RangeVtHealer = tank.maxRangeVtTankPlayer1 - healerP2.maxRangeVtHealerPlayer2;
        //altre unità

    }

    public void SetAttackBase()
    {
        if(Input.GetKeyDown(attackButton) && turn.isTurn == true && isAttack == false && selection.isActiveTank == true)
        {
            isAttack = true;
            
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if(Input.GetKeyDown(attackButton) && turn.isTurn == true && isAttack == true && selection.isActiveTank == true)
        {
            isAttack = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void SetDirectionAttackBase()
    {
        SetRange();
        //tank destra
        if(Input.GetKeyDown(KeyCode.D) && RangeHzTank == -1 && isAttack == true)
        {
            lm.lifeTankPlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selection.isActiveTank = false;
        }
        // healer destra
        if (Input.GetKeyDown(KeyCode.D) && RangeHzHealer == -1 && isAttack == true)
        {
            lm.lifeHealerPlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selection.isActiveTank = false;
        }
        //tanke sinistra
        if (Input.GetKeyDown(KeyCode.A) && RangeHzTank == 1 && isAttack == true)
        {
            lm.lifeTankPlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selection.isActiveTank = false;
        }
        //healer sinistra
        if (Input.GetKeyDown(KeyCode.A) && RangeHzHealer == 1 && isAttack == true)
        {
            lm.lifeHealerPlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selection.isActiveTank = false;
        }
        //tank sopra
        if (Input.GetKeyDown(KeyCode.W) && RangeVtTank == -1 && isAttack == true)
        {
            lm.lifeTankPlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selection.isActiveTank = false;
        }
        //healer sopra
        if (Input.GetKeyDown(KeyCode.W) && RangeVtHealer == -1 && isAttack == true)
        {
            lm.lifeHealerPlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selection.isActiveTank = false;
        }
        //tank sotto
        if (Input.GetKeyDown(KeyCode.S) && RangeVtTank == 1 && isAttack == true)
        {
            lm.lifeTankPlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selection.isActiveTank = false;
        }
        // healer sotto
        if (Input.GetKeyDown(KeyCode.S) && RangeVtHealer == -1 && isAttack == true)
        {
            lm.lifeHealerPlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selection.isActiveTank = false;
        }
    }

}
