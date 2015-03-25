﻿using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
using Xilium.CefGlue;

namespace Unico.Desktop
{
    public class MainForm : Form
    {
        private readonly SynchronizationContext synContext = WindowsFormsSynchronizationContext.Current;

        public MainForm()
        {
            Size = new Size(800, 600);
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            var winInfo = CefWindowInfo.Create();
            winInfo.SetAsChild(Handle, new CefRectangle { X = 0, Y = 0, Width = Width, Height = Height });
            CefBrowserHost.CreateBrowser(winInfo, new SimpleCefClient(), new CefBrowserSettings(), "www.baidu.com");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }
    }
}

