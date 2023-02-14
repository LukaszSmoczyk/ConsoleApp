using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp.Model;

namespace ConsoleApp
{

    public class DataReader
    {

        public List<ImportedObject> ImportAndOrganizeData(string fileToImport)
        {

            var importedLines = LoadData(fileToImport);

            var objectsList = SerializeAndOrganizeData(importedLines);

            return objectsList;
        }



        private List<string> LoadData(string fileToImport)
        {
            var importedLines = new List<string>();
            using (var stream = new StreamReader(fileToImport))
            {
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    importedLines.Add(line);
                }

            }

            return importedLines;
        }

        private List<ImportedObject> SerializeAndOrganizeData(List<string> importedLines)
        {
            List<ImportedObject> importedObjects = new List<ImportedObject>();

            for (int i = 0; i < importedLines.Count; i++)
            {
                var importedLine = importedLines[i];
                if(!string.IsNullOrEmpty(importedLine))
                {
                    var values = importedLine.Split(';');
                    var importedObject = new ImportedObject();
                    importedObject.Type = values[0] ?? null;
                    importedObject.Name = values[1] ?? null;
                    importedObject.Schema = values[2] ?? null;
                    importedObject.ParentName = values[3] ?? null;
                    importedObject.ParentType = values[4] ?? null;
                    importedObject.DataType = values[5] ?? null;
                    if (values.Length < 6)
                        importedObject.IsNullable = "0";
                    importedObjects.Add(importedObject);
                }
            }

            // clear and correct imported data
            foreach (var importedObject in importedObjects)
            {
                importedObject.Type = importedObject.Type.Trim().Replace(" ", "").Replace(Environment.NewLine, "").ToUpper();
                importedObject.Name = importedObject.Name.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
                importedObject.Schema = importedObject.Schema.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
                importedObject.ParentName = importedObject.ParentName.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
                importedObject.ParentType = importedObject.ParentType.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
            }

            // assign number of children
            for (int i = 0; i < importedObjects.Count(); i++)
            {
                var importedObject = importedObjects.ToArray()[i];
                foreach (var impObj in importedObjects)
                {
                    if (impObj.ParentType == importedObject.Type)
                    {
                        if (impObj.ParentName == importedObject.Name)
                        {
                            importedObject.NumberOfChildren++;
                        }
                    }
                }
            }

            return importedObjects;
        }
    }
}
