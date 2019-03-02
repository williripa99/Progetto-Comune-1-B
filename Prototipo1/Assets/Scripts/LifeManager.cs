using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class LifeManager : MonoBehaviour {
    public int lifeTank;
    public int lifeHealer;
    public int lifeMaxHealer;
    public int lifeHealerPlayer2;
    public int lifeMaxHealerPlayer2;
    public int lifeTankPlayer2;
    public int lifeMaxTank;
    public int lifeMaxTankPlayer2;

    // Use this for initialization
    void Start () {

          lifeTank = 20;
          lifeHealer = 9;
          lifeTankPlayer2 = 20;
          lifeHealerPlayer2 = 9;
          lifeMaxTank = lifeTank;
          lifeMaxTankPlayer2 = lifeTankPlayer2;
          lifeMaxHealer = lifeHealer;
          lifeMaxHealerPlayer2 = lifeHealerPlayer2; 

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
