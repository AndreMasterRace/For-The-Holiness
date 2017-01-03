using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float speed;

    private Vector3 vr;
    private Vector3 movement;

    void Start()
    {
        vr = new Vector3(0, 0, 20);
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
    }
}
