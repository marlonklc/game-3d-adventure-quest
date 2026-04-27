using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public string spawnId;
    public bool assignCameraToPlayer;
    public Transform spawnPoint;
    public FadeController fadePrefab;
    
    private void Start() {
        
        if (spawnId == SpawnManager.spawnId) {
            FadeController fade = Instantiate(fadePrefab);
            fade.fadeOut = false;
            Destroy(fade, 2f);
            
            Player.Instance.GetComponent<CharacterController>().enabled = false;
            SpawnManager.spawnPosition = spawnPoint.position;
            Player.Instance.transform.position = SpawnManager.spawnPosition;
            Player.Instance.GetComponent<CharacterController>().enabled = true;

            if (assignCameraToPlayer) {
                CinemachineController.Instance.AssignToPlayer();
            }
        }
    }
}
