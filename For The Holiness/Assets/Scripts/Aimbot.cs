using UnityEngine;
using System.Collections;

public class Aimbot : MonoBehaviour {

    public GameObject prefab;
    public float speed;

    private playerController pC;
    private Vector3 dir;
    private Quaternion cannonRotation;

    void Start()
    {
        pC = new playerController();
        dir = pC.GetPlayer().transform.position - transform.position;
        cannonRotation = transform.rotation;
    }

    void Update()
    {
        cannonRotation = Quaternion.LookRotation(dir);

        transform.rotation = cannonRotation;
    }
}
