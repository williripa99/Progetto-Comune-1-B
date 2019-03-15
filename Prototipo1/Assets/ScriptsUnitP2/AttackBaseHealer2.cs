using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AttackBaseHealer2 : MonoBehaviour {

    public LifeManager lm;
    public TurnManager turn;
    public int att = 1;
    public PositionHealer healerP1;
    public PositionHealer2 healerP2;
    public PositionTester tankP1;
    public PositionTester2 tankP2;
    public int RangeHzTank;
    public int RangeVtTank;
    public int RangeHzHealer;
    public int RangeVtHealer;
    public bool isAttackHealer;
    public KeyCode attackButtonHealer;
    public int contTurn;
    public bool isHit;
    private int lifeHit;
    public SelectControllerP2 selectionP2;

    // Use this for initialization
    void Start()
    {
        selectionP2 = FindObjectOfType<SelectControllerP2>();
        healerP1 = FindObjectOfType<PositionHealer>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAttackHealer = false;

    }

    void Update()
    {

        SetAttackBase();
        SetDirectionAttackBase();
        ContTurn();
        DamageForTurn();




    }

    public void SetRange()
    {


        RangeHzTank = tankP1.maxRangeHzTankPlayer1 - healerP2.maxRangeHzHealerPlayer2;
        RangeVtTank = tankP1.maxRangeVtTankPlayer1 - healerP2.maxRangeVtHealerPlayer2;
        RangeHzHealer = healerP1.maxRangeHzHealerPlayer1 - healerP2.maxRangeHzHealerPlayer2;
        RangeVtHealer = healerP1.maxRangeVtHealerPlayer1 - healerP2.maxRangeVtHealerPlayer2;
        // fare calcolo range obliquo


    }

    public void SetAttackBase()
    {
        if (Input.GetKeyDown(attackButtonHealer) && turn.isTurn == false && isAttackHealer == false && selectionP2.isActiveHealerP2 == true)
        {
            isAttackHealer = true;
            gameObject.GetComponent<InputController>().enabled = false;


        }
        else if (Input.GetKeyDown(attackButtonHealer) && turn.isTurn == false && isAttackHealer == true && selectionP2.isActiveHealerP2 == true)
        {
            isAttackHealer = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void SetDirectionAttackBase()
    {
        SetRange();
        // tank
        if (Input.GetKeyDown(KeyCode.D) && RangeHzTank <= 5 && healerP2.y == tankP1.y && isAttackHealer == true)
        {
         
            lm.lifeTank -= att;
                isAttackHealer = false;
                turn.isTurn = true;
                isHit = true;
                selectionP2.isActiveHealerP2 = false;
                gameObject.GetComponent<InputController>().enabled = true;
                lifeHit = lm.lifeTank;
            
        }
        // healer
        if (Input.GetKeyDown(KeyCode.D) && RangeHzHealer <= 5 && healerP2.y == healerP1.y && isAttackHealer == true)
        {
         
            
            lm.lifeHealer -= att;
                isAttackHealer = false;
                turn.isTurn = true;
                isHit = true;
                selectionP2.isActiveHealerP2 = false;
                gameObject.GetComponent<InputController>().enabled = true;
                lifeHit = lm.lifeHealer;
            
        }

        //tank
        if (Input.GetKeyDown(KeyCode.A) && RangeHzTank >= -5 && healerP2.y == tankP1.y && isAttackHealer == true)
        {
       
            lm.lifeTank -= att;
                isAttackHealer = false;
                turn.isTurn = true;
                isHit = true;
                selectionP2.isActiveHealerP2 = false;
                gameObject.GetComponent<InputController>().enabled = true;
                lifeHit = lm.lifeTank;
            
        }

        //healer
        if (Input.GetKeyDown(KeyCode.A) && RangeHzHealer >= -5 && healerP2.y == healerP1.y && isAttackHealer == true)
        {
         
            lm.lifeHealer -= att;
                isAttackHealer = false;
                turn.isTurn = true;
                isHit = true;
                gameObject.GetComponent<InputController>().enabled = true;
                selectionP2.isActiveHealerP2 = false;
                lifeHit = lm.lifeHealer;
            
        }

        //tank
        if (Input.GetKeyDown(KeyCode.W) && RangeVtTank <= 5 && healerP2.y == tankP1.y && isAttackHealer == true)
        {
           
            lm.lifeTank -= att;
                isAttackHealer = false;
                turn.isTurn = true;
                isHit = true;
                selectionP2.isActiveHealerP2 = false;
                gameObject.GetComponent<InputController>().enabled = true;
                lifeHit = lm.lifeTank;
            // }
        }

        //healer
        if (Input.GetKeyDown(KeyCode.W) && RangeVtHealer <= 5 && healerP2.y == healerP1.y && isAttackHealer == true)
        {
          
            lm.lifeHealer -= att;
                isAttackHealer = false;
                turn.isTurn = true;
                isHit = true;
                selectionP2.isActiveHealerP2 = false;
                gameObject.GetComponent<InputController>().enabled = true;
                lifeHit = lm.lifeHealer;
            //}
        }
        // tank
        if (Input.GetKeyDown(KeyCode.S) && RangeVtTank >= -5 && healerP2.y == tankP1.y && isAttackHealer == true)
        {
         
            lm.lifeTank -= att;
                isAttackHealer = false;
                turn.isTurn = true;
                isHit = true;
                selectionP2.isActiveHealerP2 = false;
                gameObject.GetComponent<InputController>().enabled = true;
                lifeHit = lm.lifeTank;
            
        }

        //healer
        if (Input.GetKeyDown(KeyCode.S) && RangeVtHealer >= -5 && healerP2.y == healerP1.y && isAttackHealer == true)
        {
           
            lm.lifeHealer -= att;
                isAttackHealer = false;
                turn.isTurn = true;
                isHit = true;
                selectionP2.isActiveHealerP2 = false;
                gameObject.GetComponent<InputController>().enabled = true;
                lifeHit = lm.lifeHealer;
           
        }
    }

    public void ContTurn()
    {
        if (turn.isTurn == true && contTurn == 0 && isHit == true)
        {
            contTurn += 1;
        }
    }

    public void DamageForTurn()
    {
        if (turn.isTurn == false && contTurn == 1 && isHit == true)
        {

            lifeHit -= att;
            contTurn = 0;
            isHit = false;
        }


    }
}
