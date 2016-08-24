using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary
{
   /// <summary>
   /// Represent a class.  Since there are differences between C#, VB and C++ objects, this class will serve as a parent object, containing common stuff.
   /// </summary>
   public class Objects
   {
      public enum ObjectType
      {
         Class = 0,
         Structure = 1,
         Enum = 2
      }

      protected ObjectType m_Type;
      protected string m_Name;
      protected string m_AbsolutePath;
      
      public string AbsolutePath
      {
         get { return m_AbsolutePath; }
         set { m_AbsolutePath = value; }
      }

      public string Name
      {
         get { return m_Name; }
         set { m_Name = value; }
      }

      public ObjectType ObjType
      {
         get { return m_Type; }
         set { m_Type = value; }
      }

      public Objects(string name, string absPath, ObjectType type)
      {
         this.m_Name = name;
         this.m_AbsolutePath = absPath;
         this.m_Type = type;
      }

      public string ToString(bool detailed = false)
      {
         string retValue = string.Empty;

         if (detailed)
         {
            retValue = string.Format("{0} - {1} - {2}", m_Name, m_AbsolutePath, m_Type.ToString());
         }

         return retValue;
      }

      public override string ToString()
      {
         return m_Name;
      }
   }
}

