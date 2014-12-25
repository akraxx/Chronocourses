using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Chronocourses.Client.ShopService;
using System.Collections.ObjectModel;

namespace Chronocourses.Client
{
    public partial class Map : PhoneApplicationPage
    {
        private Cart cart;
        private ShopService.ShopServiceClient shopService = new ShopService.ShopServiceClient();
        private ProductService.ProductServiceClient productService = new ProductService.ProductServiceClient();

        public Map()
        {
            InitializeComponent();


            cart = (App.Current as App).Cart;
            shopService.GetStartPositionCompleted += new EventHandler<ShopService.GetStartPositionCompletedEventArgs>(shopService_GetStartPositionCompleted);
            shopService.GetStartPositionAsync(cart.Shop.ID);

        }

        void shopService_GetStartPositionCompleted(object sender, ShopService.GetStartPositionCompletedEventArgs e)
        {
            productService.GetShortestPathCompleted += new EventHandler<ProductService.GetShortestPathCompletedEventArgs>(productService_GetShortestPathCompleted);
            int[] startPositionArray = {e.Result.PositionX, e.Result.PositionY};
            ObservableCollection<int> startPosition = new ObservableCollection<int>(startPositionArray.ToList());
            ObservableCollection<ProductService.Product> products = new ObservableCollection<ProductService.Product>();
            foreach(CommandLine commandLine in cart.CommandLines) 
            {
                products.Add(commandLine.Product);
            }

            productService.GetShortestPathAsync(cart.Shop.ID, startPosition, products);
        }

        void productService_GetShortestPathCompleted(object sender, ProductService.GetShortestPathCompletedEventArgs e)
        {
            int width = (int)Canvas.Width / cart.Shop.Width;
            int height = (int)Canvas.Height / cart.Shop.Height;
            for (int i = 0; i < cart.Shop.Width; i++)
            {
                for (int j = 0; j < cart.Shop.Height; j++)
                {
                    Rectangle rectangle = new Rectangle()
                    {
                        Fill = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0)),
                        Width = width - 1,
                        Height = height - 1,
                        Margin = new Thickness(width * i, height * j, 0, 0)
                    };

                    Canvas.Children.Add(rectangle);
                }
            }

            foreach (Entity ent in cart.Shop.Entity)
            {
                if (ent.Label == "start")
                {
                    (Canvas.Children[cart.Shop.Height * ent.PositionX + ent.PositionY] as Rectangle).Fill = new SolidColorBrush(Color.FromArgb(100, 0, 255, 0));
                }
                else
                {
                    (Canvas.Children[cart.Shop.Height * ent.PositionX + ent.PositionY] as Rectangle).Fill = new SolidColorBrush(Color.FromArgb(100, 0, 0, 255));
                    String tTip = ent.Label;
                }
            }

            foreach (CommandLine commandLine in cart.CommandLines)
            {
                foreach (ProductService.Entity entity in commandLine.Product.Entity)
                {
                    if (entity.ShopID == cart.Shop.ID)
                    {
                        Ellipse ellipse = new Ellipse { Width = width, Height = height};
                        ellipse.Name = entity.ID.ToString();
                        Point point = new Point(entity.PositionX * width, entity.PositionY * height);
                        double left = point.X;
                        double top = point.Y;

                        ellipse.Margin = new Thickness(left, top, 0, 0);

                        ellipse.Hold += new EventHandler<System.Windows.Input.GestureEventArgs>(ellipse_Hold);

                        ellipse.Fill = new SolidColorBrush() { Color = Colors.Brown };

                        Canvas.Children.Add(ellipse);
                    }
                }
                
            }
            List<List<int[]>> paths = new List<List<int[]>>();

