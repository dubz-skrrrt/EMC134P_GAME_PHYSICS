using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("GameObjects Referenced")]
    public GameObject arrow;
    public GameObject soccerBall;
    public GameObject spawnedArrow;
    public GameObject soccerBallClone;
    private Vector3 startPosBal;
    public GameObject Player;
    public Vector3 startPlayerPos;
    public Quaternion startPlayerRot;
    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
        startPlayerPos = Player.transform.position;
        startPlayerRot = Quaternion.Euler(Player.transform.rotation.x, Player.transform.rotation.y + 5, Player.transform.rotation.z);
        startPosBal = soccerBall.transform.position;
        SpawnBall();
        DirectionalArrow();
        
    }

    void Update(){
        //spawnedArrow.transform.position = Shooting.ball.transform.position + Shooting.offset;
    }
    public void SpawnBall(){
        soccerBallClone = (GameObject)Instantiate(soccerBall, startPosBal, transform.rotation) as GameObject;
        Shooting.shoot = false;
    }
    public void DirectionalArrow(){
        spawnedArrow = (GameObject)Instantiate(arrow, startPosBal, transform.rotation) as GameObject;
        
    }
}
