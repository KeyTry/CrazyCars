using System.Collections;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class CarroUser2 :MonoBehaviour
{
    public GameObject glow;
    public float powerTime = 3f;
    public bool inPower;

    public bool input;
    CarroEplode explode;
    CarroScript colScript;
    public float speed;
    public float constSpeed;
    public float HightSpeed;

    public AudioClip explosionSound;
    public AudioClip accelerationSound;
    public AudioClip idleSound;
    AudioSource audioSource;

    public float tilt;

    private float velocity;

    private Rigidbody rigidbody;

    public bool toExplode;

    bool crash;
    bool accelerating;
    bool idle;

    float prevConstSpeed;

    void Awake ( )
    {
        input = false;
        explode = gameObject.GetComponent<CarroEplode>( );
        rigidbody = GetComponent<Rigidbody>( );

        glow.SetActive( false );
        inPower = false;
        audioSource = gameObject.GetComponent<AudioSource>( );
        idle = false;
        accelerating = true;
        crash = false;
    }

    void FixedUpdate ( )
    {
        Vector3 movement = new Vector3( 0.0f, 0.0f, constSpeed );
        if( input )
        {
            float moveHorizontal = Input.GetAxis( "Horizontal" );
            float moveVertical = Input.GetAxis( "Vertical" );


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

            movement = new Vector3( moveHorizontal, 0.0f, moveVertical );
        }
        rigidbody.velocity = movement * speed;

        rigidbody.rotation = Quaternion.Euler( 0.0f, rigidbody.velocity.x * -tilt, 0.0f );
    }

    void OnCollisionEnter ( Collision col )
    {
        if( col.gameObject.CompareTag( "Car" ) )
        {
            if( toExplode )
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
        Destroy( obj.gameObject );

        if( !inPower )
        {
            StartCoroutine( Power( ) );
        }
    }

    public void StopCar ( )
    {
        prevConstSpeed = constSpeed;
        constSpeed = 0;
    }

    public void ResumeCar ( )
    {
        constSpeed = prevConstSpeed;
    }

    IEnumerator Power ( )
    {

        glow.SetActive( true );

        inPower = true;
        toExplode = false;

        yield return new WaitForSeconds( powerTime );

        glow.SetActive( false );

        inPower = false;
        toExplode = true;

    }
}
