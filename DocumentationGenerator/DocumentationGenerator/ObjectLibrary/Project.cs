using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary
{
   public class Project
   {
      public enum LangageType
      {
         CPP = 0,
         CS = 1,
         VB = 2
      }

      private string m_GUID;
      private string m_ProjectName;
      private string m_ProjectAbstractPath;
      private string m_ID;

      private List<Objects> m_Objects;
      private LangageType m_UsedLangage;

      public LangageType UsedLangage
      {
         get { return m_UsedLangage; }
         set { m_UsedLangage = value; }
      }
      
      public List<Objects> Objects
      {
         get { return m_Objects; }
         set { m_Objects = value; }
      }

      public string GUID
      {
         get { return m_GUID; }
      }

      public string ProjectName
      {
         get { return m_ProjectName; }
      }

      public string ProjectAbsolutePath
      {
         get { return m_ProjectAbstractPath; }
      }
      public Project(string guid, string projectName, string projectRelativePath, LangageType usedLangage)
      {
         this.m_GUID = guid;
         this.m_ProjectName = projectName;
         this.m_ProjectAbstractPath = projectRelativePath;
         this.m_UsedLangage = usedLangage;
         this.m_Objects = new List<Objects>();
      }

      public override string ToString()
      {
         string retValue = string.Empty;

         retValue = string.Format("{0} - {1}", m_ProjectName, m_ProjectAbstractPath);

         return retValue;
      }
   }
}
