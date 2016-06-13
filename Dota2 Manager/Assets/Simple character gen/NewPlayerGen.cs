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
		MakeNewPlayer();
		MakeNewPlayer();

        foreach (DotaPlayer player in players)
        {
            Debug.Log(player.playerTotal);
        }

    }
	
	// Update is called once per frame
	void MakeNewPlayer ()
    {
        //a = new DotaPlayer();
		DotaPlayer a = gameObject.AddComponent<DotaPlayer> () as DotaPlayer;
        a.playerName = "fred";
        a.farming = Random.Range(10,25);
        a.lastHitting = Random.Range(10, 25);
        a.denying = Random.Range(10, 25);
        a.Pushing = Random.Range(10, 25);
        a.decisionMaking = Random.Range(10, 25);
        a.rage = Random.Range(10, 25);
        a.playerStress = 0;
        a.CalculatePlayerTotal();
        players.Add(a);
        
	}
		

}
