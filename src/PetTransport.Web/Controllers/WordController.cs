#region Copyright
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using PetTransport.Infrastructure.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{   
    public  class WordController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;

        public WordController(IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        
        
        public ActionResult SalesInvoice(Guid id, string SaveOption)
        {
            string basePath = _hostingEnvironment.WebRootPath;
                    
            // Create a new document
            WordDocument doc = new WordDocument();
            // Load the template.
            string dataPathSales = basePath + @"/Word/SalesInvoiceDemo.doc";
            FileStream fileStream = new FileStream(dataPathSales, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            doc.Open(fileStream, FormatType.Automatic);
            //Create MailMergeDataTable
            MailMergeDataTable mailMergeDataTableOrder = GetTestOrder(id);
            MailMergeDataTable mailMergeDataTableOrderTotals = GetTestOrderTotals(id);
            MailMergeDataTable mailMergeDataTableOrderDetails = GetTestOrderDetails(id);           
            // Execute Mail Merge with groups.
            doc.MailMerge.ExecuteGroup(mailMergeDataTableOrder);
            doc.MailMerge.ExecuteGroup(mailMergeDataTableOrderTotals);
            // Using Merge events to do conditional formatting during runtime.
            doc.MailMerge.MergeField += new MergeFieldEventHandler(MailMerge_MergeField);           
            doc.MailMerge.ExecuteGroup(mailMergeDataTableOrderDetails);
            FormatType type = FormatType.Docx;
            string filename = "SalesInvoice.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            #region Document SaveOption
            //Save as .doc format
            if (SaveOption == "WordDoc")
            {
                type = FormatType.Doc;
                filename = "SalesInvoice.doc";
                contenttype = "application/msword";
            }
            //Save as .xml format
            else if (SaveOption == "WordML")
            {
                type = FormatType.WordML;
                filename = "SalesInvoice.xml";
                contenttype = "application/msword";
            }
            #endregion Document SaveOption
            MemoryStream ms = new MemoryStream();
            doc.Save(ms, type);
            doc.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        private void MailMerge_MergeField(object sender, MergeFieldEventArgs args)
        {
            // Conditionally format data during Merge.
            if (args.RowIndex % 2 == 0)
            {
                args.CharacterFormat.TextColor = Syncfusion.Drawing.Color.DarkBlue;
            }

        }

        private MailMergeDataTable GetTestOrder(Guid TestOrderId)
        {
            var application = _context.Applications.Include(x=>x.OrderItems).FirstOrDefault(x => x.Id == TestOrderId);
            
            
            
            List<TestOrder> orders = new List<TestOrder>();
            
                TestOrder testOrder = new TestOrder();
            testOrder.ShipName = "shipName";
            testOrder.ShipAddress = application.DestinationPoint;
            testOrder.ShipPostalCode = "shipName";
            testOrder.ShipCountry = "shipName";
            testOrder.PostalCode = "shipName";
            testOrder.CustomerID = "shipName";
            testOrder.Customers_CompanyName = "shipName";
            testOrder.Salesperson = "Manager";
            testOrder.Address = "shipName";
            testOrder.City = application.SourcePoint;
            testOrder.OrderID = application.Id.ToString();
            testOrder.OrderDate = application.CreatedAt.ToString();
            testOrder.RequiredDate = "shipName";
            testOrder.ShippedDate = application.DeliveryDate.ToString();
            testOrder.Shippers_CompanyName = "shipName";
            
            orders.Add(testOrder);

            MailMergeDataTable dataTable = new MailMergeDataTable("Orders", orders);
            
            return dataTable;
            
        }

        private MailMergeDataTable GetTestOrderDetails(Guid TestOrderId)
        {
            var application = _context.Applications.Include(x=>x.OrderItems).FirstOrDefault(x => x.Id == TestOrderId);


            var orders = application.OrderItems.Select(x => new TestOrderDetail()
            {
                OrderID = TestOrderId.ToString(),
                ProductID = x.Id.ToString(),
                ProductName = x.AnimalName,
                UnitPrice = x.Price.ToString(),
                Quantity = "Quantity",
                Discount = "Discount",
                ExtendedPrice = "ExtendedPrice"
            }).ToList();
            
          
            MailMergeDataTable dataTable = new MailMergeDataTable("Order", orders);          
            return dataTable;
            
        }
        private MailMergeDataTable GetTestOrderTotals(Guid TestOrderId)
        {
            
            var application = _context.Applications.Include(x=>x.OrderItems).FirstOrDefault(x => x.Id == TestOrderId);
            
            List<TestOrderTotal> orders = new List<TestOrderTotal>();
         
            TestOrderTotal testOrderTotal = new TestOrderTotal();
            testOrderTotal.OrderID = TestOrderId.ToString();
            testOrderTotal.Subtotal = "subtotal";
            testOrderTotal.Freight = "fris";
            testOrderTotal.Total = application.OrderItems.Sum(x=>x.Price).ToString();
          
            orders.Add(testOrderTotal);
            
            MailMergeDataTable dataTable = new MailMergeDataTable("OrderTotals", orders);

            return dataTable;
        }
        
    }
    

    public class TestOrderDetail
    {
        #region Fields

        private string m_orderID;
        private string m_productID;
        private string m_productName;
        private string m_unitPrice;
        private string m_quantity;
        private string m_discount;
        private string m_extendedPrice;
        #endregion

        #region Properties

        public string OrderID
        {
            get { return m_orderID; }
            set { m_orderID = value; }
        }

        public string ProductID
        {
            get { return m_productID; }
            set { m_productID = value; }
        }
        public string ProductName
        {
            get { return m_productName; }
            set { m_productName = value; }
        }
        public string UnitPrice
        {
            get { return m_unitPrice; }
            set { m_unitPrice = value; }
        }
        public string Quantity
        {
            get { return m_quantity; }
            set { m_quantity = value; }
        }
        public string Discount
        {
            get { return m_discount; }
            set { m_discount = value; }
        }
        public string ExtendedPrice
        {
            get { return m_extendedPrice; }
            set { m_extendedPrice = value; }
        }

        #endregion

        #region Constructor       
        public TestOrderDetail()
        { }
        #endregion
    }
    public class TestOrderTotal
    {
        #region Fields

        private string m_orderID;
        private string m_subTotal;
        private string m_freight;
        private string m_total;
        #endregion

        #region Properties

        public string OrderID
        {
            get { return m_orderID; }
            set { m_orderID = value; }
        }

        public string Subtotal
        {
            get { return m_subTotal; }
            set { m_subTotal = value; }
        }
        public string Freight
        {
            get { return m_freight; }
            set { m_freight = value; }
        }
        public string Total
        {
            get { return m_total; }
            set { m_total = value; }
        }
        #endregion

        #region Constructor       
        public TestOrderTotal()
        { }
        #endregion
    }
    public class TestOrder
    {
        #region Fields

        private string m_orderID;
        private string m_shipName;
        private string m_shipAddress;
        private string m_shipCity;
        private string m_shipPostalCode;
        private string m_shipCountry;
        private string m_customerID;
        private string m_address;
        private string m_postalCode;
        private string m_city;
        private string m_country;
        private string m_salesPerson;
        private string m_customersCompanyName;
        private string m_orderDate;
        private string m_requiredDate;
        private string m_shippedDate;
        private string m_shippersCompanyName;
        #endregion

        #region Properties

        public string ShipName
        {
            get { return m_shipName; }
            set { m_shipName = value; }
        }

        public string ShipAddress
        {
            get { return m_shipAddress; }
            set { m_shipAddress = value; }
        }
        public string ShipCity
        {
            get { return m_shipCity; }
            set { m_shipCity = value; }
        }
        public string ShipPostalCode
        {
            get { return m_shipPostalCode; }
            set { m_shipPostalCode = value; }
        }
        public string PostalCode
        {
            get { return m_postalCode; }
            set { m_postalCode = value; }
        }
        public string ShipCountry
        {
            get { return m_shipCountry; }
            set { m_shipCountry = value; }
        }
        public string CustomerID
        {
            get { return m_customerID; }
            set { m_customerID = value; }
        }
        public string Customers_CompanyName
        {
            get { return m_customersCompanyName; }
            set { m_customersCompanyName = value; }
        }
        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }

        public string City
        {
            get { return m_city; }
            set { m_city = value; }
        }

        public string Country
        {
            get { return m_country; }
            set { m_country = value; }
        }
        public string Salesperson
        {
            get { return m_salesPerson; }
            set { m_salesPerson = value; }
        }
        public string OrderID
        {
            get { return m_orderID; }
            set { m_orderID = value; }
        }
        public string OrderDate
        {
            get { return m_orderDate; }
            set { m_orderDate = value; }
        }
        public string RequiredDate
        {
            get { return m_requiredDate; }
            set { m_requiredDate = value; }
        }
        public string ShippedDate
        {
            get { return m_shippedDate; }
            set { m_shippedDate = value; }
        }
        public string Shippers_CompanyName
        {
            get { return m_shippersCompanyName; }
            set { m_shippersCompanyName = value; }
        }
        #endregion

        #region Constructor       
        public TestOrder()
        { }
        #endregion
    }
}