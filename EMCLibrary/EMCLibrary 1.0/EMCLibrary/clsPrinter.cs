/*
 *  LPrinter - A simple line printer class in C#
 *  ============================================
 *  
 *  Written by Antonino Porcino, iz8bly@yahoo.it
 *
 *  26-sep-2008, public domain.
 *
 * 
 *  some useful print codes:
 *  ========================
 *    12 = FF (form feed)
 *    14 = enlarged on
 *    20 = enlarged off
 *    15 = compress on
 *    18 = compress off
 *    ESC + "E" = bold on
 *    ESC + "F" = bold off
 *    
 * 
 */


using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;



namespace EMCLibrary
{


    public class clsPrinter
    {
        //definição de variaveis para impressão
        public string printerSextos = string.Format("{0}{1}",Convert.ToChar(27),Convert.ToChar(50));
        public string printerOitavos = string.Format("{0}{1}", Convert.ToChar(27), Convert.ToChar(48));
        public string printerCompactada = string.Format("{0}", Convert.ToChar(15));
        public string PrinterDescompactada = string.Format("{0}", Convert.ToChar(18));

        //Pulo de linha Windows
        string sCrLf = "\r\n";

        //Pulo de linha no Linux
        //string sCrLf = "\n";

        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        
        /*=================================================*/
                 
        public clsPrinter()
        {
      
        }
            
        public ArrayList installedPrinters()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            ArrayList aPrinter = new ArrayList();
            

            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                aPrinter.Add(new popCombo(pkInstalledPrinters,i.ToString()));
            }

            return aPrinter;
        }

        public string SelecionarImpressora()
        {
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog())
            {
                return pd.PrinterSettings.PrinterName;
            }
            else
            {
                return "";
            }
        }

        public bool ValidarImpressora(string lsImpressora)
        {
            //Initialize the PrinterSettings object
            IEnumerator se = PrinterSettings.InstalledPrinters.GetEnumerator();
            bool lbFound = false;

            // Tenta localizar a impressora
            while (se.MoveNext())
            {
                if (se.Current.ToString().ToUpper() == lsImpressora.ToUpper())
                {
                    lbFound = true;
                }
            }

            // Retorna se encontrou ou não
            return lbFound;
        }
  
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            PrinterSettings ps = new PrinterSettings();

            IntPtr hPrinter = IntPtr.Zero;  // The printer handle.
            Int32 dwError = default(Int32); // Last error - in case there was trouble.
            Int32 dwWritten = default(Int32);  // The number of bytes written by WritePrinter().
            bool bSuccess = false;    // Your success code.

            // Set up the DOCINFO structure.
            DOCINFOA MyDocInfo = new DOCINFOA();
            MyDocInfo.pDocName = "JLMTech Software";
            MyDocInfo.pOutputFile = null;
            MyDocInfo.pDataType = "RAW";  
            
            ps.PrinterName = szPrinterName;


            if (OpenPrinter(ps.PrinterName, out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, MyDocInfo))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your printer-specific bytes to the printer.
                        
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public bool SendStringToPrinter(string sPrinterName, string sString, int pSalto)
        {
            bool functionReturnValue = false;
            IntPtr pBytes = default(IntPtr);
            Int32 dwCount = default(Int32);
            string sSalto = "";

            //saltando a quantidade de linhas passado como parametro
            while (pSalto > 0)
            {
                //adicionando o conteudo a variavel
                sSalto += sCrLf;
                //subtraindo 1 na quantidade de saltos
                pSalto -= 1;
            }

            //adicionando o salto a string
            sString = sSalto + sString;

            //obtendo a quantidade de caracteres da string
            dwCount = sString.Length;

            //considera que a impressora esteja esperando um texto ANSI. (converte o texto para ANSI)
            pBytes = Marshal.StringToCoTaskMemAnsi(sString);

            //enviando o texto convertido para a impressora
            functionReturnValue = SendBytesToPrinter(sPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return functionReturnValue;

        }

    }
}
