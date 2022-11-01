using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    public int wave;
    public float transitionSpeed;
    public static Animator SceneTransitions { get; private set; }

    public void Start() {
        SceneTransitions = gameObject.GetComponent<Animator>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Awake()
    {
        if (Instance != null) {Destroy(gameObject);}
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        SceneTransitions.SetTrigger("Contract");
    }

    public void loadScene(string name) {
        print("cock");
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