using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    private playerController pC;
    private Vector3 offset;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 dir;

	// Use this for initialization
	void Start () {
        pC = new playerController();
        offset = transform.position - pC.GetCannon().transform.position;
        endPoint = pC.GetCannon().transform.position;
	}
	
	// Update is called once per frame
	void Update()
    {
        transform.position = pC.GetCannon().transform.position + offset;

        startPoint = pC.GetCannon().transform.forward;
        endPoint += startPoint * 300;
        //transform.rotation = pC.GetCannon().transform.rotation;
        dir = endPoint - pC.GetCannon().transform.position;

        transform.rotation = Quaternion.LookRotation(dir);
    }
}
