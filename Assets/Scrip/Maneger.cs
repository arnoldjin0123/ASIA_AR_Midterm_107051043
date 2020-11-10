using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maneger : MonoBehaviour
{
    [Header("UIButton")]
    public Button Action1B;
    public Button Action2B;
    public Button Action3B;
    public Button Action4B;
    public Button ResetB;

    [Header("UISlider&joystick")]
    public Slider ScaleS;
    public VariableJoystick joystick;

    [Header("Transform")]
    public Transform MetalMan;
    public Transform BoxMan;

    [Header("RotateSpeedX"),Range(1f,10f)]
    public float RotateSpeedX=1f;
    [Header("RotateSpeedY"), Range(1f, 10f)]
    public float RotateSpeedY=1f;

    [Header("ScaleSmallValue")]
    public int BoxManSmall=150;
    public int MetalManSmall = 1;

    [Header("BoxMan&MetialMan's animator")]
    public Animator BoxManAni;
    public Animator MetalManAni;

    private void Start()
    {
        ResetB.onClick.AddListener(RestRotate);
        Action1B.onClick.AddListener(() => PlayAnimation("Action1"));
        Action2B.onClick.AddListener(() => PlayAnimation("Action2"));
        Action3B.onClick.AddListener(() => PlayAnimation("Action3"));
        Action4B.onClick.AddListener(() => PlayAnimation("Action4"));

        void RestRotate()
        {
            ScaleS.value = 1;
            MetalMan.transform.localRotation = Quaternion.Euler(0, 0, 0);
            BoxMan.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        void PlayAnimation(string ani)
        {
            BoxManAni.SetTrigger(ani);
            MetalManAni.SetTrigger(ani);
        }
    }

    void Update()
    {
        BoxMan.transform.Rotate(joystick.Vertical * RotateSpeedX * -1, joystick.Horizontal * RotateSpeedY, 0);
        BoxMan.localScale = new Vector3(1, 1, 1) * ScaleS.value/BoxManSmall;
        MetalMan.transform.Rotate(joystick.Vertical * RotateSpeedX * -1, joystick.Horizontal * RotateSpeedY, 0);
        MetalMan.localScale = new Vector3(1, 1, 1) * ScaleS.value/MetalManSmall;
    }
}
