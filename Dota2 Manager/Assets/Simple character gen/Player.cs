using UnityEngine;
using System.Collections;

public class DotaPlayer : MonoBehaviour {


    public string playerName;

    //postive
    public double farming;
    public double lastHitting;
    public double denying;
    public double Pushing;
    public double decisionMaking;
    public double rage;

    //negative
    public double playerStress;

    //total
    public double playerTotal;

    void Start () 
	{
        CalculatePlayerTotal();
    }

    public void CalculatePlayerTotal()
    {
		playerTotal = farming * 0.145 + lastHitting * 0.145 + denying * 0.145 + Pushing * 0.145 + decisionMaking * 0.145 + rage * 0.145 - playerStress * 0.145;
    }
	

}
