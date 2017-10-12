using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

    public Text over;
    public Text pause;
    public Text over_exit;
    public Text pause_exit;

    AudioSource sound;
    public AudioClip death;
    public AudioClip puse;

    public bool isPaused;
    public bool isDead;

	// Use this for initialization
	void Start () {
        over.enabled = false;
        pause.enabled = false;
        over_exit.enabled = false;
        pause_exit.enabled = false;
        isPaused = false;
        isDead = false;

        sound = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectsWithTag("head").Length == 0) {
            if (!isDead) {
                StartCoroutine(dead());
                isDead = true;
            }
            over.enabled = true;
            over_exit.enabled = true;
        }
        else {
            if (isPaused) {
                pause.enabled = true;
                pause_exit.enabled = true;
                Time.timeScale = 0f;
            }
            else {
                pause.enabled = false;
                pause_exit.enabled = false;
                Time.timeScale = 1f;
            }
        }
        
        
        if (Input.GetKey(KeyCode.Q)) {
            Application.Quit();
        }
        if (Input.GetKeyUp(KeyCode.Escape)) {
            StartCoroutine(pauseSound());
            isPaused = !isPaused;
        }
    }

    private IEnumerator pauseSound() {
        sound.PlayOneShot(puse, .5f);
        yield return new WaitForSeconds(puse.length);
    }

    private IEnumerator dead() {
        sound.PlayOneShot(death, .5f);
        yield return new WaitForSeconds(death.length);
    }

}
