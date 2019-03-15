using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AbilityHealer : MonoBehaviour {

    public int heal = 4;
    public PositionHealer healer;
    public BaseGrid grid;
    public KeyCode abilityButton;
    public LifeManager lm;
    public TurnManager turn;
    public PositionTester tank;
    public int x, y;
    public int rangeHzTank;
    public int rangeVtTank;
    //ALTRE UNITA ALLEATE
    public bool isAbility;
    public SelectionController selection;

    // Use this for initialization
    void Start()
    {
        selection = FindObjectOfType<SelectionController>();
        healer = FindObjectOfType<PositionHealer>();
        tank = FindObjectOfType<PositionTester>();
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
        if (Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == false && selection.isActiveHealer == true)
        {

            isAbility = true;
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == true && selection.isActiveHealer == true)
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
        //destra
        if (Input.GetKeyDown(KeyCode.D) && rangeHzTank >= -5 && isAbility == true && lm.lifeTank < lm.lifeMaxTank )
        {
            //controllo front unita
            lm.lifeTank += heal;
            if (lm.lifeTank > lm.lifeMaxTank)
            {
                lm.lifeTank = 20;
            }
            turn.isTurn = false;
            isAbility = false;
            selection.isActiveHealer = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;

        }
        //sinistra
        if (Input.GetKeyDown(KeyCode.A) && rangeHzTank <= 5 && isAbility == true && lm.lifeTank < lm.lifeMaxTank)
        {
            
            lm.lifeTank += heal;
            if(lm.lifeTank > lm.lifeMaxTank)
            {
                lm.lifeTank = 20;
            }
            turn.isTurn = false; 
            isAbility = false;
            selection.isActiveHealer = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;
        }
        //sopra
        if (Input.GetKeyDown(KeyCode.W) && rangeVtTank >= -5 && isAbility == true && lm.lifeTank < lm.lifeMaxTank)
        {
            lm.lifeTank += heal;
            if (lm.lifeTank > lm.lifeMaxTank)
            {
                lm.lifeTank = 20;
            }
            turn.isTurn = false;
            isAbility = false;
            selection.isActiveHealer = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;
        }
        //sotto
        if (Input.GetKeyDown(KeyCode.S) && rangeVtTank <= 5 && isAbility == true && lm.lifeTank < lm.lifeMaxTank)
        {

            lm.lifeTank += heal;
            if (lm.lifeTank > lm.lifeMaxTank)
            {
                lm.lifeTank = 20;
            }
            turn.isTurn = false;
            isAbility = false;
            selection.isActiveHealer = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;

        }

        //autoheal 
        if(Input.GetKeyDown(KeyCode.Z) && isAbility == true && lm.lifeHealer < lm.lifeMaxHealer)
        {
            lm.lifeHealer += heal;
            if (lm.lifeHealer > lm.lifeMaxHealer)
            {
                lm.lifeHealer = 9;
            }
            turn.isTurn = false;
            isAbility = false;
            selection.isActiveHealer = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;

        }


    }


    //set up range verticale e orrizontale per portata ability
    public void SetRange()
    {
        rangeHzTank = healer.maxRangeHzHealerPlayer1 - tank.maxRangeHzTankPlayer1;
        rangeVtTank = healer.maxRangeVtHealerPlayer1 - tank.maxRangeVtTankPlayer1;
    }

}
