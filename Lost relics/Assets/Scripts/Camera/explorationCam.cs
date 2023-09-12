using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explorationCam : MonoBehaviour
{
    [SerializeField]
    private float camSpeed = 0.05f;

    private Vector3 lastMousePosition;
    private Vector3 cameraOffset;

    private Vector2 minPosition;
    private Vector2 maxPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (exploration_sceneManager.Instance.isLerping == true)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
            cameraOffset = transform.position - Camera.main.transform.position;
        }

        // Check if the left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            // Calculate the new camera position based on mouse movement
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            Vector3 newCameraPosition = Camera.main.transform.position - deltaMouse * camSpeed;

            newCameraPosition.x = Mathf.Clamp(newCameraPosition.x, minPosition.x, maxPosition.x);
            newCameraPosition.y = Mathf.Clamp(newCameraPosition.y, minPosition.y, maxPosition.y);

            Camera.main.transform.position = newCameraPosition + cameraOffset;

            // Update the last mouse position for the next frame
            lastMousePosition = Input.mousePosition;
        }
    }

    public void initMinCam(Vector3 position)
    {
        minPosition = position + new Vector3 (-5f,-5f,0);
    }

    public void initMaxCam(Vector3 position)
    {
        maxPosition = position + new Vector3(5f, 5f, 0);
    }


}
