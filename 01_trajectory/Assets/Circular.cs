using UnityEngine;

public class Circular : MonoBehaviour {
    public Vector3 initialPos = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 pos;
    float timeCounter = 0;
    float velocidade = 1;
    float x, y, z;


    void Start()
    {
        transform.Rotate(0, 0, 90);
        drawControlPoint(new Vector3(0.0f, -1.0f, 0.0f));
        drawControlPoint(new Vector3(1.0f, 0.0f, 0.0f));
        drawControlPoint(new Vector3(0.0f, 1.0f, 0.0f));
        drawControlPoint(new Vector3(-1.0f, 0.0f, 0.0f));
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

    void drawControlPoint(Vector3 position)
    {
        var point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        point.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        point.transform.position = position;
    }
}
