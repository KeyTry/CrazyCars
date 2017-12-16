using UnityEngine;

public class PowerSpawn :MonoBehaviour
{
    public GameObject power;

    private void Start ( )
    {
        SpawnPower( );
    }

    private void SpawnPower ( )
    {
        var randomChance = Random.Range( 0, 9 );
        if( randomChance == 5 )
        {
            var randomDistanceZ = Random.Range( -15f, 15f );
            var randomDistanceX = Random.Range( -1.5f, 1.5f );

            PoolManager.Spawn( Instantiate( power, this.transform.position + new Vector3( randomDistanceX, 0f, randomDistanceZ ), transform.rotation ) );
        }
    }
}
