using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astrobee : MonoBehaviour
{
    public GameObject[] laserPoints;
    private Vector3[] positions;
    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector3[laserPoints.Length];
    }


    // Update is called once per frame
    public float rotationSpeed = 60f; // Rotation speed in degrees per second

    void Update()
    {
        for (int i = 0; i < laserPoints.Length; i++)
        {
            positions[i] = laserPoints[i].transform.position;
        }
        GetComponent<LineRenderer>().SetPositions(positions);
        GameObject targetObject = GameObject.Find("point2");
        Transform transform = targetObject.transform;
        Debug.Log("point1 transform: ");
        Debug.Log("Position: " + transform.position);
        Debug.Log("Rotation: " + transform.rotation);
        Debug.Log("Scale: " + transform.localScale);
        this.transform.position = targetObject.transform.position;
        this.transform.LookAt(GameObject.Find("target2").transform.position);
        Quaternion q = Quaternion.LookRotation(GameObject.Find("target2").transform.position - this.transform.position);
        //Debug.Log(Quaternion.Angle(GameObject.Find("target2").transform.rotation, this.transform.rotation));
        //this.transform.rotation = Quaternion.LookRotation(GameObject.Find("target2").transform.forward - this.transform.forward);
        this.transform.Rotate( GameObject.Find("target2").transform.forward - this.transform.forward );
    }
}