using ExcelDataReader;
using Microsoft.CodeAnalysis;
using SwagLab_Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLab_Tests.Utilities
{
    
    internal class ExcelUtils
    {
        public static List<AddToCartAndCheckout> ReadExcelData(string excelFilePath,string sheetName)
        {
            List<AddToCartAndCheckout> addToCartAndCheckouts = new List<AddToCartAndCheckout>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

            {

                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()

                    {

                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()

                        {

                            UseHeaderRow = true,

                        }

                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)

                    {

                        foreach (DataRow row in dataTable.Rows)

                        {

                            AddToCartAndCheckout excelData = new AddToCartAndCheckout

                            {

                               UserName = GetValueOrDefault(row,"username"),
                               Password = GetValueOrDefault(row,"password"),
                               InvalidUsername = GetValueOrDefault(row,"invalidusername"),
                               InvalidPassword = GetValueOrDefault(row,"invalidpassword"),
                               Position = GetValueOrDefault(row,"position"),
                               FirstName = GetValueOrDefault(row,"firstname"),
                               LastName = GetValueOrDefault(row,"lastname"),
                               ZipCode = GetValueOrDefault(row,"zipcode"),
                                

                                

                            };



                            addToCartAndCheckouts.Add(excelData);

                        }

                    }

                    else

                    {

                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");

                    }

                }

            }

            return addToCartAndCheckouts;

        }

        static string GetValueOrDefault(DataRow row, string columnName)

        {

            Console.WriteLine(row + "  " + columnName);

            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;

        }

    
    }
}


