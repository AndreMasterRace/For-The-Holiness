using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour {

    public float speed;
    public GameObject prefab;

    private Vector3 vr;
    private Vector3 movement;
    private List<GameObject> bullets;
    private List<Vector3> vBullets;
    private GameObject cannon;
    private Quaternion cannonRotation;

    private float x;
    private float y;

    void Start()
    {
        bullets = new List<GameObject>();
        vBullets = new List<Vector3>();
        vr = new Vector3(0, 0, 20);
        cannon = GameObject.FindGameObjectWithTag("cannon");
        cannonRotation = cannon.transform.rotation;
        x = cannonRotation.eulerAngles.x;
        y = cannonRotation.eulerAngles.y;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movement = transform.up * speed;
            transform.position += movement;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-vr * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(vr * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            y -= 0.5f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            y += 0.5f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            x -= 0.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            x += 0.5f;
        }

        x = Mathf.Clamp(x, -60, -30);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vBullets.Add(cannon.transform.forward);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            vBullets[vBullets.Count - 1] *= 1.1f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            InstantiateBullet();
        }



        cannonRotation = Quaternion.Euler(x, y, 0);
        cannon.transform.rotation = cannonRotation;
    }

    void InstantiateBullet()
    {
        bullets.Add((GameObject)Instantiate(prefab, cannon.transform.position, Quaternion.identity));
    }

    public GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
}
