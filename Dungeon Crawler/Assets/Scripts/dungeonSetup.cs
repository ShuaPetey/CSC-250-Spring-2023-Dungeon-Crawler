using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungeonSetup : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit; 

    public bool northOn, southOn, eastOn, westOn; // can define multiple of same type this way
    // Start is called before the first frame update
    
    void Start()
    {
        if(northOn == false)
        {
            this.northExit.SetActive(false);
        }
        if(southOn == false)
        {
            this.southExit.SetActive(false);
        }
        if(eastOn == false)
        {
            this.eastExit.SetActive(false);
        }
        if(westOn == false)
        {
            this.westExit.SetActive(false);
        }
        
    }

    
}
