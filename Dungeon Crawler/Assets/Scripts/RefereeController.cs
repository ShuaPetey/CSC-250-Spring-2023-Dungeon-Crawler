using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RefereeController : MonoBehaviour
{
    private Monster theMonster;
    public GameObject playerGO;
    public GameObject monsterGO;
    public TextMeshPro monsterSB;
    public TextMeshPro playerSB;
    private DeathMatch theMatch;


    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("goblin");
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterData.p.getData();
        this.theMatch = new DeathMatch(MasterData.p, this.theMonster, this.playerGO, this.monsterGO);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
