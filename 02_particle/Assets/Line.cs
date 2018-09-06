using UnityEngine;

public class Line : MonoBehaviour
{
    float timeCounter = 0;
    float speed = 0.1f;
    float scale = 5.0f;

    void Start()
    {
    }

    void Update()
    {
        transform.LookAt(transform.position);
        timeCounter += Time.deltaTime * (speed - 0.01f);

        float y = transform.position.y + (scale * Mathf.Sin(timeCounter));
        transform.position = new Vector3(transform.position.x, y, 0);
    }
}
