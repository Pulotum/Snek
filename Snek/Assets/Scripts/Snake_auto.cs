using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake_auto : MonoBehaviour {

    Vector2 dir = Vector2.right;
    Color32 food_color;

    List<Transform> tails_obj = new List<Transform>();
    Color32[] tails_col = new Color32[1000];
    int col_counter = 0;
    bool ate = false;

    public bool canTouch;

    public GameObject tailObject;

    public bool waitToMove;
    public double speed_fin;
    public double speed_start;
    public double speed_rate;

    // Use this for initialization
    void Start() {
        
        waitToMove = false;
        StartCoroutine(MoveWait(speed_start));
    }

    void Update() {

        if(GameObject.FindGameObjectsWithTag("food").Length > 0) {
            Transform food_pos = GameObject.FindGameObjectWithTag("food").transform;

            Transform this_pos = this.transform;

            if (food_pos.position.x > this_pos.position.x) {
                dir = Vector2.right;
            }
            else if (food_pos.position.x < this_pos.position.x) {
                dir = Vector2.left;
            }
            else if (food_pos.position.x == this_pos.position.x) {
                if (food_pos.position.y > this_pos.position.y) {
                    dir = Vector2.up;
                }
                else if (food_pos.position.y < this_pos.position.y) {
                    dir = Vector2.down;
                }
            }

        }
        



        speed_fin = (speed_start - (tails_obj.Count * speed_rate));
        if (speed_fin < 0) {
            speed_fin = 0;
        }
        StartCoroutine(MoveWait(speed_fin));


    }

    void Move() {
        Vector2 v = transform.position;

        transform.Translate(dir);

        if (ate) {
            GameObject g = (GameObject)Instantiate(tailObject, v, Quaternion.identity);
            g.GetComponent<SpriteRenderer>().color = tails_col[col_counter - 1];
            tails_obj.Insert(0, g.transform);
            ate = false;
        }
        else if (tails_obj.Count > 0) {
            tails_obj.Last().position = v;

            tails_obj.Insert(0, tails_obj.Last());

            double value = 100 / tails_obj.Count;
            int i = 0;

            foreach (Transform ob in tails_obj) {
                double math = (value / 100) * i;

                if (i > 0) {
                    //ob.transform.localScale = new Vector3((float)(0.9f - math), (float)(0.9f - math), 0);
                    //ob.GetComponent<SpriteRenderer>().color = tails_col[i - 1];
                }
                if (i == tails_obj.Count - 1) {
                    //ob.transform.localScale = new Vector3((float)(0.9f - (math / i * 0.5)), (float)(0.9f - (math / i * 0.5)), 0);
                    //ob.GetComponent<SpriteRenderer>().color = tails_col[col_counter - 1];
                }
                ob.GetComponent<SpriteRenderer>().color = tails_col[col_counter - 1];
                i++;
            }


            tails_obj.RemoveAt(tails_obj.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.name.StartsWith("food")) {
            ate = true;
            tails_col[col_counter] = coll.GetComponent<SpriteRenderer>().color;
            col_counter++;
            Destroy(coll.gameObject);
        }
        else {
            if (!canTouch) {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("tails")) {
                    Destroy(obj);
                }
                Destroy(this.gameObject);
            }
        }
    }

    private IEnumerator MoveWait(double tim) {
        if (!waitToMove) {
            Move();
            waitToMove = true;
            yield return new WaitForSeconds((float)tim);
            waitToMove = false;
        }
    }

}
