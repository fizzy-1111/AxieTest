using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxieMovement : AxiePosition
{
    private void Start()
    {
        adjustAnim = gameObject.GetComponent<Spine.Unity.SkeletonAnimation>();
        adjustAnim.AnimationName = "action/appear";
        adjustAnim.timeScale = 1f;
        spawn = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<SpawnChar>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            axiePos = spawn.tileMap.WorldToCell(new Vector3(axiePlace.x, axiePlace.y, 0));
            axiePos.x += 1;
            newPos = spawn.tileMap.CellToWorld(axiePos);
            for(int i = 0; i < axieList.Count; i++)
            {
                Debug.Log(axieList[i].GetComponent<AxiePosition>().status);
            }

            distance = newPos - transform.position;
            adjustAnim.AnimationName = "action/move-forward";

            axiePlace = newPos;
        }
        if (Mathf.Abs(newPos.x - transform.position.x) >= 0.01f || Mathf.Abs(newPos.y - transform.position.y) >= 0.01f)
        {
            transform.position += distance * 0.001f;
        }
        else if (Mathf.Abs(newPos.x - transform.position.x) <= 0.1f || Mathf.Abs(newPos.y - transform.position.y) <= 0.1f)
        {
            distance = new Vector3(0, 0, 0);
            transform.position = newPos;
        }
        if (distance == Vector3.zero)
        {
            adjustAnim.AnimationName = "action/idle";
        }

    }
}
