using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
   public bool enableFights = true;
   public float chanceToGetIntoFight = 30f;
  
   private void OnTriggerEnter(Collider other)
   {
       if(this.enableFights && MasterData.canGetIntoFight)
       {
           int chanceToFight = Random.Range(1, 100);
          
           if(chanceToFight <= this.chanceToGetIntoFight)
           {
              MasterData.canGetIntoFight = false;
              SceneManager.LoadScene("FightScene");
           }
           else
           {
              print("No Monsters Found!");
           }

       }
       

    
   }

 
}