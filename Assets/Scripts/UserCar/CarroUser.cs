using System;
using System.Collections;
using UnityEngine;

public class CarroUser :MonoBehaviour
{
    public GameObject glow;
    public float powerTime = 3f;
    public bool inPower;
    public float inPowerTimer;

    private bool inUI;
    private bool input;

    public float speed;
    public float constSpeed;
    public float HightSpeed;

    public AudioClip explosionSound;
    public AudioClip accelerationSound;
    public AudioClip idleSound;

    public float tilt;

    private Rigidbody rb;
    private CarroEplode explode;
    private AudioSource audioSource;

    private bool canExplode;

    private bool crash;
    private bool accelerating;
    private bool idle;

    private float prevConstSpeed;

    private Vector3 movement;
    private float moveHorizontal;
    private float moveVertical;

    private void OnEnable ( )
    {
        EventManager.AddListener( EventDefinition.PAUSE, OnPause );
        EventManager.AddListener( EventDefinition.RESUME, OnResume );
        EventManager.AddListener( EventDefinition.JUEGO_NUEVO, OnNewGame );
        EventManager.AddListener( EventDefinition.FIN_BLINKING_UI, OnFinBlinkingUI );
    }

    private void OnDisable ( )
    {
        EventManager.RemoveListener( EventDefinition.PAUSE, OnPause );
        EventManager.RemoveListener( EventDefinition.RESUME, OnResume );
        EventManager.RemoveListener( EventDefinition.JUEGO_NUEVO, OnNewGame );
        EventManager.RemoveListener( EventDefinition.FIN_BLINKING_UI, OnFinBlinkingUI );
    }

    private void OnFinBlinkingUI ( )
    {
        inUI = false;
        canExplode = true;
        input = true;
    }

    private void OnNewGame ( )
    {
        inUI = true;
        canExplode = false;
        input = true;
    }

    private void OnResume ( )
    {
        constSpeed = prevConstSpeed;

        inUI = false;
        canExplode = true;
        input = true;
    }

    private void OnPause ( )
    {
        inUI = true;
        canExplode = false;
        input = false;

        prevConstSpeed = constSpeed;
        constSpeed = 0;
    }

    void Awake ( )
    {
        inUI = true;
        explode = gameObject.GetComponent<CarroEplode>( );
        rb = GetComponent<Rigidbody>( );

        movement = new Vector3( );

        glow.SetActive( false );
        inPower = false;
        audioSource = gameObject.GetComponent<AudioSource>( );
        idle = false;
        accelerating = true;
        crash = false;
    }

    private void Update ( )
    {
        SetMovement( 0.0f, 0.0f, constSpeed );

        CheckInput( );

        Power( );
    }

    private void CheckInput ( )
    {
        if( input )
        {
            moveHorizontal = Input.GetAxis( "Horizontal" );
            moveVertical = Input.GetAxis( "Vertical" );

            if( moveVertical > 0 )
            {
                moveVertical += ( HightSpeed * moveVertical );
                if( !crash && !accelerating && idle )
                {
                    audioSource.clip = accelerationSound;
                    audioSource.Play( );
                    accelerating = true;
                    idle = false;
                }
            } else
            {
                moveVertical += constSpeed;
                if( !crash && !idle && accelerating )
                {
                    audioSource.clip = idleSound;
                    audioSource.Play( );
                    accelerating = false;
                    idle = true;
                }
            }
            SetMovement( moveHorizontal, 0.0f, moveVertical );
        }
    }

    void FixedUpdate ( )
    {
        rb.velocity = movement * speed;
        rb.rotation = Quaternion.Euler( 0.0f, rb.velocity.x * -tilt, 0.0f );
    }

    private void SetMovement ( float x, float y, float z )
    {
        movement.x = x;
        movement.y = y;
        movement.z = z;
    }

    void OnCollisionEnter ( Collision col )
    {
        if( col.gameObject.CompareTag( "Car" ) )
        {
            if( !inUI && canExplode )
            {
                if( !crash )
                {
                    audioSource.clip = explosionSound;
                    audioSource.Play( );
                    crash = true;
                }
                explode.Explode( );
            }

            if( inPower )
            {
                col.gameObject.GetComponent<CarroScript>( ).Explode( );
            }

        }
    }

    public void ActivatePower ( Power obj )
    {
        PoolManager.DeSpawn( obj.gameObject );
        inPowerTimer += powerTime;
    }

    private void Power ( )
    {
        if( inPowerTimer > 0f )
        {
            if( !inPower )
            {
                glow.SetActive( true );
                inPower = true;
                canExplode = false;
            }
            inPowerTimer -= Time.unscaledDeltaTime;
        } else if( inPower )
        {
            glow.SetActive( false );
            inPower = false;

            if( !inUI )
            {
                canExplode = true;
            }
        }
    }
}
