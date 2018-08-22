using System.Collections;
using UnityEngine;

public class LampFlash : MonoBehaviour {

    public static LampFlash flasher;

    private Light lamp;

    private void Start()
    {
        flasher = this;
        lamp = GetComponent<Light>();
    }

    public void Flash()
    {
        StartCoroutine(ProcessFlash());
    }

    private IEnumerator ProcessFlash()
    {
        for (int i = 0; i < 20; i++)
        {
            lamp.intensity = 12;
            yield return null;
            lamp.intensity = 0;
            yield return null;
        }
    }
}
