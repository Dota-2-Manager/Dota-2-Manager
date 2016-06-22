using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetTeamMemberInfo : MonoBehaviour
{
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

    public Button _ttb;
    // gets default bar size from first bar
    public Vector2 _defaultBarSize;
    public Vector2 _defaultBarPos;

    List<DotaPlayer> playerList = GameData._team.GetList();

    void Start()
    {
        w = Screen.width/2;
        h = Screen.height/2;
        _ttb.GetComponent<Button>().onClick.AddListener(() => RefreshWithNewData("Miracle"));

        // used for referencing original x position

        GameData._team = GameData._teamsInGame[0];

    }

    public void GetPlayerStatData(string n)
    {
        DotaPlayer selectedPlayer = null;
        foreach (DotaPlayer p in playerList)
        {
            if (p.name == n)
            {
                selectedPlayer = p;
                break;

            }

        }
        selectedPlayer = playerList[0];
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
        GetPlayerStatData(memberName);
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

    }

    public void ChangeThisBar(GameObject csb, double stat)
    {
        Single statratio = (Convert.ToSingle(stat)/20f);
        _defaultBarPos = csb.transform.GetComponent<RectTransform>().anchoredPosition;
        _defaultBarSize = csb.transform.GetComponent<RectTransform>().sizeDelta;
        csb.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(statratio * _defaultBarSize.x , _defaultBarSize.y);
        Vector2 offset = new Vector2((_defaultBarSize.x - (statratio * _defaultBarSize.x))/2, 0);

        csb.transform.GetComponent<RectTransform>().anchoredPosition = _defaultBarPos - offset;
    }

}
