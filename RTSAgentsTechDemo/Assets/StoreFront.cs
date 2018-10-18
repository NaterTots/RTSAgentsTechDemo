using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoreFront : MonoBehaviour
{
	public Button biggerTree;
	public Button moreTrees;
	public Button moreHarvesters;
	public Button betterHarvesters;

	private int nextBiggerTreeCost;
	private int incBiggerTreeCost = 5;

	private int nextMoreTreesCost;
	private int incMoreTreesCost = 10;

	private int nextMoreHarvestersCost;
	private int incMoreHarvestersCost = 10;

	private int nextBetterHarvestersCost;
	private int incBetterHarvestersCost = 10;

	// Use this for initialization
	void Start()
	{
		Inventory.Instance.OnPointsChanged += OnPointsChanged;

		nextBiggerTreeCost = incBiggerTreeCost;
		nextMoreTreesCost = incMoreTreesCost;
		nextMoreHarvestersCost = incMoreHarvestersCost;
		nextBetterHarvestersCost = incBetterHarvestersCost;

		biggerTree.GetComponentInChildren<Text>().text = nextBiggerTreeCost.ToString();
		moreTrees.GetComponentInChildren<Text>().text = nextMoreTreesCost.ToString();
		moreHarvesters.GetComponentInChildren<Text>().text = nextMoreHarvestersCost.ToString();
		betterHarvesters.GetComponentInChildren<Text>().text = nextBetterHarvestersCost.ToString();

		EnablePurchaseButtons(Inventory.Instance.greenPoints);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnPointsChanged(int newPoints)
	{
		EnablePurchaseButtons(newPoints);
	}

	public void OnPurchaseBiggerTree()
	{
		if (Inventory.Instance.greenPoints >= nextBiggerTreeCost)
		{
			Inventory.Instance.GainGreenPoints(-nextBiggerTreeCost);
			nextBiggerTreeCost += incBiggerTreeCost;

			biggerTree.GetComponentInChildren<Text>().text = nextBiggerTreeCost.ToString();
			TreeMaker.Instance.IncreaseTreeSize();
		}
	}

	public void OnPurchaseMoreTrees()
	{
		if (Inventory.Instance.greenPoints >= nextMoreTreesCost)
		{
			Inventory.Instance.GainGreenPoints(-nextMoreTreesCost);
			nextMoreTreesCost += incMoreTreesCost;

			moreTrees.GetComponentInChildren<Text>().text = nextMoreTreesCost.ToString();
			TreeMaker.Instance.IncreaseTreeQuantity();
		}
	}

	public void OnPurchaseMoreHarvesters()
	{
		if (Inventory.Instance.greenPoints >= nextMoreHarvestersCost)
		{
			Inventory.Instance.GainGreenPoints(-nextMoreHarvestersCost);
			nextMoreHarvestersCost += incMoreHarvestersCost;

			moreHarvesters.GetComponentInChildren<Text>().text = nextMoreHarvestersCost.ToString();
			MinionMaker.Instance.SpawnMinion();
		}
	}

	public void OnPurchaseBetterHarvesters()
	{
		if (Inventory.Instance.greenPoints >= nextBetterHarvestersCost)
		{
			Inventory.Instance.GainGreenPoints(-nextBetterHarvestersCost);
			nextBetterHarvestersCost += incBetterHarvestersCost;

			betterHarvesters.GetComponentInChildren<Text>().text = nextBetterHarvestersCost.ToString();
			MinionMaker.Instance.IncreaseAttackFrequency();
		}
	}

	private void EnablePurchaseButtons(int points)
	{
		biggerTree.interactable = (points >= nextBiggerTreeCost);
		moreTrees.interactable = (points >= nextMoreTreesCost);
		moreHarvesters.interactable = (points >= nextMoreHarvestersCost);
		betterHarvesters.interactable = (points >= nextBetterHarvestersCost);
	}
}
