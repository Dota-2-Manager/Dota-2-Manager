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

    public int RandomNumber(int a, int b)
    {
        Object syncLock = new Object();
        lock (syncLock)
        {
            return ran.Next(a, b);
        }
       
    }

}
