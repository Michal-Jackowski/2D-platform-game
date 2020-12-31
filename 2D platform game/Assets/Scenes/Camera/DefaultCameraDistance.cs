using UnityEngine;
using Cinemachine;
using System.Collections;

public class DefaultCameraDistance : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    int playerLayer;    //The layer the player game object is on
    public BoxCollider2D cameraDistanceTrigger;
    public float defaultCameraDistanceValue = 12.5f;

    void Start()
    {
        //Get the integer representation of the "Player" layer
		playerLayer = LayerMask.NameToLayer("Player");
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		//If the collision wasn't with the player, exit
		if (collision.gameObject.layer != playerLayer)
			return;

        vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = defaultCameraDistanceValue;
        //cameraDistanceTrigger.enabled = false;
	}
}