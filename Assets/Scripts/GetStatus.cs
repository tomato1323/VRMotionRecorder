using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;
using UnityEngine.XR;
using Valve.VR;

/*
https://kartolitan.com/unitydevinf/
Unity��HMD�Ƃ��R���g���[���Ƃ��̍��W���擾����
https://soft-rime.com/post-4238/
�yUnityJsonUtility�z�i�N���X��z��ɂ����ꍇ�j�I�u�W�F�N�g�̃f�[�^��ۑ�������@
https://jmpelletier.com/ja/unity%E3%81%A7oculus%E3%82%B3%E3%83%B3%E3%83%88%E3%83%AD%E3%83%BC%E3%83%A9%E3%81%AE%E3%82%BB%E3%83%B3%E3%82%B5%E3%83%BC%E3%83%87%E3%83%BC%E3%82%BF%E3%82%92%E5%8F%96%E5%BE%97%E3%81%99%E3%82%8B/
Unity controller getStatus
*/

public class RecDateWrapper
{
    public RecDate[] RecDates;
}
public class RecDate
{
    //Time stamp
    public List<float> time = new List<float>();
    //Position
    public List<Vector3> position = new List<Vector3>();
    //Rotation
    public List<Quaternion> rotation = new List<Quaternion>();
}

public class GetStatus : MonoBehaviour
{
    List<XRNodeState> DeviceStat = new List<XRNodeState>();

    //public RecordDate RCDate;
    //iremono ----- DEPRECATED -----
    public XRNode[] TargetNode;
    public RecDateWrapper RCWl;

    public TitleScreen TS;
    //UI

    public CSVexport exporter;
    //Exporter

    //Kaki ready
    [SerializeField]
    bool isRecord;

    //kari oki
    Vector3 v3;
    Quaternion q3;
    int i;  //stupid index counter but ez too see

    //Timer
    [SerializeField]
    int Timer_Sequence; //0-Wait 1-Pre 2-Rec
    [SerializeField]
    float Second;
    [SerializeField]
    float TargetSecond;

    //RD transfer
    [SerializeField]
    

    public void RecordSystem()
    {
        //call when fixed update
        InputTracking.GetNodeStates(DeviceStat);
        i = 0;
        foreach (XRNodeState s in DeviceStat)
        {
            //Searching DeviceStatList
            //---------Change TarNod
            foreach (XRNode n in TargetNode)
            {
                Debug.Log("CR");
                //Checking TargetNode
                if (s.nodeType == n)
                {
                    RCWl.RecDates[i].time.Add(Second);
                    s.TryGetPosition(out v3);               //Position
                    RCWl.RecDates[i].position.Add(v3);
                    s.TryGetRotation(out q3);               //Rotation
                    RCWl.RecDates[i].rotation.Add(q3);

                    //https://forum.unity.com/threads/how-to-get-acceleration-from-motion-controller.661297/
                    //TryGerAcc function is not working X(
                    /*
                    s.TryGetAcceleration(out v3);           //Acceleration
                    Debug.Log(v3);
                    RCDate.RCWl.RecDates[i].acceleration.Add(v3);
                    */
                    /*
                    s.TryGetVelocity(out v3);               //Velocity
                    RCDate.RCWl.RecDates[i].velocity.Add(v3);
                    s.TryGetAngularAcceleration(out v3);    //AG-Acceleration
                    RCDate.RCWl.RecDates[i].AGacceleration.Add(v3);
                    s.TryGetAngularVelocity(out v3);        //AG-Velocity
                    RCDate.RCWl.RecDates[i].AGvelocity.Add(v3);
                    */

                    ///*
                    i++;
                    break;
                }
            }
        }
        //Debug.Log("RCW0" + RCW.RecDates[0]);
    }

    public void RecordInitializeSystem()
    {
        //call when start record
        InputTracking.GetNodeStates(DeviceStat);
        i = 0;
        foreach (XRNodeState s in DeviceStat)
        {
            foreach (XRNode n in TargetNode)
            {
                if (s.nodeType == n)
                {
                    RCWl.RecDates[i].time.Clear();
                    RCWl.RecDates[i].position.Clear();
                    RCWl.RecDates[i].rotation.Clear();
                    i++;
                    break;
                }
            }
        }
    }

    void Timer()
    {
        //call when Time_Start called
        //3Count+TargetCount
        if(Timer_Sequence == 1)
        {
            Second += Time.deltaTime;
            TS.TimerUIset(3 - Second);
            if(Second >= 3.0f)
            {
                isRecord = true;
                Second = 0.0f;
                Timer_Sequence++;
            }
        }
        if(Timer_Sequence == 2)
        {
            Second += Time.deltaTime;
            TS.TimerUIset(TargetSecond - Second);
            if(Second >= TargetSecond)
            {
                Debug.Log("RecordEnd");

                isRecord = false;
                TS.SequencePlus();
                Second = 0.0f;
                Timer_Sequence = 0;
                //Export2CSV();

                //Debug.Log("RD:" + RCDate.RCWl.RecDates.Length);
                //Debug.Log("RDP:" + RCDate.RCWl.RecDates[0].position.Count);
                //Debug.Log("RD:" + RCDate.RCWl.RecDates[0].position[0].ToString());
            }
        }
    }
    public void Timer_Start()
    {
        //call from TS
        if(Timer_Sequence == 0)
        {
            Timer_Sequence++;
            RecordInitializeSystem();
        }
    }

    public void TargetSecondSet(float a){
        //call from TS
        TargetSecond = TargetSecond + a;
        TS.TargetSecSet(TargetSecond);
    }

    public void Export2CSV(){
        exporter.LogSave(RCWl);
    }

    void Start()
    {
        TS = GameObject.Find("TitleScreen-v2").GetComponent<TitleScreen>();
        exporter = GameObject.Find("System").GetComponent<CSVexport>();
        isRecord = false;
        //Initialize
        TargetSecond = 5.0f;
        Debug.Log(DeviceStat);
        RCWl = new RecDateWrapper();
        //RCWl.RecDates = new RecDate[TargetNode.Length];
        RCWl.RecDates = new RecDate[TargetNode.Length].Select(x => {return new RecDate();}).ToArray();

        Debug.Log(RCWl.RecDates[0]);
        Debug.Log(RCWl.RecDates[0].time);
        Debug.Log(RCWl.RecDates[0].position);
    }

    void FixedUpdate()
    {
        Timer();
        if (isRecord){
            RecordSystem();
        }
    }
}
