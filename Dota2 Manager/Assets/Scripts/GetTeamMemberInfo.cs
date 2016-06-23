using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts;
public class GetTeamMemberInfo : MonoBehaviour
{
    DotaPlayer selectedPlayer = null;

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
    }

    public void RefreshWithNewData(string memberName)
    {
        Debug.Log("attempting to get data for player: " + memberName);
        GetPlayerStatData(memberName);
        FindPlayerRole(memberName);
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

    }

    public void ChangeThisBar(GameObject csb, double stat)
    {
        Single statratio = (Convert.ToSingle(stat)/20f);
        csb.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(statratio * _defaultBarSize.x , _defaultBarSize.y);
        Vector2 offset = new Vector2((_defaultBarSize.x - (statratio * _defaultBarSize.x))/2, 0);

        csb.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(_defaultBarPos.x - offset.x, csb.transform.GetComponent<RectTransform>().anchoredPosition.y);
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
    }

}
