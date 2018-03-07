using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockEnemyPatrol : MonoBehaviour {

	public GameObject pathGO;
	public int pathNodeIndex = 0;
	public float rotationSpeed = 5.0f;
	public float movementSpeed = 5.0f;

	private Transform targetPathNode;
	private int wayPointsCount;

    private Animator enemyAnim;

	void Start ()
	{
		pathGO = GameObject.Find ("Path");
		wayPointsCount = getWayPointsCount (pathGO.transform);
        enemyAnim = GetComponent<Animator>();
	}
	
	void Update ()
	{
		
	}

	public void GetNextPathNode ()
	{
		targetPathNode = pathGO.transform.GetChild (pathNodeIndex);
		pathNodeIndex = (pathNodeIndex + 1) % wayPointsCount;
	}

	int getWayPointsCount (Transform path)
	{
		int count = 0;

		foreach (Transform child in path)
		{
			count++;
		}

		return count;
	}

	public void rotateTowardsWayPoint ()
	{
		Vector3 relativePosition = targetPathNode.position - this.transform.position;
        relativePosition.y = 0;

		Quaternion rotation = Quaternion.LookRotation (relativePosition);

		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, rotationSpeed * Time.deltaTime);
	}

    public void Patrol()
    {
        if (targetPathNode == null)
        {
            GetNextPathNode();
        }

        float distToNextWayPoint = Vector3.Distance(transform.position, targetPathNode.position);

        if (distToNextWayPoint <= .5f)
        {
            targetPathNode = null;
        }
        else
        {
            
            rotateTowardsWayPoint();
            transform.position = Vector3.MoveTowards(transform.position, targetPathNode.position, movementSpeed * Time.deltaTime);
            enemyAnim.SetBool("isWalking", true);
            enemyAnim.SetBool("isIdle", false);
            enemyAnim.SetBool("isAttacking", false);

        }
    }

}
