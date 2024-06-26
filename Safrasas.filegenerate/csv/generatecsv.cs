using Aspose.Cells;

namespace Safrasas.filegenerate
{
    internal class ExXlsxSaveOptions
    {
        public string FileName = "C:\\Test\\test.csv";
        public void CompressXlsx()
        {
            TxtLoadOptions loadOptions = new TxtLoadOptions(LoadFormat.Csv);
            loadOptions.ConvertNumericData = false;

            Workbook workbook = new Workbook(); 
            Worksheet sheet = workbook.Worksheets[0];

            object[,] dataArray = sheet.Cells.ExportArray(0, 0, sheet.Cells.MaxDataRow + 1, sheet.Cells.MaxDataColumn + 1);

            if (dataArray != null)
            {
                Console.WriteLine("Array Length " + dataArray.Length);
            }
            Worksheet sheet2 = workbook.Worksheets[workbook.Worksheets.Add()];
            sheet2.Cells.ImportTwoDimensionArray(dataArray, 0, 0);
            workbook.Save(FileName);

        }
    }
}