using System;
using UnityEngine;

public class TimeScaler :Singleton<TimeScaler>
{

    public float minTimeScale = 0.2f;
    public float maxTimeScale = 0.6f;
    public float stopTimeScale = 0.05f;
    public float neutralTimeScale = 0.5f;

    public Rigidbody car;

    private float input;
    private float previousTimeScale;

    private void OnEnable ( )
    {
        EventManager.AddListener( EventDefinition.PAUSE, OnPause );
        EventManager.AddListener( EventDefinition.PAUSE, OnUnPause );
    }

    private void OnDisable ( )
    {
        EventManager.RemoveListener( EventDefinition.PAUSE, OnPause );
        EventManager.RemoveListener( EventDefinition.PAUSE, OnUnPause );
    }

    private void OnUnPause ( )
    {
        Time.timeScale = previousTimeScale;
    }

    private void OnPause ( )
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    private void Start ( )
    {
        Time.timeScale = neutralTimeScale;
        if( car == null )
        {
            car = GameObject.FindGameObjectWithTag( "Player" ).GetComponent<Rigidbody>();
        }
    }

    private void Update ( )
    {
        input = Input.GetAxis( "Vertical" );
    }
    private void FixedUpdate ( )
    {
        if( input > 0 )
        {
            Time.timeScale = maxTimeScale;
        }
        if( input == 0 )
        {
            Time.timeScale = neutralTimeScale;
        }
        if( input < 0 )
        {
            Time.timeScale = minTimeScale;

            if( car.velocity.magnitude == 0 )
            {
                Time.timeScale = stopTimeScale;
            }
        }

        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
