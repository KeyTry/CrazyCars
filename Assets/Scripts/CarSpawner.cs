using UnityEngine;

public class CarSpawner :MonoBehaviour
{
    private readonly float RANDOM_DISTANCIA_Z = 5f;
    private readonly float RANDOM_DISTANCIA_X = 1f;

    private readonly int MIN_RANDOM_CHANCE = 1;
    private readonly int MAX_RANDOM_CHANCE = 8;

    private readonly int CHANCE_TO_SPAWN = 3;

    public GameObject[] carrosList;

    private Transform[] spawnerList;
    private float[] nextSpawnList;

    private Transform transformSpawner;
    private Vector3 position;

    private void Awake ( )
    {
        spawnerList = GetComponentsInChildren<Transform>( );
        nextSpawnList = new float[ spawnerList.Length ];
    }

    private void Update ( )
    {
        for( int i = 0; i < nextSpawnList.Length; i++ )
        {
            if( NextFire( i ) )
            {
                SpawnCars( i );
            }
        }
    }

    private bool NextFire ( int i )
    {
        return Time.time >= nextSpawnList[ i ];
    }

    private void SpawnCars ( int i )
    {
        if( ChanceToSpawn( ) )
        {
            PickPosition( i );
            SpawnObject( );
        }
        CalcNextTime( i );
    }

    private bool ChanceToSpawn ( )
    {
        return Random.Range( MIN_RANDOM_CHANCE, MAX_RANDOM_CHANCE ) == CHANCE_TO_SPAWN;
    }

    private void PickPosition ( int i )
    {
        transformSpawner = spawnerList[ i ];
        position = transformSpawner.position + new Vector3( Random.Range( -RANDOM_DISTANCIA_X, RANDOM_DISTANCIA_X ), 0f, Random.Range( -RANDOM_DISTANCIA_Z, RANDOM_DISTANCIA_Z ) );
    }

    private void SpawnObject ( )
    {
        PoolManager.Spawn( carrosList[ Random.Range( 0, carrosList.Length ) ], position, transformSpawner.rotation );
    }

    private void CalcNextTime ( int i )
    {
        nextSpawnList[ i ] = Time.time + Random.Range( 0.5f, 2f );
    }
}
