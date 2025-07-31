using MoGYSD.ViewModels;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing;

namespace MoGYSD.Services;

public interface IExcelService
{   
    DataTable ToDataTable<T>(IEnumerable<T> data);

    StateViewModel<DataTable> ImportToDataTable(string filePath, string sheetName, int startRow);

    StateViewModel<DataTable> ImportToDataTable(int uniqueId, string filePath,
        string sheetName, int startRow);

    StateViewModel<DataTable> ExcelToDataTable(string filePath, string sheetName, int startRow);
    StateViewModel<DataTable> ExcelToDataTable(string filePath, int? startRow = 1);
    DataTable ConvertCsVtoDataTable(string strFilePath);

    string Shuffle();

    string GetPath(string directoryName = "");

    DataTable ToDataTable2<T>(List<T> items);


    StateViewModel<byte[]> Reports(DataTable dsResults, string _FileName);
}
public class ExcelService : IExcelService
{
    public StateViewModel<byte[]> Reports(DataTable dsResults, string wsname)
    {
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        StateViewModel<byte[]> _state = new StateViewModel<byte[]>();
        byte[] fileContents;
        try
        {
            try
            {
                ExcelPackage excel = new ExcelPackage();
                var ws = excel.Workbook.Worksheets.Add(wsname);
                excel.Workbook.Protection.LockStructure = false;
                ws.Protection.IsProtected = false;

                ws.Cells["A1"].LoadFromDataTable(dsResults, true);

                //AllocationTemplate should not be protected. Also hide columns 1 and 2
                if (wsname == "AllocationTemplate")
                {
                    ws.Column(1).Hidden = true;
                    ws.Column(2).Hidden = true;
                    ws.Column(3).Hidden = true;
                    ws.Column(4).Hidden = true;

                    for (int i = 1; i <= dsResults.Rows.Count + 2; i++)
                    {
                        int rowNumber = i + 1;
                        ws.Cells["I" + rowNumber].Style.Locked = false;
                        ws.Cells["J" + rowNumber].Style.Locked = false;
                        ws.Cells["K" + rowNumber].Style.Locked = false;
                        ws.Cells["L" + rowNumber].Style.Locked = false;
                        ws.Cells["M" + rowNumber].Style.Locked = false;
                        ws.Cells["N" + rowNumber].Style.Locked = false;
                        ws.Cells["O" + rowNumber].Style.Locked = false;
                        ws.Cells["P" + rowNumber].Style.Locked = false;
                        ws.Cells["Q" + rowNumber].Style.Locked = false;
                        ws.Cells["R" + rowNumber].Style.Locked = false;
                        ws.Cells["S" + rowNumber].Style.Locked = false;
                        ws.Cells["T" + rowNumber].Style.Locked = false;
                    }

                    Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#E5E3E3");
                    using (var range = ws.Cells[2, 1, dsResults.Rows.Count + 1, 8])  //Address "A1:A5"
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(colFromHex);
                        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                }
                else
                {
                    Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#E5E3E3");
                    using (var range = ws.Cells[2, 1, dsResults.Rows.Count + 1, dsResults.Columns.Count])  //Address "A1:A5"
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(colFromHex);

                        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                }

                using (var range = ws.Cells[1, 1, 1, dsResults.Columns.Count])  //Address "A1:A5"
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Black);
                    range.Style.Font.Color.SetColor(Color.White);
                }

                for (int col = 1; col <= dsResults.Columns.Count; col++)
                {
                    ws.Column(col).AutoFit(0);
                }

                fileContents = excel.GetAsByteArray();

                if (fileContents == null || fileContents.Length == 0)
                {
                    _state.Code = 500;
                    _state.Msg = "Nothing to show!";

                    return _state;
                }
                //Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#E5E3E3");
                //using (var range = ws.Cells[3, 1, dsResults.Count + 2, 11])  //Address "A1:A5"
                //{
                //    range.Style.Font.Bold = true;
                //    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                //    range.Style.Fill.BackgroundColor.SetColor(colFromHex);

                //    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                //    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                //    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                //    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                //}
                //string myPath = getPath("Enrolment");
                //myPath = myPath + "\\" + _FileName;
                //excel.SaveAs(new FileInfo(myPath));
            }
            catch (SEHException ee)
            {
                _state.Code = 500;
                _state.Msg = ee.Message;

                return _state;
            }
            catch (Exception ee)
            {
                _state.Code = 500;
                _state.Msg = ee.Message;

                return _state;
            }

