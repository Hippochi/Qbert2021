using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowBehaviour : MonoBehaviour
{
   void Start()
    {
        StartCoroutine(Flasher());
    }

    IEnumerator Flasher()
    {
        GetComponent<Image>().enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
      
        GetComponent<Image>().enabled = true;
        yield return new WaitForSecondsRealtime(0.5f);
        StartCoroutine(Flasher());
    }
}
