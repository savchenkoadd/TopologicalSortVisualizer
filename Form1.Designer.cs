namespace TopSortVisualizer
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			GraphPanel = new Panel();
			InitializeGraphButton = new Button();
			StartAnimationButton = new Button();
			Result = new Label();
			StepLabel = new Label();
			AnimationSpeedBar = new TrackBar();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)AnimationSpeedBar).BeginInit();
			SuspendLayout();
			// 
			// GraphPanel
			// 
			GraphPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			GraphPanel.AutoSize = true;
			GraphPanel.Location = new Point(71, 36);
			GraphPanel.Margin = new Padding(3, 50, 3, 50);
			GraphPanel.Name = "GraphPanel";
			GraphPanel.Padding = new Padding(0, 40, 0, 0);
			GraphPanel.Size = new Size(433, 383);
			GraphPanel.TabIndex = 0;
			// 
			// InitializeGraphButton
			// 
			InitializeGraphButton.Anchor = AnchorStyles.Right;
			InitializeGraphButton.Location = new Point(592, 59);
			InitializeGraphButton.Name = "InitializeGraphButton";
			InitializeGraphButton.Size = new Size(189, 85);
			InitializeGraphButton.TabIndex = 1;
			InitializeGraphButton.Text = "Initialize Graph";
			InitializeGraphButton.UseVisualStyleBackColor = true;
			InitializeGraphButton.Click += InitializeGraphButton_Click;
			// 
			// StartAnimationButton
			// 
			StartAnimationButton.Anchor = AnchorStyles.Right;
			StartAnimationButton.Enabled = false;
			StartAnimationButton.Location = new Point(592, 187);
			StartAnimationButton.Name = "StartAnimationButton";
			StartAnimationButton.Size = new Size(189, 80);
			StartAnimationButton.TabIndex = 2;
			StartAnimationButton.Text = "Start Animation";
			StartAnimationButton.UseVisualStyleBackColor = true;
			StartAnimationButton.Click += StartAnimationButton_Click;
			// 
			// Result
			// 
			Result.Anchor = AnchorStyles.None;
			Result.AutoSize = true;
			Result.Location = new Point(572, 399);
			Result.Name = "Result";
			Result.Size = new Size(0, 20);
			Result.TabIndex = 4;
			Result.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// StepLabel
			// 
			StepLabel.Anchor = AnchorStyles.None;
			StepLabel.AutoSize = true;
			StepLabel.Location = new Point(572, 365);
			StepLabel.Name = "StepLabel";
			StepLabel.Size = new Size(0, 20);
			StepLabel.TabIndex = 5;
			StepLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// AnimationSpeedBar
			// 
			AnimationSpeedBar.Anchor = AnchorStyles.Right;
			AnimationSpeedBar.LargeChange = 1000;
			AnimationSpeedBar.Location = new Point(591, 309);
			AnimationSpeedBar.Maximum = 7000;
			AnimationSpeedBar.Minimum = 200;
			AnimationSpeedBar.Name = "AnimationSpeedBar";
			AnimationSpeedBar.Size = new Size(190, 56);
			AnimationSpeedBar.SmallChange = 300;
			AnimationSpeedBar.TabIndex = 6;
			AnimationSpeedBar.Value = 1000;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new Point(619, 286);
			label1.Name = "label1";
			label1.Size = new Size(124, 20);
			label1.TabIndex = 7;
			label1.Text = "Animation Speed";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSize = true;
			ClientSize = new Size(800, 450);
			Controls.Add(label1);
			Controls.Add(AnimationSpeedBar);
			Controls.Add(StepLabel);
			Controls.Add(Result);
			Controls.Add(StartAnimationButton);
			Controls.Add(InitializeGraphButton);
			Controls.Add(GraphPanel);
			Name = "Form1";
			Text = "Topological Sort Visualizer";
			((System.ComponentModel.ISupportInitialize)AnimationSpeedBar).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel GraphPanel;
		private Button InitializeGraphButton;
		private Button StartAnimationButton;
		private Label Result;
		private Label StepLabel;
		private TrackBar AnimationSpeedBar;
		private Label label1;
	}
}