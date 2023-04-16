using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InhabitantStats 
{
    public string name;
    public int hp;
    public int ac;
    public int attack;

    
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

