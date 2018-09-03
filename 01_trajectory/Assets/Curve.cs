using UnityEngine;

public class Curve : MonoBehaviour {

    Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);

    float[] points = new float[15];

    int j = 0;
    int i = 0;
    
    void Start()
    {
        points[0] = -6.0f; //x1
        points[1] = 2.0f; //y1
        points[2] = 0.0f; //z1

        points[3] = 2.5f; //x2
        points[4] = 3.5f; //y2
        points[5] = 0.0f; //z2

        points[6] = 0.5f; //x3
        points[7] = 8.5f; //y3
        points[8] = 0.0f; //z3

        points[9] = 8.0f; //x4
        points[10] = 4.0f; //y4
        points[11] = 0.0f; //z4

        points[12] = 12f; //x5
        points[13] = 5f; //y5
        points[14] = 0.0f; //z5
        
        for (int i = 0; i <= points.Length - 3; i += 3)
        {
            drawControlPoint(new Vector3(points[i], points[i + 1], points[i + 2]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (j >= 1000)
        {
            i += 3;
            j = 0;
        }

        if (i >= points.Length - 9)
        {
            i = 0;
        }

        float t = (float)(j) / 999.0f;

        float powt3 = (float)Mathf.Pow(t, 3.0f);
        float powt2 = (float)Mathf.Pow(t, 2.0f);

        pos.x = (float)(((-1.0f * powt3 + 3 * powt2 - 3.0f * t + 1.0f) * (float)points[i] +
                (3.0f * powt3 - 6.0f * powt2 + 0.0f * t + 4.0f) * (float)points[i + 3] +
                (-3.0f * powt3 + 3.0f * powt2 + 3.0f * t + 1.0f) * (float)points[i + 6] +
                (1.0f * powt3 + 0.0f * powt2 + 0.0f * t + 0.0f) * (float)points[i + 9]) / 6.0f);

        pos.y = (float)(((-1.0f * powt3 + 3.0f * powt2 - 3.0f * t + 1.0f) * (float)points[i + 1] +
                (3.0f * powt3 - 6.0f * powt2 + 0.0f * t + 4.0f) * (float)points[i + 4] +
                (-3.0f * powt3 + 3.0f * powt2 + 3.0f * t + 1.0f) * (float)points[i + 7] +
                (1.0f * powt3 + 0.0f * powt2 + 0.0f * t + 0.0f) * (float)points[i + 10]) / 6.0f);


        transform.LookAt(pos);
        transform.position = pos;

        j += 12;

    }

    void drawControlPoint(Vector3 position)
    {
        var point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        point.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        point.transform.position = position;
    }
}

