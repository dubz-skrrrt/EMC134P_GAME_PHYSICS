using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("GameObjects Referenced")]
    public GameObject arrow;
    public GameObject soccerBall;
    public GameObject ringGoal;
    public GameObject spawnedArrow;
    public GameObject soccerBallClone;
    public GameObject ringGoalClone;
    public GameObject Player;

    [Header("GameObject Transforms")]
    private Vector3 startPosBal;
    private Vector3 startPosRing;
    public Vector3 startPlayerPos;
    public Quaternion startPlayerRot;
    
    
    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
        startPlayerPos = Player.transform.position;
        startPlayerRot = Quaternion.Euler(Player.transform.rotation.x, Player.transform.rotation.y + 5, Player.transform.rotation.z);
        startPosBal = soccerBall.transform.position;
        startPosRing = ringGoal.transform.position;
        SpawnBall();
        DirectionalArrow();
        SpawnRingGoal();
        
    }

    void Update(){
    }

    public void SpawnRingGoal(){
        ringGoalClone = (GameObject)Instantiate(ringGoal, startPosRing, transform.rotation) as GameObject;
    }
    public void SpawnBall(){
        soccerBallClone = (GameObject)Instantiate(soccerBall, startPosBal, transform.rotation) as GameObject;
        Shooting.shoot = false;
    }
    public void DirectionalArrow(){
        spawnedArrow = (GameObject)Instantiate(arrow, startPosBal, transform.rotation) as GameObject;
        
    }

}
