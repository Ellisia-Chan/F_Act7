using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    private void Start() {
        startButton.onClick.AddListener(() => { SceneLoader.LoadScene("Inventory"); });
        quitButton.onClick.AddListener(() => { Application.Quit(); });
    }
}
