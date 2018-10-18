using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{
	private static Inventory _instance;
	public static Inventory Instance
	{
		get
		{
			return _instance;
		}
	}

	public int greenPoints = 0;

	public TextMeshProUGUI pointsText;

	// Use this for initialization
	void Awake()
	{
		greenPoints = 0;

		_instance = this;
	}

	public delegate void PointsChanged(int newPoints);
	public PointsChanged OnPointsChanged;

	public void GainGreenPoints(int points, bool skipNotify = false)
	{
		greenPoints += points;

		print("Total Green Points: " + greenPoints.ToString());

		pointsText.text = greenPoints.ToString();

		if (!skipNotify && OnPointsChanged != null) OnPointsChanged.Invoke(greenPoints);
	}


}
