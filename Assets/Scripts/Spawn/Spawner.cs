using System.Collections.Generic;
using UnityEngine;

public class Spawner :Spawneable
{
    public GameObject[] PrefabList;
    public Transform SpawnerFather;

    private List<Transform> _spawnerList;

    private List<GameObject> _instanceList;

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
        _spawnerList = new List<Transform>( );
        _instanceList = new List<GameObject>( );

        SpawnerFather.GetComponentsInChildren( _spawnerList );
        _spawnerList.Remove( SpawnerFather.transform );
    }

    public override void Init ( )
    {
        Initialize( );
        Generate( );
    }

    public override void Dispose ( )
    {
        foreach( var item in _instanceList )
        {
            PoolManager.DeSpawn( item );
        }
    }

    private void Generate ( )
    {
        foreach( var item in _spawnerList )
        {
            Put( item );
        }
    }

    private void Put ( Transform item )
    {
        _instanceList.Add( PoolManager.Spawn( PrefabList[ Random.Range( 0, PrefabList.Length ) ], item.position, Quaternion.Euler( item.localEulerAngles ) ) );
    }
}
