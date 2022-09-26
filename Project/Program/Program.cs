using System;
using System.Threading;
using System.Windows.Forms;

namespace Project
{
    static class Program
    {
        //static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    MessageBox.Show( "Exception");
        //}

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Please Contact Support \n +962787878492");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {
                Logger.LogExceptionWritter(eventArgs.Exception);
            };

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            bool applicationCountOne = false;

            Logger.LogTransactionWritter("User is Trying To create instance of the Application");
            using (Mutex mutex = new Mutex(true, "Application2", out applicationCountOne))
            {

                if (applicationCountOne)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Logger.LogTransactionWritter("Application Started");

                    Application.Run(new LoginPageForm());
                    Logger.LogTransactionWritter("Application Closed\n\n");
                }
                else
                {
                    Logger.LogTransactionWritter("Application is Alaready Running");
                    MessageBox.Show("Application Is Already Runing");
                }
            }
        }
    }
}
