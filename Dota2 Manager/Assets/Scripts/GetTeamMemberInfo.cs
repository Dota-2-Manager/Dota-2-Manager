using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTeamMemberInfo : MonoBehaviour
{
    DotaPlayer selectedPlayer;

    public GameObject _statbar_t1_1;
    public GameObject _statbar_t1_2;
    public GameObject _statbar_t1_3;
    public GameObject _statbar_t1_4;

    public GameObject _statbar_t2_1;
    public GameObject _statbar_t2_2;
    public GameObject _statbar_t2_3;
    public GameObject _statbar_t2_4;
    public GameObject _statbar_t2_5;

    public GameObject _statbar_t3_1;
    public GameObject _statbar_t3_2;
    public GameObject _statbar_t3_3;
    public GameObject _statbar_t3_4;

    public GameObject _posbar_1;
    public GameObject _posbar_2;
    public GameObject _posbar_3;
    public GameObject _posbar_4;

    public Text nameText;

    double stat_t1_1;
    double stat_t1_2;
    double stat_t1_3;
    double stat_t1_4;

    double stat_t2_1;
    double stat_t2_2;
    double stat_t2_3;
    double stat_t2_4;
    double stat_t2_5;

    double stat_t3_1;
    double stat_t3_2;
    double stat_t3_3;
    double stat_t3_4;

    int w = 200;
    int h = 100;

    public Button _btn_player_1;
    public Button _btn_player_2;
    public Button _btn_player_3;
    public Button _btn_player_4;
    public Button _btn_player_5;
    // gets default bar size from first bar
    Vector2 _defaultBarSize;
    Vector2 _defaultBarPos;

    Vector2 _defaultPosBarSize;
    Vector2 _defaultPosBarPos;

    List<DotaPlayer> playerList;

    public Button _btn_role_1;
    public Button _btn_role_2;
    public Button _btn_role_3;
    public Button _btn_role_4;


    void Start()
    {
        w = Screen.width/2;
        h = Screen.height/2;
        // used for referencing original x position
        _defaultBarSize = _statbar_t1_1.transform.GetComponent<RectTransform>().sizeDelta;
        _defaultBarPos = _statbar_t1_1.transform.GetComponent<RectTransform>().anchoredPosition;

        _defaultPosBarSize = _posbar_1.transform.GetComponent<RectTransform>().sizeDelta;
        _defaultPosBarPos = _posbar_1.transform.GetComponent<RectTransform>().anchoredPosition;

        GameData._team = GameData._teamsInGame[0];
        // Debug.Log(GameData._team.GetTeamName());
        // Debug.Log(GameData._team.GetList());
        playerList = GameData._team.GetList();
        SetButtonTextToPlayerName(_btn_player_1, 0);
        SetButtonTextToPlayerName(_btn_player_2, 1);
        SetButtonTextToPlayerName(_btn_player_3, 2);
        SetButtonTextToPlayerName(_btn_player_4, 3);
        SetButtonTextToPlayerName(_btn_player_5, 4);

        AddListenerToButton(_btn_player_1, 0);
        AddListenerToButton(_btn_player_2, 1);
        AddListenerToButton(_btn_player_3, 2);
        AddListenerToButton(_btn_player_4, 3);
        AddListenerToButton(_btn_player_5, 4);


        // role button stuff
        _btn_role_1.GetComponent<Button>().onClick.AddListener(() => ReassignPlayerRole(1));
        _btn_role_2.GetComponent<Button>().onClick.AddListener(() => ReassignPlayerRole(2));
        _btn_role_3.GetComponent<Button>().onClick.AddListener(() => ReassignPlayerRole(3));
        _btn_role_4.GetComponent<Button>().onClick.AddListener(() => ReassignPlayerRole(4));

        Debug.Log(playerList[1].GetPos());
        DotaPlayer sdf = new DotaPlayer();
        sdf.SetPos(2);
        Debug.Log((int)sdf.GetPos());
        sdf.SetPos(3);
        Debug.Log((int)sdf.GetPos());
        sdf.SetPos(4);
        Debug.Log((int)sdf.GetPos());
        sdf.SetPos(5);
        Debug.Log((int)sdf.GetPos());

        // defaults the view to a player (TODO: set this to team captain)
        RefreshWithNewData(playerList[1].name);

    }

    public void AddListenerToButton(Button b, int i)
    {
        DotaPlayer p = playerList[i];
        b.GetComponent<Button>().onClick.AddListener(() => RefreshWithNewData(p.name));
    }

    public void GetPlayerStatData(string n)
    {
        foreach (DotaPlayer p in playerList)
        {
            if (p.name == n)
            {
                selectedPlayer = p;
                break;

            }

        }

        selectedPlayer = playerList.Find(i => i.name == n);

        ReassignStatImportance(selectedPlayer);
        UpdateBarText(selectedPlayer);

    }

    // function invoked when each player is selected
    public void RefreshWithNewData(string memberName)
    {
        Debug.Log("attempting to get data for player: " + memberName);

        // this will also set SelectedPlayer
        GetPlayerStatData(memberName);

        //FindPlayerRole(memberName); // redundant?
        //Debug.Log(_statbar_t1_1.transform.GetComponent<RectTransform>());

        ChangeThisBar(_statbar_t1_1, stat_t1_1);
        ChangeThisBar(_statbar_t1_2, stat_t1_2);
        ChangeThisBar(_statbar_t1_3, stat_t1_3);
        ChangeThisBar(_statbar_t1_4, stat_t1_4);

        ChangeThisBar(_statbar_t2_1, stat_t2_1);
        ChangeThisBar(_statbar_t2_2, stat_t2_2);
        ChangeThisBar(_statbar_t2_3, stat_t2_3);
        ChangeThisBar(_statbar_t2_4, stat_t2_4);
        ChangeThisBar(_statbar_t2_5, stat_t2_5);

        ChangeThisBar(_statbar_t3_1, stat_t3_1);
        ChangeThisBar(_statbar_t3_2, stat_t3_2);
        ChangeThisBar(_statbar_t3_3, stat_t3_3);
        ChangeThisBar(_statbar_t3_4, stat_t3_4);

        DisableCurrentRoleBtn((int)playerList.Find(i => i.name == memberName).GetPos());

        ChangeThisPosBar(_posbar_1, selectedPlayer.Carry);
        ChangeThisPosBar(_posbar_2, selectedPlayer.Mid);
        ChangeThisPosBar(_posbar_3, selectedPlayer.Offlane);
        ChangeThisPosBar(_posbar_4, selectedPlayer.Support);

        nameText.GetComponent<Text>().text = selectedPlayer.name;

    }

    public void ChangeThisPosBar(GameObject csb, double stat)
    {
        Single statratio = (Convert.ToSingle(stat)/5f);
        csb.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(_defaultPosBarSize.x , statratio * _defaultPosBarSize.y);
        Vector2 offset = new Vector2(0, (_defaultPosBarSize.y - statratio * _defaultPosBarSize.y)/2);

        csb.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(csb.transform.GetComponent<RectTransform>().anchoredPosition.x, _defaultPosBarPos.y - offset.y);

    }

    public void ChangeThisBar(GameObject csb, double stat)
    {
        Single statratio = (Convert.ToSingle(stat)/20f);
        csb.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(statratio * _defaultBarSize.x , _defaultBarSize.y);
        Vector2 offset = new Vector2((_defaultBarSize.x - (statratio * _defaultBarSize.x))/2, 0);

        csb.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(_defaultBarPos.x - offset.x, csb.transform.GetComponent<RectTransform>().anchoredPosition.y);
        foreach (Transform child in csb.transform)
        {
            foreach (Transform child2 in child)
            {
            child2.GetComponent<Text>().text = stat.ToString();
            }

        }
    }

    public void SetButtonTextToPlayerName(Button b, int i)
    {
        b.GetComponentInChildren<Text>().text = playerList[i].name;
    }

    public void FindPlayerRole(string p)
    {
        string role = playerList.Find(i => i.name == p).GetPos().ToString();


        Debug.Log(role);
    }

    public void DisableCurrentRoleBtn(int i)
    {
        _btn_role_1.interactable = true;
        _btn_role_2.interactable = true;
        _btn_role_3.interactable = true;
        _btn_role_4.interactable = true;

        switch(i)
        {
            case 1:
                _btn_role_1.interactable = false;
                break;
            case 2:
                _btn_role_2.interactable = false;
                break;
            case 3:
                _btn_role_3.interactable = false;
                break;
            case 4:
                _btn_role_4.interactable = false;
                break;
            case 5:
                // 4 and 5 pos considered support together for now
                _btn_role_4.interactable = false;
                break;
        }
    }


    public void ReassignPlayerRole(int pos)
    {
        // TODO: handle pos4 and pos5 (more of a general issue regarding
        // whether pos4 and po5 should be cosidered same or unique)
        // find the player with the desired pos. Then, sets that player's pos to the selected player's pos
        DotaPlayer switchedout = playerList.Find(x => (int)x.GetPos() == pos);
        switchedout.SetPos((int)selectedPlayer.GetPos());
        selectedPlayer.SetPos(pos);
        Debug.Log("switched roles. " + selectedPlayer.name + " is now " + selectedPlayer.GetPos() + ", " + switchedout.name + " is now " + switchedout.GetPos());
        DisableCurrentRoleBtn((int)selectedPlayer.GetPos());
        RefreshWithNewData(selectedPlayer.name);
    }

    public void ReassignStatImportance(DotaPlayer p)
    {
        switch ((int)p.GetPos())
        {
            case 1:
                // carry calcs
                stat_t1_1 = selectedPlayer.farming;
                stat_t1_2 = selectedPlayer.mapAwareness;
                stat_t1_3 = selectedPlayer.decisionMakeing;
                stat_t1_4 = selectedPlayer.fighting;

                stat_t2_1 = selectedPlayer.pushing;
                stat_t2_2 = selectedPlayer.Consistency;
                stat_t2_3 = selectedPlayer.laneControl;
                stat_t2_4 = selectedPlayer.Positioning;
                stat_t2_5 = selectedPlayer.teamWork;

                stat_t3_1 = selectedPlayer.riskTakeing;
                stat_t3_2 = selectedPlayer.flair;
                stat_t3_3 = selectedPlayer.warding;
                stat_t3_4 = selectedPlayer.roaming;
                break;
            case 2:
                // mid calcs
                stat_t1_1 = selectedPlayer.laneControl;
                stat_t1_2 = selectedPlayer.farming;
                stat_t1_3 = selectedPlayer.mapAwareness;
                stat_t1_4 = selectedPlayer.fighting;

                stat_t2_1 = selectedPlayer.Consistency;
                stat_t2_2 = selectedPlayer.decisionMakeing;
                stat_t2_3 = selectedPlayer.roaming;
                stat_t2_4 = selectedPlayer.Positioning;
                stat_t2_5 = selectedPlayer.teamWork;

                stat_t3_1 = selectedPlayer.riskTakeing;
                stat_t3_2 = selectedPlayer.flair;
                stat_t3_3 = selectedPlayer.pushing;
                stat_t3_4 = selectedPlayer.warding;
                break;
            case 3:
                // offlane calcs
                stat_t1_1 = selectedPlayer.fighting;
                stat_t1_2 = selectedPlayer.Positioning;
                stat_t1_3 = selectedPlayer.laneControl;
                stat_t1_4 = selectedPlayer.Consistency;

                stat_t2_1 = selectedPlayer.decisionMakeing;
                stat_t2_2 = selectedPlayer.farming;
                stat_t2_3 = selectedPlayer.roaming;
                stat_t2_4 = selectedPlayer.teamWork;
                stat_t2_5 = selectedPlayer.pushing;

                stat_t3_1 = selectedPlayer.mapAwareness;
                stat_t3_2 = selectedPlayer.riskTakeing;
                stat_t3_3 = selectedPlayer.flair;
                stat_t3_4 = selectedPlayer.warding;
                break;
            case 4:
                // support calcs
                stat_t1_1 = selectedPlayer.roaming;
                stat_t1_2 = selectedPlayer.warding;
                stat_t1_3 = selectedPlayer.Positioning;
                stat_t1_4 = selectedPlayer.laneControl;

                stat_t2_1 = selectedPlayer.teamWork;
                stat_t2_2 = selectedPlayer.fighting;
                stat_t2_3 = selectedPlayer.farming;
                stat_t2_4 = selectedPlayer.Consistency;
                stat_t2_5 = selectedPlayer.decisionMakeing;

                stat_t3_1 = selectedPlayer.riskTakeing;
                stat_t3_2 = selectedPlayer.flair;
                stat_t3_3 = selectedPlayer.pushing;
                stat_t3_4 = selectedPlayer.mapAwareness;
                break;
            case 5:
                // support calcs (same as 4)
                stat_t1_1 = selectedPlayer.roaming;
                stat_t1_2 = selectedPlayer.warding;
                stat_t1_3 = selectedPlayer.Positioning;
                stat_t1_4 = selectedPlayer.laneControl;

                stat_t2_1 = selectedPlayer.teamWork;
                stat_t2_2 = selectedPlayer.fighting;
                stat_t2_3 = selectedPlayer.farming;
                stat_t2_4 = selectedPlayer.Consistency;
                stat_t2_5 = selectedPlayer.decisionMakeing;

                stat_t3_1 = selectedPlayer.riskTakeing;
                stat_t3_2 = selectedPlayer.flair;
                stat_t3_3 = selectedPlayer.pushing;
                stat_t3_4 = selectedPlayer.mapAwareness;
                break;
        }


    }

    public void UpdateBarText(DotaPlayer p)
    {
        switch ((int)p.GetPos())
        {
            case 1:
                // carry calcs
                _statbar_t1_1.GetComponentInChildren<Text>().text = "FARMING";
                _statbar_t1_2.GetComponentInChildren<Text>().text = "MAP AWARENESS";
                _statbar_t1_3.GetComponentInChildren<Text>().text = "DECISION MAKING";
                _statbar_t1_4.GetComponentInChildren<Text>().text = "FIGHTING";

                _statbar_t2_1.GetComponentInChildren<Text>().text = "PUSHING";
                _statbar_t2_2.GetComponentInChildren<Text>().text = "CONSISTENCY";
                _statbar_t2_3.GetComponentInChildren<Text>().text = "LANE CONTROL";
                _statbar_t2_4.GetComponentInChildren<Text>().text = "POSITIONING";
                _statbar_t2_5.GetComponentInChildren<Text>().text = "TEAMWORK";

                _statbar_t3_1.GetComponentInChildren<Text>().text = "RISK TAKING";
                _statbar_t3_2.GetComponentInChildren<Text>().text = "FLAIR";
                _statbar_t3_3.GetComponentInChildren<Text>().text = "WARDING";
                _statbar_t3_4.GetComponentInChildren<Text>().text = "ROAMING";
                break;
            case 2:
                _statbar_t1_1.GetComponentInChildren<Text>().text = "LANE CONTROL";
                _statbar_t1_2.GetComponentInChildren<Text>().text = "FARMING";
                _statbar_t1_3.GetComponentInChildren<Text>().text = "MAP AWARENESS";
                _statbar_t1_4.GetComponentInChildren<Text>().text = "FIGHTING";

                _statbar_t2_1.GetComponentInChildren<Text>().text = "CONSISTENCY";
                _statbar_t2_2.GetComponentInChildren<Text>().text = "DECISION MAKING";
                _statbar_t2_3.GetComponentInChildren<Text>().text = "ROAMING";
                _statbar_t2_4.GetComponentInChildren<Text>().text = "POSITIONING";
                _statbar_t2_5.GetComponentInChildren<Text>().text = "TEAMWORK";

                _statbar_t3_1.GetComponentInChildren<Text>().text = "RISK TAKING";
                _statbar_t3_2.GetComponentInChildren<Text>().text = "FLAIR";
                _statbar_t3_3.GetComponentInChildren<Text>().text = "PUSHING";
                _statbar_t3_4.GetComponentInChildren<Text>().text = "WARDING";
                break;
            case 3:
                _statbar_t1_1.GetComponentInChildren<Text>().text = "FIGHTING";
                _statbar_t1_2.GetComponentInChildren<Text>().text = "POSITIONING";
                _statbar_t1_3.GetComponentInChildren<Text>().text = "LANE CONTROL";
                _statbar_t1_4.GetComponentInChildren<Text>().text = "CONSISTENCY";

                _statbar_t2_1.GetComponentInChildren<Text>().text = "DECISION MAKING";
                _statbar_t2_2.GetComponentInChildren<Text>().text = "FARMING";
                _statbar_t2_3.GetComponentInChildren<Text>().text = "ROAMING";
                _statbar_t2_4.GetComponentInChildren<Text>().text = "TEAMWORK";
                _statbar_t2_5.GetComponentInChildren<Text>().text = "PUSHING";

                _statbar_t3_1.GetComponentInChildren<Text>().text = "MAP AWARENESS";
                _statbar_t3_2.GetComponentInChildren<Text>().text = "RISK TAKING";
                _statbar_t3_3.GetComponentInChildren<Text>().text = "FLAIR";
                _statbar_t3_4.GetComponentInChildren<Text>().text = "WARDING";
                break;
            case 4:
                _statbar_t1_1.GetComponentInChildren<Text>().text = "ROAMING";
                _statbar_t1_2.GetComponentInChildren<Text>().text = "WARDING";
                _statbar_t1_3.GetComponentInChildren<Text>().text = "POSITIONING";
                _statbar_t1_4.GetComponentInChildren<Text>().text = "LANE CONTROL";

                _statbar_t2_1.GetComponentInChildren<Text>().text = "TEAMWORk";
                _statbar_t2_2.GetComponentInChildren<Text>().text = "FIGHTING";
                _statbar_t2_3.GetComponentInChildren<Text>().text = "FARMING";
                _statbar_t2_4.GetComponentInChildren<Text>().text = "CONSISTENCY";
                _statbar_t2_5.GetComponentInChildren<Text>().text = "DECISION MAKING";

                _statbar_t3_1.GetComponentInChildren<Text>().text = "RISK TAKING";
                _statbar_t3_2.GetComponentInChildren<Text>().text = "FLAIR";
                _statbar_t3_3.GetComponentInChildren<Text>().text = "PUSHING";
                _statbar_t3_4.GetComponentInChildren<Text>().text = "MAP AWARENESS";
                break;
            case 5:
                _statbar_t1_1.GetComponentInChildren<Text>().text = "ROAMING";
                _statbar_t1_2.GetComponentInChildren<Text>().text = "WARDING";
                _statbar_t1_3.GetComponentInChildren<Text>().text = "POSITIONING";
                _statbar_t1_4.GetComponentInChildren<Text>().text = "LANE CONTROL";

                _statbar_t2_1.GetComponentInChildren<Text>().text = "TEAMWORk";
                _statbar_t2_2.GetComponentInChildren<Text>().text = "FIGHTING";
                _statbar_t2_3.GetComponentInChildren<Text>().text = "FARMING";
                _statbar_t2_4.GetComponentInChildren<Text>().text = "CONSISTENCY";
                _statbar_t2_5.GetComponentInChildren<Text>().text = "DECISION MAKING";

                _statbar_t3_1.GetComponentInChildren<Text>().text = "RISK TAKING";
                _statbar_t3_2.GetComponentInChildren<Text>().text = "FLAIR";
                _statbar_t3_3.GetComponentInChildren<Text>().text = "PUSHING";
                _statbar_t3_4.GetComponentInChildren<Text>().text = "MAP AWARENESS";
                break;
        }
    }

}
