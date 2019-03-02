using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AbilityTank : MonoBehaviour {
    public int att = 3;
    public PositionTester tank;
    public BaseGrid grid;
    public KeyCode abilityButton;
    public LifeManager lm;
    public TurnManager turn;
    public PositionTester2 tankP2;
    private PositionHealer2 healerP2;
    public int x, y;
    public int rangeHzTank;
    public int rangeVtTank;
    public int rangeHzHealer;
    public int rangeVtHealer;
    public bool isAbility;
    public SelectionController selection;

    // Use this for initialization
    void Start () {

        selection = FindObjectOfType<SelectionController>();
        tank = FindObjectOfType<PositionTester>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
        
    }
	
	// Update is called once per frame
	void Update () {

        
        SetAbility();
        SetDirectionAbility();

        
	}


    public void SetAbility()
    {
        
        //abilito abilita
        if (Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == false && selection.isActiveTank == true)
        {

            isAbility = true;
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if(Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == true && selection.isActiveTank == true)
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
        //destra TankP2
        if (Input.GetKeyDown(KeyCode.D) && rangeHzTank >= -2 && isAbility == true)
        {
            if (rangeHzTank > rangeHzHealer)
            {
                tank.x++;
                transform.position = grid.GetWorldPosition(tank.x, tank.y);
                tank.maxRangeHzTankPlayer1 = tank.x;
                SetRange();
                lm.lifeTankPlayer2 -= att;
                turn.isTurn = false;
                isAbility = false;
                selection.isActiveTank = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }
        // destra HealerP2
        if (Input.GetKeyDown(KeyCode.D) && rangeHzHealer >= -2 && isAbility == true)
        {
            if (rangeHzHealer > rangeHzTank)
            {
                tank.x++;
                transform.position = grid.GetWorldPosition(tank.x, tank.y);
                tank.maxRangeHzTankPlayer1 = tank.x;
                SetRange();
                lm.lifeHealerPlayer2 -= att;
                turn.isTurn = false;
                isAbility = false;
                selection.isActiveTank = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }
        //sinistra tank
        if (Input.GetKeyDown(KeyCode.A) && rangeHzTank <= 2 && isAbility == true)
        {
            if (rangeHzTank < rangeHzHealer)
            {
                tank.x++;
                transform.position = grid.GetWorldPosition(tank.x, tank.y);
                tank.maxRangeHzTankPlayer1 = tank.x;
                SetRange();
                lm.lifeTankPlayer2 -= att;
                turn.isTurn = false;
                isAbility = false;
                selection.isActiveTank = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }
        // sinistra healer
        if (Input.GetKeyDown(KeyCode.A) && rangeHzHealer <= 2 && isAbility == true)
        {
            if (rangeHzHealer < rangeHzTank)
            {
                tank.x--;
                transform.position = grid.GetWorldPosition(tank.x, tank.y);
                tank.maxRangeHzTankPlayer1 = tank.x;
                SetRange();
                lm.lifeHealerPlayer2 -= att;
                turn.isTurn = false;
                isAbility = false;
                selection.isActiveTank = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }
        //sopra tank
        if (Input.GetKeyDown(KeyCode.W) && rangeVtTank >= -2 && isAbility == true)
        {
            if (rangeVtTank > rangeVtHealer)
            {
                tank.y++;
                transform.position = grid.GetWorldPosition(tank.x, tank.y);
                tank.maxRangeVtTankPlayer1 = tank.y;
                SetRange();
                lm.lifeTankPlayer2 -= att;
                turn.isTurn = false;
                isAbility = false;
                selection.isActiveTank = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }

        //sopra healer

        if (Input.GetKeyDown(KeyCode.W) && rangeVtHealer >= -2 && isAbility == true)
        {
            if (rangeVtHealer > rangeVtTank)
            {
                tank.y++;
                transform.position = grid.GetWorldPosition(tank.x, tank.y);
                tank.maxRangeVtTankPlayer1 = tank.y;
                SetRange();
                lm.lifeHealerPlayer2 -= att;
                turn.isTurn = false;
                isAbility = false;
                selection.isActiveTank = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }

       
         // sotto tank
        if (Input.GetKeyDown(KeyCode.S) && rangeVtTank <= 2 && isAbility == true)
        {
            if (rangeVtTank < rangeVtHealer)
            {
                tank.y--;
                transform.position = grid.GetWorldPosition(tank.x, tank.y);
                tank.maxRangeHzTankPlayer1 = tank.y;
                SetRange();
                lm.lifeTankPlayer2 -= att;
                turn.isTurn = false;
                isAbility = false;
                selection.isActiveTank = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
            }
        }

        //sotto healer
        if (Input.GetKeyDown(KeyCode.S) && rangeVtHealer <= 2 && isAbility == true)
        {
            if (rangeVtHealer < rangeVtTank)
            {
                tank.y--;
                transform.position = grid.GetWorldPosition(tank.x, tank.y);
                tank.maxRangeVtTankPlayer1 = tank.y;
                SetRange();
                lm.lifeHealerPlayer2 -= att;
                turn.isTurn = false;
                isAbility = false;
                selection.isActiveTank = false;
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
        rangeHzHealer = tank.maxRangeHzTankPlayer1 - healerP2.maxRangeHzHealerPlayer2;
        rangeVtHealer = tank.maxRangeVtTankPlayer1 - healerP2.maxRangeVtHealerPlayer2;
        // altre unità
    }
   

}



