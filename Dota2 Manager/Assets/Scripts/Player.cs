using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class DotaPlayer{


    public string name;
    private int age;
    private Position CurrentRole;

    //newStats v0.1
    private double pushing { get; set; }
    private double farming { get; set; }
    private double fighting { get; set; }
    private double warding { get; set; }
    private double Positioning { get; set; }
    private double mapAwareness { get; set; }
    private double decisionMakeing { get; set; }
    private double roaming { get; set; }
    private double laneControl { get; set; }
    private double riskTakeing { get; set; }
    private double flair { get; set; }
    private double Consistency { get; set; }
    private double teamWork { get; set; }
    private double Leadership { get; set; }

    //positions
    private double Carry { get; set; }
    private double Mid { get; set; }
    private double Offlane { get; set; }
    private double Support { get; set; }

    //total
    public double total;

    public DotaPlayer() {
        CurrentRole = 0;
        
    }

    public void CalculateTotal()
    {
        switch(CurrentRole)
        {
            case Position.FourthPositionSup:
                total = (roaming * 0.15d + warding * 0.15d + Positioning * 0.15d + laneControl * 0.15d) + (teamWork * 0.06f + fighting * 0.06f + farming * 0.06f + Consistency * 0.06f + decisionMakeing * 0.06f) + (riskTakeing * 0.025f + flair * 0.025f + pushing * 0.025f + mapAwareness * 0.025f);
                Debug.Log(total);
                break;
            case Position.Carry:
                total = (farming * 0.15f + mapAwareness * 0.15f + decisionMakeing * 0.15f + fighting * 0.15f) + (pushing * 0.06f + Consistency * 0.06f + laneControl * 0.06f + Positioning * 0.06f + teamWork * 0.06f) + (riskTakeing * 0.025f + flair * 0.025f + warding * 0.025f + roaming * 0.025f);
                break;             
            case Position.Mid:
                total = (fighting * 0.15f + mapAwareness * 0.15f + laneControl * 0.15f + farming * 0.15f) + (decisionMakeing * 0.06f + roaming * 0.06f + Consistency * 0.06f + teamWork * 0.06f + Positioning * 0.06f) + (riskTakeing * 0.025f + flair * 0.025f + warding * 0.025f + pushing * 0.025f);
                break;
            case Position.Offlane:
                total = (fighting * 0.15f + Positioning * 0.15f + laneControl * 0.15f + Consistency * 0.15f) + (decisionMakeing * 0.06f + farming * 0.06f + roaming * 0.06f + teamWork * 0.06f + pushing * 0.06f) + (riskTakeing * 0.025f + flair * 0.025f + warding * 0.025f + mapAwareness * 0.025f);
                break;
        }
    }

    public void setAll(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l, double m,double n,double o, double p, double q, double r)
    {
        Carry = a;
        Consistency = b;
        decisionMakeing = c;
        farming = d;
        fighting = e;
        flair = f;
        laneControl = g;
        Leadership = h;
        mapAwareness = i;
        Mid = j;
        Offlane = k;
        Positioning = l;
        pushing = m;
        riskTakeing = n;
        roaming = 0;
        Support = p;
        teamWork = q;
        warding = r;
    }    
}


