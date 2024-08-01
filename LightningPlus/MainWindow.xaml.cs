using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LightningPlus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupMapProjection();
        }

        private void SetupMapProjection()
        {
            MapProjector.MapProvider = GMapProviders.OpenStreetMap;
            MapProjector.CacheLocation = @".\cache\";
            MapProjector.Position = new GMap.NET.PointLatLng(40, -102);
            MapProjector.MinZoom = 1;
            MapProjector.MaxZoom = 15;
            MapProjector.Zoom = 3;
            MapProjector.ShowCenter = false;
            MapProjector.MouseMove += GMapMouseMoveEvent;
            statusLatLon.Content = $"Latitude: 0.00000, Longitude: 0.00000, Current Zoom: {MapProjector.Zoom}";
            MapProjector.DragButton = MouseButton.Left;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GMapMouseMoveEvent(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(MapProjector);
            var latLng = MapProjector.FromLocalToLatLng((int)point.X, (int)point.Y);

            statusLatLon.Content = $"Latitude: {latLng.Lat:0.00000}, Longitude: {latLng.Lng:0.00000}, Current Zoom: {MapProjector.Zoom}";
        }

        private void ViewZoomIn_Click(object sender, RoutedEventArgs e) 
        {
            if(MapProjector.Zoom < 14)
                MapProjector.Zoom += 1;
        }

        private void ViewZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if(MapProjector.Zoom > 1)
            {
                MapProjector.Zoom -= 1;
            }
        }
    }
}