using UnityEngine;

public class Circular : MonoBehaviour
{
    public Vector3 pos;
    float timeCounter = 0;
    float velocidade = 0.1f;
    float x, y, z;
    
    void Start()
    {
        transform.Rotate(0, 0, 90);
    }

    void Update()
    {
        timeCounter += velocidade * Time.deltaTime;
        x = Mathf.Sin(timeCounter);
        y = Mathf.Cos(timeCounter);
        z = 0;

        transform.LookAt(new Vector3(x, y, z));
        transform.position = new Vector3(x, y, z);
    }
}
