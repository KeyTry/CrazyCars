using UnityEngine;

public class Power :MonoBehaviour
{

    private CarroUser carro;

    private void Start ( )
    {
        carro = FindObjectOfType<CarroUser>( );
    }

    void OnTriggerEnter ( Collider col )
    {
        if( col.gameObject.CompareTag( "Player" ) )
        {
            carro.ActivatePower( this );
        }
    }
}
