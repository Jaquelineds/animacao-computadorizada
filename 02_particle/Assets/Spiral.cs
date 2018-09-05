using UnityEngine;

public class Spiral : MonoBehaviour
{
    float timeCounter = 0;
    float speed = 0.1f;
    public Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
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
