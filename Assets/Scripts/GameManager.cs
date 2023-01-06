using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject cube;
    bool created;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))// && !created)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            created = SpawnCube(Camera.main.ScreenToWorldPoint(mousePosition));
        }
    }

    bool SpawnCube(Vector2 mousePosition)
    {
        Instantiate(cube, mousePosition, Quaternion.identity);
        return created = true;
    }
}
