using UnityEngine;
using System.Collections;

public class Aimbot : MonoBehaviour {

    public GameObject prefab;
    public float speed;

    private Vector3 dir;
    private GameObject projectile;
    private playerController pC;
    private float time;

	void Start()
    {
        pC = new playerController();
        projectile = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        dir = pC.GetPlayer().transform.position - transform.position;
        projectile.transform.position += dir * speed;
    }
}
