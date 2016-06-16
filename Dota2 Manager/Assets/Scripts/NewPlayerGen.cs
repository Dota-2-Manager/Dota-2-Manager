using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NewPlayerGen{

    private DotaPlayer a;
    private static int ranseed = 322;
    private System.Random ran = new System.Random(ranseed);

    // Update is called once per frame

    // Role is based on farm priority 1-5
    public DotaPlayer MakeNewRandomPlayerWithSetRole(int p)
    {
        a = new DotaPlayer();
        a.SetPos(p); 
        // default pos was 0 in DotaPlayer constructor
        // Enumerator took care of it and defaulted to FourthPositionSup

        a.setAll(ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20));
        a.CalculateTotal();
        return a;
    }

    public DotaPlayer MakeNewRandomPlayer ()
    {
        a = new DotaPlayer();
        a.setAll(ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20), ran.Next(1, 20));
        a.CalculateTotal();
        return a;
	}
/*

    public DotaPlayer ExistingPlayer(string p)
    {
        a = new DotaPlayer();
        a.setPos(p);
        a.setAll(GameCore.playerData["players"].

                21
                18
                13
                8
                9
                17
                15
                20
                12
                22
                23
                11
                7
                16
                14
                24
                19
                10
                */

/*
0	"name": "Miracle",
1	"country": "Jordan",
2	"age": 19,
3	"team": "OG",
4	"happiness": 19,
5	"greed": 16,
6	"CurrentRole": 2,
6	"pushing": 15,
8	"farming": 18,
9	"fighting": 17,
10	"warding": 8,
11	"Positioning": 14,
12	"mapAwareness": 16,
13	"decisionMakeing": 16,
14	"roaming": 17,
15	"laneControl": 18,
16	"riskTakeing": 15,
17	"flair": 19,
18	"Consistency": 19,
19	"teamWork": 18,
20	"Leadership": 6,
21	"Carry": 4,
22	"Mid": 5,
23	"Offlane": 2,
24	"Support": 1

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
*/
                

    public int RandomNumber(int a, int b)
    {
        Object syncLock = new Object();
        lock (syncLock)
        {
            return ran.Next(a, b);
        }
       
    }

}
