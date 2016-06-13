using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameCore : MonoBehaviour {

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
    private DotaTeam team = new DotaTeam("NewBee");
    public int currentmember = 0;

    private int Cash;

    private System.Random ran = new System.Random();
    // Use this for initialization
    void Start () {
        ChangetoTeamView();
        Cash = 500000;
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
        Descisionmakeing.text = "Decision Makeing: " + team.getList()[currentmember].getdecisionMakeing().ToString();
        Calm.text = "Risktakeing: " + team.getList()[currentmember].getrisktakeing().ToString();
        Farming.text = "Farming: " + team.getList()[currentmember].getfarming().ToString();
        pushing.text = "Pushing: " + team.getList()[currentmember].getpushing().ToString();
        fighting.text = "Fighting: " + team.getList()[currentmember].getfighting().ToString();
        playertotal.text = "Players Total Ability" + Mathf.Round((float)team.getList()[currentmember].total).ToString();
        
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

}
