using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] int distanceZ;
    [SerializeField] GameObject obj;
    [SerializeField] int maxObjects;
    List<GameObject> gameObjects;
    bool created;
    // Start is called before the first frame update
    void Start()
    {
        gameObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObjects.Count <= maxObjects)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = distanceZ;
            created = SpawnObject(Camera.main.ScreenToWorldPoint(mousePosition));
        }
    }

    bool SpawnObject(Vector2 mousePosition)
    {
        if (gameObjects.Count != maxObjects)
        {
            GameObject objectNew = Instantiate(obj, mousePosition, Quaternion.identity) as GameObject;
            gameObjects.Add(objectNew);
        }
        else if (gameObjects.Count == maxObjects)
        {
            //-- Version où l'on détruit le 1er objet créé --// 
            //GameObject objToDestroy = gameObjects[0];
            //Destroy(objToDestroy);
            //gameObjects.RemoveAt(0);

            //-- Version où l'on copie le 1er objet en changeant ses coordonnées --//
            GameObject objToMove = gameObjects[0];
            objToMove.transform.position = mousePosition;
            gameObjects.Add(objToMove);
            gameObjects.RemoveAt(0);
        }
       
        return created = true;
    }
}
