using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour {

	SoundAnalysis sound;
	float dbValue;
	float[] topThreeSpectrum;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<SoundAnalysis>();
	}
	
	// Update is called once per frame
	void Update () {
		dbValue = sound.getDBValue();
		topThreeSpectrum = sound.getTopThreeSpectrum();

		//db value is too high, so we gotta make it between 0 and 1
		dbValue = dbValue/10.0f;

		if(dbValue < 0f)
			dbValue = 0f;
		else if(dbValue > 1f){
			dbValue = 1f;
		}

		//spectrum values are too low, let's pump up those numbers :)
		topThreeSpectrum[0] = topThreeSpectrum[0] * 10;
		topThreeSpectrum[1] = topThreeSpectrum[2] * 10;
		topThreeSpectrum[2] = topThreeSpectrum[1] * 10;

		if(topThreeSpectrum[0] > 1f){
			topThreeSpectrum[0] = 1f;
		} else if(topThreeSpectrum[1] > 1f){
			topThreeSpectrum[1] = 1f;
		} else if(topThreeSpectrum[2] > 1f){
			topThreeSpectrum[2] = 1f;
		} else if(topThreeSpectrum[0] < 0f){
			topThreeSpectrum[0] = 0f;
		} else if(topThreeSpectrum[1] < 0f){
			topThreeSpectrum[1] = 0f;
		} else if(topThreeSpectrum[2] < 0f){
			topThreeSpectrum[2] = 0f;
		}

		GetComponent<Renderer>().material.color = new Color(dbValue, topThreeSpectrum[1], topThreeSpectrum[2]);	
	}


}
