using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    [SerializeField] GameObject[] cameras;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void deativateCamera()
    {
        foreach(GameObject cameraObj in cameras)
        {
            cameraObj.SetActive(true);
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
            cameras[1].SetActive(false);
            cameras[0].SetActive(true);
        }
    }
}
