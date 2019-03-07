using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AttackBaseHealer : MonoBehaviour{

    public LifeManager lm;
    public TurnManager turn;
    public int att = 1;
    public PositionTester tankP1;
    public PositionHealer healerP1;
    public PositionHealer2 healerP2;
    public PositionTester2 tankP2;
    public int RangeHzTank;
    public int RangeVtTank;
    public int RangeHzHealer;
    public int RangeVtHealer;
    public bool isAttackHealer;
    public KeyCode attackButtonHealer;
    public int contTurn;
    public bool isHitHealer;
    public bool isHitTank;
    private int lifeHitHealerP2;
    private int lifeHitTankP2;
    public SelectionController selection;

    // Use this for initialization
    void Start()
    {
        selection = FindObjectOfType<SelectionController>();
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


        RangeHzTank = tankP2.maxRangeHzTankPlayer2 - healerP1.maxRangeHzHealerPlayer1;
        RangeVtTank = tankP2.maxRangeVtTankPlayer2 - healerP1.maxRangeVtHealerPlayer1;
        RangeHzHealer = healerP2.maxRangeHzHealerPlayer2 - healerP1.maxRangeHzHealerPlayer1;
        RangeVtHealer = healerP2.maxRangeVtHealerPlayer2 - healerP1.maxRangeVtHealerPlayer1;
        // fare calcolo range obliquo


    }

    public void SetAttackBase()
    {
        if (Input.GetKeyDown(attackButtonHealer) && turn.isTurn == true && isAttackHealer == false && selection.isActiveHealer == true)
        {
            isAttackHealer = true;
            gameObject.GetComponent<InputController>().enabled = false;


        }
        else if (Input.GetKeyDown(attackButtonHealer) && turn.isTurn == true && isAttackHealer == true && selection.isActiveHealer == true)
        {
            isAttackHealer = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void SetDirectionAttackBase()
    {
        SetRange();
        // tank
        if (Input.GetKeyDown(KeyCode.D) && RangeHzTank <= 5 && healerP1.y == tankP2.y && isAttackHealer == true)
        {
            
               // if (tankP2.x < healerP2.x && tankP2.x < tankP1.x && tankP2.x < healerP1.x)
               // {
                    lm.lifeTankPlayer2 -= att;
                    isAttackHealer = false;
                    turn.isTurn = false;
                    isHitTank = true;
                    gameObject.GetComponent<InputController>().enabled = true;
                    selection.isActiveHealer = false;
                    lifeHitTankP2 = lm.lifeTankPlayer2;
                
                //}
        }
        // healer
        if (Input.GetKeyDown(KeyCode.D) && RangeHzHealer <= 5 && healerP1.y == healerP2.y  && isAttackHealer == true)
        {
            //if (healerP2.x < healerP1.x && healerP2.x < tankP2.x && healerP2.x < tankP1.x)
            //{
            lm.lifeHealerPlayer2 -= att;
                isAttackHealer = false;
                turn.isTurn = false;
                isHitHealer = true;
                gameObject.GetComponent<InputController>().enabled = true;
                selection.isActiveHealer = false;
                lifeHitHealerP2 = lm.lifeHealerPlayer2;
            // }
        }

        //tank
        if (Input.GetKeyDown(KeyCode.A) && RangeHzTank >= -5 &&  healerP1.y == tankP2.y && isAttackHealer == true)
        {
            //if (RangeHzTank < RangeHzHealer)
            //{
            lm.lifeTankPlayer2 -= att;
                isAttackHealer = false;
                turn.isTurn = false;
                isHitTank = true;
                gameObject.GetComponent<InputController>().enabled = true;
                selection.isActiveHealer = false;
                lifeHitTankP2 = lm.lifeTankPlayer2;
            // }
        }

        //healer
        if (Input.GetKeyDown(KeyCode.A) && RangeHzHealer >= -5 && healerP1.y == healerP2.y && isAttackHealer == true)
        {
            //if (RangeHzHealer < RangeHzTank)
            //{
            lm.lifeHealerPlayer2 -= att;
                isAttackHealer = false;
                turn.isTurn = false;
                isHitHealer = true;
                gameObject.GetComponent<InputController>().enabled = true;
                selection.isActiveHealer = false;
                lifeHitHealerP2 = lm.lifeHealerPlayer2;
            //}
        }

        //tank
        if (Input.GetKeyDown(KeyCode.W) && RangeVtTank <= 5 && healerP1.y == tankP2.y && isAttackHealer == true)
        {
            //if (RangeVtTank > RangeVtHealer)
            // {
            lm.lifeTankPlayer2 -= att;
                isAttackHealer = false;
                turn.isTurn = false;
                isHitTank = true;
                gameObject.GetComponent<InputController>().enabled = true;
                selection.isActiveHealer = false;
                lifeHitTankP2 = lm.lifeTankPlayer2;
            // }
        }

        //healer
        if (Input.GetKeyDown(KeyCode.W) && RangeVtHealer <= 5 && healerP1.y == healerP2.y && isAttackHealer == true)
        {
            // if (RangeVtHealer > RangeVtTank)
            // {
            lm.lifeHealerPlayer2 -= att;
                isAttackHealer = false;
                turn.isTurn = false;
                isHitHealer = true;
                gameObject.GetComponent<InputController>().enabled = true;
                selection.isActiveHealer = false;
                lifeHitHealerP2 = lm.lifeHealerPlayer2;
            // }
        }
        // tank
        if (Input.GetKeyDown(KeyCode.S) && RangeVtTank >= -5 && healerP1.y == tankP2.y && isAttackHealer == true)
        {
            // if (RangeVtTank < RangeVtHealer)
            // {
            lm.lifeTankPlayer2 -= att;
                isAttackHealer = false;
                turn.isTurn = false;
                isHitTank = true;
                gameObject.GetComponent<InputController>().enabled = true;
                selection.isActiveHealer = false;
                lifeHitTankP2 = lm.lifeTankPlayer2;

            //}
        }

        //healer
        if (Input.GetKeyDown(KeyCode.S) && RangeVtHealer >= -5 && healerP1.y == healerP2.y && isAttackHealer == true)
        {
            // if (RangeVtHealer < RangeVtTank)
            // {
            lm.lifeHealerPlayer2 -= att;
                isAttackHealer = false;
                turn.isTurn = false;
                isHitHealer = true;
                gameObject.GetComponent<InputController>().enabled = true;
                selection.isActiveHealer = false;
                lifeHitHealerP2 = lm.lifeHealerPlayer2;

            // }
        }
    }

    public void ContTurn()
    {
        if(turn.isTurn == false && contTurn == 0 && isHitTank == true)
        {
            contTurn += 1;
        }

        if(turn.isTurn == false && contTurn == 0 && isHitTank == true)
        {
            contTurn += 1;
        }
    }

    public void DamageForTurn()
    {
        if (turn.isTurn == true && contTurn == 1 && isHitTank == true)
        {
            
            lifeHitTankP2 -= att;
            lm.lifeTankPlayer2 = lifeHitTankP2;
            contTurn = 0;
            isHitTank = false;
        }

        if (turn.isTurn == true && contTurn == 1 && isHitHealer == true)
        {

            lifeHitHealerP2 -= att;
            lm.lifeTankPlayer2 = lifeHitHealerP2;
            contTurn = 0;
            isHitTank = false;
        }


    }
}
