using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {

    public GameObject food;
    public GameObject new_head;

    public GameObject border_left;
    public GameObject border_right;
    public GameObject border_top;
    public GameObject border_bottom;

    public int master_counter;
    public int limit_counter;

    public bool timedSpawning;
    public bool autoPlay;

    void Start() {
        
        //NOTE: if true, then constant spawing
        if (timedSpawning) {
            InvokeRepeating("Spawn", 1, .001f);
        }
        else {
            Spawn();
        }
        
    }

    void Update() {
        if (!timedSpawning) {
            if(GameObject.FindGameObjectsWithTag("food").Length == 0) {
                Spawn();
            }
        }
        if (autoPlay) {
            if (GameObject.FindGameObjectsWithTag("head").Length == 0) {
                Instantiate(new_head, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }

        master_counter = GameObject.FindGameObjectsWithTag("food").Length;

    }

    public void Spawn() {
        //int x = (int)Random.Range(border_left.transform.position.x + border_left.GetComponent<BoxCollider2D>().bounds.size.x, border_right.transform.position.x - border_right.GetComponent<BoxCollider2D>().bounds.size.x);
        //int y = (int)Random.Range(border_bottom.transform.position.y + border_bottom.GetComponent<BoxCollider2D>().bounds.size.y, border_top.transform.position.y - border_top.GetComponent<BoxCollider2D>().bounds.size.y);

        int x = (int)Random.Range(border_left.transform.position.x, border_right.transform.position.x);
        int y = (int)Random.Range(border_bottom.transform.position.y, border_top.transform.position.y);

        food.GetComponent<SpriteRenderer>().color = new Color32((byte)Random.Range(50, 255), (byte)Random.Range(50, 255), (byte)Random.Range(50, 255), 255);
        

        if(master_counter < limit_counter) {
            Instantiate(food, new Vector2(x, y), Quaternion.identity);
        }
    }

    public void newHead() {
        
    }

}
