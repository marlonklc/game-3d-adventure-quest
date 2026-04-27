using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour {

    public string targetSpawnId;
    public string houseSceneName = "house";

    public FadeController fadePrefab;
    
    private bool isPlayerNearby;

    private void Update() {

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E)) {
            isPlayerNearby = false;
            LoadHouseScene();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            isPlayerNearby = false;
        }
    }

    void LoadHouseScene() {
        StartCoroutine(FadeScene());
    }

    IEnumerator FadeScene() {
        FadeController fade = Instantiate(fadePrefab);
        fade.fadeOut = true;        
        Destroy(fade, 2f);
        
        yield return new WaitForSeconds(2f);
        
        SpawnManager.spawnId = targetSpawnId;
        SceneManager.LoadScene(houseSceneName);
    }
}
