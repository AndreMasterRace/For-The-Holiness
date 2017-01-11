using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Aimbot : MonoBehaviour {

    public GameObject prefab;
    public float speed;

    private playerController pC;
    private Vector3 dir;
    private Quaternion cannonRotation;
    private Dictionary<GameObject, Vector3> bullets;

    private float time;

    void Start()
    {
        bullets = new Dictionary<GameObject, Vector3>();
        pC = new playerController();

        if (gameObject.CompareTag("enemyCannon1"))
        {
            time = 0f;
        }
        else if (gameObject.CompareTag("enemyCannon2"))
        {
            time = 0.375f;
        }
        else if (gameObject.CompareTag("enemyCannon3"))
        {
            time = 0.75f;
        }
        else if (gameObject.CompareTag("enemyCannon4"))
        {
            time = 1.125f;
        }
    }

    void Update()
    {
        if (time >= 1.5f)
        {
            bullets.Add((GameObject)Instantiate(prefab, transform.position, Quaternion.identity), dir);
            time = 0f;
        }

        foreach (GameObject go in bullets.Keys)
        {
            go.transform.position += bullets[go] * speed;
        }

        dir = pC.GetPlayer().transform.position - transform.position;
        cannonRotation = Quaternion.LookRotation(dir);

        transform.rotation = cannonRotation;

        time += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}