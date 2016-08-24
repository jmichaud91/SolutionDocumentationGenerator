using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Readers
{
   public static class ReaderFactory
   {
      public static ProjectReader BuildReader(Project theProject)
      {
         ProjectReader returnedReader = null;
         switch (theProject.UsedLangage)
         {
            case Project.LangageType.CPP:
               returnedReader = new CPPProjectReader(theProject);
               break;
            case Project.LangageType.CS:
               returnedReader = new CSProjectReader(theProject);
               break;
            case Project.LangageType.VB:
               returnedReader = new VBProjectReader(theProject);
               break;
            default:
               returnedReader = null;
               break;
         }

         return returnedReader;
      }
   }
}
