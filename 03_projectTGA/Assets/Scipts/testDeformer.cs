using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDeformer : MonoBehaviour {

	public float sound_value;
	MeshDeformer deformer;
	SoundAnalysis sound;

	// Use this for initialization
	void Start () {
		deformer = gameObject.GetComponent<MeshDeformer>();
		sound = gameObject.GetComponent<SoundAnalysis>();
	}
	
	// Update is called once per frame
	void Update () {		
            if (deformer){
				sound_value = sound.UpdateVisual();
                deformer.AddDeformingForce(sound_value * 1000); //the sound value is too small, so we need to amplify it, thus the 1000
				//deformer.AddDeformingForce(force);
            }
	}
}
