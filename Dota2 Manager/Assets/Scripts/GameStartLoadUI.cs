using System;
using UnityEngine;
using UnityEngine.UI;
public class GameStartLoadUI : MonoBehaviour
{
    public GameObject _selectTeamButton;
    public GameObject _mainCanvas;
    public Text _teamBioText;

    void Start()
    {
        GenerateTeamSelectButtons();
    }

    public void GenerateTeamSelectButtons()
    {
        for(int i = 0; i < GameData._teamsInGame.Count; i++)
        {
            GameObject b = Instantiate(_selectTeamButton);

            //positioning
            b.transform.SetParent(_mainCanvas.transform, false);
            //TODO: screen size formula for offset
            // not sure which is better in terms of screen size scaling, this:
            Single h = Convert.ToSingle(Screen.height);
            b.transform.Translate(0,-h/16*i,0);
            // or this:
            b.transform.Translate(0,-50*i,0);

            // set text
            b.transform.GetChild(0).GetComponent<Text>().text = GameData._teamsInGame[i].GetTeamName();
            // doesnt work if it uses just the index?
            // workaround = use string
            var teamindex = i;
            b.GetComponent<Button>().onClick.AddListener(() => SelectTeam(teamindex));
        }
    }

    public void SelectTeam(int i)
    {
        
        GameData._team =new DotaTeam(GameData._teamsInGame[i].GetTeamName());
        Debug.Log("selected " + GameData._team.GetTeamName());
        _teamBioText.text = "";
        for (int j = 0; j < 100; j++)
        {
            _teamBioText.text = _teamBioText.text + GameData._team.GetTeamName() + " bio text ";
        }
    }
}
