using System;
using System.Collections.Generic;
using System.Linq;
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
using Chronocourses.Model;
using Chronocourses.Manager.ProductService;
using Chronocourses.Manager.ShopService;
using Chronocourses.Manager.EntityService;

namespace Chronocourses.Manager
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Map : Page
    {
        Shop currentShop;
        /* Zoom */
        Point? lastCenterPositionOnTarget;
        Point? lastMousePositionOnTarget;
        Point? lastDragPoint;
        Rectangle selectedRectangle;
        ShopService.IShopService sService;
        //ProductService.IProductService pService;
        EntityService.IEntityService eService;

        public Map()
        {
            InitializeComponent();
            //pService = new ProductService.ProductServiceClient();
            sService = new ShopService.ShopServiceClient();
            eService = new EntityService.EntityServiceClient();
            ProductService.IProductService pService = new ProductService.ProductServiceClient();
            shopComboBox.ItemsSource = sService.GetShops();
            Product[] products = pService.GetProducts();
            addProductComboBox.ItemsSource = products.ToList<Product>();
            /*
             * Zoom
             * */
            scrollViewer.ScrollChanged += OnScrollViewerScrollChanged;
            //scrollViewer.MouseLeftButtonUp += OnMouseLeftButtonUp;
            scrollViewer.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp;
            scrollViewer.PreviewMouseWheel += OnPreviewMouseWheel;

            //scrollViewer.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
            scrollViewer.MouseMove += OnMouseMove;

            slider.ValueChanged += OnSliderValueChanged;

        }

        private void shopSelected(object sender, SelectionChangedEventArgs e)
        {
            currentShop = sService.GetShop((shopComboBox.SelectedItem as Shop).ID);
            editProductComboBox.ItemsSource = currentShop.Entity;
            drawShop();
        }

        private void drawShop()
        {
            canvas.Children.Clear();
            double rectangleWidth = canvas.Width / currentShop.Width;
            double rectangleHeight = canvas.Height / currentShop.Height;
            SolidColorBrush sCB = new SolidColorBrush(Color.FromRgb(46, 141, 239));
            for (int i = 0; i < currentShop.Width; i++)
            {
                for (int j = 0; j < currentShop.Height; j++)
                {

                    Rectangle rectangle = new Rectangle
                    {
                        Fill = sCB,
                        Stroke = Brushes.White,
                        StrokeThickness = 1.0,
                        Width = rectangleWidth,
                        Height = rectangleHeight,
                        Margin = new Thickness(rectangleWidth * i, rectangleHeight * j, 0, 0)
                    };
                    rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(Rectangle_MouseLeftButtonDown);
                    canvas.Children.Add(rectangle);
                }
            }
            TrackableCollection<Entity> entities = currentShop.Entity;
            sCB = new SolidColorBrush(Color.FromRgb(0,138,0));
            foreach (Entity ent in entities)
            {
                if (ent.Label == "start")
                {
                    (canvas.Children[currentShop.Height * ent.PositionX + ent.PositionY] as Rectangle).Fill = Brushes.Red;
                }
                else
                {
                    (canvas.Children[currentShop.Height * ent.PositionX + ent.PositionY] as Rectangle).Fill = sCB;
                    String tTip = ent.Label;
                    ToolTipService.SetToolTip(canvas.Children[currentShop.Height * ent.PositionX + ent.PositionY] as Rectangle, tTip);
                }
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {   
            if (this.selectedRectangle != null)
            {
                Entity ent = getSelectedEntity();
                if (ent != null)
                {
                    if (ent.Container)
                    {
                        Product p = (Product)addProductComboBox.SelectedItem;
                        if (p != null)
                        {
                            bool alreadyIn = false;
                            foreach (Product pr in ent.Product)
                            {
                                if (pr.ID == p.ID)
                                {
                                    alreadyIn = true;
                                    break;
                                }
                            }
                            if (alreadyIn)
                            {
                                logBox.AppendText("\nThe product is already in this entity");
                            }
                            else
                            {
                                int a = eService.addProductToContainer(p, ent);
                                if (a > 0)
                                {
                                    logBox.AppendText("\n" + (addProductComboBox.SelectedItem as Product).Name + " has been added to " + ent.Label + ".");
                                }
                            }
                        }
                        else
                        {
                            logBox.AppendText("\nPlease select a product");
                        }
                    }
                    else
                    {
                        logBox.AppendText("\nImpossible to add a product to a non-container entity"); 
                    }
                }
                else
                {
                    if (addTextBox.Text.Length != 0)
                    {
                        Entity newEnt = new Entity();
                        newEnt.Container = true;
                        int[] senderRectangle = getPosition(this.selectedRectangle);
                        newEnt.PositionX = senderRectangle[0];
                        newEnt.PositionY = senderRectangle[1];
                        newEnt.ShopID = this.currentShop.ID;
                        newEnt.Label = (addTextBox as TextBox).Text;
                        int result = eService.AddEntity(newEnt);
                        if (result > 0)
                        {
                            logBox.AppendText("\n" + newEnt.Label + " has been created");
                            shopSelected(null, null);
                            addTextBox.Clear();
                            addTextBox.Visibility = Visibility.Hidden;
                            label1.Visibility = Visibility.Hidden;
                            addProductComboBox.Visibility = Visibility.Visible;
                            label2.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        logBox.AppendText("\nPlease enter a name for the entity you want to create");
                    }
                }
                refreshEditProductComboBox();
                //addProductComboBox.ItemsSource = this.pService.GetProducts();
            }

        }

        private int[] getPosition(Rectangle rect)
        {
            int[] ret = new int[2];
            ret[0] = (int) (rect.Margin.Left / (canvas.Width / currentShop.Width));
            ret[1] = (int)(rect.Margin.Top / (canvas.Height / currentShop.Height));
            return ret;
        }

        private Entity getSelectedEntity()
        {
            if (this.selectedRectangle == null)
                return null;
            int[] pos = getPosition(this.selectedRectangle);
            Entity ent = sService.GetEntityByPosition(pos[0], pos[1], currentShop);
            return ent;
        }


        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle senderRectangle = (Rectangle)sender;
            if (this.selectedRectangle == senderRectangle)
            {
                selectRectangle(senderRectangle, false);
                refreshEditProductComboBox();
                editCheckBox.IsEnabled = false;
            }
            else
            {
                if(!moveItem.IsSelected){
                    if (this.selectedRectangle != null)
                        this.selectedRectangle.Stroke = Brushes.White;
                    selectRectangle(senderRectangle,true);
                    int[] pos = getPosition(senderRectangle);
                    Entity ent = sService.GetEntityByPosition(pos[0],pos[1],currentShop);
                    if (ent != null)
                    {
                        editCheckBox.IsEnabled = true;
                        editCheckBox.IsChecked = ent.Container;
                        addCheckBox.IsChecked = ent.Container;
                        addTextBox.Visibility = Visibility.Hidden;
                        label1.Visibility = Visibility.Hidden;
                        addProductComboBox.Visibility = Visibility.Visible;
                        label2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        editCheckBox.IsEnabled = false;
                        addCheckBox.IsChecked = false;
                        addProductComboBox.Visibility = Visibility.Hidden;
                        label2.Visibility = Visibility.Hidden;
                        addTextBox.Visibility = Visibility.Visible;
                        label1.Visibility = Visibility.Visible;
                    }
                    refreshEditProductComboBox();
                }else{
                    if(moveStep == 1){
                        selectRectangle(senderRectangle,true);
                        moveFcn(null);
                    }else if(moveStep == 2){
                        moveFcn(senderRectangle);
                    }
                }
            }
        }
        
        private void selectRectangle(Rectangle rect,bool select){
            if(select){
                this.selectedRectangle = rect;
                this.selectedRectangle.Stroke = Brushes.Red;
            }else{
                this.selectedRectangle.Stroke = Brushes.White;
                this.selectedRectangle = null;
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (editProductComboBox.SelectedIndex != -1)
            {
                Entity ent = getSelectedEntity();
                Product p = (Product) editProductComboBox.SelectedItem;
                int a = 0;
                if (ent != null)
                {
                    a = eService.RemoveProductFromContainer(p, ent);
                }
                if (a > 0)
                {
                    logBox.AppendText("\n" + p.Name + " was removed from " + ent.Label + ".");
                }
                refreshEditProductComboBox();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (editProductComboBox.Items.Count > 0)
            {
                logBox.AppendText("\nImpossible to delete a container if there is any products left in it");
            }
            else
            {
                Entity ent = getSelectedEntity();
                int result = 0;
                if (ent != null)
                {
                   result = eService.DeleteEntity(ent);
                }
                if (result > 0)
                {
                    logBox.AppendText("\nThe entity has been successfully removed");
                }
                else
                {
                    logBox.AppendText("\nError, did you select an Entity ? ");
                }
            }
        }


        private int moveStep = 0;

        private void moveFcn(Rectangle rect)
        {
            switch (moveStep)
            {
                case 0:
                    if (this.currentShop != null)
                    {
                        if (this.selectedRectangle != null)
                        {
                            this.selectedRectangle.Stroke = this.selectedRectangle.Fill;
                            this.selectedRectangle = null;
                        }
                        moveTextBox.AppendText("\nPlease select the entity you want to move");
                        moveStep++;
                    }
                    else
                    {
                        logBox.AppendText("\nYou must select a shop before moving entities");
                    }
                break;
                case 1:
                    if (this.selectedRectangle != null)
                    {
                        if (getSelectedEntity() != null)
                        {
                            moveTextBox.AppendText("\nSelect the new position you want for the entity");
                            moveStep++;
                        }
                        else
                        {
                            logBox.AppendText("\nYou must select an entity");
                        }
                    }
                break;
                case 2:
                    if (rect != null)
                    {
                        int[] newPos = getPosition(rect);
                        if (sService.GetEntityByPosition(newPos[0], newPos[1], currentShop) == null)
                        {
                            Entity ent = this.getSelectedEntity();
                            int test = sService.moveEntityFromShop(getSelectedEntity(), newPos, currentShop);
                            this.shopSelected(null, null);
                            logBox.AppendText("\n" + ent.Label + " has been moved to (" + newPos[0] + "," + newPos[1] + ").");
                            moveReinitializeButton_Click(null, null);
                        }
                        else
                        {
                            logBox.AppendText("\nCannot move the entity to another entity");
                        }

                    }
                break;
            }
        }

        private void tabItemChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TabItem tI = (TabItem)e.AddedItems[0];
                if (tI.Header.Equals("MOVE"))
                {
                    this.moveStep = 0;
                    moveFcn(null);
                }
                else
                {
                    moveTextBox.Document.Blocks.Clear();
                }
            }
            catch (Exception exce)
            {
                exce.Source = "fail";
            }
        }

        private void editCheckBox_Click(object sender, RoutedEventArgs e)
        {
            Entity ent = getSelectedEntity();
            int result = eService.setContainer(ent,!ent.Container);
            if (result > 0)
            {
                String str = (!ent.Container) ? "" : "non-";
                logBox.AppendText("\n" + ent.Label + " successfully switch to "+str+"Container");
            }
        }

        private void moveReinitializeButton_Click(object sender, RoutedEventArgs e)
        {
            moveStep = 0;
            moveTextBox.Document.Blocks.Clear();
            moveFcn(null);
        }

        private void removeAllProductsButton_Click(object sender, RoutedEventArgs e)
        {
            //Pop up confirmation
            Entity ent = getSelectedEntity();
            int result = 0;
            if (ent != null)
            {
                result += eService.RemoveAllProductsFromContainer(ent);
            }
            logBox.AppendText("\n "+result + " product(s) have been removed") ;
            refreshEditProductComboBox();
        }

        private void refreshEditProductComboBox()
        {
            Entity selectedEntity = this.getSelectedEntity();
            if (selectedEntity != null)
            {
                editProductComboBox.ItemsSource = selectedEntity.Product;
            }
            else
            {
                editProductComboBox.ItemsSource = null;
            }
        }


        /*
         * ZOOM
         * */
        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - dX);
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - dY);
            }
        }

        void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(scrollViewer);
            if (mousePos.X <= scrollViewer.ViewportWidth && mousePos.Y < scrollViewer.ViewportHeight) //make sure we still can use the scrollbars
            {
                scrollViewer.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer);
            }
        }

        void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            lastMousePositionOnTarget = Mouse.GetPosition(canvas);

            if (e.Delta > 0)
            {
                slider.Value += 1;
            }
            if (e.Delta < 0)
            {
                slider.Value -= 1;
            }

            e.Handled = true;
        }

        void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            scrollViewer.Cursor = Cursors.Arrow;
            scrollViewer.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        void OnSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scaleTransform.ScaleX = e.NewValue;
            scaleTransform.ScaleY = e.NewValue;

            var centerOfViewport = new Point(scrollViewer.ViewportWidth / 2, scrollViewer.ViewportHeight / 2);
            lastCenterPositionOnTarget = scrollViewer.TranslatePoint(centerOfViewport, canvas);
        }

        void OnScrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        var centerOfViewport = new Point(scrollViewer.ViewportWidth / 2, scrollViewer.ViewportHeight / 2);
                        Point centerOfTargetNow = scrollViewer.TranslatePoint(centerOfViewport, canvas);

                        targetBefore = lastCenterPositionOnTarget;
                        targetNow = centerOfTargetNow;
                    }
                }
                else
                {
                    targetBefore = lastMousePositionOnTarget;
                    targetNow = Mouse.GetPosition(canvas);

                    lastMousePositionOnTarget = null;
                }

                if (targetBefore.HasValue)
                {
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / canvas.Width;
                    double multiplicatorY = e.ExtentHeight / canvas.Height;

                    double newOffsetX = scrollViewer.HorizontalOffset - dXInTargetPixels * multiplicatorX;
                    double newOffsetY = scrollViewer.VerticalOffset - dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    scrollViewer.ScrollToHorizontalOffset(newOffsetX);
                    scrollViewer.ScrollToVerticalOffset(newOffsetY);
                }
            }
        }

        private void keyDownAddTextBox(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                addButton_Click(sender,e);
        }

    }
}