            if (dsResults != null)
            {
                _state.Code = 200;
                _state.Msg = "Success";

                _state.Data = fileContents;
            }
            else
            {
                _state.Code = 300;

                _state.Msg = "No Record Found";
            }
        }
        catch (Exception msg)
        {
            _state.Code = 500;

            _state.Msg = msg.Message;
        }

        return _state;
    }

    public DataTable ToDataTable<T>(IEnumerable<T> data)
    {
        var propertyInfos = typeof(T).GetProperties();
        var table = new DataTable();

        foreach (var property in propertyInfos)
        {
            table.Columns.Add(property.Name);
        }

        foreach (var item in data)
        {
            var newRow = table.NewRow();
            var column = 0;

            foreach (var property in propertyInfos)
            {
                var value = property.PropertyType.IsEnum
                    ? Convert.ChangeType(property.GetValue(item, null),
                        Enum.GetUnderlyingType(property.PropertyType))
                    : property.GetValue(item, null);

                newRow[column] = value;

                column++;
            }

            table.Rows.Add(newRow);
        }

        return table;
    }

    public StateViewModel<DataTable> ImportToDataTable(string filePath, string sheetName, int startRow)
    {
        var state = new StateViewModel<DataTable>();
        var dt = new DataTable();
        var fi = new FileInfo(filePath);
        // Check if the file exists
        try
        {
            if (!fi.Exists)
                throw new Exception("File " + filePath + " Does Not Exists");
            using var xlPackage = new ExcelPackage(fi);
            var worksheet = xlPackage.Workbook.Worksheets[sheetName];

            var startCell = worksheet.Dimension.Start;
            var endCell = worksheet.Dimension.End;

            foreach (var firstRowCell in worksheet.Cells[startRow, 1, 1, worksheet.Dimension.End.Column])
                dt.Columns.Add(firstRowCell.Text);

            startRow = startRow + 1;
            // place all the data into DataTable
            for (var row = startRow; row <= endCell.Row; row++)
            {
                var dr = dt.NewRow();
                var x = 0;
                for (var col = startCell.Column; col <= endCell.Column; col++)
                {
                    dr[x++] = worksheet.Cells[row, col].Value;
                }

                dt.Rows.Add(dr);
            }
        }
        catch (Exception ee)
        {
            state.Code = 500;

            state.Msg = ee.Message;

            return state;
        }

        state.Code = 200;

        state.Msg = "Success";

        state.Data = dt;

        return state;
    }

    public StateViewModel<DataTable> ImportToDataTable(int uniqueId, string filePath,
            string sheetName, int startRow)
    {
        var state = new StateViewModel<DataTable>();
        var dt = new DataTable();
        var fi = new FileInfo(filePath);
        // Check if the file exists
        try
        {
            if (!fi.Exists)
                throw new Exception("File " + filePath + " Does Not Exists");
            //dt = ConvertCSVtoDataTable(FilePath);
            using (var xlPackage = new ExcelPackage(fi))
            {
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets[sheetName];

                // Fetch the WorkSheet size
                var startCell = worksheet.Dimension.Start;
                var endCell = worksheet.Dimension.End;

                foreach (var firstRowCell in worksheet.Cells[startRow, 1, 1, worksheet.Dimension.End.Column])
                    dt.Columns.Add(firstRowCell.Text);

                startRow = startRow + 1;
                // place all the data into DataTable
                for (var row = startRow; row <= endCell.Row; row++)
                {
                    var dr = dt.NewRow();
                    var x = 0;
                    for (var col = startCell.Column; col <= endCell.Column; col++)
                    {
                        dr[x++] = worksheet.Cells[row, col].Value;
                    }

                    dt.Rows.Add(dr);
                }
            }

            var headerId = new DataColumn("HeaderID", typeof(Int16)) { DefaultValue = uniqueId };
            dt.Columns.Add(headerId);
        }
        catch (Exception ee)
        {
            state.Code = 500;

            state.Msg = ee.Message;

            return state;
        }

        //return dt;
        state.Code = 200;

        state.Msg = "Success";

        state.Data = dt;

        return state;
    }

    public StateViewModel<DataTable> ExcelToDataTable(string filePath, string sheetName, int startRow)
    {
        var state = new StateViewModel<DataTable>();
        var dt = new DataTable();
        var fi = new FileInfo(filePath);
        // Check if the file exists
        try
        {
            if (!fi.Exists)
                throw new Exception("File " + filePath + " Does Not Exists");
            //dt = ConvertCSVtoDataTable(FilePath);
            using var xlPackage = new ExcelPackage(fi);
            // get the first worksheet in the workbook
            var worksheet = xlPackage.Workbook.Worksheets[sheetName];

            // Fetch the WorkSheet size
            var startCell = worksheet.Dimension.Start;
            var endCell = worksheet.Dimension.End;

            foreach (var firstRowCell in worksheet.Cells[startRow, 1, 1, worksheet.Dimension.End.Column])
                dt.Columns.Add(firstRowCell.Text);

            startRow = startRow + 1;
            // place all the data into DataTable
            for (var row = startRow; row <= endCell.Row; row++)
            {
                var dr = dt.NewRow();
                var x = 0;
                for (var col = startCell.Column; col <= endCell.Column; col++)
                {
                    dr[x++] = worksheet.Cells[row, col].Value;
                }
                dt.Rows.Add(dr);
            }
        }
        catch (Exception ee)
        {
            state.Code = 500;

            state.Msg = ee.Message;

            return state;
        }

        if (true)
        {
            state.Code = 200;

            state.Msg = "Success";

            state.Data = dt;
        }

        return state;
    }
    public StateViewModel<DataTable> ExcelToDataTable(string filePath, int? startRow = 1)
    {
        var state = new StateViewModel<DataTable>();
        var dt = new DataTable();
        var fi = new FileInfo(filePath);
        // Check if the file exists
        try
        {
            if (!fi.Exists)
                throw new Exception("File " + filePath + " Does Not Exists");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var xlPackage = new ExcelPackage(fi);
            // get the first worksheet in the workbook
            var worksheet = xlPackage.Workbook.Worksheets[0];

            // Fetch the WorkSheet size
            var startCell = worksheet.Dimension.Start;
            var endCell = worksheet.Dimension.End;

            foreach (var firstRowCell in worksheet.Cells[startRow ?? 1, 1, 1, worksheet.Dimension.End.Column])
                dt.Columns.Add(firstRowCell.Text);

            startRow = startRow + 1;
            // place all the data into DataTable
            for (var row = startRow ?? 1; row <= endCell.Row; row++)
            {
                var dr = dt.NewRow();
                var x = 0;
                for (var col = startCell.Column; col <= endCell.Column; col++)
                {
                    dr[x++] = worksheet.Cells[row, col].Value;
                }
                dt.Rows.Add(dr);
            }
        }
        catch (Exception ee)
        {
            state.Code = 500;
            state.Msg = ee.Message;
            // ElmahExtensions.RaiseError(ee);
            return state;
        }

        if (true)
        {
            state.Code = 200;
            state.Msg = "Success";
            state.Data = dt;
        }

        return state;
    }

    public DataTable ConvertCsVtoDataTable(string strFilePath)
    {
        var dt = new DataTable();
        using (var sr = new StreamReader(strFilePath))
        {
            var headers = sr.ReadLine()?.Split(',');
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    dt.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    var rows = sr.ReadLine()?.Split(',');
                    var dr = dt.NewRow();
                    for (var i = 0; i < headers.Length; i++)
                    {
                        if (rows != null) dr[i] = rows[i];
                    }

                    dt.Rows.Add(dr);
                }
            }
        }

        return dt;
    }

    public string Shuffle()
    {
        var tempFilename = Guid.NewGuid().ToString() + DateTime.Now.ToFileTime().ToString();

        var array = tempFilename.ToCharArray();
        var rng = new Random();
        var n = array.Length;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            var value = array[k];
            array[k] = array[n];
            array[n] = value;
        }

        return new string(array);
    }

    /// <summary>
    /// Convert a List{T} to a DataTable.
    /// </summary>
    public DataTable ToDataTable2<T>(List<T> items)
    {
        var tb = new DataTable(typeof(T).Name);

        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in props)
        {
            var t = GetCoreType(prop.PropertyType);
            tb.Columns.Add(prop.Name, t);
        }

        foreach (var item in items)
        {
            var values = new object[props.Length];

            for (var i = 0; i < props.Length; i++)
            {
                values[i] = props[i].GetValue(item, null);
            }

            tb.Rows.Add(values);
        }

        return tb;
    }

    /// <summary>
    /// Determine of specified type is nullable
    /// </summary>
    private static bool IsNullable(Type t)
    {
        return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
    }

    /// <summary>
    /// Return underlying type if type is Nullable otherwise return the type
    /// </summary>
    private static Type GetCoreType(Type t)
    {
        if (t != null && IsNullable(t))
        {
            if (!t.IsValueType)
            {
                return t;
            }
            else
            {
                return Nullable.GetUnderlyingType(t);
            }
        }
        else
        {
            return t;
        }
    }

    public string GetPath(string directoryName = "")
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", directoryName);

        var exists = Directory.Exists(path);

        if (!exists)
            Directory.CreateDirectory(path);

        return path;
    }
}
