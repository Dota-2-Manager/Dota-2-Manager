using UnityEngine;
using System.Collections;

public class DotaPlayer : MonoBehaviour {


    public string name;

    //postive
    public double farming;
    public double lastHitting;
    public double denying;
    public double Pushing;
    public double decisionMaking;
    public double rage;

    //negative
    public double stress;

    //total
    public double total;

    void Start () {
        CalculateTotal();
    }

    public void CalculateTotal()
    {
        total = farming * 0.145 + lastHitting * 0.145 + denying * 0.145 + Pushing * 0.145 + decisionMaking * 0.145 + rage * 0.145 - stress * 0.145;
    }
	

}
