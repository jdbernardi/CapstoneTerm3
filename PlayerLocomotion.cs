using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    public GameObject player;

    void OnEnable()
    {
        WaypointOrb.OnClicked += MovePlayer;
    }

    void OnDisable()
    {
        WaypointOrb.OnClicked -= MovePlayer;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MovePlayer()
    {
        iTween.MoveTo(player,
            iTween.Hash(
                //              "position", OrbInteraction.orbPosition,
                "x", WaypointOrb.orbPosition.x,
                "y", WaypointOrb.orbPosition.y + 2,
                "z", WaypointOrb.orbPosition.z,
                "time", 2,
                "easetype", "linear"
            )
        );
    }
}
