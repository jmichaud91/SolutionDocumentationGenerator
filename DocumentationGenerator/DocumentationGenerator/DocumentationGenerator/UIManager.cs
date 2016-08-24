using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using ObjectLibrary;
using ObjectLibrary.Readers;

namespace DocumentationGenerator
{
   class UIManager : IDisposable
   {
      private const string DOC_THREAD_NAME = "Documentation Generation Thread";
      private const string DOC_GEN_STEP_DONE_STR = "DocumentationGenerationIsDoneEvent";

      private Thread m_DocumentationGenerationThread = null;
      private CancellationTokenSource m_CancellationSource = null;
      private CancellationToken m_CancellationToken;

      private int m_NumberOfProjectFound;

      public int NumberOfProjectFound
      {
         get { return m_NumberOfProjectFound; }
      }

      public delegate void DocumentationGenerationStepDone(int stepPercentageValue, string stepName);
      public event DocumentationGenerationStepDone DocumentationGenerationStepDoneEvent;

      public delegate void ProjectWasReadDelegate(Project theProject);
      public event ProjectWasReadDelegate ProjectWasReadEvent;

      private FileInfo m_SolutionFile;

      private List<Project> m_SolutionProjects;

      public FileInfo SolutionFile
      {
         get { return m_SolutionFile; }
      }


      public UIManager()
      {
         Initialize();
      }

      private void Initialize()
      {
         m_SolutionProjects = new List<Project>();
      }

      public bool StartDocumentationGeneration()
      {
         bool success = false;

         try
         {
            // Initialize cancellation token which will be use to stop the thread cleanly.
            InitializeCancellationToken();
            // Initialize and start the documentation generation thread
            m_DocumentationGenerationThread = new Thread(DocumentationGenerationThreadProc);
            m_DocumentationGenerationThread.Name = DOC_THREAD_NAME;
            m_DocumentationGenerationThread.Start();

            success = true;
         }
         catch (Exception ex)
         {
            success = false;
         }

         return success;
      }

      private bool InitializeCancellationToken()
      {
         bool success = false;

         try
         {
            if (m_CancellationToken != null && m_CancellationSource != null)
            {
               m_CancellationSource = new CancellationTokenSource();
               m_CancellationToken = m_CancellationSource.Token;
               success = true;
            }
         }
         catch (Exception ex)
         {
            success = false;
         }

         return success;
      }

      private void DocumentationGenerationThreadProc()
      {
         RaiseDocumentationGenerationStepDoneEvent(1, "Reading Solution...");
         List<string> mainSolutionText = new List<string>();

         using (StreamReader solStreamReader = new StreamReader(m_SolutionFile.FullName))
         {
            while (!solStreamReader.EndOfStream)
            {
               mainSolutionText.Add(solStreamReader.ReadLine());
            }
         }

         CreateProjects(mainSolutionText);
         InitializeProjectsObjects();
      }

      private const string PROJECT_HEADER = "project";

      private void InitializeProjectsObjects()
      {
         RaiseDocumentationGenerationStepDoneEvent(1, "Creating projects' objects...");

         foreach (Project proj in m_SolutionProjects)
         {
            if (File.Exists(proj.ProjectAbsolutePath))
            {
               ProjectReader currProjReader = ReaderFactory.BuildReader(proj);
               currProjReader.ProjectReadEvent += currProjReader_ProjectReadEvent;

               if (currProjReader != null)
               {
                  if(!currProjReader.ReadProject())
                  {

                  }

                  //if (currProjReader.GetType() == typeof(CPPProjectReader))
                  //{
                  //   ((CPPProjectReader)currProjReader).ProjectReadEvent += currProjReader_ProjectReadEvent;
                  //}
                  //else if (currProjReader.GetType() == typeof(CSProjectReader))
                  //{
                  //   ((CSProjectReader)currProjReader).ProjectReadEvent += currProjReader_ProjectReadEvent;
                  //}
                  //else if (currProjReader.GetType() == typeof(VBProjectReader))
                  //{
                  //   ((VBProjectReader)currProjReader).ProjectReadEvent += currProjReader_ProjectReadEvent;
                  //}
               }
            }
         }

         RaiseDocumentationGenerationStepDoneEvent(1, "Done creating projects' objects.");
      }

