using UnityEngine;
using System.Collections;

public class TreeLoot : MonoBehaviour
{

	// Use this for initialization
	public void Initialize(Vector3 pos)
	{
		transform.position = new Vector3(pos.x + Random.Range(-.5f, .5f), pos.y, pos.z + Random.Range(-.5f, .5f));
	}

	public void OnCollect()
	{
		Inventory.Instance.GainGreenPoints(1);

		Destroy(gameObject);
	}

	private void OnMouseOver()
	{
		OnCollect();
	}
}
