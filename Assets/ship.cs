using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour {

    private bool dragging = false;
    private Rigidbody2D body;
    public float speed = 10;
    public float maxSpeed = 200;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        dragging = true;
    }


        // Update is called once per frame
    void FixedUpdate()
    {
        if (dragging)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.up = body.velocity;
            body.AddForce(point * Time.smoothDeltaTime * speed);

            if (body.velocity.magnitude > maxSpeed)
            {
                body.velocity = body.velocity.normalized * maxSpeed;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

    }
}
