using UnityEngine;

public class Spiral : MonoBehaviour {
    float timeCounter = 0;
    float speed = 1.0f;
    public Vector3 pos;
    public Vector3 initialPos = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 finalPos = new Vector3(10.01f, 1.78f, 0.0f);

    void Start()
    {
        pos.x = initialPos.x;
        pos.y = initialPos.y;
    }

    void Update()
    {
        if (timeCounter > 20)
        {
            pos.x = initialPos.x;
            pos.y = initialPos.y;
            timeCounter = 0;
            speed = 1.0f;
        }
        else
        {
            timeCounter += Time.deltaTime;
            pos.x = Mathf.Sin(timeCounter) * speed;
            pos.y = Mathf.Cos(timeCounter) * speed;
            transform.LookAt(pos);
            pos.x++;
            pos.y++;
            transform.position = pos;
            speed -= 0.2f;
        }
    }

    void drawControlPoints(float x, float y)
    {
        GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        point.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        point.transform.position = new Vector3(x * speed, y * speed  , 0.0f);
    }
}
