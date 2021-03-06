﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ZuegerAdressbook.Service
{
    public class MessageDialogService : IMessageDialogService
    {
        public bool OpenConfirmationDialog(string title, string text)
        {
            var result = MessageBox.Show(text, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        public string OpenFileDialog()
        {
            string filename = null;

            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            var result = fileDialog.ShowDialog();
            if (result == true)
            {
                // Open document 
                filename = fileDialog.FileName;
            }

            return filename;
        }

        public string OpenExcelFileDialog()
        {
            string filename = null;

            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = "Excel Datei (*.xlsx)|*.xlsx";

            var result = fileDialog.ShowDialog();
            if (result == true)
            {
                // Open document 
                filename = fileDialog.FileName;
            }

            return filename;
        }

        public string SaveExcelFileDialog()
        {
            string filename = null;

            Microsoft.Win32.SaveFileDialog fileDialog = new Microsoft.Win32.SaveFileDialog();
            fileDialog.Filter = "Excel Datei (*.xlsx)|*.xlsx";

            var result = fileDialog.ShowDialog();
            if (result == true)
            {
                filename = fileDialog.FileName;
            }

            return filename;
        }

        public void OpenInformationDialog(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void OpenErrorDialog(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void OpenPrintDialog(FlowDocument document, string description)
        {
            PrintDialog printDialog = new PrintDialog();

            IDocumentPaginatorSource dps = document;
            if (printDialog.ShowDialog() == true)
            {
                document.PageHeight = printDialog.PrintableAreaHeight;
                document.PageWidth = printDialog.PrintableAreaWidth;
                document.ColumnGap = 0;
                document.ColumnWidth = printDialog.PrintableAreaWidth;
                printDialog.PrintDocument(dps.DocumentPaginator, description);
            }
        }
    }
}
