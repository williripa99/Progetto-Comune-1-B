using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AbilityHealer2 : MonoBehaviour {

    public int heal = 4;
    public PositionHealer2 healerP2;
    public BaseGrid grid;
    public KeyCode abilityButton;
    public LifeManager lm;
    public TurnManager turn;
    public PositionTester2 tankP2;
    //altre unità
    public int x, y;
    public int rangeHzTank;
    public int rangeVtTank;
    public bool isAbility;
    public SelectControllerP2 selectionP2;

    // Use this for initialization
    void Start()
    {
        selectionP2 = FindObjectOfType<SelectControllerP2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        tankP2 = FindObjectOfType<PositionTester2>();
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
        if (Input.GetKeyDown(abilityButton) && turn.isTurn == false && isAbility == false && selectionP2.isActiveHealerP2 == true)
        {

            isAbility = true;
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (Input.GetKeyDown(abilityButton) && turn.isTurn == false && isAbility == true && selectionP2.isActiveHealerP2 == true) 
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
        if (Input.GetKeyDown(KeyCode.D) && rangeHzTank <= 5 && isAbility == true && lm.lifeTankPlayer2 < lm.lifeMaxTankPlayer2  /* altre unita */)
        {

            lm.lifeTankPlayer2 += heal;
            if (lm.lifeTankPlayer2 > lm.lifeMaxTankPlayer2)
            {
                lm.lifeTankPlayer2 = 20;
            }
            turn.isTurn = true;
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;

        }
        //sinistra
        if (Input.GetKeyDown(KeyCode.A) && rangeHzTank >= -5 && isAbility == true && lm.lifeTankPlayer2 < lm.lifeMaxTankPlayer2  /* altre unita */)
        {

            lm.lifeTankPlayer2 += heal;
            if (lm.lifeTankPlayer2 > lm.lifeMaxTankPlayer2)
            {
                lm.lifeTankPlayer2 = 20;
            }
            turn.isTurn = true;
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;
        }
        //sopra
        if (Input.GetKeyDown(KeyCode.W) && rangeVtTank <= 5 && isAbility == true && lm.lifeTankPlayer2 < lm.lifeMaxTankPlayer2  /* altre unita */)
        {
            lm.lifeTankPlayer2 += heal;
            if (lm.lifeTankPlayer2 > lm.lifeMaxTankPlayer2)
            {
                lm.lifeTankPlayer2 = 20;
            }
            turn.isTurn = true;
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;
        }
        //sotto
        if (Input.GetKeyDown(KeyCode.S) && rangeVtTank >= -5 && isAbility == true && lm.lifeTankPlayer2 < lm.lifeMaxTankPlayer2 /* altre unita */)
        {

            lm.lifeTankPlayer2 += heal;
            if (lm.lifeTankPlayer2 > lm.lifeMaxTankPlayer2)
            {
                lm.lifeTankPlayer2 = 20;
            }
            turn.isTurn = true;
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;

        }


        //auto heal
        if (Input.GetKeyDown(KeyCode.Z) && isAbility == true && lm.lifeHealerPlayer2 < lm.lifeMaxHealerPlayer2)
        {
            lm.lifeHealerPlayer2 += heal;
            if (lm.lifeHealerPlayer2 > lm.lifeMaxHealerPlayer2)
            {
                lm.lifeHealerPlayer2 = 9;
            }
            turn.isTurn = true;
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;
        }



    }


    //set up range verticale e orrizontale per portata ability
    public void SetRange()
    {
        rangeHzTank = healerP2.maxRangeHzHealerPlayer2 - tankP2.maxRangeHzTankPlayer2;
        rangeVtTank = healerP2.maxRangeVtHealerPlayer2 - tankP2.maxRangeVtTankPlayer2;
        //altre unità
    }
}
