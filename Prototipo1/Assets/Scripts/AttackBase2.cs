using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class AttackBase2 : MonoBehaviour {
    public LifeManager lm;
    public TurnManager turn;
    public int att = 5;
    public PositionTester maxP1;
    public PositionTester2 maxP2;
    public int RangeHz;
    public int RangeVt;

    // Use this for initialization
    void Start () {

        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        maxP1 = FindObjectOfType<PositionTester>();
        maxP2 = FindObjectOfType<PositionTester2>();

    }
	
	public void ToAttackBase2()
    {
        RangeHz = maxP2.maxRangeHzPlayer2 - maxP1.maxRangeHzPlayer1;
        RangeVt = maxP2.maxRangeVtPlayer2 - maxP1.maxRangeVtPlayer1;
        if (RangeHz <= 2 && RangeHz >= -2 || RangeVt <= 2 && RangeVt >=2)
        {
            lm.lifeTank -= att;
            turn.isTurn = true;
            turn.ContRound += 1;
        }
    }
}
