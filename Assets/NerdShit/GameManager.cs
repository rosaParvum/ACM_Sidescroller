using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    public int wave;
    public float transitionSpeed;
    public Animator SceneTransitions;

    public void Start() {
        SceneTransitions = gameObject.GetComponent<Animator>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        SceneTransitions.SetTrigger("Contract");
        
        if (scene.name == "menu") {
            print("menu loaded. setting up buttons");
            GameObject.Find("Play").GetComponent<Button>().onClick.AddListener(delegate {loadScene("pew pew");});
        }
        //frameTimeline.SetGenericBinding((Object)(((TimelineAsset)frameTimeline.playableAsset).GetOutputTracks().Where(e => e.name=="Signal Track")), gameObject.GetComponent<SignalReceiver>());

    }

    public void loadScene(string name) {
        Instance.StartCoroutine("transition", name);
    }
    private IEnumerator transition(string name) {
        SceneTransitions.SetFloat("TransitionSpeed", transitionSpeed);
        SceneTransitions.SetTrigger("Expand");
        yield return new WaitForSeconds(1/transitionSpeed);
        SceneManager.LoadScene(name);
        yield return null;
    } 
}