using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ObjectLibrary.Readers
{
   public class CPPProjectReader : ProjectReader
   {
      private const string ITEM_GROUP = "itemgroup";
      private const string START_HEADERS = "clinclude";
      private const string START_CPP = "clcompile";
      private const string START_DEF = "none include";
      private const string START_RC = "resourcecompile include";   

      public CPPProjectReader(Project theProject)
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

                     FileInfo f = null;
                     if (trimedLine.ToLower().StartsWith(START_HEADERS) || trimedLine.ToLower().StartsWith(START_CPP) || trimedLine.ToLower().StartsWith(START_DEF) || trimedLine.ToLower().StartsWith(START_RC))
                     {
                        string[] splittedLine = trimedLine.Split('=');
                        if (splittedLine.Length >= 2)
                        {
                           string headerFileRelPath = splittedLine[1].Trim(illegalCharacters);
                           string headerFileAbsPath = Path.Combine(currDirectoryPath, headerFileRelPath);

                           f = new FileInfo(headerFileAbsPath);
                           System.Diagnostics.Debug.WriteLine(f.FullName);

                           if (f != null)
                           {
                              Objects nextAddedCPPObject = new Objects(f.Name, f.FullName, Objects.ObjectType.Class);
                              m_CurrentProject.Objects.Add(nextAddedCPPObject);
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
