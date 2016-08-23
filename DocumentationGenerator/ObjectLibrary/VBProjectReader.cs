using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ObjectLibrary
{
   public class VBProjectReader : ProjectReader
   {
      private const string ITEM_GROUP = "itemgroup";
      private const string START_CLASSES = "compile";
      public event ProjectReadDelegate ProjectReadEvent;

      public VBProjectReader(Project theProject)
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

                        if (currLine.ToLower().StartsWith(START_CLASSES))
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
