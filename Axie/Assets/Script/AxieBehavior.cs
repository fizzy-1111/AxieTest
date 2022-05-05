using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class AxieBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    protected Spine.Unity.SkeletonAnimation adjustAnim;
    Spine.AnimationState state;
    protected SpawnChar spawn;
    protected  Vector3 axiePlace;
    protected Vector3Int axiePos;
    protected Vector3 newPos;
    protected Vector3 distance = new Vector3(0, 0, 0);
    protected List<GameObject> axieList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void setAxie(float x, float y)
    {

        axiePlace.x = x;
        axiePlace.y = y;
        axiePlace.z = 0;
    }
    public Vector3 getAxie()
    {
        return new Vector3(axiePlace.x, axiePlace.y, axiePlace.z);
    }
    public void setList(List<GameObject> input)
    {
        axieList = input;
    }
}
