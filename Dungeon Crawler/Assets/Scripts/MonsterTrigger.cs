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
       while(this.enableFights && Inhabitant.hp <= 0)
       {
           int chanceToFight = Random.Range(1,100);
           print("Entered Monster Fight!!! - " + chanceToFight);
           if(chanceToFight <= this.chanceToGetIntoFight)
           {
              print("Start a Fight");
              SceneManager.LoadScene("FightScene");
             
          
          if(Player.damage >= Monster.ac)
          {
              //we hit the target and do damage
              
              Monster.hp = Monster.hp - Inhabitant.damage;
              if(Monster.hp <= 0)
              {
                  
                  //we are done fighting how do we get out?
                  SceneManager.LoadScene("DungeonRoom");
              }
          }
          else if(Monster.damage >= Player.ac)
          {
              Player.hp = Player.hp - Inhabitant.damage;
              if(Player.hp <= 0)
              {
                  
                  //we are done fighting how do we get out?
                  SceneManager.LoadScene("DungeonRoom");
              }
          }
          }
           else
           {
              print("No Monsters Found!");
           }

       }
       

    
   }

 
}