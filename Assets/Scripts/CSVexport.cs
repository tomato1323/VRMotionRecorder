using UnityEngine;
using System.IO;

public class CSVexport : MonoBehaviour
{
    public void LogSave(RecDateWrapper RD)
    {
        StreamWriter sw;
        FileInfo fi;
        string filename = "Output_" + System.DateTime.Now.ToString("yyyyMMddHHmmss");
        Debug.Log("RD: " + RD);
        Debug.Log(RD.RecDates[0].time[0]);

        #if UNITY_EDITOR
        fi = new FileInfo(Application.dataPath + "/" + filename + ".csv");
        #elif UNITY_STANDALONE
        fi = new FileInfo(Application.dataPath + "/" + filename + ".csv");
        #endif
        sw = fi.AppendText();
        sw.WriteLine(
                    "Index," +
                    "Head.pos.x," +
                    "Head.pos.y," +
                    "Head.pos.z," +
                    "Head.rot.x," +
                    "Head.rot.y," +
                    "Head.rot.z," +
                    "Head.rot.w," +

                    "LeftHand.pos.x," +
                    "LeftHand.pos.y," +
                    "LeftHand.pos.z," +
                    "LeftHand.rot.x," +
                    "LeftHand.rot.y," +
                    "LeftHand.rot.z," +
                    "LeftHand.rot.w," +

                    "RightHand.pos.x," +
                    "RightHand.pos.y," +
                    "RightHand.pos.z," +
                    "RightHand.rot.x," +
                    "RightHand.rot.y," +
                    "RightHand.rot.z," +
                    "RightHand.rot.w,"
                    /*
                    "Head.acceleration.x,"+"Head.acceleration.y,"+"Head.acceleration.z,"+
                    "LeftHand.acceleration.x,"+"LeftHand.acceleration.y,"+"LeftHand.acceleration.z,"+
                    "RightHand.acceleration.x,"+"RightHand.acceleration.y,"+"RightHand.acceleration.z"
                    */
                    );
        
        for (int i = 0; i < RD.RecDates[0].position.Count; i++)
        {
                sw.WriteLine(
                    RD.RecDates[0].time[i].ToString("f5") + "," +
                    RD.RecDates[0].position[i].x.ToString("f5") + "," +
                    RD.RecDates[0].position[i].y.ToString("f5") + "," +
                    RD.RecDates[0].position[i].z.ToString("f5") + "," +

                    RD.RecDates[0].rotation[i].x.ToString("f5") + "," +
                    RD.RecDates[0].rotation[i].y.ToString("f5") + "," +
                    RD.RecDates[0].rotation[i].z.ToString("f5") + "," +
                    RD.RecDates[0].rotation[i].w.ToString("f5") + "," +

                    RD.RecDates[1].position[i].x.ToString("f5") + "," +
                    RD.RecDates[1].position[i].y.ToString("f5") + "," +
                    RD.RecDates[1].position[i].z.ToString("f5") + "," +

                    RD.RecDates[1].rotation[i].x.ToString("f5") + "," +
                    RD.RecDates[1].rotation[i].y.ToString("f5") + "," +
                    RD.RecDates[1].rotation[i].z.ToString("f5") + "," +
                    RD.RecDates[1].rotation[i].w.ToString("f5") + "," +

                    RD.RecDates[2].position[i].x.ToString("f5") + "," +
                    RD.RecDates[2].position[i].y.ToString("f5") + "," +
                    RD.RecDates[2].position[i].z.ToString("f5") + "," +

                    RD.RecDates[2].rotation[i].x.ToString("f5") + "," +
                    RD.RecDates[2].rotation[i].y.ToString("f5") + "," +
                    RD.RecDates[2].rotation[i].z.ToString("f5") + "," +
                    RD.RecDates[2].rotation[i].w.ToString("f5")

                    /*
                    RD.RecDates[0].acceleration[i].x.ToString("f5") + "," +
                    RD.RecDates[0].acceleration[i].y.ToString("f5") + "," +
                    RD.RecDates[0].acceleration[i].z.ToString("f5") + "," +

                    RD.RecDates[1].acceleration[i].x.ToString("f5") + "," +
                    RD.RecDates[1].acceleration[i].y.ToString("f5") + "," +
                    RD.RecDates[1].acceleration[i].z.ToString("f5") + "," +

                    RD.RecDates[2].acceleration[i].x.ToString("f5") + "," +
                    RD.RecDates[2].acceleration[i].y.ToString("f5") + "," +
                    RD.RecDates[2].acceleration[i].z.ToString("f5")
                    */
                );
        }

        sw.Flush();
        sw.Close();
        Debug.Log("Write Done");
    }
}
