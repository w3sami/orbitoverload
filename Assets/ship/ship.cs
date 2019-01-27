using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables; // todo remove namespace
using RoboRyanTron.Unite2017.Events;

public class ship : MonoBehaviour {

    private bool dragging = false;
    private Rigidbody body;
    public float speed = 10;
    public float turboSpeed = 50;
    public float maxSpeed = 200;
    public bool tilt = false;
    public float tiltTime = 2f;
    public FloatVariable shipX;
    public FloatVariable shipY;
    public FloatVariable Turbo;
    public FloatVariable Fuel;
    private float turbo = 1;
    private float fuel = 1;
    public ParticleSystem blastLeft;
    public ParticleSystem blastRight;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        dragging = true;
    }

    public void reset()
    {
        fuel = 1;
        turbo = 1;
    }

    void FixedUpdate()
    {
        Fuel.SetValue(fuel);
        Turbo.SetValue(turbo);

        if (Input.GetKey(KeyCode.R))
        {
            this.enabled = true;
            reset();
        }

        var speedAndTurbo = speed;

        if (!tilt && (Input.GetMouseButtonDown(0) || Input.GetKey("joystick 1 button 0") || Input.GetKey("space")))
        {
            dragging = true;
            if (turbo > 0 && (Input.GetMouseButtonDown(2) || Input.GetKey("joystick 1 button 1") || Input.GetKey("z"))) {
                turbo -= .001f;
                fuel -= .0001f;
                speedAndTurbo = speed + turboSpeed;
            }
        }

        if (dragging && fuel > 0)
        {
            fuel -= .0001f;
            Vector3 point = Input.GetMouseButtonDown(0) ?
                Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position : 
                new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speedAndTurbo;

            var blast = body.velocity.magnitude / 2 + 2;
            var mainL = blastLeft.main;
            mainL.startSpeed = blast;
            var mainR = blastRight.main;
            mainR.startSpeed = blast;

            transform.up = body.velocity;
            body.angularVelocity = Vector3.zero;
            body.AddForce(point * Time.smoothDeltaTime * speedAndTurbo);

            if (body.velocity.magnitude > maxSpeed)
            {
                body.velocity = body.velocity.normalized * maxSpeed;
            }
        }
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp("joystick 1 button 0") || Input.GetKeyUp("space"))
        {
            dragging = false;
        }
        shipX.SetValue(transform.position.x);
        shipY.SetValue(transform.position.y);
    }

    void OnCollisionEnter()
    {
        dragging = false;
        tilt = true;

        StartCoroutine(waitAndRecover());
    }


    IEnumerator waitAndRecover()
    {
        yield return new WaitForSeconds(tiltTime);
        tilt = false;
    }

    public void OnShipDestroyed()
    {
        this.enabled = false;
    }
}
