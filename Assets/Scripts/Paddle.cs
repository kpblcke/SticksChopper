using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] 
    private float screenWidthInUnits = 16;
    [SerializeField]
    private float minX = 1;
    [SerializeField] 
    private float maxX = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(mousePositionInUnits, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePositionInUnits, minX, maxX);
        transform.position = paddlePosition;
    }
}