      void currProjReader_ProjectReadEvent(Project theProject)
      {
         if (ProjectWasReadEvent != null)
         {
            ProjectWasReadEvent(theProject);
         }
      }

      private void CreateProjects(List<string> mainSolutionText)
      {
         RaiseDocumentationGenerationStepDoneEvent(1, "Parsing projects...");
         foreach (string lineOfText in mainSolutionText)
         {
            if (lineOfText.ToLower().StartsWith(PROJECT_HEADER))
            {
               string[] splittedLine = lineOfText.Substring(lineOfText.LastIndexOf('=') + 1, lineOfText.Length - lineOfText.LastIndexOf('=') - 1).Split(',');
               if (splittedLine.Length >= 3)
               {
                  string projectName = splittedLine[0].Trim('\"', ' ');
                  string projectRelPath = splittedLine[1].Trim('\"', ' ');
                  string projectGUID = splittedLine[2].Trim('\"', ' ');

                  string fullProjectPath = Path.Combine(m_SolutionFile.DirectoryName, projectRelPath);
                  if (File.Exists(fullProjectPath))
                  {
                     FileInfo projFile = new FileInfo(fullProjectPath);
                     Project.LangageType projLangage = GetLangageFromFile(projFile.Extension);
                     Project nextAddedProject = new Project(projectGUID, projectName, fullProjectPath, projLangage);
                     m_SolutionProjects.Add(nextAddedProject);
                     m_NumberOfProjectFound++;
                  }
               }
            }
         }
         RaiseDocumentationGenerationStepDoneEvent(1, "Done Parsing projects.");
      }

      private Project.LangageType GetLangageFromFile(string extension)
      {
         Project.LangageType retLangage = Project.LangageType.CS;
         switch (extension)
         {
            case ".vcxproj":
               retLangage = Project.LangageType.CPP;
               break;
            case ".vbproj":
               retLangage = Project.LangageType.VB;
               break;
            case ".csproj":
               retLangage = Project.LangageType.CS;
               break;
            default:
               break;
         }

         return retLangage;
      }

      private void RaiseDocumentationGenerationStepDoneEvent(int stepPercentageValue, string currentStepName)
      {
         if (DocumentationGenerationStepDoneEvent != null)
         {
            DocumentationGenerationStepDoneEvent(stepPercentageValue, currentStepName);
         }
      }

      public string BrowseSolutionFile()
      {
         string selectedFile = string.Empty;

         using (OpenFileDialog solutionFileBrowser = new OpenFileDialog())
         {
            solutionFileBrowser.CheckFileExists = true;
            solutionFileBrowser.CheckPathExists = true;
            solutionFileBrowser.FileName = "*.sln";
            solutionFileBrowser.Filter = "Solution File (*.sln) | *.sln";
            solutionFileBrowser.Title = "Select your solution file";

            if (solutionFileBrowser.ShowDialog() == DialogResult.OK)
            {
               if (SetSolutionFile(solutionFileBrowser.FileName))
               {
                  selectedFile = solutionFileBrowser.FileName;
               }
            }
         }

         return selectedFile;
      }

      private bool SetSolutionFile(string solutionFilePath)
      {
         bool solutionFileCreationSuccess = false;

         if (File.Exists(solutionFilePath))
         {
            m_SolutionFile = new FileInfo(solutionFilePath);

            if (m_SolutionFile != null)
            {
               solutionFileCreationSuccess = true;
            }
         }

         return solutionFileCreationSuccess;
      }

      public void Dispose()
      {
         if (m_SolutionFile != null)
         {
            m_SolutionFile = null;
         }
      }
   }
}
