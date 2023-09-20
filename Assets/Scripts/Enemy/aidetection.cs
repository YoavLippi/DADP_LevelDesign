using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aidetection : MonoBehaviour
{
    public float distance=10f, angle=30f, height=1f;
    public Color clmesh = Color.red;
    Mesh mesh;
    int speed = 10;
     int scanps = 30;
    public LayerMask layers;
    public LayerMask exclude;
     float barfull=0;
    private GameObject bar;
    Collider[] collisiders = new Collider[50];
    public GameObject player;
    int count;
    float scanint;
    float scantimer;
    public List<GameObject> objectsdetetced = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        scanint = 1f / scanps;
    }

    // Update is called once per frame
    void Update()
    {
        scantimer -= Time.deltaTime; 
        if(scantimer<0)
        {
            scantimer += scanint;
            Scan();
        }
        if (objectsdetetced.Count!=0)
        {
            barfull += Time.deltaTime;
        }
        else
        {
            barfull -= Time.deltaTime;
        }
        if (barfull>=10f)
        {
            Chaseplayer();
        }

        // checking if this works code below. erase if not redrawing th mesh 
        Createmesh();
    }

    private void Chaseplayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }

    public bool IsInsight(GameObject obj)
    {
        Vector3 origin = transform.position;
        Vector3 dest = obj.transform.position;
        Vector3 dire = dest - origin;
        if (dire.y<0|| dire.y>height)
        {
            return false;
        }
        dire.y = 0;
        float deltaangle = Vector3.Angle(dire, transform.forward);
        if(deltaangle>angle)
        {
            return false;
        }
        origin.y += height / 2;
        dest.y = origin.y;
        if (Physics.Linecast(origin,dest,exclude))
        {
            return false;
        }


        return true;

    }
    private void Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, distance, collisiders, layers, QueryTriggerInteraction.Collide);
        objectsdetetced.Clear();
        for (int i = 0; i < count; i++)
        {
            GameObject obj = collisiders[i].gameObject;
            if (IsInsight(obj))
            {
                objectsdetetced.Add(obj);
            }
        }
    }

    Mesh Createmesh()
    {
        mesh = new Mesh();
        int numseg = 10;
        int numtri = (numseg*4)+4;
        int numverts = numtri * 3;
        Vector3[] verts = new Vector3[numverts];
        int[] triangles = new int[numverts];
        Vector3 btml = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 btmr = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;
        // Vector3 btmc = Vector3.zero; ;
        Vector3 btmc = new Vector3(0, 0, 0.5f);
        Vector3 tc = btmc + Vector3.up * height;
        Vector3 tr = btmr + Vector3.up * height;
        Vector3 tl = btml + Vector3.up * height;
        int vertices = 0;

        //triangle left
        verts[vertices++] = btmc;
        verts[vertices++] = btml;
        verts[vertices++] = tl;
        //2nd triangle
        verts[vertices++] = tl;
        verts[vertices++] = tc;
        verts[vertices++] = btmc;




        //right triangles
        verts[vertices++] = btmc;
        verts[vertices++] = tc;
        verts[vertices++] = tr;
        //2nd triangle
        verts[vertices++] = tr;
        verts[vertices++] = btmr;
        verts[vertices++] = btmc;

        float currentagle = -angle;
        float dangle = (angle * 2) / numseg;
        for (int i = 0; i < numseg; i++)
        {
            btml = Quaternion.Euler(0, currentagle, 0) * Vector3.forward * distance;
            btmr = Quaternion.Euler(0, currentagle + dangle, 0) * Vector3.forward * distance;
            tr = btmr + Vector3.up * height;
            tl = btml + Vector3.up * height;
            //archfarside
            verts[vertices++] = btml;
            verts[vertices++] = btmr;
            verts[vertices++] = tr;
            //2nd triangle
            verts[vertices++] = tr;
            verts[vertices++] = tl;
            verts[vertices++] = btml;




            //top traingles
            verts[vertices++] = tc;
            verts[vertices++] = tl;
            verts[vertices++] = tr;
            //2nd triangle
            verts[vertices++] = btmc;
            verts[vertices++] = btmr;
            verts[vertices++] = btml;
            currentagle += dangle;
        }
        
        
        for (int i = 0; i < numverts; i++)
        {
            triangles[i] = i;

            

        }
        mesh.vertices = verts;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
    private void OnValidate()
    {
        mesh = Createmesh();
    }

    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Gizmos.color = clmesh;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }
        Gizmos.DrawWireSphere(transform.position, distance);
        for(int j=0; j<count;j++)
        {
            Gizmos.DrawSphere(collisiders[j].transform.position,0.2f);
        }
        Gizmos.color = Color.green;
            
            foreach(var obj in objectsdetetced)
        {
            Gizmos.DrawSphere(obj.transform.position, 0.2f);

        }
        

    }
}
