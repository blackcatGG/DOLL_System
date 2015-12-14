using UnityEngine;
using System.Collections;

public class AddBoxToRenderer : MonoBehaviour {

    Renderer ren;
    BoxCollider box;
    float boxBorder = 0.0f;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!ren) ren = gameObject.GetComponent<TextMesh>().GetComponent< Renderer > ();
        if (!box) box = ren.gameObject.AddComponent<BoxCollider>();

        if (box && ren)
        {
            box.center = box.transform.InverseTransformPoint(ren.bounds.center);
            box.size = box.transform.InverseTransformDirection(ren.bounds.size / (transform.lossyScale.magnitude / 1.7f)) + (Vector3.one * boxBorder);
        }
    }
}
