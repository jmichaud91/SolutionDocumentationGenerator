namespace DocumentationGenerator
{
   partial class DocumentationGeneratorUI
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.label_ProjectFilePath = new System.Windows.Forms.Label();
         this.textBox_ProjectFilePath = new System.Windows.Forms.TextBox();
         this.button_BrowseProjectFilePath = new System.Windows.Forms.Button();
         this.button_StartDocumentationGeneration = new System.Windows.Forms.Button();
         this.progressBar_WaitingForDocToBeDone = new System.Windows.Forms.ProgressBar();
         this.label_ProgressionStepShower = new System.Windows.Forms.Label();
         this.listView_ProjectInfo = new System.Windows.Forms.ListView();
         this.column_Project = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.column_ObjNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.column_NbFunctions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.column_NbMembers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.label_NbProject = new System.Windows.Forms.Label();
         this.label_NbProjectValue = new System.Windows.Forms.Label();
         this.column_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.SuspendLayout();
         // 
         // label_ProjectFilePath
         // 
         this.label_ProjectFilePath.AutoSize = true;
         this.label_ProjectFilePath.Location = new System.Drawing.Point(13, 13);
         this.label_ProjectFilePath.Name = "label_ProjectFilePath";
         this.label_ProjectFilePath.Size = new System.Drawing.Size(86, 13);
         this.label_ProjectFilePath.TabIndex = 0;
         this.label_ProjectFilePath.Text = "Project file path :";
         // 
         // textBox_ProjectFilePath
         // 
         this.textBox_ProjectFilePath.Location = new System.Drawing.Point(105, 10);
         this.textBox_ProjectFilePath.Name = "textBox_ProjectFilePath";
         this.textBox_ProjectFilePath.Size = new System.Drawing.Size(482, 20);
         this.textBox_ProjectFilePath.TabIndex = 1;
         // 
         // button_BrowseProjectFilePath
         // 
         this.button_BrowseProjectFilePath.Location = new System.Drawing.Point(593, 8);
         this.button_BrowseProjectFilePath.Name = "button_BrowseProjectFilePath";
         this.button_BrowseProjectFilePath.Size = new System.Drawing.Size(75, 23);
         this.button_BrowseProjectFilePath.TabIndex = 2;
         this.button_BrowseProjectFilePath.Text = "browse";
         this.button_BrowseProjectFilePath.UseVisualStyleBackColor = true;
         this.button_BrowseProjectFilePath.Click += new System.EventHandler(this.button_BrowseProjectFilePath_Click);
         // 
         // button_StartDocumentationGeneration
         // 
         this.button_StartDocumentationGeneration.Location = new System.Drawing.Point(16, 47);
         this.button_StartDocumentationGeneration.Name = "button_StartDocumentationGeneration";
         this.button_StartDocumentationGeneration.Size = new System.Drawing.Size(168, 23);
         this.button_StartDocumentationGeneration.TabIndex = 3;
         this.button_StartDocumentationGeneration.Text = "Start documentation generation";
         this.button_StartDocumentationGeneration.UseVisualStyleBackColor = true;
         this.button_StartDocumentationGeneration.Click += new System.EventHandler(this.button_StartDocumentationGeneration_Click);
         // 
         // progressBar_WaitingForDocToBeDone
         // 
         this.progressBar_WaitingForDocToBeDone.Location = new System.Drawing.Point(190, 44);
         this.progressBar_WaitingForDocToBeDone.Name = "progressBar_WaitingForDocToBeDone";
         this.progressBar_WaitingForDocToBeDone.Size = new System.Drawing.Size(478, 10);
         this.progressBar_WaitingForDocToBeDone.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
         this.progressBar_WaitingForDocToBeDone.TabIndex = 4;
         // 
         // label_ProgressionStepShower
         // 
         this.label_ProgressionStepShower.AutoSize = true;
         this.label_ProgressionStepShower.Location = new System.Drawing.Point(191, 61);
         this.label_ProgressionStepShower.Name = "label_ProgressionStepShower";
         this.label_ProgressionStepShower.Size = new System.Drawing.Size(52, 13);
         this.label_ProgressionStepShower.TabIndex = 5;
         this.label_ProgressionStepShower.Text = "Waiting...";
         // 
         // listView_ProjectInfo
         // 
         this.listView_ProjectInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listView_ProjectInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Project,
            this.column_Type,
            this.column_ObjNumber,
            this.column_NbFunctions,
            this.column_NbMembers});
         this.listView_ProjectInfo.FullRowSelect = true;
         this.listView_ProjectInfo.GridLines = true;
         this.listView_ProjectInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listView_ProjectInfo.Location = new System.Drawing.Point(16, 92);
         this.listView_ProjectInfo.Name = "listView_ProjectInfo";
         this.listView_ProjectInfo.Size = new System.Drawing.Size(652, 354);
         this.listView_ProjectInfo.TabIndex = 6;
         this.listView_ProjectInfo.UseCompatibleStateImageBehavior = false;
         this.listView_ProjectInfo.View = System.Windows.Forms.View.Details;
         // 
         // column_Project
         // 
         this.column_Project.Text = "Project";
         this.column_Project.Width = 150;
         // 
         // column_ObjNumber
         // 
         this.column_ObjNumber.Text = "Nb Objects";
         this.column_ObjNumber.Width = 100;
         // 
         // column_NbFunctions
         // 
         this.column_NbFunctions.Text = "Nb Functions";
         this.column_NbFunctions.Width = 100;
         // 
         // column_NbMembers
         // 
         this.column_NbMembers.Text = "Nb Members";
         this.column_NbMembers.Width = 100;
         // 
         // label_NbProject
         // 
         this.label_NbProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label_NbProject.AutoSize = true;
         this.label_NbProject.Location = new System.Drawing.Point(16, 453);
         this.label_NbProject.Name = "label_NbProject";
         this.label_NbProject.Size = new System.Drawing.Size(130, 13);
         this.label_NbProject.TabIndex = 7;
         this.label_NbProject.Text = "Number of project found : ";
         // 
         // label_NbProjectValue
         // 
         this.label_NbProjectValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label_NbProjectValue.AutoSize = true;
         this.label_NbProjectValue.Location = new System.Drawing.Point(153, 453);
         this.label_NbProjectValue.Name = "label_NbProjectValue";
         this.label_NbProjectValue.Size = new System.Drawing.Size(13, 13);
         this.label_NbProjectValue.TabIndex = 8;
         this.label_NbProjectValue.Text = "0";
         // 
         // column_Type
         // 
         this.column_Type.Text = "Langage";
         this.column_Type.Width = 100;
         // 
         // DocumentationGeneratorUI
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(690, 471);
         this.Controls.Add(this.label_NbProjectValue);
         this.Controls.Add(this.label_NbProject);
         this.Controls.Add(this.listView_ProjectInfo);
         this.Controls.Add(this.label_ProgressionStepShower);
         this.Controls.Add(this.progressBar_WaitingForDocToBeDone);
         this.Controls.Add(this.button_StartDocumentationGeneration);
         this.Controls.Add(this.button_BrowseProjectFilePath);
         this.Controls.Add(this.textBox_ProjectFilePath);
         this.Controls.Add(this.label_ProjectFilePath);
         this.Name = "DocumentationGeneratorUI";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label_ProjectFilePath;
      private System.Windows.Forms.TextBox textBox_ProjectFilePath;
      private System.Windows.Forms.Button button_BrowseProjectFilePath;
      private System.Windows.Forms.Button button_StartDocumentationGeneration;
      private System.Windows.Forms.ProgressBar progressBar_WaitingForDocToBeDone;
      private System.Windows.Forms.Label label_ProgressionStepShower;
      private System.Windows.Forms.ListView listView_ProjectInfo;
      private System.Windows.Forms.ColumnHeader column_Project;
      private System.Windows.Forms.ColumnHeader column_ObjNumber;
      private System.Windows.Forms.ColumnHeader column_NbFunctions;
      private System.Windows.Forms.ColumnHeader column_NbMembers;
      private System.Windows.Forms.Label label_NbProject;
      private System.Windows.Forms.Label label_NbProjectValue;
      private System.Windows.Forms.ColumnHeader column_Type;
   }
}

