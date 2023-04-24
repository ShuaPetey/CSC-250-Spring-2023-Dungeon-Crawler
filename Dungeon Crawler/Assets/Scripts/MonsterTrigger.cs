using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
   public bool enableFights = true;
   public float chanceToGetIntoFight = 30;
  
   private void onTriggerEnter(Collider other)
   {
       while(this.enableFights)
       {
           int chanceToFight = Random.Range(1,100);
           print("Entered Monster Fight!!! - " + chanceToFight);
           if(chanceToFight <= this.chanceToGetIntoFight)
           {
              print("Start a Fight");
              SceneManager.LoadScene("FightScene");
             
          
           
           }
           else
           {
              print("No Monsters Found!");
           }

       }
       

    
   }

 
}