using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentationGenerator
{
   public partial class DocumentationGeneratorUI : Form
   {
      private delegate void DocGenerationStepDone(int stepPercentageValue, string stepName);
      private delegate void ProjectWasRead(ObjectLibrary.Project theProject);
      private UIManager m_UIManager = null;

      public DocumentationGeneratorUI()
      {
         InitializeComponent();

         Initialize();
      }

      private void Initialize()
      {
         m_UIManager = new UIManager();
         AddHandlers();
         SetControlsState();
      }

      private void AddHandlers()
      {
         m_UIManager.DocumentationGenerationStepDoneEvent += new UIManager.DocumentationGenerationStepDone(OnDocumentationGenerationStepDone);
         m_UIManager.ProjectWasReadEvent += new UIManager.ProjectWasReadDelegate(OnProjectWasReadEvent);
      }

      private void ProjectWasReadEventProc(ObjectLibrary.Project theProject)
      {
         ListViewItem.ListViewSubItem projectNameItem = new ListViewItem.ListViewSubItem();
         projectNameItem.Text = "Unkown";

         if (theProject != null)
         {
            projectNameItem.Text = theProject.ProjectName;
         }

         ListViewItem.ListViewSubItem objectName = new ListViewItem.ListViewSubItem();
         objectName.Text = "0";

         if (theProject.Objects != null)
         {
            objectName.Text = theProject.Objects.Count.ToString();
         }

         ListViewItem.ListViewSubItem nbOfFunctions = new ListViewItem.ListViewSubItem();
         nbOfFunctions.Text = "0";

         ListViewItem.ListViewSubItem nbOfVariable = new ListViewItem.ListViewSubItem();
         nbOfVariable.Text = "0";

         ListViewItem nextAddedItem = new ListViewItem(new string[]{theProject.ProjectName, "", "0", "0"});
         listView_ProjectInfo.Items.Add(nextAddedItem);

         label_NbProjectValue.Text = m_UIManager.NumberOfProjectFound.ToString();
      }

      private void OnProjectWasReadEvent(ObjectLibrary.Project theProject)
      {
         object[] parameters = { theProject };
         BeginInvoke(new ProjectWasRead(ProjectWasReadEventProc), parameters);
      }


      private void OnDocumentationGenerationStepDone(int stepPercentageValue, string stepName)
      {
         object[] parameters = { stepPercentageValue, stepName };
         BeginInvoke(new DocGenerationStepDone(DocumentationGenerationStepDoneEventProc), parameters);
      }

      private void DocumentationGenerationStepDoneEventProc(int stepPercentageValue, string stepName)
      {
         progressBar_WaitingForDocToBeDone.Increment(stepPercentageValue);
         label_ProgressionStepShower.Text = stepName;
      }

      private void SetControlsState()
      {
         bool isUIManagerInitialized = (m_UIManager != null);
         bool isSolutionFileChosen = (m_UIManager.SolutionFile != null);

         textBox_ProjectFilePath.Enabled = isUIManagerInitialized;

         button_BrowseProjectFilePath.Enabled = isUIManagerInitialized;

         button_StartDocumentationGeneration.Enabled = isSolutionFileChosen;
      }

      private void button_BrowseProjectFilePath_Click(object sender, EventArgs e)
      {
         if (m_UIManager != null)
         {
            textBox_ProjectFilePath.Text = m_UIManager.BrowseSolutionFile();
            SetControlsState();
         }
      }

      private void button_StartDocumentationGeneration_Click(object sender, EventArgs e)
      {
         if (m_UIManager != null)
         {
            m_UIManager.StartDocumentationGeneration();
            SetProgressBar();
            SetControlsState();
         }
      }

      private void SetProgressBar()
      {
         progressBar_WaitingForDocToBeDone.Maximum = 100;
         progressBar_WaitingForDocToBeDone.Minimum = 0;
         progressBar_WaitingForDocToBeDone.Style = ProgressBarStyle.Continuous;

         label_ProgressionStepShower.Text = "Waiting...";
      }
   }
}
