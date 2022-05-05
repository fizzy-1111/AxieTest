using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnChar : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ObjectToCreate;
    public Tilemap tileMap;

    public List<Vector3> SpawnPlace;
    public List<GameObject> axieList;
    public List<Vector3> trueList;
    GameObject axie;
    Vector3 place;
    void Start()
    {
        tileMap = transform.GetComponentInChildren<Tilemap>();

        SpawnPlace = new List<Vector3>();
        trueList = new List<Vector3>();
        SpawnObject();

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = tileMap.WorldToCell(mouseWorldPos);
            Vector3Int truePos = new Vector3Int(coordinate.x, coordinate.y, 0);
             place = tileMap.CellToWorld(truePos);
            if (tileMap.HasTile(truePos))
            {
                if (!SpawnPlace.Contains(place)){
                    SpawnPlace.Add(place);
                }
                
            }
        

        }
        if (Input.GetMouseButtonUp(0))
        {
          
            SpawnObject();
        }
        for(int i = 0; i < trueList.Count; i++)
        {
            trueList[i] = axieList[i].GetComponent<AxiePosition>().getAxie();
        }
        for(int i = 0; i < axieList.Count; i++)
        {
            axieList[i].GetComponent<AxiePosition>().setList(axieList);
        }


    }
    void SpawnObject()
    {
        for (int i = 0; i < SpawnPlace.Count; i++)
        {

            if (!trueList.Contains(SpawnPlace[i]))
            {
                axie = Instantiate(ObjectToCreate, SpawnPlace[i], Quaternion.identity);

                axie.GetComponent<AxiePosition>().setAxie(SpawnPlace[i].x, SpawnPlace[i].y);
                axie.GetComponent<AxiePosition>().setStatus();
                axieList.Add(axie);
                trueList.Add(axie.GetComponent<AxiePosition>().getAxie());
              
            }

        }
        SpawnPlace.Clear();
    }
}
