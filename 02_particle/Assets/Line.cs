using UnityEngine;

public class Line : MonoBehaviour
{
    float timeCounter = 0;
    float speed = 0.1f;
    float scale = 5.0f;
    public Vector3 initialPos = new Vector3(-10.0f, 5.0f, 0.0f);
    public Vector3 finalPos = new Vector3(-10.0f, -5.0f, 0.0f);
    public Vector3 pos;

    void Start()
    {
        pos = transform.position;
        finalPos = new Vector3(pos.x, pos.y + 10.0f, pos.z);
    }

    void Update()
    {
        transform.LookAt(initialPos);
        timeCounter += Time.deltaTime * (speed - 0.01f);

        pos.y = scale * Mathf.Sin(timeCounter);
        transform.position = pos;
    }

}
