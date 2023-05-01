using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RefereeController : MonoBehaviour
{
    private Monster theMonster;
    public GameObject playerGO;
    public GameObject monsterGO;
    public TextMeshPro monsterSB;
    public TextMeshPro playerSB;
    private DeathMatch theMatch;
    public GameObject fightJukeBox;
    public GameObject winnerJukeBox;
    public GameObject loserJukeBox;


    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("goblin");
        this.updateScore();
        this.winnerJukeBox.SetActive(false);
        this.loserJukeBox.SetActive(false);
        this.theMatch = new DeathMatch(MasterData.p, this.theMonster, this.playerGO, this.monsterGO, this);
        MasterData.playerShouldAttack = true;
        StartCoroutine(DelayBeforeFight());
    }

    public void playWinnerMusic()
    {
        this.fightJukeBox.SetActive(false);
        this.winnerJukeBox.SetActive(true);
        //StartCoroutine(ShowDungeonScene());
    }

    public void playLoserMusic()
    {
        this.fightJukeBox.SetActive(false);
        this.loserJukeBox.SetActive(true);
    }

    public void updateScore()
    {
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterData.p.getData();
    }

    IEnumerator DelayBeforeFight()
    {
        MasterData.canGetIntoFight = false;
        yield return new WaitForSeconds(0.5f);
        this.theMatch.fight();
    }
    /*
    IEnumerator ShowDungeonScene()
    {
        yield return new WaitForSeconds(2.0f);
        MasterData.isExiting = false;
        SceneManager.LoadScene("DungeonRoom");
    }
    */

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
