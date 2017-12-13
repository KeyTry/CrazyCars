using UnityEngine;
using UnityEngine.UI;

public class PuntosDisplay :MonoBehaviour
{

    public GameObject managerObject;
    public Rigidbody carro;
    GameManager gm;
    Text txt;
    Color32 redColor;

    // Use this for initialization
    void Start ( )
    {
        txt = gameObject.GetComponent<Text>( );
        gm = managerObject.GetComponent<GameManager>( );
        redColor = new Color32( 214, 61, 61, 255 );
    }

    // Update is called once per frame
    void OnGUI ( )
    {
        txt.text = "" + gm.displayPoints;
        if( carro.velocity.magnitude > 18 )
        {
            txt.color = redColor;
        } else
        {
            txt.color = Color.white;
        }
    }
}
