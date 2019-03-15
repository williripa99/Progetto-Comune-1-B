using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AbilityTank : MonoBehaviour {
    public int att = 3;
    public PositionTester tester;
    public BaseGrid grid;
    public KeyCode abilityButton;
    public LifeManager lm;
    public TurnManager turn;
    public PositionTester2 tester2;
    public int x, y;
    public int rangeHz;
    public int rangeVt;
    public bool isAbility;
    public InputController input;

    // Use this for initialization
    void Start () {

        tester = FindObjectOfType<PositionTester>();
        tester2 = FindObjectOfType<PositionTester2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
        input = GetComponent<InputController>();
            

    }
	
	// Update is called once per frame
	void Update () {

        
        SetAbility();
        SetDirectionAbility();

        
	}


    public void SetAbility()
    {
        
        //abilito abilita
        if (Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == false)
        {

            isAbility = true;
            //disabilito input controller per i movimenti(wasd)
            input.enabled = !input.enabled; 
         
        }else if(Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == true)
        {
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            input.enabled = true;
        }

    }
    //scelgo direzione dove lanciare l'abilita
    public void SetDirectionAbility()
    {
        SetRange();
        //destra
        if (Input.GetKeyDown(KeyCode.D) && rangeHz >= -2 && isAbility == true)
        {
           
            tester.x++;
            transform.position = grid.GetWorldPosition(tester.x, tester.y);
            tester.maxRangeHzPlayer1 = tester.x;
            SetRange();
            lm.lifePlayer2 -= att;
            turn.isTurn = false;
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            input.enabled = true;

        }
        //sinistra
        if (Input.GetKeyDown(KeyCode.A) && rangeHz <= 2 && isAbility == true)
        {
            tester.x--;
            transform.position = grid.GetWorldPosition(tester.x, tester.y);
            tester.maxRangeHzPlayer1 = tester.x;
            SetRange();
            lm.lifePlayer2 -= att;
            turn.isTurn = false;
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            input.enabled = true;
        }
        //sopra
        if (Input.GetKeyDown(KeyCode.W) && rangeVt >= -2 && isAbility == true)
        {
            tester.y++;
            transform.position = grid.GetWorldPosition(tester.x, tester.y);
            tester.maxRangeVtPlayer1 = tester.y;
            SetRange();
            lm.lifePlayer2 -= att;
            turn.isTurn = false;
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            input.enabled = true;
        }
        //sotto
        if (Input.GetKeyDown(KeyCode.S) && rangeVt <= 2 && isAbility == true)
        {
            tester.y--;
            transform.position = grid.GetWorldPosition(tester.x, tester.y);
            tester.maxRangeVtPlayer1 = tester.y;
            SetRange();
            lm.lifePlayer2 -= att;
            turn.isTurn = false;
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            input.enabled = true;

        }
        

    }
    

    //set up range verticale e orrizontale per portata ability
    public void SetRange()
    {
        rangeHz = tester.maxRangeHzPlayer1 - tester2.maxRangeHzPlayer2;
        rangeVt = tester.maxRangeVtPlayer1 - tester2.maxRangeVtPlayer2;
    }

    
    
   

}



