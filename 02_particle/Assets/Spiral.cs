using UnityEngine;

public class Spiral : MonoBehaviour
{
    float timeCounter = 0;
    float scale = 0.01f;
    float speed = 0.0f;

    void Start()
    {
    }

    void Update()
    {
        timeCounter += Time.deltaTime;
        transform.position = new Vector3(transform.position.x + ((scale * Mathf.Sin(timeCounter)) * speed) + 0.01f, 
                                         transform.position.y + ((scale *Mathf.Cos(timeCounter)) * speed), 0);
        transform.LookAt(transform.position);
        speed -= 0.2f;
    }
}
