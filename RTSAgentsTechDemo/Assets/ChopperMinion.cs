using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChopperMinion : MonoBehaviour
{
	private bool hasTarget = false;
	private bool isAttacking = false;
	private Tree target;

	private NavMeshAgent agent;

	// Use this for initialization
	void Awake ()
	{
		agent = GetComponent<NavMeshAgent>();
		
	}

	private float attackFrequency = 1.0f;
	private float attackTimer = 0.0f;

	public void SetAttackFrequency(float attackFreq)
	{
		attackFrequency = attackFreq;
	}

	// Update is called once per frame
	void Update ()
	{
		if (isAttacking)
		{
			attackTimer += Time.deltaTime;
			if (attackTimer > attackFrequency)
			{
				if (target == null || target.gameObject == null || target.Hit(1))
				{
					isAttacking = false;
					hasTarget = false;
				}

				attackTimer = 0f;
			}
		}
		else if (hasTarget)
		{
			if (target != null && target.gameObject != null)
			{
				float distance = Vector3.Distance(transform.position, target.transform.position);
				if (distance <= agent.stoppingDistance) isAttacking = true;
			}
			else
			{
				hasTarget = false;
			}
		}
		else if (!hasTarget)
		{
			Tree nextTree;
			if (TreeMaker.Instance.TryGetRandomTree(out nextTree))
			{
				target = nextTree;
				hasTarget = true;
				agent.SetDestination(target.transform.position);
			}
		}
	}
}
