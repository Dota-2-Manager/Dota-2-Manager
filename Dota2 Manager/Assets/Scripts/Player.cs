using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class DotaPlayer{


    public string name;
    private int age;
    private Position CurrentRole;

    //newStats v0.1
    public double pushing { get; set; }
    public double farming { get; set; }
    public double fighting { get; set; }
    public double warding { get; set; }
    public double Positioning { get; set; }
    public double mapAwareness { get; set; }
    public double decisionMakeing { get; set; }
    public double roaming { get; set; }
    public double laneControl { get; set; }
    public double riskTakeing { get; set; }
    public double flair { get; set; }
    public double Consistency { get; set; }
    public double teamWork { get; set; }
    public double Leadership { get; set; }

    //positions
    public double Carry { get; set; }
    public double Mid { get; set; }
    public double Offlane { get; set; }
    public double Support { get; set; }

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
        roaming = o;
        Support = p;
        teamWork = q;
        warding = r;
    }    

    public void SetPos(int p)
        // sets a position based on farm priority
    {
        switch (p)
        {
            case 1:
                CurrentRole = Position.Carry;
                break;
            case 2:
                CurrentRole = Position.Mid;
                break;
            case 3:
                CurrentRole = Position.Offlane;
                break;
            case 4:
                CurrentRole = Position.FourthPositionSup;
                break;
            case 5:
                CurrentRole = Position.FifthPositionSup;
                break;
        }
    }


    public Position GetPos()
    {
        return CurrentRole;
    }
}


