﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xfs;

namespace XfsServer
{
    public class XfsServerInit
    {
        public XfsServerInit()
        {

        }

        public XfsServerInit(string ipString, int port, int maxListenCount)
        {

        }

        //程序启动入口
        public void Init()
        {
            Console.WriteLine(XfsTimerTool.CurrentTime() + " ... ");
            Thread.Sleep(1);

            XfsGameSenceInit();

            Thread.CurrentThread.Name = "TumoWorld";
            Console.WriteLine(XfsTimerTool.CurrentTime() + " ThreadName: " + Thread.CurrentThread.Name);
            Console.WriteLine(XfsTimerTool.CurrentTime() + " ThreadId: " + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
            Console.WriteLine(XfsTimerTool.CurrentTime() + " 退出监听，并关闭程序。");
        }

        void XfsGameSenceInit()
        {
            ///服务器加载组件
            XfsGame.XfsSence.AddComponent(new XfsNode(XfsNodeType.Login));                        ///服务器加载组件 : 服务器类型组件
            //XfsGame.XfsSence.AddComponent(new XfsMysql("127.0.0.1", "tumoworld", "root", ""));    ///服务器加载组件 : 数据库链接组件
            XfsGame.XfsSence.AddComponent(new XfsTcpServer());                                    ///服务器加载组件 : 通信组件Server
            XfsGame.XfsSence.AddComponent(new XfsHandlers());                                    ///服务器加载组件 : 通信组件Server


            ///服务器加载组件驱动程序
            //XfsGame.XfsSystemMananger.AddComponent(new XfsMysqlSystem());          ///服务器加载组件 : 数据库链接组件TmSystem类型
            XfsGame.XfsSystemMananger.AddComponent(new XfsTcpServerSystem());      ///服务器加载组件 : 套接字 外网 传输数据组件
            XfsGame.XfsSystemMananger.AddComponent(new XfsTcpSessionSystem());       ///服务器加载组件 : 心跳包 组件

        }



        void Init(XfsNodeType type)
        {
            switch (type)
            {
                case XfsNodeType.Login:
                    Thread.Sleep(1);

                    ///服务器加载组件
                    XfsGame.XfsSence.AddComponent(new XfsNode(XfsNodeType.Login));                        ///服务器加载组件 : 服务器类型组件
                    XfsGame.XfsSence.AddComponent(new XfsMysql("127.0.0.1", "tumoworld", "root", ""));       ///服务器加载组件 : 数据库链接组件
                    XfsGame.XfsSence.AddComponent(new XfsTcpServer());                                    ///服务器加载组件 : 通信组件Server
                    //XfsGame.XfsSence.AddComponent(new XfsTcpClient());                                    ///服务器加载组件 : 通信组件Client

                    ///服务器加载组件驱动程序
                    XfsGame.XfsSence.AddComponent(new XfsMysqlSystem());                                  ///服务器加载组件 : 数据库链接组件TmSystem类型
                    XfsGame.XfsSence.AddComponent(new XfsTcpServerSystem());                              ///服务器加载组件 : 套接字 外网 传输数据组件
                    //XfsGame.XfsSence.AddComponent(new XfsTcpClientSystem());                              ///服务器加载组件 : 套接字 外网 传输数据组件

                    break;
                case XfsNodeType.Gate:

                    break;
                case XfsNodeType.Game:

                    break;
                case XfsNodeType.Node1:

                    break;
                case XfsNodeType.Node2:

                    break;
                case XfsNodeType.Node3:

                    break;
                case XfsNodeType.Node4:

                    break;
                case XfsNodeType.BD:

                    break;
                case XfsNodeType.All:

                    break;
                default:

                    break;
            }
        }


    }
}