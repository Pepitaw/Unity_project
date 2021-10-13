using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{
    public Transform[] formation;
    public Vector3[] formation1;
    public Vector3[] formation2;
    public Vector3[] formation3;
    public Vector3[] formation4;
    public Vector3[] formation5;

    void Awake(){
        init();
        formation1[0]=formation[0].GetChild(0).position;
        for(int i=0;i<2;i++){
            formation2[i]=formation[1].GetChild(i).position;
        }
        for(int i=0;i<3;i++){
            formation3[i]=formation[2].GetChild(i).position;
        }
        for(int i=0;i<4;i++){
            formation4[i]=formation[3].GetChild(i).position;
        }
        for(int i=0;i<5;i++){
            formation5[i]=formation[4].GetChild(i).position;
        }
    }
    void init(){
        formation1=new Vector3[1];
        formation2=new Vector3[2];
        formation3=new Vector3[3];
        formation4=new Vector3[4];
        formation5=new Vector3[5];
    }
}
