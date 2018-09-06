using UnityEngine;

public class Circular : MonoBehaviour
{
    float timeCounter = 0;
    float scale = 0.1f;
    float speed = 1.0f;
    float x, y, z;

    void Start()
    {
    }

    void Update()
    {
        timeCounter += Time.deltaTime;
        transform.position = new Vector3(transform.position.x +  (scale * Mathf.Sin(timeCounter) * speed),
                                         transform.position.y + (scale * Mathf.Cos(timeCounter) * speed), 0);
        transform.LookAt(transform.position);
    }
}
