using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour {
    float timeCounter = 0;
    float velocidade = 1;
    float teste = 1;
    float x, y, z;

    void Start()
    {

    }

    void Update()
    {
        timeCounter += velocidade * Time.deltaTime;
        x = Mathf.Sin(timeCounter) * teste;
        y = Mathf.Cos(timeCounter) * teste;
        z = 0;

        transform.LookAt(new Vector3(x, y, z));
        transform.position = new Vector3(x++, y++, z);
        teste -= 1 / velocidade;
    }
}
