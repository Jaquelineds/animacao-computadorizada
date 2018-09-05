using UnityEngine;

public class ParticleCreator : MonoBehaviour {

    float timeInSeconds = 5;
    GameObject obj;

    void Start () {
		
	}
	
	void Update () {
        defineShape();
        definePosition();
        //defineTrajectory();
        Destroy(obj, timeInSeconds);
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

    void definePosition() {
        float x = Random.Range(-15.0f, -5.0f);
        float y = Random.Range(10.0f, -10.0f);
        obj.transform.position = new Vector3(x, y, 0);
        obj.AddComponent<Rigidbody>();
    }

    void defineTrajectory() {
        float trajectory = Random.value;
        if (trajectory <= 0.3)
            obj.AddComponent<Line>();
        else if (trajectory > 0.3 && trajectory <= 0.6)
            obj.AddComponent<Spiral>();
        else
            obj.AddComponent<Line>();        
    }
}
