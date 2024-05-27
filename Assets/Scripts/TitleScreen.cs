using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    public GetStatus GS;
    //SequencePlus
    public int PanelSequence = 0;
    public GameObject cursorL;
    public GameObject cursorR;
    public GameObject TitlePanel;
    public GameObject PreRecordPanel;
    public GameObject RecordPanel;
    public GameObject SavePanel;
    
    public void SequencePlus(){
        //Destroy (this.gameObject);
        switch(PanelSequence){
            //0:Title
            case 0:
                TitlePanel.gameObject.SetActive(false);
                PreRecordPanel.gameObject.SetActive(true);
                //Title to PreRec
                Debug.Log("TS-S0push");
                PanelSequence++;
                break;
            //1:PreRecording
            case 1:
                PreRecordPanel.gameObject.SetActive(false);
                RecordPanel.gameObject.SetActive(true);

                cursorL.gameObject.SetActive(false);
                cursorR.gameObject.SetActive(false);
                //PreRec to Rec
                Debug.Log("TS-S1RecStart");
                GS.Timer_Start();
                PanelSequence++;
                break;
            //2:Record
            case 2:
                RecordPanel.gameObject.SetActive(false);
                SavePanel.gameObject.SetActive(true);

                cursorL.gameObject.SetActive(true);
                cursorR.gameObject.SetActive(true);
                //Rec to Save
                Debug.Log("TS-S2done");
                PanelSequence++;
                break;
            //3:Save
            case 3:
                SavePanel.gameObject.SetActive(false);
                PreRecordPanel.gameObject.SetActive(true);
                //Save to PreRec
                Debug.Log("TS-S3MaybeSaved");
                PanelSequence = 1;
                break;
        }
    }

    public void TargetSecSet(float t){
        PreRecordPanel.transform.Find("SetText").gameObject.GetComponent<TextMeshProUGUI>().SetText("{0:0}", t);
    }

    public void TimerUIset(float t){
        RecordPanel.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().SetText("{0:0}", t);
    }
    void Start(){
        GS = GameObject.Find("System").GetComponent<GetStatus>();
        GS.TargetSecondSet(0.0f);
    }
}
