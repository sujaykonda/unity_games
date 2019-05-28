using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    Mesh mesh;
    public Transform t;
    bool firstUpdate = true;
    Vector3[] vertices;
    public GameObject grassPatch;
    public List<GameObject> rockTypes;
    public int rockNum = 5;
    public int mapSizeX = 100;
    public int mapSizeZ = 100;
    int[] tri; 
    // Start is called before the first frame update
    void Start()
    {
       mesh = new Mesh();
       CreateTerrain();
       mesh.vertices = vertices;
       mesh.triangles = tri; 
       mesh.RecalculateNormals();
       GetComponent<MeshFilter>().mesh = mesh;
       for(int i = 0; i < mapSizeX*mapSizeZ*6; i+=3){
           PlaceGrass(vertices[tri[i]],vertices[tri[i+1]],vertices[tri[i+2]]);
       }
       
       
       
    }
    void Update(){
        if(firstUpdate){
            for(int i = 0; i < rockNum; i++){
                foreach (GameObject rock in rockTypes){
                    Vector3 origin = new Vector3(Random.Range(0f, 30f), -100f, Random.Range(0f, 30f));
                    GameObject Rock = Instantiate(rock, origin, Quaternion.identity);
                    Rock.transform.localScale= new Vector3(0.7f,0.7f,0.7f);
                    
                }
            }
            firstUpdate = false;
        }
    }
    void CreateTerrain(){
        vertices = new Vector3[(mapSizeX+1)*(mapSizeZ+1)];
        int i = 0;
        for(int z = 0; z <= mapSizeZ; z++){
            for(int x =0; x <= mapSizeX; x++){
                float y = Mathf.PerlinNoise(x*0.3f, z*0.3f)*2.5f;
                y += Mathf.PerlinNoise(x*0.05f, z*0.05f)*0.1f;
                vertices[i] = new Vector3(x,y,z);
                i++;
            }
        }
        tri = new int[mapSizeX*mapSizeZ*6];
        i = 0;
        int ind = 0;
        MeshCollider meshC;
        Mesh Submesh = new Mesh();
        for(int z = 0; z < mapSizeZ; z++){
            for(int x =0; x < mapSizeX; x++){
                meshC = gameObject.AddComponent<MeshCollider>();
                tri[ind]= i;
                tri[ind+1]=i+mapSizeZ + 1;
                tri[ind+2]=i+1;
                Submesh = new Mesh();
                Submesh.vertices = vertices;
                Submesh.triangles = new int[]{
                    i,
                    i+mapSizeZ +1,
                    i+1,
                };
                meshC.sharedMesh =Submesh;
                meshC = gameObject.AddComponent<MeshCollider>();
                tri[ind+3]=i+mapSizeZ + 1;
                tri[ind+4]=i+mapSizeZ + 2;
                tri[ind+5]=i+1;
                Submesh = new Mesh();
                Submesh.vertices = vertices;
                Submesh.triangles = new int[]{
                    i + mapSizeZ + 2,
                    i+mapSizeZ +1,
                    i+1,
                };
                ind = ind+6;
                i++;
            }
            i++;
        }
    }
    void PlaceGrass(Vector3 p, Vector3 p2, Vector3 p3){
        Vector3 Cross = Vector3.Cross(p2-p,p3-p);
        Vector3 Average = (p+p2+p3)/3;
        GameObject pgrassPatch = Instantiate(grassPatch, Average, Quaternion.identity, gameObject.transform);
        pgrassPatch.transform.LookAt(Cross);
        
    }
}
