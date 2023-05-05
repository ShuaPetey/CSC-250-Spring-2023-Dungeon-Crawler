using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public GameObject westStart, eastStart, northStart, southStart;
    public GameObject cube, cube1, cube2, cube3, cube4, cube5, cube6, cube7, cube8, cube9;
    public float movementSpeed = 40.0f;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        MasterData.setupDungeon();
        this.updateExits();

        this.rb = this.GetComponent<Rigidbody>();
        this.isMoving = false;

        if (!MasterData.whereDidIComeFrom.Equals("?"))
        {
            if(MasterData.whereDidIComeFrom.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.rb.AddForce(Vector3.back * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.rb.AddForce(Vector3.forward * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.rb.AddForce(Vector3.right * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.rb.AddForce(Vector3.left * 150.0f);
            }
        }
        StartCoroutine(PlayerHeal());
        if(MasterData.p.hp >= 1)
        {
            this.cube9.SetActive(true);
        }
        else if(MasterData.p.hp >= 2)
        {
            this.cube8.SetActive(true);
        }
        else if(MasterData.p.hp >= 3)
        {
            this.cube7.SetActive(true);
        }
        else if(MasterData.p.hp >= 4)
        {
            this.cube6.SetActive(true);
        }
        else if(MasterData.p.hp >= 5)
        {
            this.cube5.SetActive(true);
        }
        else if(MasterData.p.hp >= 6)
        {
            this.cube4.SetActive(true);
        }
        else if(MasterData.p.hp >= 7)
        {
            this.cube3.SetActive(true);
        }
        else if(MasterData.p.hp >= 8)
        {
            this.cube2.SetActive(true);
        }
        else if(MasterData.p.hp >= 9)
        {
            this.cube1.SetActive(true);
        }
        else if(MasterData.p.hp >= 10)
        {
            this.cube.SetActive(true);
        }


    }

    IEnumerator PlayerHeal()
    {
        yield return new WaitForSeconds(3.0f);
        MasterData.p.healHP(1);
        StartCoroutine(PlayerHeal());
    }

    private void updateExits()
    {
        Room currentRoom = MasterData.p.getCurrentRoom();
        if(currentRoom.hasExit("north") == false)
        {
            this.northExit.SetActive(false);
        }
        if (currentRoom.hasExit("south") == false)
        {
            this.southExit.SetActive(false);
        }
        if (currentRoom.hasExit("east") == false)
        {
            this.eastExit.SetActive(false);
        }
        if (currentRoom.hasExit("west") == false)
        {
            this.westExit.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Center"))
        {
            MasterData.canGetIntoFight = true;
            this.rb.velocity = Vector3.zero;
            this.rb.Sleep();
            //this.rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Exit") && MasterData.isExiting)
        {
            //MasterData.canGetIntoFight = true;
            MasterData.isExiting = false;
            SceneManager.LoadScene("DungeonRoom");
        }
        else if(other.gameObject.CompareTag("Exit") && !MasterData.isExiting)
        {
            MasterData.isExiting = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Room currentRoom = MasterData.p.getCurrentRoom();

        if (Input.GetKeyDown(KeyCode.UpArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("north"))
            {
                currentRoom.takeExit(MasterData.p, "north");
                MasterData.whereDidIComeFrom = "north";
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("west"))
            {
                currentRoom.takeExit(MasterData.p, "west");
                MasterData.whereDidIComeFrom = "west";
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("east"))
            {
                currentRoom.takeExit(MasterData.p, "east");
                MasterData.whereDidIComeFrom = "east";
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("south"))
            {
                currentRoom.takeExit(MasterData.p, "south");
                MasterData.whereDidIComeFrom = "south";
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                this.isMoving = true;
            }
        }

    }
}