﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using DataTypes;
using AuditService;
using DeliveryService;
using CheckoutService;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Delegates
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Page
    {
        private ProductsDataSource data = null;
        private Order order = null;
        private Auditor auditor = null;
        private Shipper shipper = null;
        private CheckoutController checkoutController = null;
        

        public MainWindow()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += App.WindowSizeChanged;

            this.auditor = new Auditor();
            this.shipper = new Shipper();
            this.checkoutController = new CheckoutController();
            this.checkoutController.CheckoutProcessing += this.auditor.AuditOrder;
            this.checkoutController.CheckoutProcessing += this.shipper.ShipOrder;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            data = new ProductsDataSource();
            this.productList.DataContext = data.Products;

            this.order = new Order {Date=DateTime.Now, Items=new List<OrderItem>(), OrderID=Guid.NewGuid(), TotalValue=0};
        }

        private void AddProductToOrderButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                // Find the product ID of the selected product (contained in the Tag property of the button)
                Button addButton = sender as Button;
                string productId = addButton.Tag as string;

                // Display the list view header if it is not already visible
                this.listViewHeader.Visibility = Visibility.Visible;

                // Enable the checkout button if it is not already enabled
                this.checkout.IsEnabled = true;

                // Check to see whether this product has already been added to the order
                OrderItem orderItem = order.Items.Find(o => o.Item.ProductID == productId);
                if (orderItem != null)
                {
                    // If the product is already included the order just increment the quantity
                    orderItem.Quantity++;

                    // Update the total value of the order
                    order.TotalValue += orderItem.Item.Price;
                }
                else
                {
                    // If the product has not previously been included in the order then add it

                    // First, find the details of the product
                    Product product = data.Products.Find(p => p.ProductID == productId);

                    // Create an OrderItem that references this product and set the Quatity to 1
                    orderItem = new OrderItem { Item = product, Quantity = 1 };

                    // Add the OrderItem to the Order
                    this.order.Items.Add(orderItem);

                    // Update the total value of the order
                    this.order.TotalValue += product.Price;
                }

                // Rebind the ListView to the order data to update the display
                this.orderDetails.DataContext = null;
                this.orderDetails.DataContext = order.Items;

                // Display the total order value
                this.orderValue.Text = String.Format("{0:C}", order.TotalValue);
            }
            catch (Exception ex)
            {
                MessageDialog dlg = new MessageDialog(ex.Message, "Exception");
                dlg.ShowAsync();
            }
        }

        private void CheckoutButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                // Perform the checkout processing
                this.checkoutController.StartCheckoutProcessing(this.order);
                
                // Display a summary of the order
                MessageDialog dlg = new MessageDialog(String.Format("Order {0}, value {1:C}", order.OrderID, order.TotalValue), "Order Placed");
                dlg.ShowAsync();

                // Clear out the order details so the user can start again with a new order
                this.order = new Order { Date = DateTime.Now, Items = new List<OrderItem>(), OrderID = Guid.NewGuid(), TotalValue = 0 };
                this.orderDetails.DataContext = null;
                this.orderValue.Text = String.Format("{0:C}", order.TotalValue);
                this.listViewHeader.Visibility = Visibility.Collapsed;
                this.checkout.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageDialog dlg = new MessageDialog(ex.Message, "Exception");
                dlg.ShowAsync();
            }
        }        
    }
}
