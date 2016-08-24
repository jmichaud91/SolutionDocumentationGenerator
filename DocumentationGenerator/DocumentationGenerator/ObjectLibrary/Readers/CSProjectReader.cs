using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ObjectLibrary.Readers
{
   public class CSProjectReader : ProjectReader
   {
      private const string ITEM_GROUP = "itemgroup";
      private const string START_CLASSES = "compile";

      public CSProjectReader(Project theProject)
         : base(theProject)
      { }

      public override bool ReadProject()
      {
         bool done = false;

         if (File.Exists(m_CurrentProject.ProjectAbsolutePath))
         {
            try
            {
               string currDirectoryPath = Directory.GetParent(m_CurrentProject.ProjectAbsolutePath).FullName;

               using (StreamReader projStreamReader = new StreamReader(m_CurrentProject.ProjectAbsolutePath))
               {
                  while (!projStreamReader.EndOfStream)
                  {
                     string currLine = projStreamReader.ReadLine();
                     string trimedLine = currLine.Trim(removedCharacters);

                     if (trimedLine.ToLower().StartsWith(START_CLASSES))
                     {
                        string[] splittedLine = trimedLine.Split('=');
                        if (splittedLine.Length >= 2)
                        {
                           string headerFileRelPath = splittedLine[1].Trim(illegalCharacters);
                           string headerFileAbsPath = Path.Combine(currDirectoryPath, headerFileRelPath);

                           FileInfo f = new FileInfo(headerFileAbsPath);
                           System.Diagnostics.Debug.WriteLine(f.FullName);

                           if (f.Extension.EndsWith(".cs"))
                           {
                              Objects nextAddedCSObject = new Objects(f.Name, f.FullName, Objects.ObjectType.Class);
                              m_CurrentProject.Objects.Add(nextAddedCSObject);
                           }
                        }
                     }
                  }
               }

               done = true;
               RaiseProjectReadEvent(m_CurrentProject);
            }
            catch (Exception ex)
            {
               done = false;
               System.Diagnostics.Debug.WriteLine("Error while reading CPP project : " + m_CurrentProject.ProjectName + ".  Error : " + ex.Message);
            }
         }

         return done;
      }
   }
}
