using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using System.Collections.Generic;
using System;

public class GameCore : MonoBehaviour {

	//This are for requesting the teams info
	private string jsonString;
	public static JsonData playerData;
    public static List<DotaPlayer> allPlayers = new List<DotaPlayer>();
	private List<string> playersInTeam = new List<string>();
	public static List<DotaTeam>  teamsInGame = new List<DotaTeam>();
	//private JsonData test;

    public GameObject selectTeamButton;

    public Sprite teamlogo;
    public Image logo;
    public GameObject playercanvis;
    public GameObject teamcanvis;
    public Text playertotal;
    public Text Stress;
    public Text lasthit;
    public Text denying;
    public Text fighting;
    public Text pushing;
    public Text Farming;
    public Text Calm;
    public Text Descisionmakeing;
    public Text Name;
    public Text CashT;
    public Text TeamValue;
    private DotaTeam team = new DotaTeam("newteam");
    public int currentmember = 0;
    public Text TeamPlayers;

    private int Cash;

    private System.Random ran = new System.Random();
    // Use this for initialization
    void Start () {
        ChangetoTeamView();
        Cash = 500000;

		jsonString = File.ReadAllText(Application.dataPath + "/Resources/playersInfo.json");
		playerData = JsonMapper.ToObject (jsonString);
		GetPlayer ("Navi", "name");
		for (int i = 0; i < 5; i++) 
		{
			Debug.Log(playersInTeam[i]);
		}

        RefreshTeamInfoDisplay();

        // pull team list from player list json and generate buttons
        GetTeams();
        // populate list of DotaPlayer type with existing players
        PopulatePlayerList();
        GenerateTeamSelectButtons();
    }

    void LateUpdate()
    {
        if (currentmember == 5)
        {
            currentmember = 0;
        }
        TeamValue.text = "Team total score " + Mathf.Round((float)team.GetTotalValue());
        CashT.text = "$" + Cash;
        Name.text = "Name: " + team.getList()[currentmember].name;
        Descisionmakeing.text = "Decision Makeing: " + team.getList()[currentmember].decisionMakeing.ToString();
        Calm.text = "Risktakeing: " + team.getList()[currentmember].riskTakeing.ToString();
        Farming.text = "Farming: " + team.getList()[currentmember].farming.ToString();
        pushing.text = "Pushing: " + team.getList()[currentmember].pushing.ToString();
        fighting.text = "Fighting: " + team.getList()[currentmember].fighting.ToString();
        playertotal.text = "Players Total Ability: " + Mathf.Round((float)team.getList()[currentmember].total).ToString();
        
    }
	
	// Update is called once per frame
	public void ChangePlayer ()
    {
        if (currentmember == 5) 
        {
            currentmember = 0;
        }
        else
        {
            currentmember++;
        }
	}

    public void ChangetoTeamView()
    {
        logo.sprite = Resources.Load<Sprite>("Images/" + ran.Next(1,4));
        playercanvis.SetActive(false);
        teamcanvis.SetActive(true);
        
    }

    public void ChangetoPlayerView()
    {
        playercanvis.SetActive(true);
        teamcanvis.SetActive(false);

    }


    public void VsRandomTeam()
    {
        DotaTeam Enemyteam = new DotaTeam("RandomTeam");

        if (Enemyteam.GetTotalValue() < team.GetTotalValue())
        {
            double a = team.GetTotalValue() * (100 / Enemyteam.GetTotalValue()) / 100;
            double percentage = 0.5d + (a - 1);
            if (ran.NextDouble() >= percentage)
            {
                Debug.Log("Your team lost");
            }
            else
            {
                Debug.Log("Your team won");
            }
        }
        else
        {
            double a = Enemyteam.GetTotalValue() * (100 / team.GetTotalValue()) / 100;
            double percentage = 0.5d + (a - 1);
            if (ran.NextDouble() >= percentage)
            {
                Debug.Log("Your team lost");
            }
            else
            {
                Debug.Log("Your team won");
            }
        }

    }

