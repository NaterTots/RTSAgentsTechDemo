using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinionMaker : MonoBehaviour
{
	private static MinionMaker _instance;
	public static MinionMaker Instance
	{
		get
		{
			return _instance;
		}
	}


	public GameObject minionPrefab;

	private Vector3 minPos = new Vector3(-4f, 0, -2f);
	private Vector3 maxPos = new Vector3(4f, 0, 2f);

	private Dictionary<int, ChopperMinion> activeMinions = new Dictionary<int, ChopperMinion>();

	private float attackFrequency = 1.0f;

	// Use this for initialization
	void Awake()
	{
		_instance = this;
	}

	private void Start()
	{
		SpawnMinion();
	}

	public void IncreaseAttackFrequency()
	{
		attackFrequency *= .75f;
		foreach(var minion in activeMinions.Values)
		{
			minion.SetAttackFrequency(attackFrequency);
		}
	}

	public void SpawnMinion()
	{
		var newMinion = Instantiate(minionPrefab, new Vector3(Random.Range(minPos.x, maxPos.x), minPos.y, Random.Range(minPos.z, maxPos.z)), Quaternion.identity);
		newMinion.transform.parent = this.transform;
		newMinion.GetComponent<ChopperMinion>().SetAttackFrequency(attackFrequency);
		activeMinions.Add(newMinion.GetInstanceID(), newMinion.GetComponent<ChopperMinion>());
	}

	public int MinionCount()
	{
		return activeMinions.Count;
	}

	public IEnumerable<ChopperMinion> Minions()
	{
		return activeMinions.Values.Select(v => v.GetComponent<ChopperMinion>());
	}
}
