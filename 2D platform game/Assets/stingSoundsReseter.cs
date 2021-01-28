using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stingSoundsReseter : MonoBehaviour
{
    public GameObject stingSoundEffect_01;
	public GameObject stingSoundEffect_02;
	public GameObject stingSoundEffect_03;
	public GameObject stingSoundEffect_04;
	public GameObject stingSoundEffect_05;
	public GameObject stingSoundEffect_06;
	public GameObject stingSoundEffect_07;
    
    void Update()
    {
        if(PlayerHealth.canRestart)
        {
            RestartStingSounds();
        }
    }
    
    public void RestartStingSounds()
    {
        stingSoundEffect_01.SetActive(true);
		stingSoundEffect_02.SetActive(true);
		stingSoundEffect_03.SetActive(true);
		stingSoundEffect_04.SetActive(true);
		stingSoundEffect_05.SetActive(true);
		stingSoundEffect_06.SetActive(true);
		stingSoundEffect_07.SetActive(true);
    }
}
