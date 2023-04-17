using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
   void Start()
   {

   }

   void Update()
   {

   }

   private void onTriggerEnter(Collider other)
   {
       int chanceToFight = Random.Range(1,100);
       print("Entered Monster Fight!!! - " + chanceToFight);
       if(chanceToFight <= 30)
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