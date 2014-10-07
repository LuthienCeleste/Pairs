using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {
    public float minimumScreenDuration;
    
    private float elapsedTime;
    
	// Use this for initialization
	void Start () {
        elapsedTime = 0f;	
	}
	
    // Update is called once per frame
    void Update () {
        elapsedTime += Time.deltaTime;
        if ( Input.GetButtonUp("Fire1") && elapsedTime > minimumScreenDuration )
            Application.LoadLevel ("TittleScene");
    }
    

}
