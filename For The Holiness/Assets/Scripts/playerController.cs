using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour {

    public float speed;
    public GameObject prefab;

    private Vector3 vr;
    private Vector3 movement;
    private GameObject cannon;
    private Quaternion cannonRotation;
    private Dictionary<GameObject, Vector3> bullets;

    private float x;
    private float y;

    private float time;

    void Start()
    {
        bullets = new Dictionary<GameObject, Vector3>();
        vr = new Vector3(0, 0, 20);
        cannon = GameObject.FindGameObjectWithTag("cannon");
        time = 1.5f;
        cannonRotation = cannon.transform.rotation;

        x = cannonRotation.eulerAngles.x;
        y = cannonRotation.eulerAngles.y;

        Physics.IgnoreLayerCollision(8, 9, true);
    }

    void Update()
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

        x = Mathf.Clamp(x, -60, 0);

        if (Input.GetKeyDown(KeyCode.Space) && time >= 1.5f)
        {
            bullets.Add((GameObject)Instantiate(prefab, transform.position, Quaternion.identity), cannon.transform.forward);
            time = 0f;
        }

        foreach (GameObject go in bullets.Keys)
        {
            go.transform.position += bullets[go];
        }

        cannonRotation = Quaternion.Euler(x, y, 0);
        cannon.transform.rotation = cannonRotation;

        time += Time.deltaTime;
    }

    public GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    public GameObject GetCannon()
    {
        return GameObject.FindGameObjectWithTag("cannon");
    }
}