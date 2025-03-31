using UnityEngine;

public class PlayerCameraDetection : MonoBehaviour
{
    Camera camera;
    MeshRenderer MeshRenderer;
    Plane[] cameraFrustum;
    Collider collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
        MeshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {

        }
        else
        {

        }
    }
}
