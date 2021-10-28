using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamZoom : MonoBehaviour
{

    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    [SerializeField] float zoomOutPoint = 9;

    [SerializeField] private Cinemachine.CinemachineVirtualCamera camera;

    [SerializeField] GameObject player;
    [SerializeField] GameObject levelCentre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // }
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);

        }
       // else if (Input.GetMouseButton(0))
       // {
       //     Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Camera.main.transform.position += direction;
      //  }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment)
    {
        if(camera.m_Lens.FieldOfView>4){
            camera.m_Lens.FieldOfView = Mathf.Clamp(camera.m_Lens.FieldOfView - increment, zoomOutMin, zoomOutMax);
        }

        else if(camera.m_Lens.FieldOfView<=4){
            camera.m_Lens.FieldOfView = 4.2f;
        }

        /*if(camera.m_Lens.FieldOfView>=zoomOutPoint && levelCentre){
            camera.Follow = levelCentre.transform;
        }

        else if(camera.m_Lens.FieldOfView<zoomOutPoint && player){
            camera.Follow = player.transform;
        }*/
        
    }
}
