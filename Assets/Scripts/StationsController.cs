﻿using UnityEngine;
using System.Collections;

public class StationsController : MonoBehaviour {

	public static StationsController Instance;

	private int totalPassengers = 2000;
	private float lastEmbarkmentTime = 0;
	private int passengersToEmbark = 0;

	private float timeBetweenEmbarkments = 0.3f;

	void Awake () {
		Instance = this;
	}

	void Start () {
		this.totalPassengers = 2000;
	}

	void Update () {
	}

	public int getInitialPassengers (int capacity, int full) {

		int passengers = full;
		this.totalPassengers -= passengers;

		UIManager.instance.capacityBox.SetMaximumCapacity (capacity, passengers);

		return passengers;

	}

	public void calculatePassengerNumbers () {
		Debug.Log ("Calculating Passenger Numbers");
		this.passengersToEmbark = totalPassengers / 10;
		this.totalPassengers -= this.passengersToEmbark;
		this.lastEmbarkmentTime = Time.realtimeSinceStartup;
	}

	public void arriveAtStation (int passengersToDisembark) {
		Debug.Log("Arriving Station");
		//Debug.Log(passengersToDisembark);
		UIManager.instance.offloadBox.ArrivedAtStation(passengersToDisembark);
		UIManager.instance.onloadBox.ArrivedAtStation(passengersToEmbark);
	}

	public void departStation () {
		Debug.Log("Departing Station");
		UIManager.instance.offloadBox.LeftStation();
		UIManager.instance.onloadBox.LeftStation();
	}

	public void disembarkPassenger () {
		UIManager.instance.offloadBox.PassengerDisembark();
		return;
	}

	public int embarkPassenger () {

		float currentTime = Time.realtimeSinceStartup;

		if (currentTime - lastEmbarkmentTime > timeBetweenEmbarkments && this.passengersToEmbark > 0) {
			lastEmbarkmentTime = currentTime;
			passengersToEmbark--;
			UIManager.instance.onloadBox.PassengerEmbark();
			return 1;
		} else {
			return 0;
		}

	}

	public int getRemainingPassengers () {
		return passengersToEmbark;
	}

}
