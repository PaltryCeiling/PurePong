using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Prect lowerWall;
    public static Prect upperWall;
    public static Prect centerline;
    private Color wallColor = new Color(0, 1, 1, 1);
    private Color CenterLineColor = new Color(1, 0, 1, 0.5f);


    public static Vector2 ballLocation;
    public static float initBallSpeed = 0.5f;
    public static List<Prect> colliderPrects = new List<Prect>();


    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;
  
    

    // Start is called before the first frame update
    void Start()
    {
        upperWall = new Prect("Upper Wall", 0, 0, Screen.width, 10, true, "WALL");
        lowerWall = new Prect("Lower Wall", 0, Screen.height - 10, Screen.width, 10, true, "WALL");
        centerline = new Prect("Center Wall", Screen.width / 2, 0, 5, Screen.height, false, "CTRLINE");


        colliderPrects.Add(upperWall);
        colliderPrects.Add(lowerWall);




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE");
            foreach(Prect p in colliderPrects)
            {
                Debug.Log(p.name);
            }
        }
    }
    public static void GUIDrawRect(Rect position, Color color)
    {
        if(_staticRectTexture == null)
        {
            _staticRectTexture = new Texture2D(1, 1);

        }
        if(_staticRectStyle == null)
        {
            _staticRectStyle = new GUIStyle();
            _staticRectStyle.fontSize = 16;

        }
        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();
        _staticRectStyle.normal.background = _staticRectTexture;
        GUI.Box(position, GUIContent.none, _staticRectStyle);


    }
    private void OnGUI()
    {
        GUIDrawRect(centerline.rect, CenterLineColor);
        GUIDrawRect(upperWall.rect, wallColor);
        GUIDrawRect(lowerWall.rect,wallColor);
    }
}
