using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using QuickFix;

namespace OrderMatchCSharp
{
    public interface IMatchingEngineView
    {
        void AddNewOrder(Order order);
        Order CancelOrder(string orderID);
        void WriteLineToConsole(string message);
        void SetNumberOfConnections(int numberOfConnections);
        void SetClientState(int clientNum, string clientName, bool newState);
    }

    public partial class MatchingEngine : Form, IMatchingEngineView
    {
        private const string TableBuys = "BuyOrders";
        private const string TableSells = "SellOrders";
        private readonly SocketAcceptor _socketAcceptor;

        public MatchingEngine()
        {
            InitializeComponent();

            dsOrders.Tables[0].Columns.Add(new DataColumn("order", Type.GetType("OrderMatchCSharp.Order")));
            dsOrders.Tables[1].Columns.Add(new DataColumn("order", Type.GetType("OrderMatchCSharp.Order")));

            Directory.SetCurrentDirectory("..\\..");
            string configurationFilePath = GetConfigurationFile();

            if (File.Exists(configurationFilePath))
            {
                SessionSettings settings = new SessionSettings(configurationFilePath);
                QuickFixApplication quickFixApplication = new QuickFixApplication(this);
                FileStoreFactory fileStoreFactory = new FileStoreFactory(settings);
                ScreenLogFactory screenLogFactory = new ScreenLogFactory(settings);
                MessageFactory messageFactory = new DefaultMessageFactory();
                //_socketAcceptor = new SocketAcceptor(quickFixApplication, fileStoreFactory, settings, screenLogFactory, messageFactory);
                _socketAcceptor = new SocketAcceptor(quickFixApplication, fileStoreFactory, settings, messageFactory);

                _socketAcceptor.start();
            }
        }

        private void cbTickers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newTicker = ((ComboBox)sender).SelectedItem.ToString();
            if (newTicker != null) ChangeOrderBookToTicker(newTicker);
        }

        private void ChangeOrderBookToTicker(string ticker)
        {
            dgBids.DataMember = GetTableForBuys(ticker).TableName;
            dgAsks.DataMember = GetTableForSells(ticker).TableName;
        }

        public void AddNewOrder(Order order)
        {
            try
            {
                if (order.Side.getValue() == Side.BUY)
                {
                    AddNewOrderToGUI(dgBids, order);
                }
                else if (order.Side.getValue() == Side.SELL)
                {
                    AddNewOrderToGUI(dgAsks, order);
                }

                if (rb2.Checked)
                {
                    ReDrawAllOrdersTable();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNewOrder: " + ex.Message);
            }
        }

        public Order CancelOrder(string orderID)
        {
            Order order = null;

            try
            {
                foreach (DataTable dataTable in dsOrders.Tables)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow.ItemArray[3].ToString() == orderID)
                        {
                            order = (Order)dataRow.ItemArray[6];
                            DeleteOrderFromTable(dataRow);
                            break;
                        }
                    }
                }

                if (rb2.Checked)
                {
                    ReDrawAllOrdersTable();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return order;
        }

        public void WriteLineToConsole(string message)
        {
            if (txtConsole.InvokeRequired)
                txtConsole.Invoke(new MethodInvoker(delegate() { WriteLineToConsole(message); }));
            else
                txtConsole.Text += message + Environment.NewLine;
        }

        public void SetNumberOfConnections(int numberOfConnections)
        {
            if (txtConnections.InvokeRequired)
                txtConnections.Invoke(new MethodInvoker(delegate() { SetNumberOfConnections(numberOfConnections); }));
            else
                txtConnections.Text = numberOfConnections.ToString();
        }

        public void SetClientState(int clientNum, string clientName, bool newState)
        {
            if (clientNum == 1)
                SetControlState(lblClient1, newState, clientName);
            else if (clientNum == 2)
                SetControlState(lblClient2, newState, clientName);
        }

