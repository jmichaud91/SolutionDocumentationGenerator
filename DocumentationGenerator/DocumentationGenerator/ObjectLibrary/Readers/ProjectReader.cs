using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Readers
{
   public class ProjectReader
   {
      protected char[] illegalCharacters = { '\"', '/', '"', ' ' };
      protected char[] removedCharacters = { '<', '>', ' ', '"', '/' };
      protected Project m_CurrentProject = null;
      public delegate void ProjectReadDelegate(Project theProject);
      public event ProjectReadDelegate ProjectReadEvent;

      public ProjectReader(Project theProject)
      {
         m_CurrentProject = theProject;
      }

      protected void RaiseProjectReadEvent(Project theProject)
      {
         if (ProjectReadEvent != null)
         {
            ProjectReadEvent(theProject);
         }
      }

      public virtual bool ReadProject()
      {
         return false;
      }
   }
}
