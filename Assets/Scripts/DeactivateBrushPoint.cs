using UnityEngine;

public class DeactiveBrushPoint : MonoBehaviour
{
    [SerializeField] float timer;
    private void OnEnable()
    {
        Invoke("deactivate", timer);
    }

    void deactivate()
    {
        gameObject.SetActive(false);
    }
}
