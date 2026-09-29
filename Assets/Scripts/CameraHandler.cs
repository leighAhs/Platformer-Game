using System.Collections;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    [SerializeField] GameObject[] cameras;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(objectiveCamera());
    }

    void deativateCamera()
    {
        foreach(GameObject cameraObj in cameras)
        {
            cameraObj.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("zoomOut"))
        {
            deativateCamera();
            cameras[1].SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("zoomOut"))
        {
            deativateCamera();
            cameras[0].SetActive(true);
        }
    }

    IEnumerator objectiveCamera()
    {
        deativateCamera();
        cameras[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        deativateCamera();
        cameras[0].SetActive(true);
    }
}
