using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Point {
    public int x;
    public int y;
}

public class App : MonoBehaviour {

    void Awake () {
        //启动PureMVC，完成Controller，Proxies，Mediators的初始化工作
        MyFacade.GetInstance ().Launch ();

    }

}