using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Inhabitant currentTarget;
    private GameObject currentAttackerGO;
    private GameObject currentTargetGO;
    private MonoBehaviour refereeInstance;

    public DeathMatch(Inhabitant dude1, Inhabitant dude2, GameObject dude1GO, GameObject dude2GO, MonoBehaviour refereeInstance)
    {
        this.dude1 = dude1;
        this.dude2 = dude2;
        this.dude1GO = dude1GO;
        this.dude2GO = dude2GO;
        this.currentAttacker = this.dude1;
        this.currentTarget = this.dude2;
        this.currentAttackerGO = this.dude1GO;
        this.currentTargetGO = this.dude2GO;
        this.refereeInstance = refereeInstance;
    }

    private IEnumerator JumpCoroutine()
    {
        float duration = 60f;
        float speed = 5f;
        float startTime = Time.time;
        Vector3 startPosition = this.currentAttackerGO.transform.position;

        while(Time.time - startTime < duration)
        {
            float newY = startPosition.y + Mathf.Sin((Time.time - startTime) *speed) * .5f;
            this.currentAttackerGO.transform.position = new Vector3(this.currentAttackerGO.transform.position.x, newY, this.currentAttackerGO.transform.position.z);

            yield return null;
        }
    }

    IEnumerator MoveObjectRoutine()
    {
        Vector3 originalPosition = this.attackerOriginalPosition;
        Vector3 targetPosition = originalPosition + this.currentAttackerGO.transform.right * attackMoveDistance;

        this.currRigidBodyOfAttacker.MovePosition(targetPosition);

        yield return new WaitForSeconds(1.5f);

        //try to do damage here
        if(Dice.roll(20) >= this.currentTarget.getAC())
        {
            this.currentTarget.takeDamage(this.currentAttacker.getDamage());
        }

        this.currRigidBodyOfAttacker.MovePosition(originalPosition);

        yield return new WaitForSeconds(1.5f);

        ((RefereeController)this.refereeInstance).updateScore();

        if(this.currentTarget.isDead())
        {
            MasterData.shouldFollowRotation = true;

            this.currentTargetGO.transform.Rotate(new Vector3(90, 0, 0));
            
            this.refereeInstance.StartCoroutine(JumpCoroutine());

            if(this.currentAttackerGO == this.dude1GO)
            {
                ((RefereeController)this.refereeInstance).playWinnerMusic();
                yield return new WaitForSeconds(6.0f);
                SceneManager.LoadScene("DungeonRoom");
            }
            else
            {
                //my music is on unity side here
                yield return new WaitForSeconds(5.0f);
                SceneManager.LoadScene("GameOver");
            }
            
        }
        else
        {
            this.fight();
        }
    }

    public void fight()
    {
        
        //while(true)
        //{
            this.attackerOriginalPosition = this.currentAttackerGO.transform.position;
            this.currRigidBodyOfAttacker = this.currentAttackerGO.GetComponent<Rigidbody>();
            this.attackMoveDistance *= -1;

            if(this.currentAttackerGO == this.dude1GO)
            {
                this.currentAttackerGO = this.dude2GO;
                this.currentAttacker = this.dude2;
                this.currentTarget = this.dude1;
                this.currentTargetGO = this.dude1GO;
            }
            else
            {
                this.currentAttackerGO = this.dude1GO;
                this.currentAttacker = this.dude1;
                this.currentTarget = this.dude2;
                this.currentTargetGO = this.dude2GO;
            }
            this.refereeInstance.StartCoroutine(MoveObjectRoutine());
        //}
        


    }
}
