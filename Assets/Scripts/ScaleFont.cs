using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScaleFont : MonoBehaviour
{
    
    public Vector2 offset;
    public float ratio = 10;
    
    // Use this for initialization
    void Start ()
    {
        
    }
    
    // Update is called once per frame
    void Update ()
    {
    }    

    void OnGUI(){
        
        float finalSize =  (float) ( Mathf.Min ( Screen.width, Screen.height ) /ratio );
        guiText.fontSize = (int)finalSize;
        guiText.pixelOffset = new Vector2( offset.x * Screen.width, offset.y * Screen.height);
    }
    
    
}
