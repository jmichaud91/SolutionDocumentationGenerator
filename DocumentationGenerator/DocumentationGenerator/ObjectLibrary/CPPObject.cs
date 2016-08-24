using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary
{
   class CPPObject : Objects
   {
      public enum FileType
      {
         Header = 0,
         CPP = 1
      }

      private FileType m_FileType;
      private List<Member> m_Members;
      private List<Function> m_Functions;

      public List<Function> Functions
      {
         get { return m_Functions; }
         set { m_Functions = value; }
      }

      public List<Member> Members
      {
         get { return m_Members; }
         set { m_Members = value; }
      }

      public FileType FType
      {
         get { return m_FileType; }
         set { m_FileType = value; }
      }

      public CPPObject(string name, string absPath, Objects.ObjectType objType, FileType fileType) 
         : base(name, absPath, objType)
      {
         this.m_FileType = fileType;

         m_Members = new List<Member>();
         m_Functions = new List<Function>();
      }
   }
}
