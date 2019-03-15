using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AbilityTank2 : MonoBehaviour {
    public int att = 3;
    public PositionTester tank;
    public BaseGrid grid;
    public KeyCode abilityButton;
    public LifeManager lm;
    public TurnManager turn;
    public PositionTester2 tankP2;
    private PositionHealer healerP1;
    public int x, y;
    public int rangeHzTank;
    public int rangeVtTank;
    public int rangeHzHealer;
    public int rangeVtHealer;
    public bool isAbility;
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
        isAbility = false;
       
    }

    // Update is called once per frame
    void Update()
    {

        SetAbility();
        SetDirectionAbility();
    }


    public void SetAbility()
    {

        //abilito abilita
        if (Input.GetKeyDown(abilityButton) && turn.isTurn == false && isAbility == false && selectionP2.isActiveTankP2 == true)
        {

            isAbility = true;
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (Input.GetKeyDown(abilityButton) && turn.isTurn == false && isAbility == true && selectionP2.isActiveTankP2 == true)
        {
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;
        }

    }
    //scelgo direzione dove lanciare l'abilita
    public void SetDirectionAbility()
    {
        SetRange();
        //destra TankP2 positivo
        if (Input.GetKeyDown(KeyCode.D) && rangeHzTank <= 2 && tankP2.y == tank.y && isAbility == true)
        {
            if (rangeHzTank < rangeHzHealer)
            {
                tankP2.x++;
                transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y);
                tankP2.maxRangeHzTankPlayer2 = tankP2.x;
                SetRange();
                lm.lifeTank -= att;
                turn.isTurn = true;
                isAbility = false;
                selectionP2.isActiveTankP2 = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }
        // destra HealerP2
        if (Input.GetKeyDown(KeyCode.D) && rangeHzHealer <= 2 && tankP2.y == healerP1.y && isAbility == true)
        {
            if (rangeHzHealer < rangeHzTank)
            {
                tankP2.x++;
                transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y);
                tankP2.maxRangeHzTankPlayer2 = tankP2.x;
                SetRange();
                lm.lifeHealer -= att;
                turn.isTurn = true;
                isAbility = false;
                selectionP2.isActiveTankP2 = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }
        //sinistra tank
        if (Input.GetKeyDown(KeyCode.A) && rangeHzTank >= -2 && tankP2.y == tank.y && isAbility == true)
        {
            if (rangeHzTank > rangeHzHealer)
            {
                tankP2.x++;
                transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y);
                tankP2.maxRangeHzTankPlayer2 = tankP2.x;
                SetRange();
                lm.lifeTank -= att;
                turn.isTurn = true;
                isAbility = false;
                selectionP2.isActiveTankP2 = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }
        // sinistra healer
        if (Input.GetKeyDown(KeyCode.A) && rangeHzHealer >= -2 && tankP2.y == healerP1.y && isAbility == true)
        {
            if (rangeHzHealer > rangeHzTank)
            {
                tankP2.x--;
                transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y);
                tankP2.maxRangeHzTankPlayer2 = tankP2.x;
                SetRange();
                lm.lifeHealer-= att;
                turn.isTurn = true;
                isAbility = false;
                selectionP2.isActiveTankP2 = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }
        //sopra tank
        if (Input.GetKeyDown(KeyCode.W) && rangeVtTank <= 2 && tankP2.y == tank.y && isAbility == true)
        {
            if (rangeVtTank < rangeVtHealer)
            {
                tankP2.y++;
                transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y);
                tankP2.maxRangeVtTankPlayer2 = tankP2.y;
                SetRange();
                lm.lifeTank -= att;
                turn.isTurn = true;
                isAbility = false;
                selectionP2.isActiveTankP2 = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }

        //sopra healer

        if (Input.GetKeyDown(KeyCode.W) && rangeVtHealer <= 2 && tankP2.y == healerP1.y && isAbility == true)
        {
            if (rangeVtHealer < rangeVtTank)
            {
                tankP2.y++;
                transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y);
                tankP2.maxRangeVtTankPlayer2 = tankP2.y;
                SetRange();
                lm.lifeHealer-= att;
                turn.isTurn = true;
                isAbility = false;
                selectionP2.isActiveTankP2 = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }


        // sotto tank
        if (Input.GetKeyDown(KeyCode.S) && rangeVtTank >= -2 && tankP2.y == tank.y && isAbility == true)
        {
            if (rangeVtTank > rangeVtHealer)
            {
                tankP2.y--;
                transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y);
                tankP2.maxRangeHzTankPlayer2 = tankP2.y;
                SetRange();
                lm.lifeTank -= att;
                turn.isTurn = true;
                isAbility = false;
                selectionP2.isActiveTankP2 = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }

        //sotto healer
        if (Input.GetKeyDown(KeyCode.S) && rangeVtHealer >= -2 && tankP2.y == healerP1.y && isAbility == true)
        {
            if (rangeVtHealer > rangeVtTank)
            {
                tankP2.y--;
                transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y);
                tankP2.maxRangeVtTankPlayer2 = tankP2.y;
                SetRange();
                lm.lifeHealer -= att;
                turn.isTurn = true;
                isAbility = false;
                selectionP2.isActiveTankP2 = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }


    }


    //set up range verticale e orrizontale per portata ability
    public void SetRange()
    {
        //range tank
        rangeHzTank = tank.maxRangeHzTankPlayer1 - tankP2.maxRangeHzTankPlayer2;
        rangeVtTank = tank.maxRangeVtTankPlayer1 - tankP2.maxRangeVtTankPlayer2;
        //range healer
        rangeHzHealer = healerP1.maxRangeHzHealerPlayer1 - tankP2.maxRangeHzTankPlayer2;
        rangeVtHealer = healerP1.maxRangeVtHealerPlayer1 - tankP2.maxRangeVtTankPlayer2;
        // altre unità
    }

}
