using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomOutFactor = 60f; 
    [SerializeField] float zoomInFactor = 30f;


    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 1f;

    [SerializeField] float zoomedOutForwardSpeed = 8f;
    [SerializeField] float zoomedOutBackwardSpeed = 4f;
    [SerializeField] float zoomedOutStrafeSpeed = 4f;

    [SerializeField] float zoomedInForwardSpeed = 4f;
    [SerializeField] float zoomedInBackwardSpeed = 2f;
    [SerializeField] float zoomedInStrafeSpeed = 2f;




    [SerializeField] Transform zoomedOutTransform, zoomedInTransform;
    [SerializeField] RigidbodyFirstPersonController fpsController;


    private void LateUpdate()
    {
        Zoom();
    }

    private void OnDisable()
    {
        //ZoomOut();
    }

    private void Zoom()
    {
        if (Input.GetMouseButton(1))
        {
            ZoomIn();
            print("zoom in");
        }
        if (Input.GetMouseButtonUp(1))
        {
            ZoomOut();
            print("zoom out");
        }
    }

    private void ZoomIn()
    {
        //fpsCamera.fieldOfView = zoomInFactor;
       
        fpsCamera.fieldOfView = Mathf.Lerp(fpsCamera.fieldOfView, zoomInFactor, 0.08f);

        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;

        //Change movement speed when zooming in
        fpsController.movementSettings.ForwardSpeed = zoomedInForwardSpeed;
        fpsController.movementSettings.BackwardSpeed = zoomedInBackwardSpeed;
        fpsController.movementSettings.StrafeSpeed = zoomedInStrafeSpeed;
    }

    private void ZoomOut()
    {

       // fpsCamera.fieldOfView = zoomOutFactor;
        fpsCamera.fieldOfView = Mathf.Lerp(fpsCamera.fieldOfView, zoomOutFactor, 0.5f);

        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;

        //Change movement speed when zooming out
        fpsController.movementSettings.ForwardSpeed = zoomedOutForwardSpeed;
        fpsController.movementSettings.BackwardSpeed = zoomedOutBackwardSpeed;
        fpsController.movementSettings.StrafeSpeed = zoomedOutStrafeSpeed;
    }
}
