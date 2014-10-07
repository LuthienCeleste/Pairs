using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimateColorTittle : MonoBehaviour {
    public float timePeriod;
    
    private float elapsedTime;
    private Vector3 colorSphereStart;
    private Vector3 colorSphereEnd;

    private Text text;

    // Use this for initialization
    void Start () {
        elapsedTime = 0f;
        colorSphereStart = Random.onUnitSphere;
        ChoseColorSphereEnd ();
        GameObject obj = GameObject.Find ("Text");
        text = obj.GetComponent<Text> ();

    }
    
    // We use a sphere surface to lerp Hue and saturation.
    // The angle from atan2( x, y ) is the hue.
    // z is the saturation. With z=0 meaning max saturation and z=-1 or z=-1 meaning minimun saturation.
    
    // Update is called once per frame
    void Update () {
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= timePeriod) {
            elapsedTime = 0f;
            colorSphereStart = colorSphereEnd;
            ChoseColorSphereEnd();
        }
        
        float ratio = elapsedTime / timePeriod;
        Vector3 currentSphereColor = Vector3.Slerp (colorSphereStart, colorSphereEnd, ratio);
        float h = Mathf.Atan2 (currentSphereColor.y, currentSphereColor.x);
        if (h < 0f)
            h += Mathf.PI;
        h /= 2*Mathf.PI;
        float s = 1f - Mathf.Abs (currentSphereColor.z);
        s *= .3f;
        s += .5f;
        
        if (h < 0 || s < 0)
            Debug.Log ("HSV = " + h + "," + s + ",1");
        text.color = Util.HSVtoRGB (h, s, 1f);
        if (h < 0 || s < 0)
            Debug.Log ("Color  : " + guiText.color);
        
    }
    
    private void ChoseColorSphereEnd ()
    {
        do {
            colorSphereEnd = Random.onUnitSphere;
        } while ( (colorSphereEnd-colorSphereStart).magnitude < 1f );
    }
}
