using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using Application = System.Windows.Application;

namespace QuickTranslate.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NotifyIcon Icon;
        private MainWindow _mainWindow;
        readonly KeyboardListener _kListener = new KeyboardListener();

        const int WM_DRAWCLIPBOARD = 0x0308;
        const int WM_CHANGECBCHAIN = 0x030D;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(
            IntPtr hWndRemove, 
            IntPtr hWndNewNext 
            );

        private HwndSource _hwndSource;
        private WindowInteropHelper _wih;

        protected override void OnStartup(StartupEventArgs e)
        {
            Icon = new NotifyIcon();
            Icon.Click += icon_Click;
            Icon.Icon = QuickTranslate.App.Properties.Resources.favicon;
            Icon.Visible = true;
            Icon.ContextMenu = new ContextMenu(new[]
            {
                new MenuItem("Exit", application_Exit), 
            });

            _mainWindow = new MainWindow();
            _mainWindow.Show();

            _wih = new WindowInteropHelper(_mainWindow);
            _hwndSource = HwndSource.FromHwnd(_wih.Handle);
            if (_hwndSource != null)
                _hwndSource.AddHook(MainWindowProc);

            RegisterClipboardViewer();

            _kListener.KeyDown += KListener_KeyDown;

            base.OnStartup(e);
        }

        private void icon_Click(object sender, EventArgs e)
        {
            _mainWindow.Visibility = Visibility.Visible;
        }

        private void application_Exit(object sender, EventArgs e)
        {
            UnregisterClipboardViewer();
            Icon.Visible = false;
            Current.Shutdown();
        }

        IntPtr _clipboardViewerNext;
        public void RegisterClipboardViewer()
        {
            _clipboardViewerNext = SetClipboardViewer(_hwndSource.Handle);
        }

        public void UnregisterClipboardViewer()
        {
            ChangeClipboardChain(_hwndSource.Handle, _clipboardViewerNext);
        }

        private bool _getCopyValue = false;
        private void CopyFromActiveProgram()
        {
            _getCopyValue = true;
            SendKeys.SendWait("^c");
        }

        private IntPtr MainWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_DRAWCLIPBOARD:

                    if (_getCopyValue && System.Windows.Clipboard.ContainsText())
                    {
                        _getCopyValue = false;
                        var selectedText = System.Windows.Clipboard.GetText();
                        Translate(selectedText);
                        System.Windows.Clipboard.Clear();
                    }
                    SendMessage(_clipboardViewerNext, msg, wParam, lParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (wParam == _clipboardViewerNext)
                    {
                        _clipboardViewerNext = lParam;
                    }
                    else
                    {
                        SendMessage(_clipboardViewerNext, msg, wParam, lParam);
                    }
                    break;
            }

            return IntPtr.Zero;
        }

        Key _lastKey;
        protected void KListener_KeyDown(object sender, RawKeyEventArgs args)
        {
            if (_lastKey == Key.LeftCtrl && args.Key == Key.Q)
            {
                CopyFromActiveProgram();
            }
            _lastKey = args.Key;
        }

        private void Translate(string text)
        {
            _mainWindow.ViewModel.Text = text;
            _mainWindow.ViewModel.Translate();
            _mainWindow.Visibility = Visibility.Visible;
            _mainWindow.Activate();
        }
    }
}
