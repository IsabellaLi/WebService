using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services.Protocols;
using System.Net;
using System.Diagnostics;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        Stopwatch sw = new Stopwatch();
        Service1 proxy = new Service1();
        public void CallService()
        {
            sw.Reset();
            sw.Start();
            proxy.Timeout = 10000;//10s
            string rt=proxy.HelloWorld();
            rtLabel.Text =rt+ " Time elapsed: "+sw.ElapsedMilliseconds.ToString()+" milliseconds.";
        }

        protected void syncCall_Click(object sender, EventArgs e)
        {
            CallService();
        }

        protected void sleepCall_Click(object sender, EventArgs e)
        {
            sw.Reset();
            sw.Start();
            proxy.Timeout = 10000;//10s
            try
            {
                string rt = proxy.JustSleep1Min();
            }
            catch (WebException ex)
            {
                Response.Write("<script language=javascript>alert('" + ex.Message + ". Time elapsed: " + sw.ElapsedMilliseconds.ToString() + " milliseconds." + "');</script>");
                return;
            }
        }

        protected void flushCall_Click(object sender, EventArgs e)
        {
            sw.Reset();
            sw.Start();
            proxy.Timeout = 10000;//10s
            try
            {
                string rt = proxy.FlushAndSleep1Min();
            }
            catch (InvalidOperationException ex) 
            {
                Response.Write("<script language=javascript>alert('Protocal Exception. "+" Time elapsed: " + sw.ElapsedMilliseconds.ToString() + " milliseconds." + "');</script>");
                return;
            }
        }

        protected void noflush_Click(object sender, EventArgs e)
        {
            sw.Reset();
            sw.Start();
            proxy.Timeout = 10000;//10s
            try
            {
                string rt = proxy.NoFlushAndSleep1Min();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('" + ex.Message.Replace("'", "\'") + ". Time elapsed: " + sw.ElapsedMilliseconds.ToString() + " milliseconds." + "');</script>");
                return;
            }
        }

        protected void asynCall_Click(object sender, EventArgs e)
        {
            sw.Reset();
            sw.Start();
            
            proxy.FlushAndSleep1MinCompleted += proxy_FlushAndSleep1MinCompleted;
            proxy.JustSleep1MinCompleted += proxy_JustSleep1MinCompleted;
            try
            {
                proxy.FlushAndSleep1MinAsync();
            }
            catch(Exception ex) 
            {
                Response.Write("<script language=javascript>alert('Protocol Exception. Time elapsed: " + sw.ElapsedMilliseconds.ToString() + " milliseconds." + "');</script>");
                return;
            }
            System.Threading.Thread.Sleep(5000);//5s
            asynLabel.Text = "Main Thread Execution Time :" + sw.ElapsedMilliseconds.ToString() + " Milliseconds";
        }

        void proxy_FlushAndSleep1MinCompleted(object sender, FlushAndSleep1MinCompletedEventArgs e)
        {
            asynRtLabel.Text = "Call ended.";
        }

        void proxy_JustSleep1MinCompleted(object sender, JustSleep1MinCompletedEventArgs e)
        {
            asynRtLabel.Text = e.Result;
        }
    }
}