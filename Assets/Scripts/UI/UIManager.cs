﻿using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public static UIManager instance;

	public GameObject gameOver;

	public SatisfactionBarController satBar;
	public CapacityBoxController capacityBox;
	public OffloadBoxController offloadBox;
	public OnloadBoxController onloadBox;


	// Use this for initialization
	void Start () {
		instance = this;
	}

	void Awake(){
		gameOver.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerStats.GetInstance ().satisfaction <= 0) {
			gameOver.SetActive (true);
		}
	}
}
