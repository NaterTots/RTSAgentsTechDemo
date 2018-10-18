using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeMaker : MonoBehaviour
{
	private static TreeMaker _instance;
	public static TreeMaker Instance
	{
		get
		{
			return _instance;
		}
	}


	public GameObject treePrefab;
	private int maxTrees = 20;
	private float timeBetweenSpawns = 10.0f;
	private Vector3 minPos = new Vector3(-4f, 0, -2f);
	private Vector3 maxPos = new Vector3(4f, 0, 2f);

	private Dictionary<int, Tree> activeTrees = new Dictionary<int, Tree>();
	private float treeTimer = 0f;

	private float treeSize = 1.0f;
	private int pointsPerTree = 2;

	// Use this for initialization
	void Awake ()
	{
		_instance = this;
	}

	private void Start()
	{
		SpawnTree();
	}

	// Update is called once per frame
	void Update ()
	{
		treeTimer += Time.deltaTime;
		if (treeTimer > timeBetweenSpawns)
		{
			SpawnTree();
			treeTimer = 0f;
		}
	}

	public void IncreaseTreeSize()
	{
		treeSize += .25f;
		pointsPerTree = (int)(pointsPerTree * 1.5);
	}

	public void IncreaseTreeQuantity()
	{
		timeBetweenSpawns *= .5f;
	}

	public void SpawnTree()
	{
		if (activeTrees.Count < maxTrees)
		{
			var newTree = Instantiate(treePrefab, new Vector3(Random.Range(minPos.x, maxPos.x), minPos.y, Random.Range(minPos.z, maxPos.z)), Quaternion.identity);
			newTree.transform.parent = this.transform;
			newTree.GetComponent<Tree>().Initialize(treeSize, pointsPerTree);
			activeTrees.Add(newTree.GetInstanceID(), newTree.GetComponent<Tree>());
		}
	}

	public void RemoveTree(Tree t)
	{
		int treeId = t.gameObject.GetInstanceID();
		if (activeTrees.ContainsKey(treeId)) activeTrees.Remove(treeId);
	}

	public int TreeCount()
	{
		return activeTrees.Count;
	}

	public IEnumerable<Tree> Trees()
	{
		return activeTrees.Values.Select(v => v.GetComponent<Tree>());
	}

	public bool TryGetRandomTree(out Tree t)
	{
		t = null;
		if (activeTrees.Count > 0)
		{
			t = activeTrees.Values.ElementAt(Random.Range(0, activeTrees.Count));
		}
		return (t != null);
	}
}
