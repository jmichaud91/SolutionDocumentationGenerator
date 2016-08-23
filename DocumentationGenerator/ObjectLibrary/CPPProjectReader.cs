using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ObjectLibrary
{
   public class CPPProjectReader : ProjectReader
   {
      private const string ITEM_GROUP = "itemgroup";
      private const string START_HEADERS = "clinclude";
      private const string START_CPP = "clcompile";
      public event ProjectReadDelegate ProjectReadEvent;

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
                     string currLine = projStreamReader.ReadLine().Trim(removedCharacters);

                     if (currLine.ToLower().StartsWith(ITEM_GROUP))
                     {
                        currLine = projStreamReader.ReadLine().Trim(removedCharacters);

                        if (currLine.ToLower().StartsWith(START_HEADERS))
                        {
                           string[] splittedLine = currLine.Split('=');
                           if (splittedLine.Length >= 2)
                           {
                              string headerFileRelPath = splittedLine[1].Trim(illegalCharacters);
                              string headerFileAbsPath = Path.Combine(currDirectoryPath, headerFileRelPath);

                              FileInfo f = new FileInfo(headerFileAbsPath);
                              System.Diagnostics.Debug.WriteLine(f.FullName);
                           }
                        }
                        else if (currLine.ToLower().StartsWith(START_CPP))
                        {
                           string[] splittedLine = currLine.Split('=');
                           if (splittedLine.Length >= 2)
                           {
                              string headerFileRelPath = splittedLine[1].Trim(illegalCharacters);
                              string headerFileAbsPath = Path.Combine(currDirectoryPath, headerFileRelPath);

                              FileInfo f = new FileInfo(headerFileAbsPath);
                              System.Diagnostics.Debug.WriteLine(f.FullName);
                           }
                        }
                     }
                  }
               }

               done = true;

               ProjectReadEvent(m_CurrentProject);
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
