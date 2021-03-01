using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] 
    private Paddle woodCutter;

    [SerializeField] 
    private Vector3 offset = new Vector2(1.2f, 1.23f);

    [SerializeField]
    private Vector2 throwStrength = new Vector2(2f, 13f);
    private bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockAxeToWoodCutter();
            LaunchOnMouseClick();   
        }
    }

    private void LockAxeToWoodCutter()
    {
        transform.position = woodCutter.transform.position + offset;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = throwStrength;
            hasStarted = true;
        }
    }
}
