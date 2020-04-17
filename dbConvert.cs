using DbAccess;
using POS_Client;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class dbConvert : Form
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public string msg;

		public int percent;

		public bool done;

		public bool success;

		public dbConvert <>4__this;

		internal void <dbConvert_Load>b__1()
		{
			<>4__this.lblMessage.Text = msg;
			<>4__this.pbrProgress.Value = percent;
			if (done)
			{
				<>4__this.Cursor = Cursors.Default;
				if (success)
				{
					MessageBox.Show(<>4__this, msg, "資料移轉成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					<>4__this.Close();
					return;
				}
				MessageBox.Show(<>4__this, msg, "資料移轉失敗", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				<>4__this.pbrProgress.Value = 0;
				<>4__this.lblMessage.Text = string.Empty;
				Application.Exit();
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_1
	{
		public ViewSchema vs;

		public string updated;

		public dbConvert <>4__this;

		internal void <dbConvert_Load>b__3()
		{
			ViewFailureDialog viewFailureDialog = new ViewFailureDialog();
			viewFailureDialog.View = vs;
			if (viewFailureDialog.ShowDialog(<>4__this) == DialogResult.OK)
			{
				updated = viewFailureDialog.ViewSQL;
			}
			else
			{
				updated = null;
			}
		}
	}

	private bool _shouldExit;

	private IContainer components;

	private ProgressBar pbrProgress;

	private Label lblMessage;

	public dbConvert()
	{
		InitializeComponent();
	}

	private void dbConvert_Load(object sender, EventArgs e)
	{
		string text = "";
		string appSettings = ConfigOperation.GetAppSettings("OLD_POS_DATABASE_NAME");
		text = ((!bool.Parse(ConfigOperation.GetAppSettings("OLD_POS_DATABASE_SSPI"))) ? string.Format("Data Source=(local)\\SQLExpress;Initial Catalog={0};User ID=sa;Password=1031", appSettings) : string.Format("Data Source=(local)\\SQLExpress;Initial Catalog={0};Integrated Security=SSPI;", appSettings));
		string sqlitePath = Program.DataPath + "\\Old_db.db3";
		Cursor = Cursors.WaitCursor;
		SqlConversionHandler handler = new SqlConversionHandler(<dbConvert_Load>b__1_0);
		SqlTableSelectionHandler selectionHandler = null;
		FailedViewDefinitionHandler viewFailureHandler = new FailedViewDefinitionHandler(<dbConvert_Load>b__1_2);
		string password = "1031";
		bool createViews = false;
		bool createTriggers = false;
		SqlServerToSQLite.ConvertSqlServerToSQLiteDatabase(text, sqlitePath, password, handler, selectionHandler, viewFailureHandler, createTriggers, createViews);
	}

	private void dbConvert_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (SqlServerToSQLite.IsActive)
		{
			SqlServerToSQLite.CancelConversion();
			_shouldExit = true;
			e.Cancel = true;
		}
		else
		{
			e.Cancel = false;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		pbrProgress = new System.Windows.Forms.ProgressBar();
		lblMessage = new System.Windows.Forms.Label();
		SuspendLayout();
		pbrProgress.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
		pbrProgress.Location = new System.Drawing.Point(14, 75);
		pbrProgress.Name = "pbrProgress";
		pbrProgress.Size = new System.Drawing.Size(506, 30);
		pbrProgress.TabIndex = 16;
		lblMessage.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
		lblMessage.Location = new System.Drawing.Point(12, 18);
		lblMessage.Name = "lblMessage";
		lblMessage.Size = new System.Drawing.Size(508, 43);
		lblMessage.TabIndex = 15;
		lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(540, 128);
		base.Controls.Add(lblMessage);
		base.Controls.Add(pbrProgress);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.Name = "MainForm";
		Text = "防檢局資料移轉";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(dbConvert_FormClosing);
		base.Load += new System.EventHandler(dbConvert_Load);
		ResumeLayout(false);
	}

	[CompilerGenerated]
	private void <dbConvert_Load>b__1_0(bool done, bool success, int percent, string msg)
	{
		<>c__DisplayClass1_0 <>c__DisplayClass1_ = new <>c__DisplayClass1_0();
		<>c__DisplayClass1_.<>4__this = this;
		<>c__DisplayClass1_.msg = msg;
		<>c__DisplayClass1_.percent = percent;
		<>c__DisplayClass1_.done = done;
		<>c__DisplayClass1_.success = success;
		Invoke(new MethodInvoker(<>c__DisplayClass1_.<dbConvert_Load>b__1));
	}

	[CompilerGenerated]
	private string <dbConvert_Load>b__1_2(ViewSchema vs)
	{
		<>c__DisplayClass1_1 <>c__DisplayClass1_ = new <>c__DisplayClass1_1();
		<>c__DisplayClass1_.<>4__this = this;
		<>c__DisplayClass1_.vs = vs;
		<>c__DisplayClass1_.updated = null;
		Invoke(new MethodInvoker(<>c__DisplayClass1_.<dbConvert_Load>b__3));
		return <>c__DisplayClass1_.updated;
	}
}
