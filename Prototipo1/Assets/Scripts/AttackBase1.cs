using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AttackBase1 : MonoBehaviour {
    public LifeManager lm;
    public TurnManager turn;
    public int att = 1;
    public PositionTester tester1;
    public PositionTester2 tester2;
    public int RangeHz;
    public int RangeVt;
    public bool isAttack;
    public InputController input;
    public KeyCode attackButton;

    // Use this for initialization
    void Start () {

        tester1 = FindObjectOfType<PositionTester>();
        tester2 = FindObjectOfType<PositionTester2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        input = GetComponent<InputController>();
        isAttack = false;

    }
	
    void Update()
    {

        SetAttackBase();
        SetDirectionAttackBase();

    }

    public void SetRange()
    {

        RangeHz = tester1.maxRangeHzPlayer1 - tester2.maxRangeHzPlayer2;
        RangeVt = tester1.maxRangeVtPlayer1 - tester2.maxRangeVtPlayer2;
        

    }

    public void SetAttackBase()
    {
        if(Input.GetKeyDown(attackButton) && turn.isTurn == true && isAttack == false)
        {
            isAttack = true;
            input.enabled = !input.enabled;


        }
        else if(Input.GetKeyDown(attackButton) && turn.isTurn == true && isAttack == true)
        {
            isAttack = false;
            input.enabled = true;
        }
    }

    public void SetDirectionAttackBase()
    {
        SetRange();
        if(Input.GetKeyDown(KeyCode.D) && RangeHz == -1 && isAttack == true)
        {
            lm.lifePlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            input.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.A) && RangeHz == 1 && isAttack == true)
        {
            lm.lifePlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            input.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && RangeVt == -1 && isAttack == true)
        {
            lm.lifePlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            input.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && RangeVt == 1 && isAttack == true)
        {
            lm.lifePlayer2 -= att;
            isAttack = false;
            turn.isTurn = false;
            input.enabled = true;
        }
    }

}
