using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBuilder : MonoBehaviour
{
    [SerializeField]
    private float _extraSegments;

    [SerializeField]
    private GameObject _item;

    [SerializeField]
    private float _jointSpring;

    [SerializeField]
    private float _jointDamper;

    public void Start()
    {

        GameObject firstLink = Instantiate(_item,transform,false);


        GameObject previousLink = firstLink;
        //previousLink.AddComponent(typeof(SpringJoint));
        //previousLink.GetComponent<SpringJoint>().spring = 40;
       
        for (int i = 0; i <_extraSegments; i++)
        {
            Vector3 prevloc = previousLink.transform.localPosition;
            Quaternion prevrot = previousLink.transform.localRotation;
            GameObject currentLink = Instantiate(_item,prevloc,prevrot);
            currentLink.AddComponent(typeof(SpringJoint));
            SpringJoint currentJoint = currentLink.GetComponent<SpringJoint>();
            currentJoint.spring = _jointSpring;
            currentJoint.damper = _jointDamper;
            currentJoint.connectedBody = (Rigidbody)previousLink.GetComponent(typeof(Rigidbody));

            previousLink = currentLink;


        }


    }
}
