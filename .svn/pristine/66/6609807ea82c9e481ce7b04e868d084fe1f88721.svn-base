using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

namespace ISA.Batch
{
    public class SMS
    {

        #region Open and Close Ports
        //Open Port
        public SerialPort OpenPort(string portName)
        {
            receiveNow = new AutoResetEvent(false);
            SerialPort port = new SerialPort();

            try
            {
                port.PortName = portName;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.StopBits = StopBits.One;
                port.Parity = Parity.None;
                port.ReadTimeout = 300;
                port.WriteTimeout = 300;
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    throw new UnauthorizedAccessException(string.Format(Message.Error.PortAccessDenied, portName));
                }
                else if (ex is IOException)
                {
                    throw new UnauthorizedAccessException(string.Format(Message.Error.PortInUse, portName));
                }
                else
                {
                    throw ex;
                }
            }
            return port;
        }

        //Close Port
        public void ClosePort(SerialPort port)
        {
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        //Execute AT Command
        public string ExecCommand(SerialPort port, string command, int responseTimeout, string errorMessage)
        {
            try
            {

                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                receiveNow.Reset();
                port.Write(command + "\r");

                string input = ReadResponse(port, responseTimeout);
                if ((input.Length == 0) || ((!input.EndsWith("\r\n> ")) && (!input.EndsWith("\r\nOK\r\n"))))
                    throw new ApplicationException(Message.Error.NoResponse);
                return input;
            }
            catch (ApplicationException ex)
            {
                if (ex.Message != string.Empty)
                {
                    throw ex;
                }
                else
                {
                    throw new ApplicationException(errorMessage);
                }
            }
            catch
            {
                throw new Exception(errorMessage);
            }
        }

        //Receive data from port
        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                {
                    receiveNow.Set();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ReadResponse(SerialPort port, int timeout)
        {
            string buffer = string.Empty;
            try
            {
                do
                {
                    if (receiveNow.WaitOne(timeout, false))
                    {
                        string t = port.ReadExisting();
                        buffer += t;
                    }
                    else
                    {
                        if (buffer.Length > 0)
                            throw new ApplicationException(Message.Error.IncompleteResponse);
                        else
                            throw new ApplicationException(string.Empty);
                    }
                }
                while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\n> ") && !buffer.EndsWith("\r\nERROR\r\n"));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return buffer;
        }

        #region Count SMS
        public int CountSMSmessages(SerialPort port)
        {
            int CountTotalMessages = 0;
            try
            {

                #region Execute Command

                string recievedData = ExecCommand(port, "AT", 300, string.Format(Message.Error.NoModem, port.PortName));
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, Message.Error.FailToFormat);
                String command = "AT+CPMS?";
                recievedData = ExecCommand(port, command, 1000, Message.Error.FailToCount);
                int uReceivedDataLength = recievedData.Length;

                #endregion

                #region If command is executed successfully
                if (recievedData.Length >= 45)
                {

                    #region Parsing SMS
                    string[] strSplit = recievedData.Split(',');
                    string strMessageStorageArea1 = strSplit[0];     //SM
                    string strMessageExist1 = strSplit[1];           //Msgs exist in SM
                    #endregion

                    #region Count Total Number of SMS In SIM
                    CountTotalMessages = Convert.ToInt32(strMessageExist1);
                    #endregion

                }
                #endregion

                #region If command is not executed successfully
                else if (recievedData.Contains("ERROR"))
                {

                    #region Error in Counting total number of SMS
                    string recievedError = recievedData;
                    recievedError = recievedError.Trim();
                    recievedData = recievedError;
                    #endregion

                }
                #endregion

                return CountTotalMessages;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Read SMS

        public AutoResetEvent receiveNow;

        public ShortMessages ReadSMS(SerialPort port, string command)
        {

            // Set up the phone and read the messages
            ShortMessages messages = null;
            try
            {

                #region Execute Command
                // Check connection
                ExecCommand(port, "AT", 300, string.Format(Message.Error.NoModem, port.PortName));
                // Use message format "Text mode"
                ExecCommand(port, "AT+CMGF=1", 300, Message.Error.FailToFormat);
                // Use character set "GSM"
                ExecCommand(port, "AT+CSCS=\"GSM\"", 300, Message.Error.FailToCharSet);
                // Select SIM storage
                ExecCommand(port, "AT+CPMS=\"SM\"", 300, Message.Error.FailToSIM);
                // Read the messages
                string input = ExecCommand(port, command, 5000, Message.Error.FailToRead);
                #endregion

                #region Parse messages
                messages = ParseMessages(input);
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (messages != null)
                return messages;
            else
                return null;

        }
        public ShortMessages ParseMessages(string input)
        {
            ShortMessages messages = new ShortMessages();
            try
            {
                Regex r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n");
                Match m = r.Match(input);
                while (m.Success)
                {
                    ShortMessage msg = new ShortMessage();
                    //msg.Index = int.Parse(m.Groups[1].Value);
                    msg.Index = m.Groups[1].Value;
                    msg.Status = m.Groups[2].Value;
                    msg.Sender = m.Groups[3].Value;
                    msg.Alphabet = m.Groups[4].Value;
                    msg.Sent = m.Groups[5].Value;
                    msg.Message = m.Groups[6].Value;
                    messages.Add(msg);

                    m = m.NextMatch();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return messages;
        }

        #endregion

        #region Send SMS

        static AutoResetEvent readNow = new AutoResetEvent(false);

        public bool SendMsg(SerialPort port, string phoneNo, string message, int responseTimeout)
        {
            bool isSend = false;

            string recievedData = string.Empty;

            try
            {

                recievedData = ExecCommand(port, "AT", 300, string.Format(Message.Error.NoModem, port.PortName));
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, Message.Error.FailToFormat);
                String command = "AT+CMGS=\"" + phoneNo + "\"";
                recievedData = ExecCommand(port, command, 300, Message.Error.FailToAccPhoneNo);
                command = message + char.ConvertFromUtf32(26) + "\r";
                recievedData = ExecCommand(port, command, responseTimeout, Message.Error.FailToSend); //3 seconds
                if (recievedData.EndsWith("\r\nOK\r\n"))
                {
                    isSend = true;
                }
                else if (recievedData.Contains("ERROR"))
                {
                    isSend = false;
                }
                return isSend;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                    readNow.Set();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Delete SMS
        public bool DeleteMsg(SerialPort port, string command)
        {
            bool isDeleted = false;
            try
            {

                #region Execute Command
                string recievedData = ExecCommand(port, "AT", 300, string.Format(Message.Error.NoModem, port.PortName));
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, Message.Error.FailToFormat);
                recievedData = ExecCommand(port, command, 300, Message.Error.FailToDelete);
                #endregion

                if (recievedData.EndsWith("\r\nOK\r\n"))
                {
                    isDeleted = true;
                }
                if (recievedData.Contains("ERROR"))
                {
                    isDeleted = false;
                }
                return isDeleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
