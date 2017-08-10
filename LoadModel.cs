using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadModel : MonoBehaviour
{
   
    void Start()
    {

        Debug.Log("LoadModel");

        

        GameObject CactusPart = new GameObject();
        CactusPart.AddComponent<Rigidbody>();
        CactusPart.GetComponent<Rigidbody>().isKinematic = false;
        CactusPart.GetComponent<Rigidbody>().useGravity = true;
        CactusPart.transform.position = new Vector3(0,0,0);


        Mesh holderMesh = new Mesh();
        ObjImporter newMesh = new ObjImporter();
        holderMesh = newMesh.ImportFile("C:/dev/CGAL-4.10/build/examples/Surface_mesh_segmentation/data/1_part_1.obj");

        MeshRenderer renderer = CactusPart.AddComponent<MeshRenderer>();
        MeshFilter filter = CactusPart.AddComponent<MeshFilter>();
        filter.mesh = holderMesh;

        CactusPart.AddComponent<MeshCollider>().sharedMesh = null;
        // CactusPart.GetComponent<MeshCollider>().sharedMesh = null;
        CactusPart.GetComponent<MeshCollider>().sharedMesh = holderMesh;
        CactusPart.GetComponent<MeshCollider>().convex = true;
        //....
        //....
        //....

        Debug.Log("LoadModel Part2");
        CactusPart = new GameObject();
        CactusPart.AddComponent<Rigidbody>();
        CactusPart.GetComponent<Rigidbody>().isKinematic = false;
        CactusPart.GetComponent<Rigidbody>().useGravity = true;
        CactusPart.transform.position = new Vector3(0,0,0);
        holderMesh = newMesh.ImportFile("C:/dev/CGAL-4.10/build/examples/Surface_mesh_segmentation/data/2_part_2.obj");
        renderer = CactusPart.AddComponent<MeshRenderer>();
        filter = CactusPart.AddComponent<MeshFilter>();
        filter.mesh = holderMesh;
        CactusPart.AddComponent<MeshCollider>().sharedMesh = null;
        CactusPart.GetComponent<MeshCollider>().sharedMesh = holderMesh;
        CactusPart.GetComponent<MeshCollider>().convex = true;
        //GetComponent<MeshCollider>().sharedMesh = null;
        // GetComponent<MeshCollider>().sharedMesh = holderMesh;

        RaycastHit[] belowThings = GetComponent<Rigidbody>().SweepTestAll(-transform.up, 0.5f, QueryTriggerInteraction.Ignore);
        Debug.Log("What you need");
        foreach (RaycastHit item in belowThings)
        {
            Debug.Log(item);
        }



    }

    void OnCollisionEnter(Collision collision )
    {

        Debug.Log("Ono rabotaet!!!");



    }

    void OnCollisionStay(Collision collision)
    {

        Debug.Log("Ono rabotaet!!!");



    }

    void OnTriggerEnter(Collider collider)
    {
        // Вызывается, когда другой объект попадает в зону триггера
        Debug.Log("Triggered by " + collider.gameObject.name);
    }

    void Update()
    {
        // Перемещение из точки A в точку B на 0.2 в каждом кадре.
        // Предполагается вызов в Update. Чтобы не промахнуться
        // мимо точки назначения, максимальное смещение - 0.2.
       
    }


}