        public void SetControlState(Control control, bool newState, string clientName)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate() { control.Visible = newState; control.Text = clientName; }));
            }
        }

        private void DeleteOrderFromTable(DataRow dataRow)
        {
            if (dataRow.Table.TableName.Contains(TableSells))
            {
                if (dgAsks.InvokeRequired)
                {
                    dgAsks.Invoke(new MethodInvoker(delegate() { DeleteOrderFromTable(dataRow); }));
                }
                else
                {
                    dataRow.Delete();
                }
            }
            else if (dataRow.Table.TableName.Contains(TableBuys))
            {
                if (dgBids.InvokeRequired)
                {
                    dgBids.Invoke(new MethodInvoker(delegate() { DeleteOrderFromTable(dataRow); }));
                }
                else
                {
                    dataRow.Delete();
                }
            }
        }

        public void AddNewOrderToGUI(DataGridView dataGridView, Order order)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new MethodInvoker(delegate() { AddNewOrderToGUI(dataGridView, order); }));
            }
            else
            {
                DataTable symbolTable = GetTableForOrder(order);
                if (OrderDoesNotExistAndIsUnique(symbolTable.Rows, order.ClientId))
                {
                    int cellColorStyle = 0;
                    if (order.Side.getValue() == Side.SELL)
                        cellColorStyle = 2;
                    symbolTable.Rows.Add(new object[] { order.Price, order.OpenQuantity, cellColorStyle, order.ClientId, order.Symbol, order.Owner, order });
                }
                AddToListOfTickers(order.Symbol);    
            }
        }

        private DataTable GetTableForOrder(Order order)
        {
            if (order.Side.getValue() == Side.SELL)
                return GetTableForSells(order.Symbol);
            return GetTableForBuys(order.Symbol);
        }

        private DataTable GetTableForBuys(string symbol)
        {
            return GetOrCreateTable(symbol + TableBuys);
        }

        private DataTable GetTableForSells(string symbol)
        {
            return GetOrCreateTable(symbol + TableSells);
        }

        private DataTable GetOrCreateTable(string tableName)
        {
            if (dsOrders.Tables[tableName] == null)
            {
                DataTable newTable = dsOrders.Tables[1].Clone();
                newTable.TableName = tableName;
                dsOrders.Tables.Add(newTable);
            }

            return dsOrders.Tables[tableName];
        }

        private void AddToListOfTickers(string symbol)
        {
            if (TickerDoesNotExistInList(symbol))
                AddItemToTickerBox(cbTickers, symbol);
        }

        private void AddItemToTickerBox(ComboBox cb, string symbol)
        {
            if (cb.InvokeRequired)
                cb.Invoke(new MethodInvoker(delegate(){AddItemToTickerBox(cb,symbol);}));
            else
            {
                int index = cb.Items.Add(symbol);
                if (cb.SelectedIndex == -1)
                {
                    cb.SelectedItem = cb.Items[index];
                    ChangeOrderBookToTicker(symbol);
                }
            }
        }

        private bool TickerDoesNotExistInList(string symbol)
        {
            foreach (object item in cbTickers.Items)
                if (item.ToString() == symbol)
                    return false;
            return true;
        }

        private static bool OrderDoesNotExistAndIsUnique(DataRowCollection rows, string id)
        {
            foreach (DataRow row in rows)
                if (row.ItemArray[3].ToString() == id)
                    return false;
            return true;
        }

        private static string GetConfigurationFile()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())
                + "\\cfg\\" + "OrderMatchCSharp.cfg";
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            StopServer();
            Exit();
        }

        private void Exit()
        {
            Close();
        }

        private void StopServer()
        {
            if (_socketAcceptor != null) _socketAcceptor.stop(true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }

        private void dgBids_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            DataRowView item = (DataRowView)((DataGridView)sender).Rows[e.RowIndex].DataBoundItem;

            if (item != null && item[2] != null)
            {
                try
                {
                    DataGridViewCellStyle dataGridViewCellStyle;

                    switch ((int)item[2])
                    {
                        case 0:
                            dataGridViewCellStyle = GetBuyOutOfMoneyStyle();
                            break;
                        case 1:
                            dataGridViewCellStyle = GetBuyInTheMoneyStyle();
                            break;
                        case 2:
                            dataGridViewCellStyle = GetSellOutOfTheMoneyStyle();
                            break;
                        case 3:
                            dataGridViewCellStyle = GetSellInTheMoneyStyle();
                            break;
                        default:
                            dataGridViewCellStyle = GetBuyOutOfMoneyStyle();
                            break;
                    }
                    e.CellStyle.ApplyStyle(dataGridViewCellStyle);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("dgBids_CellFormatting: " + ex.Message);
                }
            }
        }

        private static DataGridViewCellStyle GetBuyOutOfMoneyStyle()
        {
            DataGridViewCellStyle buyOutOfMoneyCellStyle = new DataGridViewCellStyle();
            buyOutOfMoneyCellStyle.BackColor = System.Drawing.Color.Blue;
            buyOutOfMoneyCellStyle.ForeColor = System.Drawing.Color.WhiteSmoke;

            CopyStyleToSelectionStyle(buyOutOfMoneyCellStyle);

            return buyOutOfMoneyCellStyle;
        }

        private static DataGridViewCellStyle GetBuyInTheMoneyStyle()
        {
            DataGridViewCellStyle buyOutOfMoneyCellStyle = new DataGridViewCellStyle();
            buyOutOfMoneyCellStyle.BackColor = System.Drawing.Color.Yellow;
            buyOutOfMoneyCellStyle.ForeColor = System.Drawing.Color.WhiteSmoke;

            CopyStyleToSelectionStyle(buyOutOfMoneyCellStyle);

            return buyOutOfMoneyCellStyle;
        }

        private static DataGridViewCellStyle GetSellOutOfTheMoneyStyle()
        {
            DataGridViewCellStyle sellOutOfTheMoneyStyle = new DataGridViewCellStyle();
            sellOutOfTheMoneyStyle.BackColor = System.Drawing.Color.Red;
            sellOutOfTheMoneyStyle.ForeColor = System.Drawing.Color.WhiteSmoke;

            CopyStyleToSelectionStyle(sellOutOfTheMoneyStyle);

            return sellOutOfTheMoneyStyle;
        }

        private static DataGridViewCellStyle GetSellInTheMoneyStyle()
        {
            DataGridViewCellStyle sellInTheMoneyStyle = new DataGridViewCellStyle();
            sellInTheMoneyStyle.BackColor = System.Drawing.Color.Yellow;
            sellInTheMoneyStyle.ForeColor = System.Drawing.Color.WhiteSmoke;

            CopyStyleToSelectionStyle(sellInTheMoneyStyle);

            return sellInTheMoneyStyle;
        }

        private static void CopyStyleToSelectionStyle(DataGridViewCellStyle cellStyle)
        {
            cellStyle.SelectionBackColor = cellStyle.BackColor;
            cellStyle.SelectionForeColor = cellStyle.ForeColor;
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton) sender;
            if (radioButton.Checked)
            {
                cbTickers.Enabled = true;
                if (cbTickers.SelectedItem != null)
                {
                    string newTicker = cbTickers.SelectedItem.ToString();
                    if (newTicker != null)
                        ChangeOrderBookToTicker(newTicker);
                }
            }
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                cbTickers.Enabled = false;

                ReDrawAllOrdersTable();
            }
        }

        private void ReDrawAllOrdersTable()
        {
            ReGenerateAllOrdersTable();

            ChangeOrderBookToTicker("ALL");
        }

        private void ReGenerateAllOrdersTable()
        {
            if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(ReGenerateAllOrdersTable));
                }
            else
            {
                DataTable buyOrders = GetTableForBuys("ALL");
                buyOrders.Rows.Clear();
                DataTable sellOrders = GetTableForSells("ALL");
                sellOrders.Rows.Clear();

                foreach (DataTable dataTable in dsOrders.Tables)
                {
                    if (dataTable.TableName.Contains(TableBuys))
                        foreach (DataRow dataRow in dataTable.Rows)
                            buyOrders.Rows.Add(new[]
                                               {
                                                   dataRow.ItemArray[0], dataRow.ItemArray[1],
                                                   dataRow.ItemArray[2], dataRow.ItemArray[3],
                                                   dataRow.ItemArray[4], dataRow.ItemArray[5]
                                               });
                    else if (dataTable.TableName.Contains(TableSells))
                        foreach (DataRow dataRow in dataTable.Rows)
                            sellOrders.Rows.Add(new[]
                                               {
                                                   dataRow.ItemArray[0], dataRow.ItemArray[1],
                                                   dataRow.ItemArray[2], dataRow.ItemArray[3],
                                                   dataRow.ItemArray[4], dataRow.ItemArray[5]
                                               });
                }                
            }
        }

        private int _debugCount;
        private void btnDebug_Click(object sender, EventArgs e)
        {
            StopServer();

            DeleteStoreFiles();

            Exit();
        }

        private static void DeleteStoreFiles()
        {
            string path = "C:\\work\\FIN-ENG\\lwip\\Server-Winsock\\bin\\store";
            foreach (string file in System.IO.Directory.GetFiles(path))
            {
                System.IO.File.Delete(file);
            }
        }

        public void FillUpWithTestData(int iteration)
        {
            if (iteration == 0)
            {
                AddNewOrder(
                    new Order("101", "GE", "owner", "ORDERMATCH",
                        new Side(Side.SELL), new OrdType(OrdType.LIMIT), 11.00, 100)
                    );
                AddNewOrder(
                    new Order("103", "GE", "owner", "ORDERMATCH",
                        new Side(Side.SELL), new OrdType(OrdType.LIMIT), 12.00, 200)
                    );
                AddNewOrder(
                    new Order("102", "GE", "owner", "ORDERMATCH",
                        new Side(Side.BUY), new OrdType(OrdType.LIMIT), 12.50, 200)
                    );    
            }
            if (iteration == 1)
            {
                AddNewOrder(
                        new Order("104", "GOOG", "owner", "ORDERMATCH",
                        new Side(Side.SELL), new OrdType(OrdType.LIMIT), 35.50, 100)
                    );
                AddNewOrder(
                    new Order("105", "GOOG", "owner", "ORDERMATCH",
                        new Side(Side.BUY), new OrdType(OrdType.LIMIT), 36.00, 100)
                    );
            }
            if (iteration == 2)
            {
                CancelOrder("101");
                CancelOrder("103");
            }
        }
    }
}