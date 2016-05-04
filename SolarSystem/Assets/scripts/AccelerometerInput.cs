using UnityEngine;
using System.Collections;

public class OutofBoundsScript : MonoBehaviour
{

    public GameObject ship;
    public GameObject earth;
    public GameObject sun;
    public GameObject mars;
    public GameObject mercury;
    public GameObject venus;

    public float maxSpeed;

    ArrayList objects = new ArrayList();
    ArrayList reachedPlanets = new ArrayList();

    void Start()
    {
        objects.Add(earth);
        objects.Add(mars);
        objects.Add(mercury);
        objects.Add(sun);
        objects.Add(venus);
    }

    void Update()
    {
        // last 'safe' position
        Vector3 position = ship.transform.position;

        // joystick manipulation of spaceship

        // ROTATION // 
        float y = Input.acceleration.y; // y is mapped as pitch
        float z = Input.acceleration.z; // z is mapped as yaw
        // no need for roll in our implementation
        // wlog we can keep the spaceship upright at all times

        ship.transform.Rotate(new Vector3(0, y, z));

        // SPEED //
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // get movement of finger since last frame
            Vector2 touchDelta = Input.GetTouch(0).deltaPosition;
            float speed = 1 - touchDelta.y; // because of the orientation of our input devices vs Unity's default orientation, the y axis encodes
            // speed and we need to subtract it from 1
            // speed * maxSpeed now defines the speed of the spaceship

            // move spaceship along its forward axis
            ship.transform.Translate(Vector3.forward * speed * maxSpeed);
        }

        // check that the new position is in bounds
        Vector3 newPosition = ship.transform.position;

        foreach (GameObject o in objects)
        {
            if ((o.transform.position - newPosition).magnitude < o.GetComponent<SphereCollider>().radius + 2)
            {
                ship.transform.position = position; // too close to a planet
                // CHECK HERE IF THE PLANET IS THE GOAL PLANET
                // RELIES ON ADDING A 'GOAL' TAG TO A PLANET WHEN ITS SELECTED
                if (o.tag == "goal"){
                    reachedPlanets.Add(o); // add it to the list of planets the player has reached
                    o.tag.Remove(0); // its no longer a goal
                    //o.GetComponents<text>().show; // display information text. maybe add timer?

                    // check if the player has visited all the planets
                    if (reachedPlanets.Count == 4) 
                    {
                        // display some sort of 'you won' text
                    }
                }
            }
        }

        // update new position
        newPosition = ship.transform.position;

        // change these bounds to what is appropriate for newest iteration of project
        if (newPosition.x > 0 || newPosition.x < 0 || newPosition.y > 0 || newPosition.y < 0 || newPosition.z > 0 || newPosition.z < 0)
        {
            ship.transform.position = position; // out of bounds
        }
    }
}
