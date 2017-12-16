using UnityEngine;
using UnityEngine.UI;

public class PuntosDisplay :MonoBehaviour
{
    public Rigidbody carro;
    public Text txt;
    public Color32 fastColor;
    public Color32 slowColor;

    private void Start ( )
    {

        if( carro == null )
        {
            carro = FindObjectOfType<CarroUser>( ).GetComponent<Rigidbody>( );
        }

        if( txt == null )
        {
            txt = gameObject.GetComponent<Text>( );
        }

    }

    private void OnGUI ( )
    {
        txt.text = GameManager.Instance.points.ToString();
        if( carro.velocity.magnitude > 18 )
        {
            txt.color = fastColor;
        } else
        {
            txt.color = slowColor;
        }
    }
}
