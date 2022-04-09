using System.Collections;
using UnityEngine;

public class CoroutinesSample : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0.5f;
        Coroutine coroutine = StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        for (int i = 0; i < 10; i++)
        {
            //yield return new WaitForSeconds(1);
            yield return new WaitForSecondsRealtime(1);
            Debug.Log(i);
        }
    }
}
