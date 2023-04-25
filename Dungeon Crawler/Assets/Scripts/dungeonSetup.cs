using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungeonSetup : MonoBehaviour
{
    public GameObject northExit, southExit, eastExit, westExit;
    public bool northOn, southOn, eastOn, westOn; // can define multiple of same type this way
    // Start is called before the first frame update
    
    void Start()
    {
        
        /*
        if(northOn == false)
        {
            this.northExit.SetActive(false);

            //Vector3 oppositeForce = new Vector3(-PlayerController.rb.velocity.x, 0f, 0f) * PlayerController.rb.mass;
            //PlayerController.rb.AddForce(oppositeForce, ForceMode.Impulse);
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
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
