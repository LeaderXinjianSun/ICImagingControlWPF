using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ICImagingControlWPF1
{
    /// <summary>
    /// ICImagingControlWFM.xaml 的交互逻辑
    /// </summary>
    public partial class ICImagingControlWFM : UserControl
    {
        public ICImagingControlWFM()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 控件初始化，选择相机
        /// </summary>
        public static readonly DependencyProperty LoadDeviceProperty =
    DependencyProperty.Register("LoadDevice", typeof(bool), typeof(ICImagingControlWFM), new PropertyMetadata(
        new PropertyChangedCallback((d, e) =>
        {
            var myICImagingControlWFM = d as ICImagingControlWFM;
            //imageViewer.viewController.repaint();
            myICImagingControlWFM.iCImagingControl.ShowDeviceSettingsDialog();
            if (myICImagingControlWFM.iCImagingControl.DeviceValid)
            {
                myICImagingControlWFM.iCImagingControl.LiveDisplayDefault = false;
                myICImagingControlWFM.iCImagingControl.LiveDisplayHeight = myICImagingControlWFM.iCImagingControl.Height;
                myICImagingControlWFM.iCImagingControl.LiveDisplayWidth = myICImagingControlWFM.iCImagingControl.Width;
            }
        })));
        public bool LoadDevice
        {
            get { return (bool)GetValue(LoadDeviceProperty); }
            set { SetValue(LoadDeviceProperty, value); }
        }
        /// <summary>
        /// 控件初始化，选择相机
        /// </summary>
        public static readonly DependencyProperty StartLiveProperty =
    DependencyProperty.Register("StartLive", typeof(bool), typeof(ICImagingControlWFM), new PropertyMetadata(
        new PropertyChangedCallback((d, e) =>
        {
            var myICImagingControlWFM = d as ICImagingControlWFM;
            myICImagingControlWFM.iCImagingControl.LiveStart();
        })));
        public bool StartLive
        {
            get { return (bool)GetValue(StartLiveProperty); }
            set { SetValue(StartLiveProperty, value); }
        }
        public static readonly DependencyProperty LiveStopProperty =
    DependencyProperty.Register("LiveStop", typeof(bool), typeof(ICImagingControlWFM), new PropertyMetadata(
    new PropertyChangedCallback((d, e) =>
    {
        var myICImagingControlWFM = d as ICImagingControlWFM;
        if (myICImagingControlWFM.iCImagingControl.LiveVideoRunning)
        {
            myICImagingControlWFM.iCImagingControl.LiveStop();
        }        
    })));
        public bool LiveStop
        {
            get { return (bool)GetValue(LiveStopProperty); }
            set { SetValue(LiveStopProperty, value); }
        }
    }
}
