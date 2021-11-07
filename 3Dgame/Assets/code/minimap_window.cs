using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap_window : MonoBehaviour
{

    public Material cameraBoxMaterial;

    public Camera minimap;

    public float lineWidth;

    public Collider mapCollider;
    public float z=1;
    private Vector3 GetCameraFrustumPoint(Vector3 position)
    {
        var positionRay = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;
        Vector3 result = mapCollider.Raycast(positionRay, out hit, Camera.main.transform.position.y * 2) ? hit.point : new Vector3();

        return result;

    }


    public void OnPostRender()
    {


        Vector3 minViewportPoint = minimap.WorldToViewportPoint(GetCameraFrustumPoint(new Vector3(0f, 0f)));
        Vector3 maxViewportPoint = minimap.WorldToViewportPoint(GetCameraFrustumPoint(new Vector3(Screen.width, Screen.height)));

        float minX = minViewportPoint.x;
        float minY = minViewportPoint.y;

        float maxX = maxViewportPoint.x;
        float maxY = maxViewportPoint.y;

        GL.PushMatrix();
        {
            cameraBoxMaterial.SetPass(0);
            GL.LoadOrtho();

            GL.Begin(GL.QUADS);
            GL.Color(Color.green);
            {

                GL.Vertex(new Vector3(minX, minY + lineWidth, z));
                GL.Vertex(new Vector3(minX, minY - lineWidth, z));
                GL.Vertex(new Vector3(maxX, minY - lineWidth, z));
                GL.Vertex(new Vector3(maxX, minY + lineWidth, z));


                GL.Vertex(new Vector3(minX + lineWidth, minY, z));
                GL.Vertex(new Vector3(minX - lineWidth, minY, z));
                GL.Vertex(new Vector3(minX - lineWidth, maxY, z));
                GL.Vertex(new Vector3(minX + lineWidth, maxY, z));



                GL.Vertex(new Vector3(minX, maxY + lineWidth, z));
                GL.Vertex(new Vector3(minX, maxY - lineWidth, z));
                GL.Vertex(new Vector3(maxX, maxY - lineWidth, z));
                GL.Vertex(new Vector3(maxX, maxY + lineWidth, z));

                GL.Vertex(new Vector3(maxX + lineWidth, minY, z));
                GL.Vertex(new Vector3(maxX - lineWidth, minY, z));
                GL.Vertex(new Vector3(maxX - lineWidth, maxY, z));
                GL.Vertex(new Vector3(maxX + lineWidth, maxY, z));

            }
            GL.End();
        }
        GL.PopMatrix();
    }

}