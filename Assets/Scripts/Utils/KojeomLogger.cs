using System.Text;
using UnityEngine;

public enum KojeomLogType
{
    NORMAL = 0,
    ERROR = 1,
    INFO = 2,
    SYSTEM_FILE_IO = 3,
    WARNNING = 4,
    NETWORK = 5,
    EDITOR_TOOL = 6,
    DATABASE = 7,
}
public class KojeomLogger
{
    public static void DebugLog(string log, KojeomLogType logType = KojeomLogType.INFO)
    {
        StringBuilder changedLog = new StringBuilder();
        switch (logType)
        {
            case KojeomLogType.NORMAL:
                changedLog.AppendFormat("<color=blue><b>[NORMAL]</b></color> {0}", log);
                break;
            case KojeomLogType.ERROR:
                changedLog.AppendFormat("<color=red><b>[ERROR]</b></color> {0}", log);
                break;
            case KojeomLogType.INFO:
                changedLog.AppendFormat("<color=green><b>[INFO]</b></color> {0}", log);
                break;
            case KojeomLogType.SYSTEM_FILE_IO:
                changedLog.AppendFormat("<color=white><b>[SYSTEM_FILE_IO]</b></color> {0}", log);
                break;
            case KojeomLogType.WARNNING:
                changedLog.AppendFormat("<color=yellow><b>[WARNNING]</b></color> {0}", log);
                break;
            case KojeomLogType.NETWORK:
                changedLog.AppendFormat("<color=yellow><b>[NETWORK]</b></color> {0}", log);
                break;
            case KojeomLogType.EDITOR_TOOL:
                changedLog.AppendFormat("<color=magenta><b>[EDITOR_TOOL]</b></color> {0}", log);
                break;
            case KojeomLogType.DATABASE:
                changedLog.AppendFormat("<color=#FFCC00><b>[EDITOR_TOOL]</b></color> {0}", log);
                break;
            default:
                break;
        }
        Debug.Log(changedLog);
    }
}
