using UnityEngine;
using System.Collections;

public class DotaPlayer{


    public string name;
    private int age;
    private double CurrentRole;

    //newStats v0.1
    private double pushing;
    private double farming;
    private double fighting;
    private double warding;
    private double Positioning;
    private double mapAwareness;
    private double decisionMakeing;
    private double roaming;
    private double laneControl;
    private double riskTakeing;
    private double flair;
    private double Consistency;
    private double teamWork;
    private double Leadership;

    //positions
    private double Carry;
    private double Mid;
    private double Offlane;
    private double Support;

    //total
    public double total;

	//Stats for v0.2
	private double happiness;
	private double greed;

    public DotaPlayer() {
        CurrentRole = 0;
        
    }

    public void CalculateTotal()
    {
        if (CurrentRole == 0)
        {
            //suport
            total = (roaming * 0.15d + warding * 0.15d + Positioning * 0.15d + laneControl * 0.15d) + (teamWork * 0.06f + fighting * 0.06f + farming * 0.06f + Consistency * 0.06f + decisionMakeing * 0.06f) + (riskTakeing * 0.025f + flair * 0.025f + pushing * 0.025f + mapAwareness * 0.025f);
            Debug.Log(total);
        }
        else if (CurrentRole == 1)
        {
            //carry
            total = (farming * 0.15f + mapAwareness * 0.15f + decisionMakeing * 0.15f + fighting * 0.15f) + (pushing * 0.06f + Consistency * 0.06f + laneControl * 0.06f + Positioning * 0.06f + teamWork * 0.06f) + (riskTakeing * 0.025f + flair * 0.025f + warding * 0.025f + roaming * 0.025f);
        }
        else if (CurrentRole == 2)
        {
            //oflane
            total = (fighting * 0.15f + Positioning * 0.15f + laneControl * 0.15f + Consistency * 0.15f) + (decisionMakeing * 0.06f + farming * 0.06f + roaming * 0.06f + teamWork * 0.06f + pushing * 0.06f) + (riskTakeing * 0.025f + flair * 0.025f + warding * 0.025f + mapAwareness * 0.025f);
        }
        else
        {
            //mid
            total = (fighting * 0.15f + mapAwareness * 0.15f + laneControl * 0.15f + farming * 0.15f) + (decisionMakeing * 0.06f + roaming * 0.06f + Consistency * 0.06f + teamWork * 0.06f + Positioning * 0.06f) + (riskTakeing * 0.025f + flair * 0.025f + warding * 0.025f + pushing * 0.025f);
        }
    }

    public void setAll(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l, double m,double n,double o, double p, double q, double r)
    {
        setCarry(a);
        setConsistency(b);
        setdecisionMakeing(c);
        setfarming(d);
        setfighting(e);
        setflair(f);
        setlaneControl(g);
        setLeadership(h);
        setmapAwareness(i);
        setMid(j);
        setOfflane(k);
        setPositioning(l);
        setpushing(m);
        setrisktakeing(n);
        setRoaming(o);
        setSupport(p);
        setteamwork(q);
        setWarding(r);
    }


    //setters

    public void setpushing(double num)
    {
        pushing = num;
    }
    public void setfarming(double num)
    {
        farming = num;
    }
    public void setfighting(double num)
    {
        fighting = num;
    }
    public void setWarding(double num)
    {
        warding = num;
    }
    public void setPositioning(double num)
    {
        Positioning = num;
    }
    public void setmapAwareness(double num)
    {
        mapAwareness = num;
    }
    public void setRoaming(double num)
    {
        roaming = num;
    }
    public void setdecisionMakeing(double num)
    {
        decisionMakeing = num;
    }
    public void setlaneControl(double num)
    {
        laneControl = num;
    }
    public void setrisktakeing(double num)
    {
        riskTakeing = num;
    }
    public void setflair(double num)
    {
        flair = num;
    }
    public void setConsistency(double num)
    {
        Consistency = num;
    }
    public void setteamwork(double num)
    {
        teamWork = num;
    }
    public void setLeadership(double num)
    {
        Leadership = num;
    }
    public void setCarry(double num)
    {
        Carry = num;
    }
    public void setMid(double num)
    {
        Mid = num;
    }
    public void setOfflane(double num)
    {
        Offlane = num;
    }
    public void setSupport(double num)
    {
        Support = num;
    }

    //getters

    public double getpushing()
    {
        return pushing;
    }
    public double getfarming()
    {
        return farming;
    }
    public double getfighting()
    {
        return fighting;
    }
    public double getWarding()
    {
        return warding;
    }
    public double getPositioning()
    {
        return Positioning;
    }
    public double getmapAwareness()
    {
        return mapAwareness;
    }
    public double getRoaming()
    {
        return roaming;
    }
    public double getdecisionMakeing()
    {
        return decisionMakeing;
    }
    public double getlaneControl()
    {
        return laneControl;
    }
    public double getrisktakeing()
    {
        return riskTakeing;
    }
    public double getflair()
    {
        return flair;
    }
    public double getConsistency()
    {
        return Consistency;
    }
    public double getteamwork()
    {
        return teamWork;
    }
    public double getLeadership()
    {
        return Leadership;
    }
    public double getCarry()
    {
        return Carry;
    }
    public double getMid()
    {
        return Mid;
    }
    public double getOfflane()
    {
        return Offlane;
    }
    public double getSupport()
    {
        return Support;
    }
}


