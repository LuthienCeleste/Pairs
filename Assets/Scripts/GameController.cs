using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private float maxTime;
    public float extraTimePerMatching;

    private float remainingTime;

    public GameObject tilePrefab;
    private G g;

    private GameObject timeBar;
    private GameObject quitDialog;

    private bool isQuitScreenShowing;

    // Use this for initialization
    void Start ()
    {
        g = GameObject.Find ("G").GetComponent<G> ();
        timeBar = GameObject.Find ("TimeBar");
        quitDialog = GameObject.Find ("QuitDialog");
        quitDialog.gameObject.SetActive (false);
        SetupLevel ();
        maxTime = 1f + 2 * g.getLevel ();
        remainingTime = maxTime;
        isQuitScreenShowing = false;
    }

    // Update is called once per frame
    void Update ()
    {
        CheckEscape ();
        if ( !IsQuitScreenShowing() )
            UpdateTime ();
        UpdateWhiteIconEnabled ();
    }

    public bool IsQuitScreenShowing()
    {
        return isQuitScreenShowing;
    }

    private void SetupLevel ()
    {
        SetupScreenSize ();
        SetupNewBoard ();
    }

    private float screenHeight;
    private float screenWidth;
    private float gameWidth;
    private Camera mainCamera;
    private Vector3 iconScale;
    private Vector3 boardOrigin;
    private float iconStep;
    private float iconSize;

    private float barHeight;
    private GameObject whiteIcon;

    private void SetupScreenSize ()
    {
        mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
        screenHeight = mainCamera.orthographicSize * 2f;
        screenWidth = mainCamera.aspect * mainCamera.orthographicSize * 2f;

        // reservar 5% superior para la barra de tiempo.
        if (screenWidth / screenHeight < .95f) {
            // Podemos usar todo el ancho para el tablero y nos sobra altura para la barra de tiempo
            gameWidth = screenWidth;
        } else {
            //  Usar 95% de la altura para tablero y 5% para barra tiempo
            gameWidth = screenHeight * .95f;
        }
        int level = g.getLevel ();
        iconSize = tilePrefab.renderer.bounds.size.x;
        iconScale = new Vector3 (gameWidth / iconSize / level, gameWidth / iconSize / level, 0f);
        iconStep = gameWidth / level;

        float totalHeight = gameWidth / .95f;
        barHeight = totalHeight - gameWidth;
        boardOrigin = new Vector3 (- (level - 1f) / 2f * iconStep, - (level - 1) / 2f * iconStep - barHeight / 2f);

        timeBar.transform.localScale = new Vector3 (
            gameWidth / iconSize,
            0.05f * gameWidth / iconSize,
            0f);
        timeBar.transform.position = new Vector3 (0f, gameWidth / 2 + barHeight / 2, 0f);
    }

    private void SetupNewBoard ()
    {
        List<int> typesUsed = new List<int> ();
        bool[,] usedPosition;

        usedPosition = new bool[g.getLevel (), g.getLevel ()];
        for (int i=0; i<g.getLevel(); ++i) {
            for (int j=0; j<g.getLevel(); ++j)
                usedPosition [i, j] = false;
        }

        if (g.getLevel () % 2 != 0) {
            usedPosition [g.getLevel () / 2, g.getLevel () / 2] = true;
        }

        int numPairs = g.getLevel () * g.getLevel () / 2;
        for (int i=0; i<numPairs; ++i) {
            int type = getNonUsedType (typesUsed);
            typesUsed.Add (type);
            int x1;
            int y1;
            getNonUsedPosition (usedPosition, out x1, out y1);
            usedPosition [x1, y1] = true;
            int x2;
            int y2;
            getNonUsedPosition (usedPosition, out x2, out y2);
            usedPosition [x2, y2] = true;
            Color color = RandomColor ();
            GameObject tile1 = Instantiate (tilePrefab, 
                                           boardOrigin + Vector3.right * iconStep * x1 + Vector3.up * iconStep * y1,
                                           Quaternion.identity) 
                                as GameObject;
            tile1.transform.localScale = iconScale;
            TileController cont1 = tile1.GetComponent<TileController> ();
            cont1.setData (type, x1, y1, this);
            GameObject tile2 = Instantiate (tilePrefab, 
                                          boardOrigin + Vector3.right * iconStep * x2 + Vector3.up * iconStep * y2,
                                          Quaternion.identity) 
                               as GameObject;
            cont1.GetComponent<SpriteRenderer> ().sprite = g.getIcons () [type];
            cont1.GetComponent<SpriteRenderer> ().color = color;
            tile2.transform.localScale = iconScale;
            TileController cont2 = tile2.GetComponent<TileController> ();
            cont2.setData (type, x2, y2, this);
            cont2.GetComponent<SpriteRenderer> ().sprite = g.getIcons () [type];
            cont2.GetComponent<SpriteRenderer> ().color = color;

            activeTiles = g.getLevel()*g.getLevel();
            if ( activeTiles%2!=0 )
                --activeTiles;
            maxTiles = activeTiles;
        }

        selectedTile = null;

        whiteIcon = GameObject.Find ("WhiteIcon") as GameObject;
        whiteIcon.renderer.enabled = false;
        whiteIcon.transform.position = Vector3.forward;
        whiteIcon.transform.localScale = iconScale;
    }

    private Color RandomColor ()
    {
        Color res = new Color (Random.Range (.4f, .6f),
                               Random.Range (.4f, .6f),
                               Random.Range (.7f, .6f),
                               1f);
        switch (Random.Range (0, 3)) {
        case 0:
            res.r = Random.Range (.7f, 1f);
            break;
        case 1:
            res.g = Random.Range (.7f, 1f);
            break;
        case 2:
            res.b = Random.Range (.7f, 1f);
            break;
        }
        return res;
    }

    private int getNonUsedType (List<int> typesUsed)
    {
        int res;
        do {
            res = Random.Range (0, g.getIcons ().Length);
        } while ( typesUsed.Contains(res) );
        return res;
    }

    private void getNonUsedPosition (bool[,] usedPosition, out int x, out int y)
    {
        do {
            x = Random.Range (0, g.getLevel ());
            y = Random.Range (0, g.getLevel ());
        } while ( usedPosition[x,y] );
    }

    private GameObject selectedTile;
    private int activeTiles;
    private int maxTiles;

    public void TileClicked (TileController tile)
    {
        if (IsQuitScreenShowing ())
            return;
        if (selectedTile == null ||
            selectedTile.GetComponent<TileController> ().GetIconType () != tile.GetIconType () ||
            selectedTile == tile.gameObject) {
            selectedTile = tile.gameObject;
            UpdateWhiteIconPosition ();
            return;
        }

        activeTiles -= 2;
        DestroyTile (tile.gameObject);
        DestroyTile (selectedTile);
        selectedTile = null;
        UpdateWhiteIconPosition ();

        remainingTime += extraTimePerMatching * ( ( .5f * activeTiles / maxTiles ) + .5f );

        if (activeTiles <= 0) {
            g.getNextLevel();
            Application.LoadLevel("GameScene");
        }
    }

    private void UpdateWhiteIconPosition ()
    {
        if (selectedTile == null) 
            return;

        whiteIcon.transform.position = 
            boardOrigin +
                selectedTile.GetComponent<TileController> ().GetBoardX () * iconStep * Vector3.right +
                selectedTile.GetComponent<TileController> ().GetBoardY () * iconStep * Vector3.up +
                Vector3.forward;
        
    }
    
    private void UpdateWhiteIconEnabled ()
    {
        if (selectedTile == null) {
            whiteIcon.renderer.enabled = false;
            return;
        }
        whiteIcon.renderer.enabled = !IsQuitScreenShowing();
    }
    
    private void DestroyTile (GameObject tile)
    {
        GameObject.Destroy (tile);
    }

    private void UpdateTime()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f) {
            Application.LoadLevel ("GameOverScene");
            return;
        }
        float ratioTime = remainingTime / maxTime;
        ratioTime = Mathf.Clamp (ratioTime, 0f, 1f);
        timeBar.transform.localScale = new Vector3 (
            ratioTime * gameWidth / iconSize,
            0.05f * gameWidth / iconSize,
            0f);
        timeBar.transform.position = new Vector3 (
            -gameWidth*(1f-ratioTime)/2f, 
            gameWidth / 2 + barHeight / 2, 
            0f);
    }

    public void OnClickContinue()
    {
        isQuitScreenShowing = false;
        quitDialog.SetActive (false);
    }

    public void OnClickQuit()
    {
        Application.Quit ();
    }

    private void CheckEscape()
    {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            quitDialog.SetActive(true);
            isQuitScreenShowing = true;
        }
    }
}













