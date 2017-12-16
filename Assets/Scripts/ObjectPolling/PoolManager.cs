using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Pool
{
    public GameObject prefab;
    public int size;
}

public class PoolManager :Singleton<PoolManager>
{
    public bool logStatus;
    public Transform root;

    private Dictionary<GameObject, ObjectPool<GameObject>> prefabLookup;
    private Dictionary<GameObject, ObjectPool<GameObject>> instanceLookup;

    public Pool[] warmer;

#if UNITY_EDITOR
    private void OnGUI ( )
    {
        if( logStatus )
        {
            _PrintStatus( );
        }
    }
# endif

    private void Awake ( )
    {
        prefabLookup = new Dictionary<GameObject, ObjectPool<GameObject>>( );
        instanceLookup = new Dictionary<GameObject, ObjectPool<GameObject>>( );

        if( warmer != null )
        {
            foreach( var pool in warmer )
            {
                _WarmPool( pool.prefab, pool.size );
            }
        }
    }

    private void _WarmPool ( GameObject prefab, int size )
    {
        if( prefabLookup.ContainsKey( prefab ) )
        {
            throw new Exception( "Pool for prefab " + prefab.name + " has already been created" );
        }
        var pool = new ObjectPool<GameObject>( ( ) =>
        {
            return _InstantiatePrefab( prefab );
        }, size );
        prefabLookup[ prefab ] = pool;
    }

    public GameObject _Spawn ( GameObject prefab )
    {
        return _Spawn( prefab, Vector3.zero, Quaternion.identity );
    }

    public GameObject _Spawn ( GameObject prefab, Vector3 position, Quaternion rotation, Transform parent )
    {
        var clone = _Spawn( prefab, position, rotation );
        clone.transform.parent = parent;
        return clone;
    }

    public GameObject _Spawn ( GameObject prefab, Vector3 position, Quaternion rotation )
    {
        if( !prefabLookup.ContainsKey( prefab ) )
        {
            WarmPool( prefab, 1 );
        }

        var pool = prefabLookup[ prefab ];

        var clone = pool.GetItem( );
        clone.transform.position = position;
        clone.transform.rotation = rotation;
        clone.SetActive( true );
        clone.BroadcastMessage( "OnSpawned", clone, SendMessageOptions.DontRequireReceiver );

        instanceLookup.Add( clone, pool );
        return clone;
    }

    public void _ReleaseObject ( GameObject clone )
    {
        clone.BroadcastMessage( "OnDespawned", clone, SendMessageOptions.DontRequireReceiver );

        if( instanceLookup.ContainsKey( clone ) )
        {
            instanceLookup[ clone ].ReleaseItem( clone );
            instanceLookup.Remove( clone );
        }

        clone.SetActive( false );
    }

    private GameObject _InstantiatePrefab ( GameObject prefab )
    {
        var go = Instantiate( prefab ) as GameObject;
        if( root != null )
        {
            go.transform.parent = root;
        }

        return go;
    }

    public void _PrintStatus ( )
    {
        foreach( KeyValuePair<GameObject, ObjectPool<GameObject>> keyVal in prefabLookup )
        {
            Debug.Log( string.Format( "Object Pool for Prefab: {0} In Use: {1} Total {2}", keyVal.Key.name, keyVal.Value.CountUsedItems, keyVal.Value.Count ) );
        }
    }

    #region Static API
    public static void PrintStatus ( )
    {
        Instance._PrintStatus( );
    }

    public static void WarmPool ( GameObject prefab, int size )
    {
        Instance._WarmPool( prefab, size );
    }

    public static GameObject Spawn ( GameObject prefab )
    {
        return Instance._Spawn( prefab );
    }

    public static GameObject Spawn ( GameObject prefab, Vector3 position, Quaternion rotation )
    {
        return Instance._Spawn( prefab, position, rotation );
    }

    //public static GameObject Spawn ( GameObject prefab, Vector3 position, Quaternion rotation, Transform parent )
    //{
    //    return Instance._Spawn( prefab, position, rotation, parent );
    //}

    public static void DeSpawn ( GameObject clone )
    {
        Instance._ReleaseObject( clone );
    }

    #endregion
}


