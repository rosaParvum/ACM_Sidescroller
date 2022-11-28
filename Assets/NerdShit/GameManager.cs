using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //public static GameManager Instance { get; private set; }
    public int wave;
    public float transitionSpeed;
    private Animator SceneTransitions;
    public bool playing;


    public void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        /*
        GameManager[] gms = FindObjectsOfType<GameManager>();
        if (gms.Length > 1) {
            foreach (GameManager gm in gms) {
                if (gm != this) {
                    Destroy(gm.gameObject);
                }
            }
        }
        */
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this);
        SceneTransitions = gameObject.GetComponent<Animator>();
        DontDestroyOnLoad(SceneTransitions);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        SceneTransitions = gameObject.GetComponent<Animator>();
        print("loaded "+scene.name);
        SceneTransitions.SetTrigger("Contract");
        if (scene.name == "pew pew") {SceneTransitions.SetTrigger("fadeOut");playing=true;}
        if (scene.name == "menu" && playing) {SceneTransitions.SetTrigger("fadeIn");playing=false;}
        //frameTimeline.SetGenericBinding((Object)(((TimelineAsset)frameTimeline.playableAsset).GetOutputTracks().Where(e => e.name=="Signal Track")), gameObject.GetComponent<SignalReceiver>());

    }

    public void loadScene(string name) {
        SceneTransitions = gameObject.GetComponent<Animator>();
        StartCoroutine("transition", name);
    }
    private IEnumerator transition(string name) {
        SceneTransitions.SetFloat("TransitionSpeed", transitionSpeed);
        SceneTransitions.SetTrigger("Expand");
        yield return new WaitForSeconds(1/transitionSpeed);
        SceneManager.LoadScene(name);
        yield return null;
    } 
}
