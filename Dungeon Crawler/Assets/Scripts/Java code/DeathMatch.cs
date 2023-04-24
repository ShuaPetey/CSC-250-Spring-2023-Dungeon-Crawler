using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatch 
{
    private Inhabitant dude1;
    private Inhabitant dude2;
    private GameObject dude1GO;
    private GameObject dude2GO;
    private Rigidbody currRigidBodyOfAttacker;
    private float attackMoveDistance = 2.5f;
    private Vector3 attackerOriginalPosition;
    private Inhabitant currentAttacker;
    private GameObject currentAttackerGO;
    private MonoBehaviour refereeInstance;

    public DeathMatch(Inhabitant dude1, Inhabitant dude2, GameObject dude1GO, GameObject dude2GO, MonoBehaviour refereeInstance)
    {
        this.dude1 = dude1;
        this.dude2 = dude2;
        this.dude1GO = dude1GO;
        this.dude2GO = dude2GO;
        this.currentAttacker = this.dude1;
        this.currentAttackerGO = this.dude1GO;
        this.refereeInstance = refereeInstance;
    }

    IEnumerator MoveObjectRoutine()
    {
        Vector3 originalPosition = this.attackerOriginalPosition;
        Vector3 targetPosition = originalPosition + this.currentAttackerGO.transform.right * attackMoveDistance;

        this.currRigidBodyOfAttacker.MovePosition(targetPosition);

        yield return new WaitForSeconds(1.5f);

        this.currRigidBodyOfAttacker.MovePosition(originalPosition);
    }

    public void fight()
    {
        /*
        while(true)
        {
            this.attackerOriginalPosition = this.currentAttackerGO.transform.position;
            this.currRigidBodyOfAttacker = this.currentAttackerGO.GetComponent<RigidBody>();
            this.attackMoveDistance *= -1;

            if(this.currentAttackerGO == this.dude1GO)
            {
                this.currentAttackerGO = this.dude2GO;
            }
            else
            {
                this.currentAttackerGO = this.dude1GO;
            }
            this.refereeInstance.StartCoroutine(MoveObjectRoutine());
        }
        */


    }
}
