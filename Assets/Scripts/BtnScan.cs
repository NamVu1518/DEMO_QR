using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScan : ButtonBase
{
    void Start()
    {
        btn.onClick.AddListener(StartScan);
    }

    private void StartScan()
    {
        AppManage.Ins.Scan();
    }
}
