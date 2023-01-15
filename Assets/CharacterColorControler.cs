using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[ExecuteAlways]
public class CharacterColorControler : MonoBehaviour
{


    public Color leftArm;
    public Color rightArm;
    public Color leftLeg;
    public Color rightLeg;
    public Color torso;

    public Color headFrame;
    public Color Eyebrow;
    public Color Eyes;


    public GameObject leftArmObject;
    public GameObject rightArmObject;
    public GameObject leftLegObject;
    public GameObject rightLegObject;

    public GameObject torsoObject;

    public GameObject headFrameObject;
    public GameObject EyebrowObject;
    public GameObject EyesObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        leftArmObject.GetComponent<SpriteRenderer>().color = leftArm;
        rightArmObject.GetComponent<SpriteRenderer>().color = rightArm;
        leftLegObject.GetComponent<SpriteRenderer>().color = leftLeg;
        rightLegObject.GetComponent<SpriteRenderer>().color = rightLeg;

        torsoObject.GetComponent<SpriteRenderer>().color = torso;

        headFrameObject.GetComponent<SpriteRenderer>().color = headFrame;
        EyebrowObject.GetComponent<SpriteRenderer>().color = Eyebrow;
        EyesObject.GetComponent<SpriteRenderer>().color = Eyes;

    }
}
