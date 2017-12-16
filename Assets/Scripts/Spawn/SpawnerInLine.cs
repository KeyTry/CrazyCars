using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Section
{
    public Transform from;
    public Transform to;

    public float minSize;
    public float maxSize;

    public bool randomX;
    public bool randomY;
    public bool randomZ;

}

public class SpawnerInLine :Spawneable
{

    public GameObject[] PrefabList;

    public Section[] seccions;

    public Transform SpawnerFather;

    private List<GameObject> instanceList;

    private Vector3 pos;

    private void OnSpawned ( )
    {
        Init( );
    }

    private void OnDespawned ( )
    {
        Dispose( );
    }

    private void Initialize ( )
    {
        instanceList = new List<GameObject>( );
    }

    public override void Init ( )
    {
        Initialize( );
        Generate( );
    }

    public override void Dispose ( )
    {
        foreach( var item in instanceList )
        {
            PoolManager.DeSpawn( item );
        }
    }

    private void Generate ( )
    {
        foreach( var sec in seccions )
        {
            var size = Random.Range( sec.minSize, sec.maxSize );

            for( int i = 0; i < size; i++ )
            {
                Put( sec, i, size );
            }
        }
    }

    private void Put ( Section sec, int i, float size )
    {
        pos = Vector3.Lerp( sec.from.position, sec.to.position, GetRandomLerp( i, size ) );

        instanceList.Add( PoolManager.Spawn( PrefabList[ Random.Range( 0, PrefabList.Length ) ], pos, GetRotation( sec ) ) );
    }

    private float GetRandomLerp ( int i, float size )
    {
        return Random.Range( i * ( 1f / size ), i + 1 * ( 1f / size ) );
    }

    private Quaternion GetRotation ( Section sec )
    {
        if( !( sec.randomX || sec.randomY || sec.randomZ ) )
        {
            return Quaternion.identity;
        }

        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;

        if( sec.randomX )
        {
            x = Random.Range( 0f, 360f );
        }
        if( sec.randomY )
        {
            y = Random.Range( 0f, 360f );
        }
        if( sec.randomZ )
        {
            z = Random.Range( 0f, 360f );
        }

        return Quaternion.Euler( x, y, z );
    }
}
