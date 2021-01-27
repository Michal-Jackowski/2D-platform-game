using UnityEngine;
using Cinemachine;
using System.Collections;

public class DefaultCameraDistanceSlowly : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    int playerLayer;    //The layer the player game object is on
    private float timeElapsed;
    public BoxCollider2D cameraDistanceTrigger;
    bool canChangeCameraDistance = false;
    private float minCameraDistance = 12.5f;

    void Start()
    {
        //Get the integer representation of the "Player" layer
		playerLayer = LayerMask.NameToLayer("Player");
    }

    void Update()
    {
        if(canChangeCameraDistance && vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance>minCameraDistance)
        {
            StartCoroutine(ExecuteAfterTime(0.02f));
        }
        else
        {
            canChangeCameraDistance = false;
            cameraDistanceTrigger.enabled = true;
        }
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		//If the collision wasn't with the player, exit
		if (collision.gameObject.layer != playerLayer)
			return;

        canChangeCameraDistance = true;
        cameraDistanceTrigger.enabled = false;
	}

    void DecreseCameraDistance(float cameraDistance)
    {
        vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance -= cameraDistance;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
 
        // Code to execute after the delay
        DecreseCameraDistance(0.04f);
    }
}
