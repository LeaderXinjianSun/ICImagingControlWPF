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
using System.Drawing;

namespace ICImagingControlWPF1
{
    /// <summary>
    /// ICImagingControlWFM.xaml 的交互逻辑
    /// </summary>
    delegate void DeviceLostRouteEventHandler(object sender, DeviceLostEventArgs e);
    public class DeviceLostEventArgs : RoutedEventArgs
    {
        public DeviceLostEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source) { }
        
    }
    public partial class ICImagingControlWFM : UserControl
    {
        public ICImagingControlWFM()
        {
            InitializeComponent();
            this.iCImagingControl.DeviceLost += ICImagingControl_DeviceLost;
        }

        private void ICImagingControl_DeviceLost(object sender, TIS.Imaging.ICImagingControl.DeviceLostEventArgs e)
        {
            //throw new NotImplementedException();
            
            DeviceLostEventArgs args = new DeviceLostEventArgs(DeviceLostEvent, this);
            this.RaiseEvent(args);
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
                myICImagingControlWFM.iCImagingControl.Size = new System.Drawing.Size(320, 240);
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

        //1、为元素声明并注册事件
        public static readonly RoutedEvent DeviceLostEvent = EventManager.RegisterRoutedEvent("DeviceLost", RoutingStrategy.Bubble,
                                                             typeof(DeviceLostRouteEventHandler), typeof(ICImagingControlWFM));

        //2、包装事件
        public event RoutedEventHandler DeviceLost
        {
            add { this.AddHandler(DeviceLostEvent, value); }
            remove { this.RemoveHandler(DeviceLostEvent, value); }
        }

        public static readonly DependencyProperty ImageActiveBuffer1Property =
        DependencyProperty.Register("ImageActiveBuffer1", typeof(Bitmap), typeof(ICImagingControlWFM));
        //iCImagingControl.ImageActiveBuffer.Bitmap;
        public Bitmap ImageActiveBuffer1
        {
            get { return (Bitmap)GetValue(ImageActiveBuffer1Property); }
            set { SetValue(ImageActiveBuffer1Property, value); }
        }
        public static readonly DependencyProperty SnapActionProperty =
    DependencyProperty.Register("SnapAction", typeof(bool), typeof(ICImagingControlWFM), new PropertyMetadata(
    new PropertyChangedCallback((d, e) =>
    {
        var myICImagingControlWFM = d as ICImagingControlWFM;
        
            myICImagingControlWFM.iCImagingControl.MemorySnapImage();
        

    })));
        public bool SnapAction
        {
            get { return (bool)GetValue(SnapActionProperty); }
            set { SetValue(SnapActionProperty, value); }
        }
        //3、创建激发事件的方法
        //protected void onDeviceLost()
        //{            
        //    DeviceLostEventArgs args = new DeviceLostEventArgs(DeviceLostEvent, this);            
        //    this.RaiseEvent(args);
        //}
    }
}
