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
    public GameObject TitlePanel;
    public GameObject PreRecordPanel;
    public GameObject PreMovePanel;
    public GameObject TimePanel;

    public void SequencePlus(){
        //Destroy (this.gameObject);
        switch(PanelSequence){
            //0:Title
            case 0:
                TitlePanel.gameObject.SetActive(false);
                PreRecordPanel.gameObject.SetActive(true);
                Debug.Log("TS-S0push");
                PanelSequence++;
                break;
            //1:PreRecording
            case 1:
                PreRecordPanel.gameObject.SetActive(false);
                PreMovePanel.gameObject.SetActive(true);
                Debug.Log("TS-S1push");
                PanelSequence++;
                break;
            //2:PreMove
            case 2:
                PreMovePanel.gameObject.SetActive(false);
                TimePanel.gameObject.SetActive(true);
                Debug.Log("TS-S2push");
                GS.Timer_Start();
                PanelSequence++;
                break;
            //3:Invisible
            case 3:
                TimePanel.gameObject.SetActive(false);
                PreRecordPanel.gameObject.SetActive(true);
                Debug.Log("TS-S3Done");
                PanelSequence = 0;
                break;
        }
    }

    public void TimerUIset(float t){
        TimePanel.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().SetText("{0:0}", t);
    }
     private void Awake() {
        GS = GameObject.Find("System").GetComponent<GetStatus>();
     }
}
