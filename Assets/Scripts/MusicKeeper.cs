using UnityEngine;

public class MusicKeeper :MonoBehaviour
{
    static GameObject thisMusique;

    private void Start ( )
    {
        if( thisMusique == null )
        {
            thisMusique = gameObject;
            DontDestroyOnLoad( gameObject );
        } else
        {
            Destroy( gameObject );
        }
    }
}
