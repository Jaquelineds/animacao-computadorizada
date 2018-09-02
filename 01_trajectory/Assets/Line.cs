using UnityEngine;

public class Line : MonoBehaviour {
    float timeCounter = 0;
    float speed = 1.0f;
    float scale = 5.0f;
    public Vector3 initialPos = new Vector3(-10.0f, 5.0f, 0.0f);
    public Vector3 finalPos = new Vector3(-10.0f, -5.0f, 0.0f);
    public Vector3 pos;

    void Start()
    {
        drawControlPoint(initialPos);
        drawControlPoint(finalPos);

        pos = initialPos;
        transform.position = pos;
    }

    void Update()
    {
        transform.LookAt(initialPos);
        timeCounter += Time.deltaTime * speed;
        
        pos.y = scale * Mathf.Sin(timeCounter);
        transform.position = pos;
    }    

    void drawControlPoint(Vector3 position)
    {
        var point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        point.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        point.transform.position = position;
    }
}
