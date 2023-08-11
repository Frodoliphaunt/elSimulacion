using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneScale : MonoBehaviour
{
    private float sphereSize = 0.1f;
    [SerializeField] Slider planeSlider;

    List<Vector3> VerticeList = new List<Vector3>();
    public List<Vector3> VerticeListToShow = new List<Vector3>();
    
    public void Begin()
    {
        transform.localScale = new Vector3(planeSlider.value, 1, planeSlider.value);
        VerticeList = new List<Vector3>(GetComponent<MeshFilter>().sharedMesh.vertices); //get vertice points from the mesh of the object
        foreach (Vector3 point in VerticeList) //all the points are added to be shown on the editor
        {
            VerticeListToShow.Add(transform.TransformPoint(point));
        }      
        SetCornerPoints();    
    }
    public void SetCornerPoints()
    {
        VerticeListToShow.Clear(); //incase of transform changes corner points are reset

        VerticeListToShow.Add(transform.TransformPoint(VerticeList[0])); //corner points are added to show  on the editor
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[10]));
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[110]));
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[120]));
    }

    List<Color> Colors = new List<Color>() { Color.red, Color.blue, Color.yellow, Color.green, Color.cyan, Color.magenta, Color.gray, Color.black, Color.white, Color.red, Color.blue }; //each color for each column
    void OnDrawGizmos()
    {
        int b = 0; //b is used to divide points into columns 
        if (VerticeList.Count > 0)
            for (int a = 0; a < VerticeListToShow.Count; a++)
            {
                Gizmos.color = Colors[b++ % Colors.Count];
                Gizmos.DrawSphere(VerticeListToShow[a], sphereSize);
            }
    }

    private void Update()
    {
        transform.localScale = new Vector3(planeSlider.value, 1, planeSlider.value);
    }
}
