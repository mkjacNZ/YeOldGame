using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamLook : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    public GameObject player;
    float mouseDeltaX = 0f;
    float mouseDeltaY = 0f;
    float sensitivity = 500f;
    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseDeltaX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        player.transform.Rotate(new Vector3(mouseDeltaY, mouseDeltaX, 0f));
    }
}
