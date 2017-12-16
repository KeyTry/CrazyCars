using UnityEngine;

public class GameManager :Singleton<GameManager>
{
    public enum State
    {
        MENU_PINCIPAL,
        JUEGO_NUEVO
    }

    private State _state;

    public State Estado
    {
        get
        {
            return _state;
        }

        set
        {
            _state = value;
        }
    }

    public float points;
    public int displayPoints;
    public Rigidbody carro;
    public bool countPoints;
    public float minSpeedToCountPoints = 0.35f;

    private float carroSpeed;

    private void Start ( )
    {
        ClearPoints( );
    }

    private void ClearPoints ( )
    {
        points = 0;
    }

    private void Update ( )
    {
        Points( );
    }

    private void Points ( )
    {
        if( countPoints )
        {
            carroSpeed = carro.velocity.magnitude;
            if( carroSpeed > minSpeedToCountPoints )
            {
                points = ( ( points + ( ( Mathf.Pow( 1.2f, ( carroSpeed * 0.4f ) ) ) ) ) ) / 10;
            }
        }
    }

    public void ExitGame ( )
    {
        Application.Quit( );
    }
}
