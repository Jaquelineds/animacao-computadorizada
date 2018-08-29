using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour {
    float timeCounter = 0;
    float velocidade = 5;
    float[,,] Geometry = new float[1, 4, 3] { { {10, 10, 0 }, // Point1
    {-10,5,-2 }, // Point2
    { 5,-5,0 }, // Tangent1
    { 5,10,0 }// Tangent2
        } };
    int LOD = 20;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i != LOD; ++i)
        {
            timeCounter += velocidade * Time.deltaTime;

            float t = (float)i / (LOD - 1);
            // calculate blending functions
            float b0 = 2 * t * t * t - 3 * t * t + 1;
            float b1 = -2 * t * t * t + 3 * t * t;
            float b2 = t * t * t - 2 * t * t + t;
            float b3 = t * t * t - t * t;
            // calculate the x,y and z of the curve point
            float x = b0 * Geometry[0, 0, 0] +
            b1 * Geometry[0, 1, 0] +
            b2 * Geometry[0, 2, 0] +
            b3 * Geometry[0, 3, 0] * timeCounter;
            float y = b0 * Geometry[0, 0, 1] +
            b1 * Geometry[0, 1, 1] +
            b2 * Geometry[0, 2, 1] +
            b3 * Geometry[0, 3, 1] * timeCounter;
            float z = b0 * Geometry[0, 0, 2] +
            b1 * Geometry[0, 1, 2] +
            b2 * Geometry[0, 2, 2] +
            b3 * Geometry[0, 3, 2] * timeCounter;
            // specify the point
            transform.position = new Vector3(x, y, z);
        }

    }
}
