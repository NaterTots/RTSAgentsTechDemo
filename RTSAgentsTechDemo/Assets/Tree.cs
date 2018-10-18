using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour
{
	private int health = 2;

	public GameObject treeLootPrefab;

	private float baseScale = 0.5f;

	public void Initialize(float size, int startingHealth)
	{
		transform.localScale = new Vector3(size * baseScale, size * baseScale, size * baseScale);

		health = startingHealth;
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="attack"></param>
	/// <returns>true if it killed the tree</returns>
	public bool Hit(int attack)
	{
		bool killed = false;

		int previoushealth = health;

		health -= attack;
		if (health < 0) health = 0;

		for (int i = 0; i < previoushealth - health; i++)
		{
			var newLoot = Instantiate(treeLootPrefab);
			newLoot.GetComponent<TreeLoot>().Initialize(this.transform.position);
		}

		if (health <= 0)
		{
			TreeMaker.Instance.RemoveTree(this);
			Destroy(this.gameObject);
			killed = true;
		}

		return killed;
	}
}
