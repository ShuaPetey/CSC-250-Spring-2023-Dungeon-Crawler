using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public float movementSpeed = 40.0f;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        //print(MasterData.count);
        MasterData md = new MasterData();
        this.isMoving = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && this.isMoving == false)
        {
            //this.rb.transform.position = new Vector3(0f, 0f, 0f);
            this.rb.AddForce(this.northExit.transform.position * movementSpeed);
            this.isMoving = true;
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
            if(other.gameObject.tag.Equals("Exit"))
            {
                MasterData.count++;
                SceneManager.LoadScene("DungeonRoom");
            }
        }
}
