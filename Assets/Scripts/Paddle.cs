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

    private GameSession _gameSession;
    private Axe _axe;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _axe = FindObjectOfType<Axe>();
    }

    // Update is called once per frame
    void Update()
    {
        float paddlePos = GetXPos();
        Vector2 paddlePosition = new Vector2(paddlePos, transform.position.y);
        paddlePosition.x = Mathf.Clamp(paddlePos, minX, maxX);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (_gameSession.IsAutoPlayEnable())
        {
            return _axe.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
