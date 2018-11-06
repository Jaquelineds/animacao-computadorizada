using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAnalysis : MonoBehaviour {

	private const int SAMPLE_SIZE = 1024;

	public float rmsValue;
    public float dbValue;
    public float pitchValue;
	public float visualModifier = 150.0f;
	public float smoothSpeed = 10.0f;
	public float maxVisualScale = 10.0f;
	public float keepPercentage = 0.5f;


	public float spec1;
	public float spec2;
	public float spec3;

    private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float sampleRate;

	//private Transform[] visualList;
	private float[] visualScale;
	private int amtVisual = 8;



	// Use this for initialization
	void Start () {
		
		source = GetComponent<AudioSource>();
        samples = new float[SAMPLE_SIZE];
        spectrum = new float[SAMPLE_SIZE];
        sampleRate = AudioSettings.outputSampleRate;

		visualScale = new float[amtVisual];


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void AnalyzeSound(){
        source.GetOutputData(samples, 0);

        //get rms value
        int i = 0;
        float sum = 0;
        for(; i < SAMPLE_SIZE; i++){
            sum += samples[i]*samples[i];
        }
        rmsValue = Mathf.Sqrt(sum/SAMPLE_SIZE);

        //get dbValue
        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //get sound spectrum
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

		spec1 = spectrum[0]; spec2 = spectrum[1]; spec3 = spectrum[2];
    }

	public float UpdateVisual(){

		AnalyzeSound();

		int visualIndex = 0;
		int spectrumIndex = 0;
		int averageSize = (int) ((SAMPLE_SIZE*keepPercentage) / amtVisual);

		while(visualIndex < amtVisual){
			int j= 0;
			float sum = 0;
			while(j < averageSize){
				sum += spectrum[spectrumIndex];
				spectrumIndex++;
				j++;
			}
			float scaleY = sum/averageSize*visualModifier;
			visualScale[visualIndex] = Time.deltaTime * smoothSpeed;

			if(visualScale[visualIndex] < scaleY){
				visualScale[visualIndex] = scaleY;				
			}

			if(visualScale[visualIndex] > maxVisualScale)
				visualScale[visualIndex] = maxVisualScale;

			//visualList[visualIndex].localScale = Vector3.one + Vector3.up * visualScale[visualIndex];
			visualIndex++;
		}
		float avrg = 0f;
		for(int i = 0; i<amtVisual; i++){
			//get the average of the first eight "blocks" and return it to be used as the FORCE!
			avrg += visualScale[i];
		}
		avrg = avrg/amtVisual;
		return avrg;
	}

	public float getDBValue(){
		AnalyzeSound();
		return dbValue;
	}

	public float[] getTopThreeSpectrum(){
		AnalyzeSound();
		float[] spec = new float[3];
		spec[0] = spectrum[0];
		spec[1] = spectrum[1];
		spec[2] = spectrum[2];
		return spec;
	}

	
}
