using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    
    public GameObject wall_bottom;
    public GameObject wall_top;
    public GameObject wall_right;
    public GameObject wall_left;
    GameObject tmp;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

	// Use this for initialization
	void Start () {

        var VertExtent = Camera.main.orthographicSize;
        var HorzExtent = VertExtent * Screen.width / Screen.height;

        minX = -Mathf.Floor(HorzExtent);
        maxX = Mathf.Floor(HorzExtent);
        minY = -Mathf.Floor(VertExtent);
        maxY = Mathf.Floor(VertExtent);

        wall_left.transform.position = new Vector3(minX, 0);
        wall_left.transform.localScale = new Vector3(1, maxY * 2, 0);

        wall_right.transform.position = new Vector3(maxX, 0);
        wall_right.transform.localScale = new Vector3(1, maxY * 2, 0);

        wall_bottom.transform.position = new Vector3(0, minY);
        wall_bottom.transform.localScale = new Vector3(maxX * 2, 1, 0);

        wall_top.transform.position = new Vector3(0, maxY);
        wall_top.transform.localScale = new Vector3(maxX * 2, 1, 0);
    }
	
}
