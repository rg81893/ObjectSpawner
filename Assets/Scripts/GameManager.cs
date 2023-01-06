using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] int distanceZ;
    [SerializeField] GameObject cube;
    [SerializeField] int maxObjects;
    bool created;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && maxObjects < 10)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = distanceZ;
            created = SpawnCube(Camera.main.ScreenToWorldPoint(mousePosition));
        }
    }

    bool SpawnCube(Vector2 mousePosition)
    {
        Instantiate(cube, mousePosition, Quaternion.identity);
        maxObjects++;
        return created = true;
    }
}
