using UnityEngine;

public class ParticleCreator : MonoBehaviour {

    float timeInSeconds = 8;
    GameObject obj;

    void Start () { 
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.A))
            defineA();
        else if (Input.GetKey(KeyCode.B))
            defineB();
        else if (Input.GetKey(KeyCode.C))
            defineC();
        else
            defineDefault();

        Destroy(obj, timeInSeconds);
    }

    void defineDefault() {
        defineShape();
        definePosition();
        defineColor();
        defineTrajectory();
    }

    void defineA()
    {
        obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.transform.position = new Vector3(-10, 0, -10);
        obj.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        obj.AddComponent<Circular>();
    }

    void defineB()
    {
        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.position = new Vector3(-5, 5, -10);
        obj.GetComponent<MeshRenderer>().material.color = new Color(0.8f, 0.0f, 1.0f, 1.0f);
        obj.AddComponent<Spiral>();
    }

    void defineC()
    {
        obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        obj.transform.position = new Vector3(-2, -8, -12);
        obj.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        obj.AddComponent<Line>();
    }

    void  defineShape() {        
        float shape = Random.value;
        if (shape <= 0.3)
            obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        else if (shape > 0.3 && shape <= 0.6)
            obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        else
            obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
    }

    void defineColor() {
        obj.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), 
                                                                    Random.Range(0.0f, 1.0f),
                                                                    Random.Range(0.0f, 1.0f), 
                                                                    1.0f);
    }

    void definePosition() {
        float x = Random.Range(-15.0f, -5.0f);
        float y = Random.Range(-10.0f, 20.0f);
        obj.transform.position = new Vector3(x, y, 0);
    }

    void defineTrajectory() {
        float trajectory = Random.value;
        if (trajectory <= 0.3)
            obj.AddComponent<Line>();
        else if (trajectory > 0.3 && trajectory <= 0.6)
            obj.AddComponent<Spiral>();
        else
            obj.AddComponent<Circular>();        
    }
}
