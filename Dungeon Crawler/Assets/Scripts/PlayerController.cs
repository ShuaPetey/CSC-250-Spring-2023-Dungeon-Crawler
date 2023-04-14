using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public GameObject westStart, eastStart, northStart, southStart;
    public float movementSpeed = 40.0f;
    private bool isMoving;
    public bool northOn, southOn, eastOn, westOn;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.isMoving = false;

        if(!MasterData.whereDidIComeFrom.Equals("?"))
        {
            if(MasterData.whereDidIComeFrom.Equals("North"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.rb.AddForce(Vector3.back * 150.0f);
            }
            else if(MasterData.whereDidIComeFrom.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.rb.AddForce(Vector3.forward * 150.0f);
            }
            else if(MasterData.whereDidIComeFrom.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.rb.AddForce(Vector3.left * 150.0f);
            }
            else if(MasterData.whereDidIComeFrom.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.rb.AddForce(Vector3.right * 150.0f);
            }
        }
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && this.isMoving == false)
        {
            //this.rb.transform.position = new Vector3(0f, 0f, 0f);
            this.rb.AddForce(this.northExit.transform.position * movementSpeed);
            this.isMoving = true;
            /*if(northOn == false)
            {
                this.rb.AddForce(this.northExit.transform.position * 0.0f);
            }
            */
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && this.isMoving == false)
        {
            //this.rb.transform.position = new Vector3(0f, 0f, 0f);
            this.rb.AddForce(this.southExit.transform.position * movementSpeed);
            this.isMoving = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.isMoving == false)
        {
            //this.rb.transform.position = new Vector3(0f, 0f, 0f);
            this.rb.AddForce(this.westExit.transform.position * movementSpeed);
            this.isMoving = true;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && this.isMoving == false)
        {
            //this.rb.transform.position = new Vector3(0f, 0f, 0f);
            this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
            this.isMoving = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Center"))
        {
            this.rb.velocity = Vector3.zero;
            this.rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.tag.Equals("Exit") && MasterData.isExiting)
            {
                if(other.gameObject == this.northExit)
                {
                    MasterData.whereDidIComeFrom = "North";
                    MasterData.count++;
                    //SceneManager.LoadScene("DungeonRoom");
                    //this.rb.transform.position = new Vector3(0f, .5f, 4.5f);
                    //this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                    
                }
                else if(other.gameObject == this.southExit)
                {
                    MasterData.whereDidIComeFrom = "south";
                    MasterData.count++;
                    //SceneManager.LoadScene("DungeonRoom");
                    //this.rb.transform.position = new Vector3(0f, .5f, -4.5f);
                    //this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                    
                    
                }
                else if(other.gameObject == this.eastExit)
                {
                    MasterData.whereDidIComeFrom = "east";
                    MasterData.count++;
                    //SceneManager.LoadScene("DungeonRoom");
                    //this.rb.transform.position = new Vector3(4.5f, .5f, 0f);
                    //this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                    
                }
                else if(other.gameObject == this.westExit)
                {
                    MasterData.whereDidIComeFrom = "west";
                    MasterData.count++;
                    //SceneManager.LoadScene("DungeonRoom");
                    //this.rb.transform.position = new Vector3(-4.5f, .5f, 0f);
                    //this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                    
                }
                MasterData.isExiting = false;
                SceneManager.LoadScene("DungeonRoom");
            }
            else if(other.gameObject.tag.Equals("Exit") && !MasterData.isExiting)
            {
                MasterData.isExiting = true;
            }
        }
}
