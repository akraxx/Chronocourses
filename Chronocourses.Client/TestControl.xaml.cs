using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Chronocourses.Client
{
    public partial class TestControl : UserControl
    {
        public TestControl(int entityId)
        {
            InitializeComponent();

            EntityService.EntityServiceClient entityService = new EntityService.EntityServiceClient();
            entityService.GetEntityCompleted += new EventHandler<EntityService.GetEntityCompletedEventArgs>(entityService_GetEntityCompleted);
            entityService.GetEntityAsync(entityId);
        }

        void entityService_GetEntityCompleted(object sender, EntityService.GetEntityCompletedEventArgs e)
        {
            listBox1.ItemsSource = e.Result.Product;
        }
    }
}
