using UnityEngine;

public class GameManager :MonoBehaviour
{

    public float points;
    public int displayPoints;
    public Rigidbody carro;
    public bool countPoints;
    float carroSpeed;

    // Use this for initialization
    void Start ( )
    {
        points = 0;
    }

    // Update is called once per frame
    void Update ( )
    {
        if( countPoints )
        {
            carroSpeed = carro.velocity.magnitude;
            if( carroSpeed > 0.3f )
            {
                points = ( ( points + ( ( Mathf.Pow( 1.2f, ( carroSpeed * 0.4f ) ) ) ) ) );
                displayPoints = ( int )( points / 10 );
            }
        }
    }

    public void exitGame ( )
    {
        Application.Quit( );
    }
}
