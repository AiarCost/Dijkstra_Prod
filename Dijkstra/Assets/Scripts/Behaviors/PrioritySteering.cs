using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySteering
{
    public BlendedSteering[] Groups;

    float epsilon = .1f;

    BehaviorAndWeight PrioritizedBehavior;
    public SteeringOutput getSteering()
    {
        SteeringOutput steering = new SteeringOutput();

        foreach(BlendedSteering group in Groups)
        {
            steering = group.getSteering();

            if(steering.linear.magnitude > epsilon || Mathf.Abs(steering.angular) > epsilon)
            {
                return steering;
            }
        }

        return steering;
    }
}
