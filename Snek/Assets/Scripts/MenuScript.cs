using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Button start;
    public Button exit;

    AudioSource sound;
    public AudioClip blip;

    // Use this for initialization
    void Start () {

        start = start.GetComponent<Button>();
        exit = start.GetComponent<Button>();
        sound = GetComponent<AudioSource>();

    }

    public void ButtonStart() {
        StartCoroutine(makeSound(1));
    }
    public void ButtonExit() {
        StartCoroutine(makeSound(2));
    }

    private IEnumerator makeSound(int choice) {
        sound.PlayOneShot(blip, .5f);
        yield return new WaitForSeconds(blip.length);
        if(choice == 1) {
            SceneManager.LoadScene("_Scenes/_S_MAIN");
        }
        else if(choice == 2) {
            Application.Quit();
        }
    }

}
