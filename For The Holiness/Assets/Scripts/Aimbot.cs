using UnityEngine;
using System.Collections;

public class Aimbot : MonoBehaviour {

    private Vector3 dir;
    public GameObject prefab;
    private GameObject projectile;

	void Start()
    {
    }

    void FixedUpdate()
    {
        GameObject projectile = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
        projectile.transform.position = transform.position + Vector3.up;
    }
}
