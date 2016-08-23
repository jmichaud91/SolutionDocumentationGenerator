using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary
{
   public class ProjectReader
   {
      protected char[] illegalCharacters = { '\"', '/', '"', ' ' };
      protected char[] removedCharacters = { '<', '>', ' ', '"', '/' };
      protected Project m_CurrentProject = null;
      public delegate void ProjectReadDelegate(Project theProject);

      public ProjectReader(Project theProject)
      {
         m_CurrentProject = theProject;
      }

      public virtual bool ReadProject()
      {
         return false;
      }
   }
}
