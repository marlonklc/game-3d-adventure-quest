using System;
using Unity.Cinemachine;
using UnityEngine;

public class CinemachineController : MonoBehaviour {

    private CinemachineCamera camera;
    public static CinemachineController Instance;

    private void Awake() {
        Instance = this;
        camera = GetComponent<CinemachineCamera>();
    }

    public void AssignToPlayer() {
        camera.Follow = Player.Instance.transform;
    }
}
