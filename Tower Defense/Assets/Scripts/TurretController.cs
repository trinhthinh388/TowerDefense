using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
	public Transform target;
	public float range = 15f;
	public Transform partToRotate;
	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget()
	{
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
        foreach(GameObject Enemy in Enemies)
		{
			float DistanceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);
            if(DistanceToEnemy < shortestDistance)
			{
				shortestDistance = DistanceToEnemy;
				nearestEnemy = Enemy;
			}
            if(nearestEnemy != null && shortestDistance <= range)
			{
				target = nearestEnemy.transform;
			}
			else
			{
				target = null;
			}
		}

		
	}

	// Update is called once per frame
	void Update () {
		if (target == null)
			return;

		Vector3 dir = -transform.position + target.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = lookRotation.eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		
	}
    
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
