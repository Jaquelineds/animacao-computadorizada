using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
    float timeCounter = 0;
    float velocidade = 5;
    float x, y, z;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(new Vector3(x, y, z));

        timeCounter += Time.deltaTime;
        x = Mathf.Sin(timeCounter);
        y = 0;
        z = 0;

        transform.position = new Vector3(x, y, z);

    }
}
