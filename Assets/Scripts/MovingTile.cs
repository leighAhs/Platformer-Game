using UnityEngine;

public class MovingTile : MonoBehaviour
{
    [SerializeField] float maxX;
    [SerializeField] float speed;

    [SerializeField] bool moveDirection;

    [SerializeField] float minX;
    [SerializeField] float startingPosX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosX = transform.position.x;
        minX = startingPosX;
    }

    // Update is called once per frame
    void Update()
    {
        startingPosX = transform.position.x;
        if (startingPosX < maxX && moveDirection)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); 
        } else if (startingPosX > minX && !moveDirection)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        } else
        {
            moveDirection = !moveDirection;
        }
    }
}