    // populates a list of DotaPlayers with data from json
    void PopulatePlayerList()
    {
		for(int i = 0; i< playerData["players"].Count; i++)
        {
            DotaPlayer p = new DotaPlayer();
            p.SetPos((Int32.Parse(Convert.ToString(playerData["players"][i]["CurrentRole"]))));

            int a_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Carry"]));
            int b_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Consistency"]));
            int c_ = Int32.Parse(Convert.ToString(playerData["players"][i]["decisionMakeing"]));
            int d_ = Int32.Parse(Convert.ToString(playerData["players"][i]["farming"]));
            int e_ = Int32.Parse(Convert.ToString(playerData["players"][i]["fighting"]));
            int f_ = Int32.Parse(Convert.ToString(playerData["players"][i]["flair"]));
            int g_ = Int32.Parse(Convert.ToString(playerData["players"][i]["laneControl"]));
            int h_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Leadership"]));
            int i_ = Int32.Parse(Convert.ToString(playerData["players"][i]["mapAwareness"]));
            int j_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Mid"]));
            int k_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Offlane"]));
            int l_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Positioning"]));
            int m_ = Int32.Parse(Convert.ToString(playerData["players"][i]["pushing"]));
            int n_ = Int32.Parse(Convert.ToString(playerData["players"][i]["riskTakeing"]));
            int o_ = Int32.Parse(Convert.ToString(playerData["players"][i]["roaming"]));
            int p_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Support"]));
            int q_ = Int32.Parse(Convert.ToString(playerData["players"][i]["teamWork"]));
            int r_ = Int32.Parse(Convert.ToString(playerData["players"][i]["warding"]));

            string s_ = Convert.ToString(playerData["players"][i]["team"]);
            string t_ = Convert.ToString(playerData["players"][i]["name"]);
            
            p.setAll(a_, b_, c_, d_, e_, f_, g_, h_, i_, j_, k_, l_, m_, n_, o_, p_, q_, r_);
            p.SetTeam(s_);
            p.SetName(t_);
            p.CalculateTotal();
            allPlayers.Add(p);
        }
    }

	JsonData GetPlayer(string team, string type)
	{
		playersInTeam.Clear ();
		for(int i = 0; i< playerData["players"].Count; i++)
		{
			if(playerData["players"][i]["team"].ToString() == team)
			{
				//test = playerData ["players"] [i];
				playersInTeam.Add (Convert.ToString(playerData["players"][i][type]));
			}
		}

		//Return the first position as returning null seems to pause unity
		return playerData["players"][0];
	}

    public void GetTeams()
    {
        teamsInGame.Clear();

        List<string> foundTeams = new List<string>();

		for(int i = 0; i < playerData["players"].Count; i++)
        {
            string teamName = playerData["players"][i]["team"].ToString();

            DotaTeam t = new DotaTeam(teamName);
            if (!foundTeams.Contains(teamName))
            {
                foundTeams.Add(teamName);
                teamsInGame.Add(t);
            }
        }

    }

    public void GenerateTeamSelectButtons()
    {
        for(int i = 0; i < teamsInGame.Count; i++)
        {
            GameObject b = Instantiate(selectTeamButton);

            //positioning
            b.transform.SetParent(teamcanvis.transform, false);
            b.transform.Translate(0,-20*i,0);

            // set text
            b.transform.GetChild(0).GetComponent<Text>().text = teamsInGame[i].GetTeamName();
            // doesnt work if it uses just the index?
            // workaround = use string
            string s = "selected " + teamsInGame[i].GetTeamName() + " index " + i;
            b.GetComponent<Button>().onClick.AddListener(() => SelectTeam(s));
        }
    }

    public void SelectTeam(string s)
    {
        int index = Int32.Parse(s.Substring(s.Length - 1, 1));
        team = new DotaTeam(teamsInGame[index].GetTeamName());
        Debug.Log("selected " + team.GetTeamName());
        RefreshTeamInfoDisplay();
    }

    public void RefreshTeamInfoDisplay()
    {
        TeamPlayers.text = "Team Stats:\n";
        foreach (DotaPlayer member in team.getList()) {
            //Debug.Log(member.total); //not updating!
            // position and rating
            TeamPlayers.text = TeamPlayers.text + member.name + " " + member.GetPos() + " " + Math.Round((float)member.total) + "\n";
        }
    }
}

