using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] //Requires this, of not existing it creates one

public class Tiling : MonoBehaviour
{
    public int offsetX = 2; // the offset so that we dont get any weird errors
    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;

    public bool reverseScale = false; // used if object isnt tileable

    private float spriteWidth = 0f;
    
    private Camera cam;
    private Transform myTransform;

    private void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sRenderer= GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Does it still need buddies? If not do nothing
        if (!hasALeftBuddy || !hasARightBuddy)
        {
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height; // half width of camera view

            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend; // x pos where cam can see sprite edge
            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend; // x pos where cam can see sprite edge

            // Checking if we can see the edge of the element and calling MakeNewBuddy if we can
            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && !hasARightBuddy)
            {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            }
            else if(cam.transform.position.x <= edgeVisiblePositionRight + offsetX && !hasALeftBuddy)
            {
                MakeNewBuddy(-1);
                hasALeftBuddy = true;
            }
        }
    }

    // Function that creates a buddy on the side required
    void MakeNewBuddy (int rightOrLeft)
    {
        // Calculating the new position for our new buddy
        Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
        Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform; //like (Transform)

        // If not tileable let's reverse the x size of our object to get rid of ugly scenes c:
        if (reverseScale)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y * -1, newBuddy.localScale.z * -1);
        }

        newBuddy.parent = myTransform.parent;
        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
        }
        else{
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
        }
    }
}
