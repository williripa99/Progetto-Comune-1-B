using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;

public class HudManagerTest : MonoBehaviour {
    public Text unitP1;
    public Text unitP2;
    public Text Turn;
    public Text lifeTP1;
    public Text lifeHP1;
    public Text lifeTP2;
    public Text lifeHP2;
    public TurnManager turn;
    public LifeManager lm;

    // Use this for initialization
    void Start () {

        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
        if(turn.isTurn == true)
        {
            Turn.text = "turno player 1";
        }
        else if (turn.isTurn == false)
        {
            Turn.text = "turno player 2";
        }

        lifeTP1.text = lm.lifeTank.ToString();
        lifeHP1.text = lm.lifeHealer.ToString();
        lifeTP2.text = lm.lifeTankPlayer2.ToString();
        lifeHP2.text = lm.lifeHealerPlayer2.ToString();

    }
}
