using UnityEngine;

public class Line : MonoBehaviour
{
    float timeCounter = 0;
    float speed = 0.009f;
    float scale = 5.0f;

    void Start()
    {
    }

    void Update()
    {
        transform.LookAt(transform.position);
        timeCounter += Time.deltaTime;  

        float y = transform.position.y + (scale * Mathf.Sin(timeCounter * speed));
        transform.position = new Vector3(transform.position.x, y, 0);

        speed -= 0.0001f;

        if (timeCounter > 3)
            GetComponent<Renderer>().material.color = Color.yellow;
    }
}
