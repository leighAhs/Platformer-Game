using UnityEngine;
using System.Collections.Generic;

public class PaintBrush : MonoBehaviour
{
    [SerializeField] GameObject brushPointParent;
    [SerializeField] GameObject brushPoint;
    Vector2 brushPosition;

    [SerializeField] List<GameObject> brushList;
    [SerializeField] int poolLimit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        createObjectPool();
    }

    // Update is called once per frame
    void Update()
    {
        brushPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = brushPosition;
        if (Input.GetMouseButton(0))
        {
            getObjectFromPool(brushList);
            //Instantiate(brushPoint, transform.position, transform.rotation);
        }
    }

    void createObjectPool()
    {
        for(int i = 0; i < poolLimit; i++)
        {
            GameObject obj = Instantiate(brushPoint);
            obj.SetActive(false);
            brushList.Add(obj);
            obj.transform.parent = brushPointParent.transform;
        }
    }

    GameObject getObjectFromPool(List<GameObject> poolSource)
    {
        foreach(GameObject obj in poolSource)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = brushPosition;
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
}
