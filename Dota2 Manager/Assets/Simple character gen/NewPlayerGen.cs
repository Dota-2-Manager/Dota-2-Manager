using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NewPlayerGen : MonoBehaviour {

    public List<DotaPlayer> players;
    public DotaPlayer a;
    // Use this for initialization
    void Start () {
        players = new List<DotaPlayer>();
        MakeNewPlayer();
        MakeNewPlayer();
        MakeNewPlayer();

        foreach (DotaPlayer player in players)
        {
            Debug.Log(player.total);
        }
       

    }
	
	// Update is called once per frame
	void MakeNewPlayer ()
    {
        a = new DotaPlayer();
        a.name = "fred";
        a.farming = Random.Range(10,25);
        a.lastHitting = Random.Range(10, 25);
        a.denying = Random.Range(10, 25);
        a.Pushing = Random.Range(10, 25);
        a.decisionMaking = Random.Range(10, 25);
        a.rage = Random.Range(10, 25);
        a.stress = 0;
        a.CalculateTotal();
        players.Add(a);
        
	}

}
