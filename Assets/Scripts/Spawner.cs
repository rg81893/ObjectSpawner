using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int distanceZ;
    [SerializeField] GameObject obj;
    [SerializeField] int maxObjects;
    List<GameObject> gameObjects;
    [SerializeField] float rayonPerimetre;
    GameObject perimetre;
    [SerializeField] List<GameObject> objects;
    [SerializeField] int objetParSeconde;
    bool created;
    // Start is called before the first frame update
    void Start()
    {
        // créer la surface d'apparition des objets, forme sphérique
        // coordonnées du périmètre
        perimetre = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        perimetre.transform.position = new Vector3(0, 0, 10);
        gameObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        perimetre.transform.localScale = new Vector3(rayonPerimetre, 0.001f, rayonPerimetre);
        if (gameObjects.Count < maxObjects)
        {
            Vector3 objectPosition = new Vector3(Random.Range(-rayonPerimetre, rayonPerimetre), Random.Range(-rayonPerimetre, rayonPerimetre), Random.Range(-rayonPerimetre , rayonPerimetre));
            //created = SpawnRandomObject(Camera.main.ScreenToWorldPoint(objectPosition));
            created = SpawnRandomObject(objectPosition);
        }
    }

    bool SpawnRandomObject(Vector3 objectPosition)
    {
        GameObject obj = objects[Random.Range(0, 5)];
        GameObject objectNew = Instantiate(obj, objectPosition, Quaternion.identity) as GameObject;
        objectNew.GetComponent<Renderer>().material.color = Random.ColorHSV();
        gameObjects.Add(objectNew);
        if (gameObjects.Count == maxObjects)
        {
            GameObject objToDestroy = gameObjects[0];
            Destroy(objToDestroy);
            gameObjects.RemoveAt(0);
        }

        return created = true;
    }
}
