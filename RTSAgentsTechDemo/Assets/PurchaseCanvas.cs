using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseCanvas : MonoBehaviour
{
	public Canvas purchaseCanvas;
	public Button revealButton;

	// Use this for initialization
	void Start ()
	{
		OnConceal();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnReveal()
	{
		purchaseCanvas.gameObject.SetActive(true);
		revealButton.gameObject.SetActive(false);
	}

	public void OnConceal()
	{
		purchaseCanvas.gameObject.SetActive(false);
		revealButton.gameObject.SetActive(true);
	}
}
