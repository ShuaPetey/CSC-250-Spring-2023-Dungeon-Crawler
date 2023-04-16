using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster
{
    private string name;
    private Room currentRoom;

    public int hp;
    public int ac;
    public int attack;

    
    public Monster(string name)
    {
        this.name = name;
    }
    
    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }
    
    public void setCurrentRoom(Room r)
    {
        if(r != null)
        {
            this.currentRoom = r;
        }
    }
    public int rollHP(int sides)
    {
        return Random.Range(10, 20) % sides;
    }
    public int rollAC(int sides)
    {
        return Random.Range(10, 17) % sides;
    }
    public int rollAttack(int sides)
    {
        return Random.Range(1, 5) % sides;
    }
   
    
}