using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AttackBase2 : MonoBehaviour {
    public LifeManager lm;
    public TurnManager turn;
    public int att = 1;
    public PositionTester tank;
    public PositionTester2 tankP2;
    public PositionHealer healerP1;
    public int RangeHzTank;
    public int RangeVtTank;
    public int RangeHzHealer;
    public int RangeVtHealer;
    public bool isAttack;
    public KeyCode attackButton;
    public SelectControllerP2 selectionP2;

    // Use this for initialization
    void Start()
    {
        selectionP2 = FindObjectOfType<SelectControllerP2>();
        tank = FindObjectOfType<PositionTester>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP1 = FindObjectOfType<PositionHealer>();
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
        RangeHzHealer = tank.maxRangeHzTankPlayer1 - healerP1.maxRangeHzHealerPlayer1;
        RangeVtHealer = tank.maxRangeVtTankPlayer1 - healerP1.maxRangeVtHealerPlayer1;
        //altre unità

    }

    public void SetAttackBase()
    {
        if (Input.GetKeyDown(attackButton) && turn.isTurn == false && isAttack == false && selectionP2.isActiveTankP2 == true)
        {
            isAttack = true;
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (Input.GetKeyDown(attackButton) && turn.isTurn == false && isAttack == true && selectionP2.isActiveTankP2 == true)
        {
            isAttack = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void SetDirectionAttackBase()
    {
        SetRange();
        //tank destra
        if (Input.GetKeyDown(KeyCode.D) && RangeHzTank == -1 && isAttack == true)
        {
            lm.lifeTank -= att;
            isAttack = false;
            turn.isTurn = true;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveTankP2 = false;
        }
        // healer destra
        if (Input.GetKeyDown(KeyCode.D) && RangeHzHealer == -1 && isAttack == true)
        {
            lm.lifeHealer -= att;
            isAttack = false;
            turn.isTurn = true;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveTankP2 = false;
        }
        //tanke sinistra
        if (Input.GetKeyDown(KeyCode.A) && RangeHzTank == 1 && isAttack == true)
        {
            lm.lifeTank -= att;
            isAttack = false;
            turn.isTurn = true;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveTankP2 = false;
        }
        //healer sinistra
        if (Input.GetKeyDown(KeyCode.A) && RangeHzHealer == 1 && isAttack == true)
        {
            lm.lifeHealer -= att;
            isAttack = false;
            turn.isTurn = true;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveTankP2 = false;
        }
        //tank sopra
        if (Input.GetKeyDown(KeyCode.W) && RangeVtTank == -1 && isAttack == true)
        {
            lm.lifeTank -= att;
            isAttack = false;
            turn.isTurn = true;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveTankP2 = false;
        }
        //healer sopra
        if (Input.GetKeyDown(KeyCode.W) && RangeVtHealer == -1 && isAttack == true)
        {
            lm.lifeHealer -= att;
            isAttack = false;
            turn.isTurn = true;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveTankP2 = false;
        }
        //tank sotto
        if (Input.GetKeyDown(KeyCode.S) && RangeVtTank == 1 && isAttack == true)
        {
            lm.lifeTank -= att;
            isAttack = false;
            turn.isTurn = true;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveTankP2 = false;
        }
        // healer sotto
        if (Input.GetKeyDown(KeyCode.S) && RangeVtHealer == -1 && isAttack == true)
        {
            lm.lifeHealer -= att;
            isAttack = false;
            turn.isTurn = true;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveTankP2 = false;
        }
    }
}
