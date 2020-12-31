using UnityEngine;

public class UnitySplash
{
   [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
   static void OnBeforeSceneLoadRuntimeMethod()
   {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
   }
}