            foreach (ObservableCollection<ObservableCollection<int>> path in e.Result)
            {
                // Create a line geometry

                Point startPoint = new Point(-1, -1);
                foreach (ObservableCollection<int> entity in path)
                {
                    // Create a blue and a black Brush
                    SolidColorBrush blueBrush = new SolidColorBrush();
                    blueBrush.Color = Colors.Blue;
                    SolidColorBrush blackBrush = new SolidColorBrush();
                    blackBrush.Color = Colors.Black;

                    // Create a Path with black brush and blue fill
                    Path bluePath = new Path();
                    bluePath.Stroke = blackBrush;
                    bluePath.StrokeThickness = 3;
                    bluePath.Fill = blueBrush;

                    ;
                    if (startPoint.X.Equals(-1))
                    {
                        startPoint = new Point(entity[0] * width + width / 2, entity[1] * height + height / 2);
                    }
                    else
                    {
                        LineGeometry blackLineGeometry = new LineGeometry();
                        blackLineGeometry.StartPoint = startPoint;
                        blackLineGeometry.EndPoint = new Point(entity[0] * width + width / 2, entity[1] * height + height / 2);
                        // Add all the geometries to a GeometryGroup.
                        GeometryGroup blueGeometryGroup = new GeometryGroup();
                        blueGeometryGroup.Children.Add(blackLineGeometry);

                        // Set Path.Data
                        bluePath.Data = blueGeometryGroup;

                        Canvas.Children.Add(bluePath);
                        startPoint = blackLineGeometry.EndPoint;
                    }

                    
                }
            }
        }

        void ellipse_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;

            Popup popup = new Popup();
            TestControl control = new TestControl(int.Parse(ellipse.Name));
            control.OkBtn.Click += (s, args) =>
            {
                popup.IsOpen = false;
            };

            popup.Child = control;
            popup.IsOpen = true;

            Point point = e.GetPosition(Canvas);
            control.Margin = new Thickness(point.X, point.Y, 0, 0);
        }

        private double _imageScale = 1d;
        private Point _imageTranslation = new Point(0, 0);
        private Point _fingerOne;
        private Point _fingerTwo;
        private double _previousScale;

        private void OnPinchStarted(object s, PinchStartedGestureEventArgs e)
        {
            _fingerOne = e.GetPosition(Canvas, 0);
            _fingerTwo = e.GetPosition(Canvas, 1);
            _previousScale = 1;
        }

        private void OnPinchDelta(object s, PinchGestureEventArgs e)
        {
            var newScale = e.DistanceRatio / _previousScale;
            var currentFingerOne = e.GetPosition(Canvas, 0);
            var currentFingerTwo = e.GetPosition(Canvas, 1);
            var translationDelta = GetTranslationOffset(currentFingerOne,
            currentFingerTwo, _fingerOne, _fingerTwo, _imageTranslation, newScale);
            _fingerOne = currentFingerOne;
            _fingerTwo = currentFingerTwo;
            _previousScale = e.DistanceRatio;
            UpdatePicture(newScale, translationDelta);
        }

        private void UpdatePicture(double scaleFactor, Point delta)
        {
            var newscale = _imageScale * scaleFactor;
            var transform = (CompositeTransform)Canvas.RenderTransform;
            if (newscale > 1)
            {
                _imageScale *= scaleFactor;
                _imageTranslation = new Point
                (_imageTranslation.X + delta.X, _imageTranslation.Y + delta.Y);
                transform.ScaleX = _imageScale;
                transform.ScaleY = _imageScale;
                transform.TranslateX = _imageTranslation.X;
                transform.TranslateY = _imageTranslation.Y;
            }
            else
            {
                transform.TranslateX = 0;
                transform.TranslateY = 0;
                transform.ScaleX = transform.ScaleY = 1;
                _imageTranslation = new Point(0, 0);
            }
        }

        private Point GetTranslationOffset(Point currentFingerOne, Point currentFingerTwo,
        Point oldFingerOne, Point oldFingerTwo, Point currentPosition, double scale)
        {
            var newFingerOnePosition = new Point(
                currentFingerOne.X + (currentPosition.X - oldFingerOne.X) * scale,
                currentFingerOne.Y + (currentPosition.Y - oldFingerOne.Y) * scale);
            var newFingerTwoPosition = new Point(
                currentFingerTwo.X + (currentPosition.X - oldFingerTwo.X) * scale,
                currentFingerTwo.Y + (currentPosition.Y - oldFingerTwo.Y) * scale);
            var newPosition = new Point(
                (newFingerOnePosition.X + newFingerTwoPosition.X) / 2,
                (newFingerOnePosition.Y + newFingerTwoPosition.Y) / 2);
            return new Point(
                newPosition.X - currentPosition.X,
                newPosition.Y - currentPosition.Y);
        }


        private void GestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            var transform = (CompositeTransform)Canvas.RenderTransform;

            // Move the rectangle
            transform.TranslateX += e.HorizontalChange;
            transform.TranslateY += e.VerticalChange;
        }

        private void Canvas_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var transform = (CompositeTransform)Canvas.RenderTransform;
            transform.TranslateX = 0;
            transform.TranslateY = 0;
            transform.ScaleX = transform.ScaleY = 1;
            _imageTranslation = new Point(0, 0);
        }   
    }
}